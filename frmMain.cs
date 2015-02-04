using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ImagerySvc=VehicleSimulator.BingImageryService;
using System.IO.Ports;
using Microsoft.Win32;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;
using RouteSvc = VehicleSimulator.BingRouteService;
using System.Threading;


namespace VehicleSimulator
{

    public partial class frmMain : Form
    {

        public bool RoutePlaybackInSession { get; set; }


        SimpleSerialPort m_EcmPort;
        SimpleSerialPort m_GpsPort;

        SerialPort m_EcmOutputSerialPort = null;
        SerialPort m_GpsOutputSerialPort = null;


        private Vehicle m_Vehicle;
        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        eUnitsOfMeasure m_currUnitsOfMeasure = eUnitsOfMeasure.Mph;

        const double m_dblDEFAULT_ACCELERATION = 2.0; // always in meters/second/second
        const double m_dblDEFAULT_RAPIDDECELERATION = 8.0; // always in meters/second/second

        const double m_dblDEFAULT_RPM_ACCELERATION = 200.0;


        enum eUnitsOfMeasure
        {
            Mph,
            Kph
        }


        bool EcmTransmitEnabled
        {
            get
            {
                return System.Convert.ToBoolean(toolStripButton_EcmTransmit.Tag);
            }
        }


        bool GpsTransmitEnabled
        {
            get
            {
                return System.Convert.ToBoolean(toolStripButton_GpsTransmit.Tag);
            }
        }


        List<Address> m_lstAddressesPreviouslyFound = new List<Address>();


        private bool m_bMapOn = true;


        #region CTORs

        public frmMain()
        {
            InitializeComponent();

            txtLatitude.KeyPress += Program.txtNumericWithDecimalAndMinus_KeyPress;
            txtLongitude.KeyPress += Program.txtNumericWithDecimalAndMinus_KeyPress;

            txtDirectionOfTravel.KeyPress += Program.txtNumericWithDecimal_KeyPress;

            m_EcmPort = new SimpleSerialPort(Properties.Settings.Default.EcmComPort);
            m_GpsPort = new SimpleSerialPort(Properties.Settings.Default.GpsComPort);

            ComPortsValidityGuiFeedback();

            toolStripButton_EcmTransmit.Tag = false;
            SetStripButtonGuiState(toolStripButton_EcmTransmit, false);

            toolStripButton_GpsTransmit.Tag = false;
            SetStripButtonGuiState(toolStripButton_GpsTransmit, false);

            toolStripButton_PTO.Tag = false;
            SetStripButtonGuiState(toolStripButton_PTO, false);

            m_currUnitsOfMeasure = eUnitsOfMeasure.Mph;
            DoChangeUnitsOfMeasure();

            cboEcmProtocol.Items.Add(ECM.eEcmProtocols.J1587);
            cboEcmProtocol.Items.Add(ECM.eEcmProtocols.J1939);
            cboEcmProtocol.SelectedIndex = 0;

            cmdResetVehicleLocationFields_Click(null, null);

            m_lstAddressesPreviouslyFound = Program.AllAddresses;
            cboPreviousLocations.Items.AddRange(m_lstAddressesPreviouslyFound.ToArray());
        }

        #endregion


        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text += string.Format(" ver {0}", Application.ProductVersion);

            m_iTargetTerminalCycleVelocity = (int)(Physics.MPH_to_KPH(30) + .5); // Always stored in KPH!!

            if (m_currUnitsOfMeasure == eUnitsOfMeasure.Mph) {
                cmdCycleStartStop.Text = string.Format("Cycle ({0})", (int)(Physics.KPH_to_MPH(m_iTargetTerminalCycleVelocity) + .5));
            } else
            {
                cmdCycleStartStop.Text = string.Format("Cycle ({0})", m_iTargetTerminalCycleVelocity);
            }

            if (m_GpsOutputSerialPort == null && m_GpsPort.IsValid)
            {
                try
                {
                    SerialPortFixer.Execute(m_GpsPort.ToString());

                    m_GpsOutputSerialPort
                        = new SerialPort(m_GpsPort.ToString(),
                                         (int)SimpleSerialPort.eBaudRate.Baud_4800,
                                         Parity.None,
                                         8); //data bits
                    m_GpsOutputSerialPort.Open();
                }
                catch { }
            }
            if (m_EcmOutputSerialPort == null && m_EcmPort.IsValid)
            {
                try
                {
                    SerialPortFixer.Execute(m_EcmPort.ToString());

                    m_EcmOutputSerialPort
                        = new SerialPort(m_EcmPort.ToString(),
                                         (int)SimpleSerialPort.eBaudRate.Baud_9600,
                                         Parity.None,
                                         8); //data bits
                    m_EcmOutputSerialPort.Open();
                }
                catch { }
            }


            Address address = CurrentAddress;
            VehicleSimulator.Location location;
            if (address.IsValid)
                location = Program.GeocodingWrapper.Geocode(address);
            else
                location = VehicleSimulator.Location.CreateInvalidLocation();

            m_Vehicle = new Vehicle(location,
                                    (ECM.eEcmProtocols)cboEcmProtocol.SelectedItem,
                                    m_EcmOutputSerialPort,
                                    m_GpsOutputSerialPort);

            m_Vehicle.Odometer = Properties.Settings.Default.Odometer;
            ProcessVehicleOdometer();

            pictureBox_Map.VehicleImage = imageList1.Images[0];

            UpdateDisplay();
        }


        void ComPortsValidityGuiFeedback()
        {
            lock (timerSerialPortMonitor)
            {
                string strMsg;
                string strToolStripText;
                if (!DoComPortsValidityGuiFeedback(out strMsg, out strToolStripText))
                {
                    timerSerialPortMonitor.Enabled = true;

                    toolStripButton_ComPortSettings.ToolTipText = strToolStripText;

                    if (!string.IsNullOrEmpty(strMsg))
                        MessageBox.Show(strMsg);
                }
                else
                {
                    timerSerialPortMonitor.Enabled = true;
                }
            }
        }

        bool DoComPortsValidityGuiFeedback(out string strMsg,
                                           out string strToolStripText)
        {
            strMsg = "";
            strToolStripText = "";

            toolStripButton_ComPortSettings.ToolTipText = "";

            // Check if Com port simply is invalid (never saved?)
            if (m_EcmPort.IsValid == false && m_GpsPort.IsValid == false)
            {
                toolStripButton_ComPortSettings.BackColor = Color.Red;
                toolStripButton_EcmTransmit.Enabled = false;
                toolStripButton_GpsTransmit.Enabled = false;

                if (m_EcmPort.IsValid == false)
                    strToolStripText = "ECM Port Invalid";

                if (m_GpsPort.IsValid == false)
                    if (string.IsNullOrEmpty(strToolStripText))
                        strToolStripText = "GPS Port Invalid";
                    else
                        strToolStripText += " | GPS Port Invalid";

                toolStripStatusLabel_PortsStatus.Text = strToolStripText;

                return false;
            }

            
            if (m_EcmPort.IsValid == true && m_GpsPort.IsValid == false)
            {
                toolStripButton_ComPortSettings.BackColor = Color.Yellow;
                toolStripButton_EcmTransmit.Enabled = true;
                toolStripButton_GpsTransmit.Enabled = false;

                strToolStripText = "ECM Port Ok, GPS Port Invalid";
                toolStripStatusLabel_PortsStatus.Text = strToolStripText;

                return false;
            }


            if (m_EcmPort.IsValid == false && m_GpsPort.IsValid == true)
            {
                toolStripButton_ComPortSettings.BackColor = Color.Yellow;
                toolStripButton_EcmTransmit.Enabled = false;
                toolStripButton_GpsTransmit.Enabled = true;

                strToolStripText = "GPS Port Ok, ECM Port Invalid";
                toolStripStatusLabel_PortsStatus.Text = strToolStripText;

                return false;
            }

            // All specified saved ports are valid. 
            toolStripStatusLabel_PortsStatus.Text = "";

            // But do the COM ports still exist in THIS computer?
            if (   (!SimpleSerialPort.GetSortedPortObjects().Contains(m_EcmPort))
                || (!SimpleSerialPort.GetSortedPortObjects().Contains(m_GpsPort)))
            {
                toolStripButton_ComPortSettings.BackColor = Color.Red;
                toolStripButton_GpsTransmit.Enabled = false;

                if (!SimpleSerialPort.GetSortedPortObjects().Contains(m_EcmPort))
                {
                    toolStripButton_EcmTransmit.Enabled = false;
                    strMsg = string.Format("Specified ECM Port \"{0}\" does not exist.", m_EcmPort);
                }
                else
                {
                    toolStripButton_EcmTransmit.Enabled = true;
                }

                if (!SimpleSerialPort.GetSortedPortObjects().Contains(m_GpsPort))
                {
                    toolStripButton_GpsTransmit.Enabled = false;
                    if (strMsg.Length < 1)
                        strMsg = string.Format("Specified GPS Port \"{0}\" does not exist.", m_GpsPort);
                    else
                        strMsg += string.Format("\r\n\r\nSpecified GPS Port \"{0}\" does not exist.", m_GpsPort);
                }
                else
                {
                    toolStripButton_GpsTransmit.Enabled = true;
                }

                toolStripStatusLabel_PortsStatus.Text = strMsg;

                strMsg += "\r\n\r\nDo you need a USB Serial Port attached?";

                return false;
            }


            if (m_EcmPort.Equals(m_GpsPort))
            {
                toolStripButton_ComPortSettings.BackColor = Color.Red;
                toolStripButton_EcmTransmit.Enabled = false;
                toolStripButton_GpsTransmit.Enabled = false;

                strToolStripText = "ECM Port SAME AS GPS Port";
                toolStripStatusLabel_PortsStatus.Text = strToolStripText;

                return false;
            }


            toolStripButton_ComPortSettings.BackColor = Color.LightGreen;
            toolStripButton_EcmTransmit.Enabled = true;

            if (m_Vehicle != null && m_Vehicle.Location.IsValid)
                toolStripButton_GpsTransmit.Enabled = true;
            else
                toolStripButton_GpsTransmit.Enabled = false;

            return true;
        }


        void CloseSerialPortAndNull(ref SerialPort sp)
        {
            if (m_EcmOutputSerialPort != null && m_EcmOutputSerialPort.IsOpen)
            {
                try
                {
                    sp.Close();
                }
                catch
                {
                    ;
                }
            }

            sp = null;
        }


        #region Menu Handling

        private void toolStripButton_ComPortSettings_Click(object sender, EventArgs e)
        {
            using (frmComSettings comSettingsForm = new frmComSettings())
            {
                DialogResult rc = comSettingsForm.ShowDialog(this);
                if (rc == DialogResult.OK)
                {
                    SimpleSerialPort ecmPort = null;
                    SimpleSerialPort gpsPort = null;

                    try
                    {
                        ecmPort = new SimpleSerialPort(Properties.Settings.Default.EcmComPort);
                    }
                    catch { ; }

                    try
                    {
                        gpsPort = new SimpleSerialPort(Properties.Settings.Default.GpsComPort);
                    }
                    catch { ; }


                    if (ecmPort != null && ecmPort.Equals(m_EcmPort) == false)
                    {
                        m_EcmPort = ecmPort;

                        CloseSerialPortAndNull(ref m_EcmOutputSerialPort);

                        if (m_EcmPort.IsValid && SimpleSerialPort.GetSortedPortObjects().Contains(m_EcmPort))
                        {
                            m_EcmOutputSerialPort
                                = new SerialPort(m_EcmPort.ToString(),
                                                 (int)SimpleSerialPort.eBaudRate.Baud_115200,
                                                 Parity.None,
                                                 8); //data bits

                            try
                            {
                                m_EcmOutputSerialPort.Open();
                            }
                            catch
                            {
                                m_EcmOutputSerialPort = null;
                            }
                        }
                        else
                        {
                            m_EcmOutputSerialPort = null;
                        }
                    }

                    if (gpsPort != null && gpsPort.Equals(m_GpsPort) == false)
                    {
                        m_GpsPort = gpsPort;

                        CloseSerialPortAndNull(ref m_GpsOutputSerialPort);

                        if (m_GpsPort.IsValid && SimpleSerialPort.GetSortedPortObjects().Contains(m_GpsPort))
                        {
                            SerialPortFixer.Execute(m_GpsPort.ToString());

                            m_GpsOutputSerialPort
                                = new SerialPort(m_GpsPort.ToString(),
                                                 (int)SimpleSerialPort.eBaudRate.Baud_4800,
                                                 Parity.None,
                                                 8); //data bits

                            try
                            {
                                m_GpsOutputSerialPort.Open();
                            }
                            catch
                            {
                                m_GpsOutputSerialPort = null;
                            }
                        }
                        else
                        {
                            m_GpsOutputSerialPort = null;
                        }
                    }

                    ComPortsValidityGuiFeedback();
                }  // if (rc == DialogResult.OK)


                VehicleSimulator.Location location;
                if (m_Vehicle != null)
                {
                    location = m_Vehicle.Location;
                    m_Vehicle.Dispose();
                    m_Vehicle = null;
                }
                else
                {
                    location = VehicleSimulator.Location.CreateInvalidLocation();
                }

                m_Vehicle = new Vehicle(location,
                                        (ECM.eEcmProtocols)cboEcmProtocol.SelectedItem,
                                        m_EcmOutputSerialPort,
                                        m_GpsOutputSerialPort);

                m_Vehicle.Odometer = Properties.Settings.Default.Odometer;
                ProcessVehicleOdometer();

            }  // using (frmComSettings comSettingsForm = new frmComSettings())
        }

        static void SetStripButtonGuiState(ToolStripButton button, eUnitsOfMeasure unitsOfMeasure)
        {
            button.Text = unitsOfMeasure == eUnitsOfMeasure.Mph ? "MPH" : "KPH";
        }

        static void SetStripButtonGuiState(ToolStripButton button, bool bOn)
        {
            button.Tag = bOn;
            button.Text = bOn ? "ON" : "OFF";
            button.BackColor = bOn ? Color.LightGreen : Color.Salmon;
        }

        void CreateVehicle()
        {
            VehicleSimulator.Location location;
            if (m_Vehicle != null)
            {
                location = m_Vehicle.Location;
                m_Vehicle.Dispose();
                m_Vehicle = null;
            }
            else
            {
                location = VehicleSimulator.Location.CreateInvalidLocation();
            }

            m_Vehicle = new Vehicle(location,
                                    (ECM.eEcmProtocols)cboEcmProtocol.SelectedItem,
                                    m_EcmOutputSerialPort,
                                    m_GpsOutputSerialPort);
        }



        private void toolStripButton_EcmTransmit_Click(object sender, EventArgs e)
        {
            bool bOn = !System.Convert.ToBoolean(toolStripButton_EcmTransmit.Tag);
            SetStripButtonGuiState(toolStripButton_EcmTransmit, bOn);

            if (bOn)
            {
                if (m_Vehicle.ECM.SerialPort == null ||
                    m_Vehicle.ECM.SerialPort.IsOpen == false)
                {
                    CreateVehicle();
                }

                if (!m_Vehicle.IsRunning)
                    m_Vehicle.Start();

                if (timerUpdateDisplay.Enabled == false)
                    timerUpdateDisplay.Enabled = true;
            }

            m_Vehicle.EmitEcmData = bOn;
        }


        private void toolStripButton_GpsTransmit_Click(object sender, EventArgs e)
        {
            bool bOn = !System.Convert.ToBoolean(toolStripButton_GpsTransmit.Tag);
            SetStripButtonGuiState(toolStripButton_GpsTransmit, bOn);

            m_Vehicle.EmitGpsData = bOn;
        }


        private void toolStripButton_PTO_Click(object sender, EventArgs e)
        {
            bool bOn = !System.Convert.ToBoolean(toolStripButton_PTO.Tag);
            SetStripButtonGuiState(toolStripButton_PTO, bOn);

            m_Vehicle.PowerTakeOff = bOn;
        }


        void DoChangeUnitsOfMeasure()
        {
            if (m_currUnitsOfMeasure == eUnitsOfMeasure.Kph)
            {
                lblVelocityUnits.Text = "KPH";

                cmdCycleStartStop.Text = string.Format("Cycle ({0})", m_iTargetTerminalCycleVelocity);

                lblOdometerUnits.Text = "Kilometers";

                lblGphLabel.Text = "LPH";
                lblMpgLabel.Text = "KPG";

                gaugeVelocity.MaxValue = (int)Physics.MPH_to_KPH(Properties.Settings.Default.Max_MilesPerHour);

                gaugeVelocity.Range_Idx = 0;
                gaugeVelocity.RangeStartValue = 0;
                gaugeVelocity.RangeEndValue = (int)Physics.MPH_to_KPH(Properties.Settings.Default.Speed_GreenZone_End_MilesPerHour);

                gaugeVelocity.Range_Idx = 1;
                gaugeVelocity.RangeStartValue = (int)Physics.MPH_to_KPH(Properties.Settings.Default.Speed_GreenZone_End_MilesPerHour);
                gaugeVelocity.RangeEndValue = (int)Physics.MPH_to_KPH(Properties.Settings.Default.Speed_YellowZone_End_MilesPerHour);

                gaugeVelocity.Range_Idx = 2;
                gaugeVelocity.RangeStartValue = (int)Physics.MPH_to_KPH(Properties.Settings.Default.Speed_YellowZone_End_MilesPerHour);
                gaugeVelocity.RangeEndValue = gaugeVelocity.MaxValue;
            }
            else
            {
                cmdCycleStartStop.Text = string.Format("Cycle ({0})", (int)(Physics.KPH_to_MPH(m_iTargetTerminalCycleVelocity)+.5));

                lblVelocityUnits.Text = "MPH";

                lblOdometerUnits.Text = "Miles";

                lblGphLabel.Text = "GPH";
                lblMpgLabel.Text = "MPG";

                gaugeVelocity.MaxValue = (float)Properties.Settings.Default.Max_MilesPerHour;

                gaugeVelocity.Range_Idx = 0;
                gaugeVelocity.RangeStartValue = 0;
                gaugeVelocity.RangeEndValue = (float)Properties.Settings.Default.Speed_GreenZone_End_MilesPerHour;

                gaugeVelocity.Range_Idx = 1;
                gaugeVelocity.RangeStartValue = (float)Properties.Settings.Default.Speed_GreenZone_End_MilesPerHour;
                gaugeVelocity.RangeEndValue = (float)Properties.Settings.Default.Speed_YellowZone_End_MilesPerHour;

                gaugeVelocity.Range_Idx = 2;
                gaugeVelocity.RangeStartValue = (float)Properties.Settings.Default.Speed_YellowZone_End_MilesPerHour;
                gaugeVelocity.RangeEndValue = gaugeVelocity.MaxValue;
            }

            SetStripButtonGuiState(toolStripButton_UnitsOfMeasure, m_currUnitsOfMeasure);
        }

        private void toolStripButton_UnitsOfMeasure_Click(object sender, EventArgs e)
        {
            if (m_currUnitsOfMeasure == eUnitsOfMeasure.Mph)
                m_currUnitsOfMeasure = eUnitsOfMeasure.Kph;
            else
                m_currUnitsOfMeasure = eUnitsOfMeasure.Mph;

            DoChangeUnitsOfMeasure();
        }

        #endregion



        public void UpdateDisplay()
        {
            if (!m_bMapOn)
                return;

            VehicleSimulator.Location location = m_Vehicle.Location;

            if (!location.IsValid)
                return;

            txtLatitude.Text = location.Latitude.ToString();
            txtLongitude.Text = location.Longitude.ToString();

            // Bing only allows Latitude values in the [-85,85] range.
            if (location.Latitude.Value < -85 || location.Latitude.Value > 85)
                return;

            toolStripStatusLabel_LocationChanged.BackColor = Color.Yellow;
            toolStripStatusLabel_LocationChanged.Text = "Loading...";
            Application.DoEvents();


            bool? bRC =
                Program.ImageryWrapper.GetMapImage(pictureBox_Map, 
                                                   location, 
                                                   trackbarMapZoom.Value,
                                                   lblBingCopyrightNotice);

            if (bRC.HasValue == false)
            {
                pictureBox_Map.Tag = null;
                toolStripStatusLabel_LocationChanged.BackColor = Color.Gray;
                toolStripStatusLabel_LocationChanged.Text = "BAD LAT/LON";
            }
            else if (bRC.Value == false)
            {
                pictureBox_Map.Tag = null;
                toolStripStatusLabel_LocationChanged.BackColor = Color.Red;
                toolStripStatusLabel_LocationChanged.Text = "BING ERROR";
            } 
            else
            {
                pictureBox_Map.Tag = location;
            }
        }


        private void trackbarMapZoom_Scroll(object sender, EventArgs e)
        {
            UpdateDisplay();
        }


        

        #region Timers Processing


        void ProcessVehicleOdometer()
        {
            double dblDistance = m_Vehicle.Odometer;

            if (Math.Round(Properties.Settings.Default.Odometer, 3) != Math.Round(dblDistance, 3))
            {
                Properties.Settings.Default.Odometer = dblDistance;
                Properties.Settings.Default.Save();
            }


            if (m_currUnitsOfMeasure != eUnitsOfMeasure.Kph)
                dblDistance = Physics.Kilometers_to_Miles(dblDistance);

            int iDistanceWhole = (int) dblDistance;
            int iDistanceTenths = (int)((dblDistance - iDistanceWhole) * 10);

            lblOdometerWhole.Text = iDistanceWhole.ToString("0000000000");
            lblOdometerTenths.Text = iDistanceTenths.ToString();
        }



        private void timerUpdateDisplay_Tick(object sender, EventArgs e)
        {
            lock (timerUpdateDisplay)
            {
                VehicleSimulator.Location prevLocation = pictureBox_Map.Tag as VehicleSimulator.Location;

                timerUpdateDisplay.Enabled = false;

                if (   prevLocation != null
                    && prevLocation.Equals(m_Vehicle.Location) == false
                    && prevLocation.IsValid)
                {
                    UpdateDisplay();
                }


                ProcessVehicleOdometer();

                pictureBox_Map.VehicleSymbolOrientation = m_Vehicle.DirectionOfTravel;
                gaugeDirectionOfTravel.Value = (float)m_Vehicle.DirectionOfTravel;
                txtDirectionOfTravel.Text = m_Vehicle.DirectionOfTravel.ToString("0.0");

                float fRPM = (float) m_Vehicle.EngineRPM;
                lblRPM.Text = ((int)fRPM).ToString();
                gaugeRPM.Value = fRPM;

                double dblRoadSpeed = m_Vehicle.Speed;

                if (m_bCyclingStop)
                {
                    if ((int)dblRoadSpeed == m_iTargetCyclingStopVelocity)
                    {
                        if (m_iTargetCyclingStopVelocity > 0)
                        {
                            m_iTargetCyclingStopVelocity = 0;
                        }
                        else
                        {
                            m_iTargetCyclingStopVelocity = m_iTargetTerminalCycleVelocity;
                            Thread.Sleep(1000); // stay at 0 mpg for a little
                        }

                        m_Vehicle.SetTargetSpeed(m_iTargetCyclingStopVelocity, m_dblDEFAULT_ACCELERATION);
                    }
                }

                double dblFuelRateLitersPerSecond = m_Vehicle.FuelRate;
                double dblFuelRatePerHour;

                if (dblRoadSpeed == 0 && cmdRapidDecel.Text == "STOP Rapid Deceleration")
                {
                    cmdRapidDecel.Text = "Rapid Deceleration";
                }

                if (m_currUnitsOfMeasure == eUnitsOfMeasure.Kph)
                {
                    gaugeVelocity.Value = (float) dblRoadSpeed;

                    dblFuelRatePerHour = Physics.LitersPerSecond_to_LitersPerrHour(dblFuelRateLitersPerSecond);
                    lblGPH.Text = dblFuelRatePerHour.ToString("0.00000");
                }
                else
                {
                    dblRoadSpeed = Math.Round(Physics.KPH_to_MPH(dblRoadSpeed));
                    gaugeVelocity.Value = (float) dblRoadSpeed;

                    dblFuelRatePerHour = Physics.LitersPerSecond_to_GallonsPerHour(dblFuelRateLitersPerSecond);
                    lblGPH.Text = dblFuelRatePerHour.ToString("0.00000");
                }


                if (dblFuelRatePerHour > 0)
                    lblMPG.Text = (dblRoadSpeed/dblFuelRatePerHour).ToString("0.00000");
                else
                    lblMPG.Text = "--";

                lblVelocity.Text = ((int)gaugeVelocity.Value).ToString();

                cmdRapidDecel.Enabled = (int) dblRoadSpeed > 0;

                timerUpdateDisplay.Enabled = true;
            }  // lock (timerUpdateDisplay)
        }





        public bool VehiclePaused
        {
            get { return m_Vehicle.IsPaused; }
            set
            {
                m_Vehicle.IsPaused = value;
            }
        }


        #endregion


        public Address CurrentAddress
        {
            get
            {
                return new Address
                {
                    Country = cboCountry.SelectedItem != null
                              ? (string)cboCountry.SelectedItem
                              : "",
                    State = cboState.SelectedItem != null
                              ? (string)cboState.SelectedItem
                              : "",
                    City = txtCity.Text,
                    Street = txtStreet.Text
                };
            }

            set
            {
                cboCountry.SelectedItem = value.Country;
                Application.DoEvents();

                cboState.SelectedItem = value.State;
                Application.DoEvents();

                txtCity.Text = value.City;
                txtStreet.Text = value.Street;

            }
        }


        private void cboEcmProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            lock (timerUpdateDisplay)
            {
                if (RoutePlaybackInSession)
                    return;

                cboEcmProtocol.Tag = (ECM.eEcmProtocols) cboEcmProtocol.SelectedItem;


                VehicleSimulator.Location location;
                if (m_Vehicle != null)
                {
                    location = m_Vehicle.Location;
                    m_Vehicle.Dispose();
                    m_Vehicle = null;
                }
                else
                {
                    location = VehicleSimulator.Location.CreateInvalidLocation();
                }

                gaugeVelocity.Value = 0;
                gaugeRPM.Value = 0;


                //TODO: re-enable once J1939 implemented so we correctly flex
                // between 1939 and 1587
                /*
                m_Vehicle = new Vehicle(location,
                                        (ECM.eEcmProtocols) cboEcmProtocol.SelectedItem,
                                        m_EcmOutputSerialPort,
                                        m_GpsOutputSerialPort);

                m_Vehicle.Odometer = Properties.Settings.Default.Odometer;
                ProcessVehicleOdometer();

                m_Vehicle.Start();
                */
            }
        }



        #region Set Vehicle Location group box

        bool m_bIn_SetVehicleLocationField_TextChanged = false;
        private void SetVehicleLocationField_TextChanged(object sender, EventArgs e)
        {
            if (m_bIn_SetVehicleLatitudeLongitude_TextChanged
                || m_bIn_SetVehicleLocationField_TextChanged)
                return;

            m_bIn_SetVehicleLocationField_TextChanged = true;

            if (txtStreet.Text.Length > 0
                || txtCity.Text.Length > 0
                || cboState.SelectedIndex > -1
                || cboCountry.SelectedIndex > -1)
            {

                txtLatitude.Text = "";
                txtLongitude.Text = "";
            }

            m_bIn_SetVehicleLocationField_TextChanged = false;
        }


        bool m_bIn_SetVehicleLatitudeLongitude_TextChanged = false;


        private void SetVehicleLatitudeLongitude_TextChanged(object sender, EventArgs e)
        {
            if (m_bIn_SetVehicleLatitudeLongitude_TextChanged
                || m_bIn_SetVehicleLocationField_TextChanged)
                return;

            m_bIn_SetVehicleLatitudeLongitude_TextChanged = true;

            txtLatitude.Text = txtLatitude.Text.Trim();
            txtLongitude.Text = txtLongitude.Text.Trim();

            if (txtLatitude.Text.Length > 0
                || txtLongitude.Text.Length > 0)
            {
                txtStreet.Text = "";
                txtCity.Text = "";
                cboState.SelectedIndex = -1;
                cboCountry.SelectedIndex = -1;
            }

            m_bIn_SetVehicleLatitudeLongitude_TextChanged = false;
        }


        bool m_bIn_cmdSetVehicleLocation_Click = false;


        private bool m_bVehicleLocationSetViaLatLonEntry = false;

        public void DoSetVehicleLocation(bool bFromUser)
        {
            lock (timerUpdateDisplay)
            {
                Address address = CurrentAddress;

                VehicleSimulator.Location location;
                if (address.IsValid)
                {
                    location = Program.GeocodingWrapper.Geocode(address);
                    if (!location.IsValid)
                    {
                        MessageBox.Show(this, "Could not find specified address.", "Not Found", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                    m_bVehicleLocationSetViaLatLonEntry = false;
                }
                else
                {
                    location = new Location(txtLongitude.Text, txtLatitude.Text);
                    m_bVehicleLocationSetViaLatLonEntry = true;
                }

                if (location.IsValid)
                {
                    lock (timerUpdateDisplay)
                        m_Vehicle.Location = location;

                    if (m_Vehicle.Location.IsValid && m_GpsPort.IsValid == false)
                        toolStripButton_GpsTransmit.Enabled = true;
                    else
                        toolStripButton_GpsTransmit.Enabled = true;

                    if (CurrentAddress.IsValid
                        && (!m_lstAddressesPreviouslyFound.Contains(CurrentAddress))
                        && bFromUser)
                    {
                        Program.AddAddress(address);
                        m_lstAddressesPreviouslyFound.Add(address);
                        cboPreviousLocations.Items.Add(address);

                        cboPreviousLocations.SelectedIndex
                            = cboPreviousLocations.FindStringExact(address.ToString());
                    }

                }

                UpdateDisplay();

                if (!m_Vehicle.IsRunning)
                    m_Vehicle.Start();

                timerUpdateDisplay.Enabled = true;
            }  // lock (timerUpdateDisplay)
        }


        private void cmdSetVehicleLocation_Click(object sender, EventArgs e)
        {
            m_bIn_cmdSetVehicleLocation_Click = true;

            if (RoutePlaybackInSession)
                return;

            DoSetVehicleLocation(true);

            m_bIn_cmdSetVehicleLocation_Click = false;
        }


        public void StartScreenUpdates(bool bStart)
        {
            lock (timerUpdateDisplay)
            {
                timerUpdateDisplay.Enabled = bStart;
            }
        }

        private void cmdResetVehicleLocationFields_Click(object sender, EventArgs e)
        {
            txtStreet.Text = "";
            txtCity.Text = "";
            cboState.SelectedIndex = -1;
            cboCountry.SelectedIndex = -1;
            txtLatitude.Text = "";
            txtLongitude.Text = "";
        }

        #endregion


        public void DoDirectionOfTravelFromMapClick(float fNewDirectionInDegrees)
        {
            while (fNewDirectionInDegrees < 0)
                fNewDirectionInDegrees += 360;
            while (fNewDirectionInDegrees > 360)
                fNewDirectionInDegrees -= 360;


            System.Diagnostics.Trace
            .WriteLine(string.Format("Map Click Angle in Degrees: {0}",
                                     fNewDirectionInDegrees));

            if (fNewDirectionInDegrees <= 90)
                fNewDirectionInDegrees = 90 - fNewDirectionInDegrees;
            else if (fNewDirectionInDegrees <= 180)
                fNewDirectionInDegrees = 360 - (fNewDirectionInDegrees - 90);
            else if (fNewDirectionInDegrees <= 270)
                fNewDirectionInDegrees = 270 - (fNewDirectionInDegrees - 180);
            else
                fNewDirectionInDegrees = 180 - (fNewDirectionInDegrees - 270);

            lock (timerUpdateDisplay)
                m_Vehicle.DirectionOfTravel = fNewDirectionInDegrees;
        }


        void DoDirectionOfTravelFromGaugeClick(float fNewDirectionInDegrees)
        {
            lock (timerUpdateDisplay)
                m_Vehicle.DirectionOfTravel = fNewDirectionInDegrees;
        }

        
        private void txtDirectionOfTravel_TextChanged(object sender, EventArgs e)
        {
            txtDirectionOfTravel.Text = txtDirectionOfTravel.Text.Trim();
            if (txtDirectionOfTravel.Text.Length < 1)
                txtDirectionOfTravel.Text = "0";

            try
            {
                lock (timerUpdateDisplay)
                    m_Vehicle.DirectionOfTravel = System.Convert.ToDouble(txtDirectionOfTravel.Text);
            }
            catch
            {
                ;
            }
        }


        private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboState.Enabled = Program.SetStatesComboBox(cboState, cboCountry.SelectedItem as string);
        }


        private void cboPreviousLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_bIn_cmdSetVehicleLocation_Click)
                return;

            Address address = cboPreviousLocations.SelectedItem as Address;
            if (address == null)
                return;

            cboCountry.SelectedItem = address.Country;
            Application.DoEvents();
            cboState.SelectedItem = address.State;
            Application.DoEvents();
            txtCity.Text = address.City;
            Application.DoEvents();
            txtStreet.Text = address.Street;
            Application.DoEvents();
        }



        public void DoRapidDecel(bool bFromUser)
        {
            if (cmdRapidDecel.Text == "Rapid Deceleration")
            {
                cmdRapidDecel.Text = "STOP Rapid Deceleration";
                lock (timerUpdateDisplay)
                    m_Vehicle.SetTargetSpeed(0, m_dblDEFAULT_RAPIDDECELERATION);
            }
            else
            {
                cmdRapidDecel.Text = "Rapid Deceleration";
            }
        }


        private void cmdRapidDecel_Click(object sender, EventArgs e)
        {
            if (RoutePlaybackInSession)
                return;

            DoRapidDecel(true);
        }


        #region MAP PictureBox Event handlers


        private void pictureBox_Map_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            toolStripStatusLabel_LocationChanged.BackColor = SystemColors.Control;
            toolStripStatusLabel_LocationChanged.Text = "";

            Application.DoEvents();
        }


        public void DoMapClick(bool bFromUser)
        {
            int iMapMidY = pictureBox_Map.Height / 2;
            int iMapMidX = pictureBox_Map.Width / 2;

            Point mouseLocation = MousePosition;

            Point mouseLocationInMap = pictureBox_Map.PointToClient(mouseLocation);
            mouseLocationInMap.Y = iMapMidY - mouseLocationInMap.Y;
            mouseLocationInMap.Offset(-iMapMidX, 0);

            double? dblDegrees = null;
            if (mouseLocationInMap.X == 0)
            {
                if (mouseLocationInMap.Y >= 0)
                    dblDegrees = 90;
                else
                   dblDegrees = 270;
            }

            if (mouseLocationInMap.Y == 0)
            {
                if (mouseLocationInMap.X >= 0)
                    dblDegrees = 0;
                else
                    dblDegrees = 180;
            }

            if (!dblDegrees.HasValue)
            {
                double dblRadAngle = Math.Atan2(mouseLocationInMap.Y, mouseLocationInMap.X);

                dblDegrees = Physics.Radians_to_Degrees(dblRadAngle);
            }

            System.Diagnostics.Trace
            .WriteLine(string.Format("Map Click (x: {0}, y: {1}) Degrees: {2}",
                                     mouseLocationInMap.X, mouseLocationInMap.Y,
                                     dblDegrees));

            DoDirectionOfTravelFromMapClick((float)dblDegrees);
        }


        private void pictureBox_Map_Click(object sender, EventArgs e)
        {
            if (RoutePlaybackInSession)
                return;

            DoMapClick(true);
        }


        #endregion



        #region Direction of Travel Gauge Event handlers

        private void gaugeDirectionOfTravel_OnMouseValueSelection(float fClickedValue)
        {
            if (RoutePlaybackInSession)
                return;

            DoDirectionOfTravelFromGaugeClick(fClickedValue);
        }


        private void gaugeDirectionOfTravel_OnMouseDownValueSelection(float fClickedValue)
        {
            if (RoutePlaybackInSession)
                return;

            lblFloater.Text = ((int)fClickedValue).ToString();
            lblFloater.BringToFront();
            Point pt = this.PointToClient(MousePosition);
            pt.Offset(0, -lblFloater.Height);
            lblFloater.Location = pt;

            lblFloater.Visible = true;
        }


        private void gaugeDirectionOfTravel_MouseUp(object sender, MouseEventArgs e)
        {
            if (RoutePlaybackInSession)
                return;

            lblFloater.Text = "";
            lblFloater.Visible = false;
            lblFloater.SendToBack();
        }

        #endregion


        #region RPM Gauge Event handlers

        public void DoRpmGaugeClicked(float fClickedValue, bool bFromUser)
        {
            lock (timerUpdateDisplay)
                m_Vehicle.SetTargetEngineRPM(((int)fClickedValue), m_dblDEFAULT_RPM_ACCELERATION);
        }


        private void gaugeRPM_OnMouseValueSelection(float fClickedValue)
        {
            if (RoutePlaybackInSession)
                return;

            DoRpmGaugeClicked(fClickedValue, true);
        }


        private void gaugeRPM_OnMouseDownValueSelection(float fClickedValue)
        {
            if (RoutePlaybackInSession)
                return;

            lblFloater.Text = ((int)fClickedValue).ToString();
            lblFloater.BringToFront();
            Point pt = this.PointToClient(MousePosition);
            pt.Offset(0, -lblFloater.Height);
            lblFloater.Location = pt;

            lblFloater.Visible = true;
        }


        private void gaugeRPM_MouseUp(object sender, MouseEventArgs e)
        {
            if (RoutePlaybackInSession)
                return;

            lblFloater.Text = "";
            lblFloater.Visible = false;
            lblFloater.SendToBack();
        }


        #endregion


        #region VELOCITY Gauge Event handlers

        public void DoVelocityGaugeClicked(float fClickedValue, bool bFromUser)
        {
            double dblFinalVelocityKPH = (int)fClickedValue;
            if (m_currUnitsOfMeasure == eUnitsOfMeasure.Mph)
            {
                dblFinalVelocityKPH = Physics.MPH_to_KPH(dblFinalVelocityKPH);
            }

            lock (timerUpdateDisplay)
                m_Vehicle.SetTargetSpeed(dblFinalVelocityKPH, m_dblDEFAULT_ACCELERATION);
        }


        private void gaugeVelocity_OnMouseValueSelection(float fClickedValue)
        {
            if (RoutePlaybackInSession)
                return;

            DoVelocityGaugeClicked(fClickedValue, true);
        }


        private void gaugeVelocity_OnMouseDownValueSelection(float fClickedValue)
        {
            if (RoutePlaybackInSession)
                return;

            lblFloater.Text = ((int)fClickedValue).ToString();
            lblFloater.BringToFront();
            Point pt = this.PointToClient(MousePosition);
            pt.Offset(0, -lblFloater.Height);
            lblFloater.Location = pt;

            lblFloater.Visible = true;
        }


        private void gaugeVelocity_MouseUp(object sender, MouseEventArgs e)
        {
            if (RoutePlaybackInSession)
                return;

            lblFloater.Text = "";
            lblFloater.Visible = false;
            lblFloater.SendToBack();
        }

        #endregion




        #region Route Methods

        private frmRoutePlayback m_frmRoutePlayback = null;


        private void toolStripButton_LoadRoute_Click(object sender, EventArgs e)
        {
            if (RoutePlaybackInSession)
                return;

            openFileDialog1.Filter = "route files (*.route)|*.route|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.InitialDirectory = Program.Directory_AppDataRoot_Routes;

            DialogResult rc = openFileDialog1.ShowDialog(this);
            if (rc != DialogResult.OK)
                return;

            List<VehicleSimulator.RouteLeg> lstLegs;

            using (TextReader textReader = new StreamReader(openFileDialog1.FileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<VehicleSimulator.RouteLeg>));

                try
                {
                    lstLegs = (List<VehicleSimulator.RouteLeg>)serializer.Deserialize(textReader);

                    if (lstLegs.Count > 0)
                    {
                        m_frmRoutePlayback = new frmRoutePlayback(this, lstLegs.ToArray());
                        m_frmRoutePlayback.OnRoutePlaybackStarted += m_frmRoutePlayback_OnRoutePlacebackStarted;
                        m_frmRoutePlayback.OnRoutePlaybackStopped += m_frmRoutePlayback_OnRoutePlacebackStopped;
                        m_frmRoutePlayback.Show();
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }


        void m_frmRoutePlayback_OnRoutePlacebackStopped()
        {
            RoutePlaybackInSession = true;
        }


        void m_frmRoutePlayback_OnRoutePlacebackStarted()
        {
            RoutePlaybackInSession = true;
        }


        private void toolStripButton_CreateRoute_Click(object sender, EventArgs e)
        {
            if (RoutePlaybackInSession)
                return;

            using (frmCreateRoute routeCreationForm = new frmCreateRoute())
            {
                routeCreationForm.ShowDialog(this);
            }
        }

        #endregion

        private void toolStripButton_MapOnOff_Click(object sender, EventArgs e)
        {
            m_bMapOn = !m_bMapOn;
            SetStripButtonGuiState(toolStripButton_MapOnOff, m_bMapOn);
        }


        private void timerSerialPortMonitor_Tick(object sender, EventArgs e)
        {
            lock (timerSerialPortMonitor)
            {
                string strMsg;
                string strToolStripText;
                timerSerialPortMonitor.Enabled = 
                    !DoComPortsValidityGuiFeedback(out strMsg,
                                                   out strToolStripText);
            }
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseSerialPortAndNull(ref m_EcmOutputSerialPort);
            CloseSerialPortAndNull(ref m_GpsOutputSerialPort);
        }



        private void lblVelocity_DoubleClick(object sender, EventArgs e)
        {
            if (RoutePlaybackInSession)
                return;

            lock (timerUpdateDisplay)
                m_Vehicle.SetTargetSpeed(0, m_dblDEFAULT_ACCELERATION);
        }

        private void lblRPM_DoubleClick(object sender, EventArgs e)
        {
            if (RoutePlaybackInSession)
                return;

            lock (timerUpdateDisplay)
                m_Vehicle.SetTargetEngineRPM(0, m_dblDEFAULT_RPM_ACCELERATION);
        }

        private void lblOdometerWhole_DoubleClick(object sender, EventArgs e)
        {
            double dblODO = m_Vehicle.Odometer;
            string strUnits;
            if (m_currUnitsOfMeasure == eUnitsOfMeasure.Kph)
            {
                strUnits = "Kilometers";
            }
            else
            {
                dblODO = Physics.Kilometers_to_Miles(dblODO);
                strUnits = "Miles";
            }

            using (frmChangeVehicleODO changeVehicleOdoForm = new frmChangeVehicleODO(dblODO, strUnits))
            {
                DialogResult rc = changeVehicleOdoForm.ShowDialog(this);

                if (rc == DialogResult.OK
                    && changeVehicleOdoForm.NewODO.HasValue)
                {
                    Properties.Settings.Default.Odometer = changeVehicleOdoForm.NewODO.Value;
                    Properties.Settings.Default.Save();

                    lock (timerUpdateDisplay)
                    {
                        if (m_currUnitsOfMeasure == eUnitsOfMeasure.Kph)
                            m_Vehicle.Odometer = Properties.Settings.Default.Odometer;
                        else
                            m_Vehicle.Odometer = Physics.MPH_to_KPH(Properties.Settings.Default.Odometer);
                    }
                }
            }
        }



        private bool m_bCyclingStop = false;
        private int m_iTargetTerminalCycleVelocity = 0; // Always stored in KPH!!
        private int m_iTargetCyclingStopVelocity = 0;


        private void cmdCycleStartStop_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                m_bCyclingStop = !m_bCyclingStop;
                if (m_bCyclingStop) {
                    m_iTargetCyclingStopVelocity = m_iTargetTerminalCycleVelocity;
                    lock (timerUpdateDisplay)
                        m_Vehicle.SetTargetSpeed(m_iTargetCyclingStopVelocity, m_dblDEFAULT_ACCELERATION);
                }
            }
        }

        private void cmdCycleStartStop_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                using (frmGetUserInput getUserInputForm = new frmGetUserInput("Terminal Velocity", "Please enter the terminating velocity for the 'Cycle' function.", "New Velocity (whole # only):")) {
                    DialogResult rc = getUserInputForm.ShowDialog(this);
                    if (rc == DialogResult.OK) {
                        if (!string.IsNullOrEmpty(getUserInputForm.UserText)) {
                            try {
                                m_iTargetTerminalCycleVelocity = System.Convert.ToInt32(getUserInputForm.UserText);
                                cmdCycleStartStop.Text = string.Format("Cycle ({0})", m_iTargetTerminalCycleVelocity);

                                if (m_currUnitsOfMeasure == eUnitsOfMeasure.Mph)
                                {
                                    m_iTargetTerminalCycleVelocity =
                                        (int)(Physics.MPH_to_KPH(m_iTargetTerminalCycleVelocity) + .5);
                                }
                            } catch {
                                ;
                            } // User entered non-numeric value, so we don't care.
                        }
                    }
                }
            }
        }

        private void frmMain_Resize(object sender, EventArgs e) {
            pictureBox_Map.Tag = null;
        }

    }  // public partial class frmMain : Form

}  // namespace VehicleSimulator

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using RouteSvc = VehicleSimulator.BingRouteService;


namespace VehicleSimulator
{

    public partial class frmCreateRoute : Form
    {

        public frmCreateRoute()
        {
            InitializeComponent();

            txtArriveSetVelocity.KeyPress += Program.txtNumericWithDecimal_KeyPress;
            txtArriveSetRPM.KeyPress += Program.txtNumericWithDecimal_KeyPress;
            txtArrivePauseBeforeContinuing.KeyPress += Program.txtNumericWithDecimal_KeyPress;

            txtLeaveSetVelocity.KeyPress += Program.txtNumericWithDecimal_KeyPress;
            txtLeaveSetRPM.KeyPress += Program.txtNumericWithDecimal_KeyPress;

            cboCountry.SelectedIndex = 1;
        }


        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (lstWayPoints.Items.Count > 0)
            {
                DialogResult answer = MessageBox.Show(this,
                                                      "Cancel and lose ALL Route data?", "Are You Sure?",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (answer == DialogResult.Yes)
                    return;
            }

            this.DialogResult = DialogResult.Cancel;
            this.Hide();
            this.Close();
        }


        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (lstWayPoints.Items.Count < 1)
                return;

            string strRouteName = txtRouteName.Text.Trim(new char[] { '<', '>', ':', '"', '/', '\\', '|', '?', '*' });

            string strRouteFileName = string.Format("{0}.route", strRouteName.Trim());

            saveFileDialog1.FileName = strRouteFileName;
            saveFileDialog1.InitialDirectory = Program.Directory_AppDataRoot_Routes;

            DialogResult rc = saveFileDialog1.ShowDialog(this);

            if (rc != DialogResult.OK)
                return;

            string strFQFileName = Path.Combine(Path.GetDirectoryName(saveFileDialog1.FileName),
                                                strRouteFileName);

            List<object> lstNewWayPoints = new List<object>();

            foreach (object objWayPoint in lstWayPoints.Items)
            {
                WayPoint wayPoint = (WayPoint)objWayPoint;
                lstNewWayPoints.Add(wayPoint);
            }


            List<VehicleSimulator.RouteLeg> lstLegs = new List<RouteLeg>();
            VehicleSimulator.RouteLeg routeLeg = null;
            WayPoint prevWayPoint = null;

            foreach (object objWayPoint in lstWayPoints.Items)
            {
                WayPoint wayPoint = (WayPoint)objWayPoint;

                if (routeLeg == null)
                {
                    if (prevWayPoint == null)
                    {
                        routeLeg = new RouteLeg(wayPoint, null);
                    }
                    else
                    {
                        routeLeg = new RouteLeg(prevWayPoint, wayPoint);
                        lstLegs.Add(routeLeg);

                        prevWayPoint = wayPoint;

                        routeLeg = null;
                    }
                }
                else
                {
                    routeLeg.End = wayPoint;
                    lstLegs.Add(routeLeg);

                    prevWayPoint = wayPoint;

                    routeLeg = null;
                }
            }


            foreach (VehicleSimulator.RouteLeg leg in lstLegs)
            {
                RouteSvc.RouteResponse routeResponse
                    = Program.RoutingWrapper.CalculateRoute(new List<object> { leg.Start, leg .End});

                if (routeResponse.ResponseSummary.StatusCode != RouteSvc.ResponseStatusCode.Success
                    || routeResponse.Result.Legs.Length < 1)
                {
                    throw new ApplicationException();
                }

                RouteSvc.Location[] aRouteLocations = routeResponse.Result.RoutePath.Points;

                foreach (RouteSvc.Location point in aRouteLocations)
                {
                    VehicleSimulator.Location routeLocation 
                        = new VehicleSimulator.Location(point.Longitude, point.Latitude);

                    leg.DrivingLocations.Add(new WayPoint { Location = routeLocation });
                }
            }

            using (TextWriter textWriter = new StreamWriter(strFQFileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<VehicleSimulator.RouteLeg>));

                serializer.Serialize(textWriter, lstLegs);
            }

            this.DialogResult = DialogResult.OK;
            this.Hide();
            this.Close();
        }


        Address CurrentAddress
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
        }


        private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboState.Enabled = Program.SetStatesComboBox(cboState, (string)cboCountry.SelectedItem);
        }


        private void cmdResetNewWayPointFields_Click(object sender, EventArgs e)
        {
            txtArriveSetVelocity.Text = "";
            txtArriveSetRPM.Text = "";
            txtArrivePauseBeforeContinuing.Text = "";

            txtLeaveSetVelocity.Text = "";
            txtLeaveSetRPM.Text = "";

            cboCountry.SelectedIndex = -1;

            cmdAddNewWayPoint.Enabled = false;
        }


        void ClearWayPointDetails()
        {
            txtWayPointDetails_ArriveVelocity.Text = "";
            txtWayPointDetails_ArriveRPM.Text = "";
            txtWayPointDetails_ArrivePause.Text = "";

            txtWayPointDetails_DepartVelocity.Text = "";
            txtWayPointDetails_DepartRPM.Text = "";
        }


        static double? GetValue(string strValue)
        {
            double? dblValue = null;
            try
            {
                dblValue = System.Convert.ToDouble(strValue);
            }
            catch { ;}

            return dblValue;
        }


        private void lstWayPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstWayPoints.SelectedIndex < 0)
            {
                ClearWayPointDetails();
                return;
            }

            WayPoint wayPoint = (WayPoint)lstWayPoints.SelectedItem;

            txtWayPointDetails_ArriveVelocity.Text = wayPoint.ArriveVelocity.ToString();
            txtWayPointDetails_ArriveRPM.Text = wayPoint.ArriveRPM.ToString();
            txtWayPointDetails_ArrivePause.Text = wayPoint.ArrivePauseBeforeDeparture.ToString();

            txtWayPointDetails_DepartVelocity.Text = wayPoint.DepartVelocity.ToString();
            txtWayPointDetails_DepartRPM.Text = wayPoint.DepartRPM.ToString();
        }


        private void NewWayPointAddress_TextChanged(object sender, EventArgs e)
        {
            cmdAddNewWayPoint.Enabled = CurrentAddress.IsValid;
        }


 
        private void cmdAddNewWayPoint_Click(object sender, EventArgs e)
        {
            Address currAddress = this.CurrentAddress;
            if (!currAddress.IsValid)
                return;

            VehicleSimulator.Location geocodedLocation
                = Program.GeocodingWrapper.Geocode(currAddress);
//            geocodedLocation.Precision = 5;

            if (!geocodedLocation.IsValid)
                return;

            WayPoint wayPoint
                = new WayPoint
                      {
                          WayPointAddress = currAddress,

                          ArriveVelocity = GetValue(txtArriveSetVelocity.Text),
                          ArriveRPM = GetValue(txtArriveSetRPM.Text),
                          ArrivePauseBeforeDeparture = GetValue(txtArrivePauseBeforeContinuing.Text),

                          DepartVelocity = GetValue(txtLeaveSetVelocity.Text),
                          DepartRPM = GetValue(txtLeaveSetRPM.Text),

                          Location = geocodedLocation
                      };

            lstWayPoints.SelectedIndex = lstWayPoints.Items.Add(wayPoint);

            txtStreet.Text = "";
            txtStreet.Focus();
        }


    }  // public partial class frmCreateRoute : Form

}  // namespace VehicleSimulator

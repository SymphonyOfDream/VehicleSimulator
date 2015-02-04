using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using log4net;
using log4net.Config;
using System.Net.NetworkInformation;
using log4net.Appender;
using System.IO;

namespace VehicleSimulator
{
    static partial class Program
    {
        public static string BingApiKey
        {
            get { return "AusgAUxHHZ_-97UgXSYov4MsBcnKaRb6UVPQEXf2PPSV61gssGc_SCskY05QH0Me"; }
        }


        private static ILog m_Logger = null;
        public static ILog Logger
        {
            get
            {
                if (Program.m_Logger == null)
                {
                    Program.m_Logger = LogManager.GetLogger("VehicleSimulator");
                    XmlConfigurator.Configure();

                    log4net.Repository.Hierarchy.Hierarchy h 
                        = (log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository();

                    foreach (IAppender a in h.Root.Appenders)
                    {
                        if (a is FileAppender || a is RollingFileAppender)
                        {
                            FileAppender fa = (FileAppender)a;
                            // Programmatically set this to the desired location here
                            string logFileLocation
                                = Path.Combine(Program.Directory_AppDataRoot_Logs,
                                               "VehicleSimulator.log");

                            // Uncomment the lines below if you want to retain the base file name
                            // and change the folder name...
                            //FileInfo fileInfo = new FileInfo(fa.File);
                            //logFileLocation = string.Format(@"C:\MySpecialFolder\{0}", fileInfo.Name);

                            fa.File = logFileLocation;
                            fa.ActivateOptions();
                            break;
                        }
                    }

                }
                return Program.m_Logger;
            }
        }
 


        public static void AddAddress(Address address)
        {
            RegistryKey regVehicleSimulator = null;
            try
            {
                regVehicleSimulator = Registry.CurrentUser.OpenSubKey("Vehicle Simulator", true);
            }
            catch
            {
                regVehicleSimulator = null;
            }

            if (regVehicleSimulator == null)
            {
                try
                {
                    regVehicleSimulator = Registry.CurrentUser.CreateSubKey("Vehicle Simulator");
                }
                catch
                {
                    regVehicleSimulator = null;
                }
            }

            if (regVehicleSimulator != null)
            {
                RegistryKey regVehicleSimulatorAddresses = null;
                try
                {
                    regVehicleSimulatorAddresses = regVehicleSimulator.OpenSubKey("ADDRESSES", true);
                }
                catch
                {
                    regVehicleSimulatorAddresses = null;
                }

                if (regVehicleSimulatorAddresses == null)
                {
                    try
                    {
                        regVehicleSimulatorAddresses = regVehicleSimulator.CreateSubKey("ADDRESSES");
                    }
                    catch
                    {
                        regVehicleSimulatorAddresses = null;
                    }
                }

                if (regVehicleSimulatorAddresses != null)
                {
                    string strNewSubKeyName = string.Format("ADDRESS {0}", regVehicleSimulatorAddresses.SubKeyCount + 1);

                    using (RegistryKey regKey = regVehicleSimulatorAddresses.CreateSubKey(strNewSubKeyName))
                    {
                        if (regKey != null)
                        {
                            regKey.SetValue("STREET", address.Street);
                            regKey.SetValue("CITY", address.City);
                            regKey.SetValue("STATE", address.State);
                            regKey.SetValue("COUNTRY", address.Country);
                        }
                    }

                    regVehicleSimulatorAddresses.Close();
                }  // if (regVehicleSimulatorAddresses != null)

                regVehicleSimulator.Close();
            }  // if (regVehicleSimulator != null)
        }


        public static List<Address> AllAddresses
        {
            get
            {
                List<Address> lstAddresses = new List<Address>();

                RegistryKey regVehicleSimulator = null;
                try
                {
                    regVehicleSimulator = Registry.CurrentUser.OpenSubKey("Vehicle Simulator", true);
                }
                catch
                {
                    regVehicleSimulator = null;
                }

                if (regVehicleSimulator == null)
                {
                    try
                    {
                        regVehicleSimulator = Registry.CurrentUser.CreateSubKey("Vehicle Simulator");
                    }
                    catch
                    {
                        regVehicleSimulator = null;
                    }
                }


                if (regVehicleSimulator != null)
                {
                    RegistryKey regVehicleSimulatorAddresses = null;
                    try
                    {
                        regVehicleSimulatorAddresses = regVehicleSimulator.OpenSubKey("ADDRESSES", true);
                    }
                    catch
                    {
                        regVehicleSimulatorAddresses = null;
                    }

                    if (regVehicleSimulatorAddresses == null)
                    {
                        try
                        {
                            regVehicleSimulatorAddresses = regVehicleSimulator.CreateSubKey("ADDRESSES");
                        }
                        catch
                        {
                            regVehicleSimulatorAddresses = null;
                        }
                    }

                    if (regVehicleSimulatorAddresses != null)
                    {
                        string[] astrPreviousAddresses = regVehicleSimulatorAddresses.GetSubKeyNames();
                        foreach (string strAddressSubkey in astrPreviousAddresses)
                        {
                            using (RegistryKey regKey = regVehicleSimulatorAddresses.OpenSubKey(strAddressSubkey))
                            {
                                if (regKey == null)
                                    continue;

                                string strStreet = (string)regKey.GetValue("STREET");
                                string strCity = (string)regKey.GetValue("CITY");
                                string strState = (string)regKey.GetValue("STATE");
                                string strCountry = (string)regKey.GetValue("COUNTRY");

                                Address address = new Address
                                {
                                    Street = strStreet,
                                    City = strCity,
                                    State = strState,
                                    Country = strCountry
                                };

                                lstAddresses.Add(address);
                            }  // using (RegistryKey regKey = regVehicleSimulatorAddresses.OpenSubKey(strAddressSubkey))
                        }  // foreach (string strAddressSubkey in astrPreviousAddresses)

                        regVehicleSimulatorAddresses.Close();
                    }  // if (regVehicleSimulatorAddresses != null)

                    regVehicleSimulator.Close();
                }  // if (regVehicleSimulator != null)

                return lstAddresses;
            }
        }



        public static 
        void txtNumericWithDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtSender = sender as TextBox;
            if (txtSender == null)
                return;

            if (char.IsDigit(e.KeyChar) == false
                && char.IsControl(e.KeyChar) == false
                && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.'
                && txtSender.Text.Contains('.'))
                e.Handled = true;
        }





        public static
        void txtNumericWithDecimalAndMinus_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtSender = sender as TextBox;
            if (txtSender == null)
                return;

            if (char.IsDigit(e.KeyChar) == false
                && char.IsControl(e.KeyChar) == false
                && e.KeyChar != '.'
                && e.KeyChar != '-')
                e.Handled = true;

            if (e.KeyChar == '.'
                && txtSender.Text.Contains('.'))
                e.Handled = true;

            if (e.KeyChar == '-'
                && txtSender.Text.Contains('-'))
                e.Handled = true;
        }



        public static
        void txtNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false
                && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }


        public static
        bool SetStatesComboBox(ComboBox cboState, string strCountry)
        {
            cboState.Items.Clear();

            if (string.IsNullOrEmpty(strCountry))
                return false;

            if (strCountry.ToUpper() == "CANADA")
            {
                cboState.Enabled = true;
                cboState.Items.AddRange(new object[] {
                                        "AB",
                                        "BC",
                                        "MB",
                                        "NB",
                                        "NL",
                                        "NT",
                                        "NS",
                                        "NU",
                                        "ON",
                                        "PE",
                                        "QC",
                                        "SK",
                                        "YT"});
            }
            else if (strCountry.ToUpper() == "U.S.A.")
            {
                cboState.Enabled = true;
                cboState.Items.AddRange(new object[] {
                                        "AL",
                                        "AK",
                                        "AZ",
                                        "AR",
                                        "CA",
                                        "CO",
                                        "CT",
                                        "DE",
                                        "DC",
                                        "FL",
                                        "GA",
                                        "HI",
                                        "ID",
                                        "IL",
                                        "IN",
                                        "IA",
                                        "KS",
                                        "KY",
                                        "LA",
                                        "ME",
                                        "MD",
                                        "MA",
                                        "MI",
                                        "MN",
                                        "MS",
                                        "MO",
                                        "MT",
                                        "NE",
                                        "NV",
                                        "NH",
                                        "NJ",
                                        "NM",
                                        "NY",
                                        "NC",
                                        "ND",
                                        "OH",
                                        "OK",
                                        "OR",
                                        "PA",
                                        "RI",
                                        "SC",
                                        "SD",
                                        "TN",
                                        "TX",
                                        "UT",
                                        "VT",
                                        "VA",
                                        "WA",
                                        "WV",
                                        "WI",
                                        "WY"});
            }
            else
            {
                return false;
            }

            return true;
        }



        private static BingGeocodingWrapper m_BingGeocodingWrapper;
        public static BingGeocodingWrapper GeocodingWrapper
        {
            get
            {
                if (Program.m_BingGeocodingWrapper == null)
                    Program.m_BingGeocodingWrapper = new BingGeocodingWrapper();

                return Program.m_BingGeocodingWrapper;
            }
        }


        private static BingImageryWrapper m_BingImageryWrapper;
        public static BingImageryWrapper ImageryWrapper
        {
            get
            {
                if (Program.m_BingImageryWrapper == null)
                    Program.m_BingImageryWrapper = new BingImageryWrapper();

                return Program.m_BingImageryWrapper;
            }
        }





        private static BingRoutingWrapper m_BingRoutingWrapper;
        public static BingRoutingWrapper RoutingWrapper
        {
            get
            {
                if (Program.m_BingRoutingWrapper == null)
                    Program.m_BingRoutingWrapper = new BingRoutingWrapper();

                return Program.m_BingRoutingWrapper;
            }
        }



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Program.Logger.Info("Application Started.");

           List<SimpleSerialPort> lstSSP = SimpleSerialPort.GetSortedPortObjects();

           if (lstSSP.Count > 0)
           {
              string strMsg = "";

              for (int idx = 0; idx < lstSSP.Count; ++idx)
              {
                 strMsg += lstSSP[idx].ToString();

                 if (idx + 1 < lstSSP.Count)
                    strMsg += ", ";
              }

              Program.Logger.InfoFormat("Serial Ports on system at startup: {0}", strMsg);
           }
           else
           {
              Program.Logger.Info("NO Serial Ports on system at startup");
           }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
                Program.Logger.Error("Unhandled Exception Detected!");

                bool networkUp
                    = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

                if (!networkUp)
                {
                    Program.Logger.Error("Machine Networking Appears to be Down!");
                }


                int iExceptionCount = 1;
                while (ex != null)
                {
                    Program.Logger.Error(string.Format("Unhandled Exception {0}", iExceptionCount++), ex);

                    ex = ex.InnerException;
                }
            }
            finally
            {
                Program.Logger.Info("Application Ended.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VehicleSimulator
{

    public partial class frmComSettings : Form
    {
        SimpleSerialPort m_OriginalEcmPort;
        SimpleSerialPort m_CurrentEcmPort;

        SimpleSerialPort m_OriginalGpsPort;
        SimpleSerialPort m_CurrentGpsPort;

        bool m_bInCTor = true;
        bool m_bChangeMade = false;


        public frmComSettings()
        {
            InitializeComponent();

            m_OriginalEcmPort = new SimpleSerialPort(Properties.Settings.Default.EcmComPort);
            m_CurrentEcmPort = m_OriginalEcmPort;

            m_OriginalGpsPort = new SimpleSerialPort(Properties.Settings.Default.GpsComPort);
            m_CurrentGpsPort = m_OriginalGpsPort;

            cboEcmPorts.Items.Add(SimpleSerialPort.CreateInvalid());
            cboEcmPorts.Items.AddRange(SimpleSerialPort.GetSortedPortObjectsArray());
            
            cboGpsPorts.Items.Add(SimpleSerialPort.CreateInvalid());
            cboGpsPorts.Items.AddRange(SimpleSerialPort.GetSortedPortObjectsArray());

            DoReset();

            m_bInCTor = false;
        }



        #region Reset

        private void DoReset()
        {
            if (cboEcmPorts.Items.Contains(m_OriginalEcmPort))
            {
                cboEcmPorts.SelectedItem = m_OriginalEcmPort;
            }
            else
            {
                cboEcmPorts.SelectedIndex = 0;
            }

            if (cboGpsPorts.Items.Contains(m_OriginalGpsPort))
            {
                cboGpsPorts.SelectedItem = m_OriginalGpsPort;
            }
            else
            {
                cboGpsPorts.SelectedIndex = 0;
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            DoReset();
        }

        #endregion


        #region Port Changed Processing

        bool PortChangeGuiFeedback(SimpleSerialPort original, SimpleSerialPort current, Label label)
        {
            if (!current.Equals(original))
            {
                label.Font = new Font(label.Font, FontStyle.Bold);
                return true;
            }

            label.Font = new Font(label.Font, FontStyle.Regular);
            return false;
        }


        void HandlePortChange()
        {
            m_CurrentEcmPort = (SimpleSerialPort)cboEcmPorts.SelectedItem;
            bool bSomethingChanged
                = PortChangeGuiFeedback(m_OriginalEcmPort, m_CurrentEcmPort, lblEcmPort);

            m_CurrentGpsPort = (SimpleSerialPort)cboGpsPorts.SelectedItem;
            bSomethingChanged |= PortChangeGuiFeedback(m_OriginalGpsPort, m_CurrentGpsPort, lblGpsPort);

            if (   m_CurrentEcmPort.Equals(m_CurrentGpsPort) == false
                || (m_CurrentEcmPort.IsValid == false || m_CurrentGpsPort.IsValid == false))
            {
                lblEcmPort.ForeColor = SystemColors.ControlText;
                lblGpsPort.ForeColor = SystemColors.ControlText;

                cmdSave.Enabled = bSomethingChanged;
                cmdReset.Enabled = bSomethingChanged;
            }
            else
            {
                lblEcmPort.ForeColor = Color.Red;
                lblGpsPort.ForeColor = Color.Red;

                cmdSave.Enabled = false;
                cmdReset.Enabled = false;
            }
        }


        private void cboPortChanges_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_bInCTor)
                return;

            HandlePortChange();
        }

        #endregion


        void DoClose()
        {
            this.Hide();
            this.DialogResult = m_bChangeMade
                                ? DialogResult.OK
                                : DialogResult.Cancel;
        }


        private void cmdSave_Click(object sender, EventArgs e)
        {
            bool bSomethingChanged = false;
            if (!m_OriginalEcmPort.Equals(m_CurrentEcmPort))
            {
                Properties.Settings.Default.EcmComPort = m_CurrentEcmPort.ToString();
                bSomethingChanged = true;
            }
            if (!m_OriginalGpsPort.Equals(m_CurrentGpsPort))
            {
                Properties.Settings.Default.GpsComPort = m_CurrentGpsPort.ToString();
                bSomethingChanged = true;
            }

            if (bSomethingChanged)
            {
                Properties.Settings.Default.Save();
                m_bChangeMade = true;
                m_OriginalEcmPort = m_CurrentEcmPort;
                m_OriginalGpsPort = m_CurrentGpsPort;
                HandlePortChange();
            }

            DoClose();
        }


        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (   m_OriginalEcmPort.Equals(m_CurrentEcmPort) == false
                || m_OriginalGpsPort.Equals(m_CurrentGpsPort) == false)
            {
                DialogResult answer = MessageBox.Show("You have made changes.\r\n\r\nContinue and lose all changes?",
                                                      "Are You Sure?",
                                                      MessageBoxButtons.YesNo, 
                                                      MessageBoxIcon.Question);

                if (answer != DialogResult.Yes)
                {
                    return;
                }
            }

            DoClose();
        }
    }

}  // namespace VehicleSimulator

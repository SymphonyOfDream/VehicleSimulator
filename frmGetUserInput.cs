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

    public partial class frmGetUserInput : Form
    {
        public string UserText { get; private set; }

        public frmGetUserInput(string strCaption,
                               string strMessage,
                               string strPrompt)
        {
            InitializeComponent();

            UserText = null;

            if (!string.IsNullOrEmpty(strCaption))
                Text = strCaption;

            if (!string.IsNullOrEmpty(strMessage))
                lblMessage.Text = strMessage;

            if (!string.IsNullOrEmpty(strPrompt))
                lblPrompt.Text = strPrompt;
        }


        private void cmdCancel_Click(object sender, EventArgs e)
        {
            UserText = null;
            DialogResult = DialogResult.Cancel;
            this.Hide();
        }


        private void cmdOK_Click(object sender, EventArgs e)
        {
            UserText = txtUserInput.Text;
            DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void frmChangeVehicleODO_Load(object sender, EventArgs e)
        {
            txtUserInput.Focus();
        }



    }  // public partial class frmGetUserInput : Form

}  // namespace VehicleSimulator

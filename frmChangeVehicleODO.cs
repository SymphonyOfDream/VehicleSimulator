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

    public partial class frmChangeVehicleODO : Form
    {
        public double? NewODO { get; private set; }

        public frmChangeVehicleODO(double dblCurrentODO,
                                   string strUnits)
        {
            InitializeComponent();

            txtNewODO.KeyPress += Program.txtNumericWithDecimal_KeyPress;

            NewODO = null;

            lblUnits.Text = strUnits;
            txtCurrentODO.Text = dblCurrentODO.ToString();


        }


        private void cmdCancel_Click(object sender, EventArgs e)
        {
            NewODO = null;
            this.DialogResult = DialogResult.Cancel;
            Hide();
            Close();
        }


        private void txtNewODO_TextChanged(object sender, EventArgs e)
        {
            txtNewODO.Text = txtNewODO.Text.Trim();
            cmdOK.Enabled = txtNewODO.Text.Length > 0;
        }


        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                NewODO = System.Convert.ToDouble(txtNewODO.Text);

                this.DialogResult = DialogResult.OK;
                Hide();
                Close();
            }
            catch
            {
                cmdCancel_Click(sender, e);
            }
        }

        private void frmChangeVehicleODO_Load(object sender, EventArgs e)
        {
            txtNewODO.Focus();
        }



    }  // public partial class frmChangeVehicleODO : Form

}  // namespace VehicleSimulator

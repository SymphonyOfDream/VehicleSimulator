namespace VehicleSimulator
{
    partial class frmComSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpECM = new System.Windows.Forms.GroupBox();
            this.cboEcmPorts = new System.Windows.Forms.ComboBox();
            this.lblEcmPort = new System.Windows.Forms.Label();
            this.grpGPS = new System.Windows.Forms.GroupBox();
            this.cboGpsPorts = new System.Windows.Forms.ComboBox();
            this.lblGpsPort = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.grpECM.SuspendLayout();
            this.grpGPS.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpECM
            // 
            this.grpECM.Controls.Add(this.cboEcmPorts);
            this.grpECM.Controls.Add(this.lblEcmPort);
            this.grpECM.Location = new System.Drawing.Point(12, 12);
            this.grpECM.Name = "grpECM";
            this.grpECM.Size = new System.Drawing.Size(174, 64);
            this.grpECM.TabIndex = 0;
            this.grpECM.TabStop = false;
            this.grpECM.Text = "ECM";
            // 
            // cboEcmPorts
            // 
            this.cboEcmPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEcmPorts.FormattingEnabled = true;
            this.cboEcmPorts.Location = new System.Drawing.Point(57, 24);
            this.cboEcmPorts.Name = "cboEcmPorts";
            this.cboEcmPorts.Size = new System.Drawing.Size(96, 21);
            this.cboEcmPorts.TabIndex = 1;
            this.cboEcmPorts.SelectedIndexChanged += new System.EventHandler(this.cboPortChanges_SelectedIndexChanged);
            // 
            // lblEcmPort
            // 
            this.lblEcmPort.Location = new System.Drawing.Point(11, 27);
            this.lblEcmPort.Name = "lblEcmPort";
            this.lblEcmPort.Size = new System.Drawing.Size(40, 18);
            this.lblEcmPort.TabIndex = 0;
            this.lblEcmPort.Text = "Port:";
            // 
            // grpGPS
            // 
            this.grpGPS.Controls.Add(this.cboGpsPorts);
            this.grpGPS.Controls.Add(this.lblGpsPort);
            this.grpGPS.Location = new System.Drawing.Point(12, 91);
            this.grpGPS.Name = "grpGPS";
            this.grpGPS.Size = new System.Drawing.Size(174, 64);
            this.grpGPS.TabIndex = 1;
            this.grpGPS.TabStop = false;
            this.grpGPS.Text = "GPS";
            // 
            // cboGpsPorts
            // 
            this.cboGpsPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGpsPorts.FormattingEnabled = true;
            this.cboGpsPorts.Location = new System.Drawing.Point(57, 24);
            this.cboGpsPorts.Name = "cboGpsPorts";
            this.cboGpsPorts.Size = new System.Drawing.Size(96, 21);
            this.cboGpsPorts.TabIndex = 1;
            this.cboGpsPorts.SelectedIndexChanged += new System.EventHandler(this.cboPortChanges_SelectedIndexChanged);
            // 
            // lblGpsPort
            // 
            this.lblGpsPort.Location = new System.Drawing.Point(11, 27);
            this.lblGpsPort.Name = "lblGpsPort";
            this.lblGpsPort.Size = new System.Drawing.Size(40, 18);
            this.lblGpsPort.TabIndex = 0;
            this.lblGpsPort.Text = "Port:";
            // 
            // cmdSave
            // 
            this.cmdSave.Enabled = false;
            this.cmdSave.Location = new System.Drawing.Point(192, 12);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(90, 31);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "Save && Exit";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.Enabled = false;
            this.cmdReset.Location = new System.Drawing.Point(192, 58);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(90, 31);
            this.cmdReset.TabIndex = 3;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(192, 124);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(90, 31);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmComSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 167);
            this.ControlBox = false;
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.grpGPS);
            this.Controls.Add(this.grpECM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmComSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Com Ports";
            this.grpECM.ResumeLayout(false);
            this.grpGPS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpECM;
        private System.Windows.Forms.ComboBox cboEcmPorts;
        private System.Windows.Forms.Label lblEcmPort;
        private System.Windows.Forms.GroupBox grpGPS;
        private System.Windows.Forms.ComboBox cboGpsPorts;
        private System.Windows.Forms.Label lblGpsPort;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdClose;
    }
}
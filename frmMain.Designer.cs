namespace VehicleSimulator
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_ComPortSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_EcmTransmit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_GpsTransmit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_PTO = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_UnitsOfMeasure = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.cboEcmProtocol = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_MapOnOff = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton_Routes = new System.Windows.Forms.ToolStripDropDownButton();
            this.createRouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadRouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackbarMapZoom = new System.Windows.Forms.TrackBar();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grpSetVehicleLocation = new System.Windows.Forms.GroupBox();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboPreviousLocations = new System.Windows.Forms.ComboBox();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdResetVehicleLocationFields = new System.Windows.Forms.Button();
            this.cmdSetVehicleLocation = new System.Windows.Forms.Button();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblVelocityUnits = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDirectionOfTravel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblOdometerUnits = new System.Windows.Forms.Label();
            this.lblFloater = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_PortsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_LocationChanged = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmdRapidDecel = new System.Windows.Forms.Button();
            this.grpFuelConsumption = new System.Windows.Forms.GroupBox();
            this.lblMPG = new System.Windows.Forms.Label();
            this.lblMpgLabel = new System.Windows.Forms.Label();
            this.lblGPH = new System.Windows.Forms.Label();
            this.lblGphLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timerUpdateDisplay = new System.Windows.Forms.Timer(this.components);
            this.lblBingCopyrightNotice = new System.Windows.Forms.Label();
            this.timerSerialPortMonitor = new System.Windows.Forms.Timer(this.components);
            this.cmdCycleStartStop = new System.Windows.Forms.Button();
            this.lblVelocity = new System.Windows.Forms.Label();
            this.lblRPM = new System.Windows.Forms.Label();
            this.lblOdometerWhole = new System.Windows.Forms.Label();
            this.lblOdometerTenths = new System.Windows.Forms.Label();
            this.gaugeDirectionOfTravel = new VehicleSimulator.ucGauge();
            this.gaugeRPM = new VehicleSimulator.ucGauge();
            this.gaugeVelocity = new VehicleSimulator.ucGauge();
            this.pictureBox_Map = new VehicleSimulator.MapPictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarMapZoom)).BeginInit();
            this.grpSetVehicleLocation.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grpFuelConsumption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Map)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_ComPortSettings,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.toolStripButton_EcmTransmit,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.toolStripLabel2,
            this.toolStripButton_GpsTransmit,
            this.toolStripSeparator5,
            this.toolStripSeparator6,
            this.toolStripLabel4,
            this.toolStripButton_PTO,
            this.toolStripSeparator7,
            this.toolStripSeparator8,
            this.toolStripLabel3,
            this.toolStripButton_UnitsOfMeasure,
            this.toolStripSeparator9,
            this.toolStripSeparator10,
            this.toolStripLabel5,
            this.cboEcmProtocol,
            this.toolStripSeparator11,
            this.toolStripSeparator13,
            this.toolStripLabel6,
            this.toolStripButton_MapOnOff,
            this.toolStripSeparator12,
            this.toolStripSeparator14,
            this.toolStripDropDownButton_Routes});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(4);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(902, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_ComPortSettings
            // 
            this.toolStripButton_ComPortSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_ComPortSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ComPortSettings.Image")));
            this.toolStripButton_ComPortSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ComPortSettings.Name = "toolStripButton_ComPortSettings";
            this.toolStripButton_ComPortSettings.Size = new System.Drawing.Size(116, 22);
            this.toolStripButton_ComPortSettings.Text = "Com Port Settings...";
            this.toolStripButton_ComPortSettings.Click += new System.EventHandler(this.toolStripButton_ComPortSettings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(85, 22);
            this.toolStripLabel1.Text = "ECM Transmit:";
            // 
            // toolStripButton_EcmTransmit
            // 
            this.toolStripButton_EcmTransmit.BackColor = System.Drawing.Color.Salmon;
            this.toolStripButton_EcmTransmit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_EcmTransmit.Enabled = false;
            this.toolStripButton_EcmTransmit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton_EcmTransmit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_EcmTransmit.Image")));
            this.toolStripButton_EcmTransmit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_EcmTransmit.Name = "toolStripButton_EcmTransmit";
            this.toolStripButton_EcmTransmit.Size = new System.Drawing.Size(32, 22);
            this.toolStripButton_EcmTransmit.Text = "OFF";
            this.toolStripButton_EcmTransmit.Click += new System.EventHandler(this.toolStripButton_EcmTransmit_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(81, 22);
            this.toolStripLabel2.Text = "GPS Transmit:";
            // 
            // toolStripButton_GpsTransmit
            // 
            this.toolStripButton_GpsTransmit.BackColor = System.Drawing.Color.Salmon;
            this.toolStripButton_GpsTransmit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_GpsTransmit.Enabled = false;
            this.toolStripButton_GpsTransmit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton_GpsTransmit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_GpsTransmit.Image")));
            this.toolStripButton_GpsTransmit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_GpsTransmit.Name = "toolStripButton_GpsTransmit";
            this.toolStripButton_GpsTransmit.Size = new System.Drawing.Size(32, 22);
            this.toolStripButton_GpsTransmit.Text = "OFF";
            this.toolStripButton_GpsTransmit.Click += new System.EventHandler(this.toolStripButton_GpsTransmit_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(33, 22);
            this.toolStripLabel4.Text = "PTO:";
            // 
            // toolStripButton_PTO
            // 
            this.toolStripButton_PTO.BackColor = System.Drawing.Color.Salmon;
            this.toolStripButton_PTO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_PTO.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton_PTO.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_PTO.Image")));
            this.toolStripButton_PTO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_PTO.Name = "toolStripButton_PTO";
            this.toolStripButton_PTO.Size = new System.Drawing.Size(32, 22);
            this.toolStripButton_PTO.Text = "OFF";
            this.toolStripButton_PTO.Click += new System.EventHandler(this.toolStripButton_PTO_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabel3.Text = "Units:";
            // 
            // toolStripButton_UnitsOfMeasure
            // 
            this.toolStripButton_UnitsOfMeasure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_UnitsOfMeasure.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton_UnitsOfMeasure.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_UnitsOfMeasure.Image")));
            this.toolStripButton_UnitsOfMeasure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_UnitsOfMeasure.Name = "toolStripButton_UnitsOfMeasure";
            this.toolStripButton_UnitsOfMeasure.Size = new System.Drawing.Size(38, 22);
            this.toolStripButton_UnitsOfMeasure.Text = "MPH";
            this.toolStripButton_UnitsOfMeasure.Click += new System.EventHandler(this.toolStripButton_UnitsOfMeasure_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator9.Visible = false;
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator10.Visible = false;
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(83, 22);
            this.toolStripLabel5.Text = "ECM Protocol:";
            this.toolStripLabel5.Visible = false;
            // 
            // cboEcmProtocol
            // 
            this.cboEcmProtocol.Name = "cboEcmProtocol";
            this.cboEcmProtocol.Size = new System.Drawing.Size(75, 25);
            this.cboEcmProtocol.Visible = false;
            this.cboEcmProtocol.SelectedIndexChanged += new System.EventHandler(this.cboEcmProtocol_SelectedIndexChanged);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(34, 22);
            this.toolStripLabel6.Text = "Map:";
            // 
            // toolStripButton_MapOnOff
            // 
            this.toolStripButton_MapOnOff.BackColor = System.Drawing.Color.LightGreen;
            this.toolStripButton_MapOnOff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_MapOnOff.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton_MapOnOff.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_MapOnOff.Image")));
            this.toolStripButton_MapOnOff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_MapOnOff.Name = "toolStripButton_MapOnOff";
            this.toolStripButton_MapOnOff.Size = new System.Drawing.Size(29, 22);
            this.toolStripButton_MapOnOff.Text = "ON";
            this.toolStripButton_MapOnOff.Click += new System.EventHandler(this.toolStripButton_MapOnOff_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton_Routes
            // 
            this.toolStripDropDownButton_Routes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton_Routes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createRouteToolStripMenuItem,
            this.loadRouteToolStripMenuItem});
            this.toolStripDropDownButton_Routes.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_Routes.Image")));
            this.toolStripDropDownButton_Routes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_Routes.Name = "toolStripDropDownButton_Routes";
            this.toolStripDropDownButton_Routes.Size = new System.Drawing.Size(56, 22);
            this.toolStripDropDownButton_Routes.Text = "Routes";
            // 
            // createRouteToolStripMenuItem
            // 
            this.createRouteToolStripMenuItem.Name = "createRouteToolStripMenuItem";
            this.createRouteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.createRouteToolStripMenuItem.Text = "Create Route";
            this.createRouteToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton_CreateRoute_Click);
            // 
            // loadRouteToolStripMenuItem
            // 
            this.loadRouteToolStripMenuItem.Name = "loadRouteToolStripMenuItem";
            this.loadRouteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadRouteToolStripMenuItem.Text = "Load Route";
            this.loadRouteToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton_LoadRoute_Click);
            // 
            // trackbarMapZoom
            // 
            this.trackbarMapZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.trackbarMapZoom.LargeChange = 1;
            this.trackbarMapZoom.Location = new System.Drawing.Point(12, 320);
            this.trackbarMapZoom.Maximum = 21;
            this.trackbarMapZoom.Minimum = 1;
            this.trackbarMapZoom.Name = "trackbarMapZoom";
            this.trackbarMapZoom.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackbarMapZoom.Size = new System.Drawing.Size(45, 269);
            this.trackbarMapZoom.TabIndex = 9;
            this.trackbarMapZoom.TabStop = false;
            this.trackbarMapZoom.Value = 17;
            this.trackbarMapZoom.Scroll += new System.EventHandler(this.trackbarMapZoom_Scroll);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "2uparrow.png");
            // 
            // grpSetVehicleLocation
            // 
            this.grpSetVehicleLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSetVehicleLocation.Controls.Add(this.txtLongitude);
            this.grpSetVehicleLocation.Controls.Add(this.label4);
            this.grpSetVehicleLocation.Controls.Add(this.txtLatitude);
            this.grpSetVehicleLocation.Controls.Add(this.label10);
            this.grpSetVehicleLocation.Controls.Add(this.label8);
            this.grpSetVehicleLocation.Controls.Add(this.cboPreviousLocations);
            this.grpSetVehicleLocation.Controls.Add(this.cboCountry);
            this.grpSetVehicleLocation.Controls.Add(this.label7);
            this.grpSetVehicleLocation.Controls.Add(this.cmdResetVehicleLocationFields);
            this.grpSetVehicleLocation.Controls.Add(this.cmdSetVehicleLocation);
            this.grpSetVehicleLocation.Controls.Add(this.cboState);
            this.grpSetVehicleLocation.Controls.Add(this.label5);
            this.grpSetVehicleLocation.Controls.Add(this.txtCity);
            this.grpSetVehicleLocation.Controls.Add(this.label1);
            this.grpSetVehicleLocation.Controls.Add(this.txtStreet);
            this.grpSetVehicleLocation.Controls.Add(this.label3);
            this.grpSetVehicleLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSetVehicleLocation.Location = new System.Drawing.Point(650, 32);
            this.grpSetVehicleLocation.Name = "grpSetVehicleLocation";
            this.grpSetVehicleLocation.Size = new System.Drawing.Size(236, 274);
            this.grpSetVehicleLocation.TabIndex = 1;
            this.grpSetVehicleLocation.TabStop = false;
            this.grpSetVehicleLocation.Text = "Set Vehicle Location";
            // 
            // txtLongitude
            // 
            this.txtLongitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLongitude.Location = new System.Drawing.Point(72, 168);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(158, 20);
            this.txtLongitude.TabIndex = 15;
            this.txtLongitude.TabStop = false;
            this.txtLongitude.TextChanged += new System.EventHandler(this.SetVehicleLatitudeLongitude_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Longitude:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtLatitude
            // 
            this.txtLatitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLatitude.Location = new System.Drawing.Point(72, 142);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(158, 20);
            this.txtLatitude.TabIndex = 13;
            this.txtLatitude.TabStop = false;
            this.txtLatitude.TextChanged += new System.EventHandler(this.SetVehicleLatitudeLongitude_TextChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "Latitude:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Previous Locations:";
            // 
            // cboPreviousLocations
            // 
            this.cboPreviousLocations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPreviousLocations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreviousLocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPreviousLocations.FormattingEnabled = true;
            this.cboPreviousLocations.Location = new System.Drawing.Point(9, 243);
            this.cboPreviousLocations.Name = "cboPreviousLocations";
            this.cboPreviousLocations.Size = new System.Drawing.Size(221, 21);
            this.cboPreviousLocations.TabIndex = 11;
            this.cboPreviousLocations.SelectedIndexChanged += new System.EventHandler(this.cboPreviousLocations_SelectedIndexChanged);
            // 
            // cboCountry
            // 
            this.cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Items.AddRange(new object[] {
            "Canada",
            "U.S.A."});
            this.cboCountry.Location = new System.Drawing.Point(72, 102);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(158, 21);
            this.cboCountry.TabIndex = 7;
            this.cboCountry.SelectedIndexChanged += new System.EventHandler(this.cboCountry_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Country:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmdResetVehicleLocationFields
            // 
            this.cmdResetVehicleLocationFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdResetVehicleLocationFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdResetVehicleLocationFields.Location = new System.Drawing.Point(9, 194);
            this.cmdResetVehicleLocationFields.Name = "cmdResetVehicleLocationFields";
            this.cmdResetVehicleLocationFields.Size = new System.Drawing.Size(75, 23);
            this.cmdResetVehicleLocationFields.TabIndex = 8;
            this.cmdResetVehicleLocationFields.Text = "Reset";
            this.cmdResetVehicleLocationFields.UseVisualStyleBackColor = true;
            this.cmdResetVehicleLocationFields.Click += new System.EventHandler(this.cmdResetVehicleLocationFields_Click);
            // 
            // cmdSetVehicleLocation
            // 
            this.cmdSetVehicleLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSetVehicleLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSetVehicleLocation.Location = new System.Drawing.Point(155, 194);
            this.cmdSetVehicleLocation.Name = "cmdSetVehicleLocation";
            this.cmdSetVehicleLocation.Size = new System.Drawing.Size(75, 23);
            this.cmdSetVehicleLocation.TabIndex = 9;
            this.cmdSetVehicleLocation.Text = "Set";
            this.cmdSetVehicleLocation.UseVisualStyleBackColor = true;
            this.cmdSetVehicleLocation.Click += new System.EventHandler(this.cmdSetVehicleLocation_Click);
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.Enabled = false;
            this.cboState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(72, 74);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(66, 21);
            this.cboState.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "State:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.Location = new System.Drawing.Point(72, 48);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(158, 20);
            this.txtCity.TabIndex = 3;
            this.txtCity.TabStop = false;
            this.txtCity.TextChanged += new System.EventHandler(this.SetVehicleLocationField_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "City:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtStreet
            // 
            this.txtStreet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreet.Location = new System.Drawing.Point(72, 22);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(158, 20);
            this.txtStreet.TabIndex = 1;
            this.txtStreet.TabStop = false;
            this.txtStreet.TextChanged += new System.EventHandler(this.SetVehicleLocationField_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Street:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblVelocityUnits
            // 
            this.lblVelocityUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVelocityUnits.Location = new System.Drawing.Point(87, 169);
            this.lblVelocityUnits.Name = "lblVelocityUnits";
            this.lblVelocityUnits.Size = new System.Drawing.Size(53, 23);
            this.lblVelocityUnits.TabIndex = 28;
            this.lblVelocityUnits.Text = "MPH";
            this.lblVelocityUnits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(338, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 23);
            this.label2.TabIndex = 30;
            this.label2.Text = "RPM";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(467, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Direction of Travel:";
            // 
            // txtDirectionOfTravel
            // 
            this.txtDirectionOfTravel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectionOfTravel.Location = new System.Drawing.Point(588, 26);
            this.txtDirectionOfTravel.Name = "txtDirectionOfTravel";
            this.txtDirectionOfTravel.Size = new System.Drawing.Size(53, 20);
            this.txtDirectionOfTravel.TabIndex = 39;
            this.txtDirectionOfTravel.TabStop = false;
            this.txtDirectionOfTravel.Text = "0";
            this.txtDirectionOfTravel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDirectionOfTravel.TextChanged += new System.EventHandler(this.txtDirectionOfTravel_TextChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(80, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 19);
            this.label9.TabIndex = 40;
            this.label9.Text = "Odometer:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblOdometerUnits
            // 
            this.lblOdometerUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOdometerUnits.Location = new System.Drawing.Point(327, 223);
            this.lblOdometerUnits.Name = "lblOdometerUnits";
            this.lblOdometerUnits.Size = new System.Drawing.Size(116, 19);
            this.lblOdometerUnits.TabIndex = 42;
            this.lblOdometerUnits.Text = "Miles";
            // 
            // lblFloater
            // 
            this.lblFloater.AutoSize = true;
            this.lblFloater.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblFloater.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFloater.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFloater.Location = new System.Drawing.Point(594, 751);
            this.lblFloater.Name = "lblFloater";
            this.lblFloater.Size = new System.Drawing.Size(0, 20);
            this.lblFloater.TabIndex = 43;
            this.lblFloater.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_PortsStatus,
            this.toolStripStatusLabel_LocationChanged});
            this.statusStrip1.Location = new System.Drawing.Point(0, 641);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(902, 22);
            this.statusStrip1.TabIndex = 44;
            // 
            // toolStripStatusLabel_PortsStatus
            // 
            this.toolStripStatusLabel_PortsStatus.Name = "toolStripStatusLabel_PortsStatus";
            this.toolStripStatusLabel_PortsStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel_LocationChanged
            // 
            this.toolStripStatusLabel_LocationChanged.Name = "toolStripStatusLabel_LocationChanged";
            this.toolStripStatusLabel_LocationChanged.Size = new System.Drawing.Size(0, 17);
            // 
            // cmdRapidDecel
            // 
            this.cmdRapidDecel.Enabled = false;
            this.cmdRapidDecel.Location = new System.Drawing.Point(29, 249);
            this.cmdRapidDecel.Name = "cmdRapidDecel";
            this.cmdRapidDecel.Size = new System.Drawing.Size(171, 33);
            this.cmdRapidDecel.TabIndex = 45;
            this.cmdRapidDecel.Text = "Rapid Deceleration";
            this.cmdRapidDecel.UseVisualStyleBackColor = true;
            this.cmdRapidDecel.Click += new System.EventHandler(this.cmdRapidDecel_Click);
            // 
            // grpFuelConsumption
            // 
            this.grpFuelConsumption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFuelConsumption.Controls.Add(this.lblMPG);
            this.grpFuelConsumption.Controls.Add(this.lblMpgLabel);
            this.grpFuelConsumption.Controls.Add(this.lblGPH);
            this.grpFuelConsumption.Controls.Add(this.lblGphLabel);
            this.grpFuelConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFuelConsumption.Location = new System.Drawing.Point(487, 219);
            this.grpFuelConsumption.Name = "grpFuelConsumption";
            this.grpFuelConsumption.Size = new System.Drawing.Size(154, 89);
            this.grpFuelConsumption.TabIndex = 46;
            this.grpFuelConsumption.TabStop = false;
            this.grpFuelConsumption.Text = "Fuel Consumption";
            // 
            // lblMPG
            // 
            this.lblMPG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMPG.Font = new System.Drawing.Font("Courier New", 12F);
            this.lblMPG.Location = new System.Drawing.Point(60, 57);
            this.lblMPG.Name = "lblMPG";
            this.lblMPG.Size = new System.Drawing.Size(83, 20);
            this.lblMPG.TabIndex = 59;
            this.lblMPG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMpgLabel
            // 
            this.lblMpgLabel.Location = new System.Drawing.Point(6, 59);
            this.lblMpgLabel.Name = "lblMpgLabel";
            this.lblMpgLabel.Size = new System.Drawing.Size(48, 16);
            this.lblMpgLabel.TabIndex = 1;
            this.lblMpgLabel.Text = "MPG:";
            this.lblMpgLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblGPH
            // 
            this.lblGPH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGPH.Font = new System.Drawing.Font("Courier New", 12F);
            this.lblGPH.Location = new System.Drawing.Point(60, 29);
            this.lblGPH.Name = "lblGPH";
            this.lblGPH.Size = new System.Drawing.Size(83, 20);
            this.lblGPH.TabIndex = 58;
            this.lblGPH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGphLabel
            // 
            this.lblGphLabel.Location = new System.Drawing.Point(6, 31);
            this.lblGphLabel.Name = "lblGphLabel";
            this.lblGphLabel.Size = new System.Drawing.Size(48, 16);
            this.lblGphLabel.TabIndex = 0;
            this.lblGphLabel.Text = "GPH:";
            this.lblGphLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timerUpdateDisplay
            // 
            this.timerUpdateDisplay.Interval = 1000;
            this.timerUpdateDisplay.Tick += new System.EventHandler(this.timerUpdateDisplay_Tick);
            // 
            // lblBingCopyrightNotice
            // 
            this.lblBingCopyrightNotice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBingCopyrightNotice.Location = new System.Drawing.Point(57, 611);
            this.lblBingCopyrightNotice.Name = "lblBingCopyrightNotice";
            this.lblBingCopyrightNotice.Size = new System.Drawing.Size(823, 30);
            this.lblBingCopyrightNotice.TabIndex = 48;
            // 
            // timerSerialPortMonitor
            // 
            this.timerSerialPortMonitor.Interval = 1000;
            this.timerSerialPortMonitor.Tick += new System.EventHandler(this.timerSerialPortMonitor_Tick);
            // 
            // cmdCycleStartStop
            // 
            this.cmdCycleStartStop.Location = new System.Drawing.Point(2, 217);
            this.cmdCycleStartStop.Name = "cmdCycleStartStop";
            this.cmdCycleStartStop.Size = new System.Drawing.Size(74, 23);
            this.cmdCycleStartStop.TabIndex = 53;
            this.cmdCycleStartStop.Text = "Cycle";
            this.cmdCycleStartStop.UseVisualStyleBackColor = true;
            this.cmdCycleStartStop.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmdCycleStartStop_MouseClick);
            this.cmdCycleStartStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cmdCycleStartStop_MouseUp);
            // 
            // lblVelocity
            // 
            this.lblVelocity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVelocity.Font = new System.Drawing.Font("Courier New", 12F);
            this.lblVelocity.Location = new System.Drawing.Point(86, 188);
            this.lblVelocity.Name = "lblVelocity";
            this.lblVelocity.Size = new System.Drawing.Size(53, 20);
            this.lblVelocity.TabIndex = 54;
            this.lblVelocity.Text = "0";
            this.lblVelocity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVelocity.DoubleClick += new System.EventHandler(this.lblVelocity_DoubleClick);
            // 
            // lblRPM
            // 
            this.lblRPM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRPM.Font = new System.Drawing.Font("Courier New", 12F);
            this.lblRPM.Location = new System.Drawing.Point(338, 188);
            this.lblRPM.Name = "lblRPM";
            this.lblRPM.Size = new System.Drawing.Size(53, 20);
            this.lblRPM.TabIndex = 55;
            this.lblRPM.Text = "0";
            this.lblRPM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRPM.DoubleClick += new System.EventHandler(this.lblRPM_DoubleClick);
            // 
            // lblOdometerWhole
            // 
            this.lblOdometerWhole.BackColor = System.Drawing.Color.Black;
            this.lblOdometerWhole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOdometerWhole.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.lblOdometerWhole.ForeColor = System.Drawing.Color.White;
            this.lblOdometerWhole.Location = new System.Drawing.Point(194, 219);
            this.lblOdometerWhole.Name = "lblOdometerWhole";
            this.lblOdometerWhole.Size = new System.Drawing.Size(112, 26);
            this.lblOdometerWhole.TabIndex = 56;
            this.lblOdometerWhole.Text = "0";
            this.lblOdometerWhole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblOdometerWhole.DoubleClick += new System.EventHandler(this.lblOdometerWhole_DoubleClick);
            // 
            // lblOdometerTenths
            // 
            this.lblOdometerTenths.BackColor = System.Drawing.Color.White;
            this.lblOdometerTenths.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOdometerTenths.Font = new System.Drawing.Font("Courier New", 12F);
            this.lblOdometerTenths.Location = new System.Drawing.Point(305, 219);
            this.lblOdometerTenths.Name = "lblOdometerTenths";
            this.lblOdometerTenths.Size = new System.Drawing.Size(16, 26);
            this.lblOdometerTenths.TabIndex = 57;
            this.lblOdometerTenths.Text = "0";
            this.lblOdometerTenths.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gaugeDirectionOfTravel
            // 
            this.gaugeDirectionOfTravel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gaugeDirectionOfTravel.BaseArcColor = System.Drawing.Color.Gray;
            this.gaugeDirectionOfTravel.BaseArcRadius = 55;
            this.gaugeDirectionOfTravel.BaseArcStart = -90;
            this.gaugeDirectionOfTravel.BaseArcSweep = 360;
            this.gaugeDirectionOfTravel.BaseArcWidth = 1;
            this.gaugeDirectionOfTravel.Cap_Idx = ((byte)(1));
            this.gaugeDirectionOfTravel.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.gaugeDirectionOfTravel.CapPosition = new System.Drawing.Point(10, 10);
            this.gaugeDirectionOfTravel.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.gaugeDirectionOfTravel.CapsText = new string[] {
        "",
        "",
        "",
        "",
        ""};
            this.gaugeDirectionOfTravel.CapText = "";
            this.gaugeDirectionOfTravel.Center = new System.Drawing.Point(85, 85);
            this.gaugeDirectionOfTravel.Location = new System.Drawing.Point(470, 38);
            this.gaugeDirectionOfTravel.MaxValue = 359F;
            this.gaugeDirectionOfTravel.MinValue = 0F;
            this.gaugeDirectionOfTravel.Name = "gaugeDirectionOfTravel";
            this.gaugeDirectionOfTravel.NeedleColor1 = VehicleSimulator.ucGauge.NeedleColorEnum.Blue;
            this.gaugeDirectionOfTravel.NeedleColor2 = System.Drawing.Color.LightSteelBlue;
            this.gaugeDirectionOfTravel.NeedleRadius = 57;
            this.gaugeDirectionOfTravel.NeedleType = 0;
            this.gaugeDirectionOfTravel.NeedleWidth = 8;
            this.gaugeDirectionOfTravel.Range_Idx = ((byte)(0));
            this.gaugeDirectionOfTravel.RangeColor = System.Drawing.Color.CadetBlue;
            this.gaugeDirectionOfTravel.RangeEnabled = true;
            this.gaugeDirectionOfTravel.RangeEndValue = 360F;
            this.gaugeDirectionOfTravel.RangeInnerRadius = 26;
            this.gaugeDirectionOfTravel.RangeOuterRadius = 55;
            this.gaugeDirectionOfTravel.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.CadetBlue,
        System.Drawing.Color.Red,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.gaugeDirectionOfTravel.RangesEnabled = new bool[] {
        true,
        false,
        false,
        false,
        false};
            this.gaugeDirectionOfTravel.RangesEndValue = new float[] {
        360F,
        400F,
        0F,
        0F,
        0F};
            this.gaugeDirectionOfTravel.RangesInnerRadius = new int[] {
        26,
        70,
        70,
        70,
        70};
            this.gaugeDirectionOfTravel.RangesOuterRadius = new int[] {
        55,
        80,
        80,
        80,
        80};
            this.gaugeDirectionOfTravel.RangesStartValue = new float[] {
        0F,
        300F,
        0F,
        0F,
        0F};
            this.gaugeDirectionOfTravel.RangeStartValue = 0F;
            this.gaugeDirectionOfTravel.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.gaugeDirectionOfTravel.ScaleLinesInterInnerRadius = 55;
            this.gaugeDirectionOfTravel.ScaleLinesInterOuterRadius = 60;
            this.gaugeDirectionOfTravel.ScaleLinesInterWidth = 1;
            this.gaugeDirectionOfTravel.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.gaugeDirectionOfTravel.ScaleLinesMajorInnerRadius = 55;
            this.gaugeDirectionOfTravel.ScaleLinesMajorOuterRadius = 60;
            this.gaugeDirectionOfTravel.ScaleLinesMajorStepValue = 45F;
            this.gaugeDirectionOfTravel.ScaleLinesMajorWidth = 2;
            this.gaugeDirectionOfTravel.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.gaugeDirectionOfTravel.ScaleLinesMinorInnerRadius = 55;
            this.gaugeDirectionOfTravel.ScaleLinesMinorNumOf = 5;
            this.gaugeDirectionOfTravel.ScaleLinesMinorOuterRadius = 60;
            this.gaugeDirectionOfTravel.ScaleLinesMinorWidth = 1;
            this.gaugeDirectionOfTravel.ScaleNumbersColor = System.Drawing.Color.Black;
            this.gaugeDirectionOfTravel.ScaleNumbersFormat = null;
            this.gaugeDirectionOfTravel.ScaleNumbersRadius = 72;
            this.gaugeDirectionOfTravel.ScaleNumbersRotation = 0;
            this.gaugeDirectionOfTravel.ScaleNumbersStartScaleLine = 0;
            this.gaugeDirectionOfTravel.ScaleNumbersStepScaleLines = 1;
            this.gaugeDirectionOfTravel.Size = new System.Drawing.Size(171, 173);
            this.gaugeDirectionOfTravel.TabIndex = 26;
            this.gaugeDirectionOfTravel.TabStop = false;
            this.gaugeDirectionOfTravel.Text = "Direction Of Travel";
            this.gaugeDirectionOfTravel.Value = 0F;
            this.gaugeDirectionOfTravel.OnMouseDownValueSelection += new VehicleSimulator.ucGauge.MouseDownValueSelectionHandler(this.gaugeDirectionOfTravel_OnMouseDownValueSelection);
            this.gaugeDirectionOfTravel.OnMouseValueSelection += new VehicleSimulator.ucGauge.MouseValueSelectionHandler(this.gaugeDirectionOfTravel_OnMouseValueSelection);
            this.gaugeDirectionOfTravel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gaugeDirectionOfTravel_MouseUp);
            // 
            // gaugeRPM
            // 
            this.gaugeRPM.BaseArcColor = System.Drawing.Color.Gray;
            this.gaugeRPM.BaseArcRadius = 80;
            this.gaugeRPM.BaseArcStart = 135;
            this.gaugeRPM.BaseArcSweep = 270;
            this.gaugeRPM.BaseArcWidth = 2;
            this.gaugeRPM.Cap_Idx = ((byte)(0));
            this.gaugeRPM.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.gaugeRPM.CapPosition = new System.Drawing.Point(88, 150);
            this.gaugeRPM.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(88, 150),
        new System.Drawing.Point(88, 170),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.gaugeRPM.CapsText = new string[] {
        "",
        "",
        "",
        "",
        ""};
            this.gaugeRPM.CapText = "";
            this.gaugeRPM.Center = new System.Drawing.Point(110, 100);
            this.gaugeRPM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gaugeRPM.Location = new System.Drawing.Point(254, 32);
            this.gaugeRPM.MaxValue = 2400F;
            this.gaugeRPM.MinValue = 0F;
            this.gaugeRPM.Name = "gaugeRPM";
            this.gaugeRPM.NeedleColor1 = VehicleSimulator.ucGauge.NeedleColorEnum.Gray;
            this.gaugeRPM.NeedleColor2 = System.Drawing.Color.DimGray;
            this.gaugeRPM.NeedleRadius = 80;
            this.gaugeRPM.NeedleType = 0;
            this.gaugeRPM.NeedleWidth = 4;
            this.gaugeRPM.Range_Idx = ((byte)(1));
            this.gaugeRPM.RangeColor = System.Drawing.Color.Yellow;
            this.gaugeRPM.RangeEnabled = true;
            this.gaugeRPM.RangeEndValue = 1400F;
            this.gaugeRPM.RangeInnerRadius = 70;
            this.gaugeRPM.RangeOuterRadius = 80;
            this.gaugeRPM.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.Yellow,
        System.Drawing.Color.Red,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.gaugeRPM.RangesEnabled = new bool[] {
        true,
        true,
        true,
        false,
        false};
            this.gaugeRPM.RangesEndValue = new float[] {
        800F,
        1400F,
        2400F,
        0F,
        0F};
            this.gaugeRPM.RangesInnerRadius = new int[] {
        70,
        70,
        70,
        70,
        70};
            this.gaugeRPM.RangesOuterRadius = new int[] {
        80,
        80,
        80,
        80,
        80};
            this.gaugeRPM.RangesStartValue = new float[] {
        0F,
        800F,
        1400F,
        0F,
        0F};
            this.gaugeRPM.RangeStartValue = 800F;
            this.gaugeRPM.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.gaugeRPM.ScaleLinesInterInnerRadius = 73;
            this.gaugeRPM.ScaleLinesInterOuterRadius = 80;
            this.gaugeRPM.ScaleLinesInterWidth = 0;
            this.gaugeRPM.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.gaugeRPM.ScaleLinesMajorInnerRadius = 70;
            this.gaugeRPM.ScaleLinesMajorOuterRadius = 80;
            this.gaugeRPM.ScaleLinesMajorStepValue = 200F;
            this.gaugeRPM.ScaleLinesMajorWidth = 0;
            this.gaugeRPM.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.gaugeRPM.ScaleLinesMinorInnerRadius = 75;
            this.gaugeRPM.ScaleLinesMinorNumOf = 4;
            this.gaugeRPM.ScaleLinesMinorOuterRadius = 80;
            this.gaugeRPM.ScaleLinesMinorWidth = 0;
            this.gaugeRPM.ScaleNumbersColor = System.Drawing.Color.Black;
            this.gaugeRPM.ScaleNumbersFormat = null;
            this.gaugeRPM.ScaleNumbersRadius = 95;
            this.gaugeRPM.ScaleNumbersRotation = 0;
            this.gaugeRPM.ScaleNumbersStartScaleLine = 0;
            this.gaugeRPM.ScaleNumbersStepScaleLines = 1;
            this.gaugeRPM.Size = new System.Drawing.Size(220, 198);
            this.gaugeRPM.TabIndex = 25;
            this.gaugeRPM.TabStop = false;
            this.gaugeRPM.Text = "RPM";
            this.gaugeRPM.Value = 0F;
            this.gaugeRPM.OnMouseDownValueSelection += new VehicleSimulator.ucGauge.MouseDownValueSelectionHandler(this.gaugeRPM_OnMouseDownValueSelection);
            this.gaugeRPM.OnMouseValueSelection += new VehicleSimulator.ucGauge.MouseValueSelectionHandler(this.gaugeRPM_OnMouseValueSelection);
            this.gaugeRPM.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gaugeRPM_MouseUp);
            // 
            // gaugeVelocity
            // 
            this.gaugeVelocity.BaseArcColor = System.Drawing.Color.Gray;
            this.gaugeVelocity.BaseArcRadius = 80;
            this.gaugeVelocity.BaseArcStart = 135;
            this.gaugeVelocity.BaseArcSweep = 270;
            this.gaugeVelocity.BaseArcWidth = 2;
            this.gaugeVelocity.Cap_Idx = ((byte)(0));
            this.gaugeVelocity.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.gaugeVelocity.CapPosition = new System.Drawing.Point(88, 150);
            this.gaugeVelocity.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(88, 150),
        new System.Drawing.Point(88, 170),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.gaugeVelocity.CapsText = new string[] {
        "",
        "",
        "",
        "",
        ""};
            this.gaugeVelocity.CapText = "";
            this.gaugeVelocity.Center = new System.Drawing.Point(100, 100);
            this.gaugeVelocity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gaugeVelocity.Location = new System.Drawing.Point(12, 32);
            this.gaugeVelocity.MaxValue = 120F;
            this.gaugeVelocity.MinValue = 0F;
            this.gaugeVelocity.Name = "gaugeVelocity";
            this.gaugeVelocity.NeedleColor1 = VehicleSimulator.ucGauge.NeedleColorEnum.Gray;
            this.gaugeVelocity.NeedleColor2 = System.Drawing.Color.DimGray;
            this.gaugeVelocity.NeedleRadius = 80;
            this.gaugeVelocity.NeedleType = 0;
            this.gaugeVelocity.NeedleWidth = 4;
            this.gaugeVelocity.Range_Idx = ((byte)(0));
            this.gaugeVelocity.RangeColor = System.Drawing.Color.LightGreen;
            this.gaugeVelocity.RangeEnabled = true;
            this.gaugeVelocity.RangeEndValue = 40F;
            this.gaugeVelocity.RangeInnerRadius = 70;
            this.gaugeVelocity.RangeOuterRadius = 80;
            this.gaugeVelocity.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.Yellow,
        System.Drawing.Color.Red,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.gaugeVelocity.RangesEnabled = new bool[] {
        true,
        true,
        true,
        false,
        false};
            this.gaugeVelocity.RangesEndValue = new float[] {
        40F,
        70F,
        120F,
        0F,
        0F};
            this.gaugeVelocity.RangesInnerRadius = new int[] {
        70,
        70,
        70,
        70,
        70};
            this.gaugeVelocity.RangesOuterRadius = new int[] {
        80,
        80,
        80,
        80,
        80};
            this.gaugeVelocity.RangesStartValue = new float[] {
        0F,
        40F,
        70F,
        0F,
        0F};
            this.gaugeVelocity.RangeStartValue = 0F;
            this.gaugeVelocity.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.gaugeVelocity.ScaleLinesInterInnerRadius = 73;
            this.gaugeVelocity.ScaleLinesInterOuterRadius = 80;
            this.gaugeVelocity.ScaleLinesInterWidth = 1;
            this.gaugeVelocity.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.gaugeVelocity.ScaleLinesMajorInnerRadius = 70;
            this.gaugeVelocity.ScaleLinesMajorOuterRadius = 80;
            this.gaugeVelocity.ScaleLinesMajorStepValue = 10F;
            this.gaugeVelocity.ScaleLinesMajorWidth = 2;
            this.gaugeVelocity.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.gaugeVelocity.ScaleLinesMinorInnerRadius = 75;
            this.gaugeVelocity.ScaleLinesMinorNumOf = 4;
            this.gaugeVelocity.ScaleLinesMinorOuterRadius = 80;
            this.gaugeVelocity.ScaleLinesMinorWidth = 1;
            this.gaugeVelocity.ScaleNumbersColor = System.Drawing.Color.Black;
            this.gaugeVelocity.ScaleNumbersFormat = null;
            this.gaugeVelocity.ScaleNumbersRadius = 95;
            this.gaugeVelocity.ScaleNumbersRotation = 0;
            this.gaugeVelocity.ScaleNumbersStartScaleLine = 0;
            this.gaugeVelocity.ScaleNumbersStepScaleLines = 1;
            this.gaugeVelocity.Size = new System.Drawing.Size(209, 179);
            this.gaugeVelocity.TabIndex = 24;
            this.gaugeVelocity.TabStop = false;
            this.gaugeVelocity.Text = "SPEED";
            this.gaugeVelocity.Value = 0F;
            this.gaugeVelocity.OnMouseDownValueSelection += new VehicleSimulator.ucGauge.MouseDownValueSelectionHandler(this.gaugeVelocity_OnMouseDownValueSelection);
            this.gaugeVelocity.OnMouseValueSelection += new VehicleSimulator.ucGauge.MouseValueSelectionHandler(this.gaugeVelocity_OnMouseValueSelection);
            this.gaugeVelocity.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gaugeVelocity_MouseUp);
            // 
            // pictureBox_Map
            // 
            this.pictureBox_Map.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Map.Location = new System.Drawing.Point(57, 320);
            this.pictureBox_Map.MaximumSize = new System.Drawing.Size(880, 834);
            this.pictureBox_Map.MinimumSize = new System.Drawing.Size(80, 80);
            this.pictureBox_Map.Name = "pictureBox_Map";
            this.pictureBox_Map.Size = new System.Drawing.Size(823, 288);
            this.pictureBox_Map.TabIndex = 2;
            this.pictureBox_Map.TabStop = false;
            this.pictureBox_Map.VehicleImage = null;
            this.pictureBox_Map.VehicleSymbolOrientation = 0;
            this.pictureBox_Map.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBox_Map_LoadCompleted);
            this.pictureBox_Map.Click += new System.EventHandler(this.pictureBox_Map_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 663);
            this.Controls.Add(this.lblOdometerTenths);
            this.Controls.Add(this.lblOdometerWhole);
            this.Controls.Add(this.lblRPM);
            this.Controls.Add(this.lblVelocity);
            this.Controls.Add(this.cmdCycleStartStop);
            this.Controls.Add(this.lblBingCopyrightNotice);
            this.Controls.Add(this.grpFuelConsumption);
            this.Controls.Add(this.cmdRapidDecel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblFloater);
            this.Controls.Add(this.lblOdometerUnits);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDirectionOfTravel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblVelocityUnits);
            this.Controls.Add(this.gaugeDirectionOfTravel);
            this.Controls.Add(this.gaugeRPM);
            this.Controls.Add(this.gaugeVelocity);
            this.Controls.Add(this.trackbarMapZoom);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox_Map);
            this.Controls.Add(this.grpSetVehicleLocation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(918, 491);
            this.Name = "frmMain";
            this.Text = "Vehicle Simulator";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarMapZoom)).EndInit();
            this.grpSetVehicleLocation.ResumeLayout(false);
            this.grpSetVehicleLocation.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpFuelConsumption.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Map)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_ComPortSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton_EcmTransmit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButton_GpsTransmit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButton_UnitsOfMeasure;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton toolStripButton_PTO;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private MapPictureBox pictureBox_Map;
        private System.Windows.Forms.TrackBar trackbarMapZoom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripComboBox cboEcmProtocol;
        private ucGauge gaugeDirectionOfTravel;
        private ucGauge gaugeRPM;
        private ucGauge gaugeVelocity;
        private System.Windows.Forms.GroupBox grpSetVehicleLocation;
        private System.Windows.Forms.Button cmdResetVehicleLocationFields;
        private System.Windows.Forms.Button cmdSetVehicleLocation;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblVelocityUnits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDirectionOfTravel;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboPreviousLocations;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblOdometerUnits;
        private System.Windows.Forms.Label lblFloater;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_LocationChanged;
        private System.Windows.Forms.Button cmdRapidDecel;
        private System.Windows.Forms.GroupBox grpFuelConsumption;
        private System.Windows.Forms.Label lblMpgLabel;
        private System.Windows.Forms.Label lblGphLabel;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_Routes;
        private System.Windows.Forms.ToolStripMenuItem createRouteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadRouteToolStripMenuItem;
        private System.Windows.Forms.Timer timerUpdateDisplay;
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripButton toolStripButton_MapOnOff;
        private System.Windows.Forms.Label lblBingCopyrightNotice;
        private System.Windows.Forms.Timer timerSerialPortMonitor;
        private System.Windows.Forms.Button cmdCycleStartStop;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_PortsStatus;
        private System.Windows.Forms.Label lblVelocity;
        private System.Windows.Forms.Label lblRPM;
        private System.Windows.Forms.Label lblOdometerWhole;
        private System.Windows.Forms.Label lblOdometerTenths;
        private System.Windows.Forms.Label lblGPH;
        private System.Windows.Forms.Label lblMPG;


    }
}


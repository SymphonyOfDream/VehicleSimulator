namespace VehicleSimulator
{
    partial class frmCreateRoute
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtRouteName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpWayPointDetails = new System.Windows.Forms.GroupBox();
            this.txtWayPointDetails_DepartRPM = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtWayPointDetails_DepartVelocity = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtWayPointDetails_ArrivePause = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtWayPointDetails_ArriveRPM = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtWayPointDetails_ArriveVelocity = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lstWayPoints = new System.Windows.Forms.ListBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdResetNewWayPointFields = new System.Windows.Forms.Button();
            this.cmdAddNewWayPoint = new System.Windows.Forms.Button();
            this.grpNewWayPointDetails = new System.Windows.Forms.GroupBox();
            this.txtLeaveSetRPM = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLeaveSetVelocity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtArrivePauseBeforeContinuing = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtArriveSetRPM = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtArriveSetVelocity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.grpWayPointDetails.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpNewWayPointDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(325, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Route Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtRouteName
            // 
            this.txtRouteName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRouteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRouteName.Location = new System.Drawing.Point(483, 14);
            this.txtRouteName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRouteName.MaxLength = 64;
            this.txtRouteName.Name = "txtRouteName";
            this.txtRouteName.Size = new System.Drawing.Size(386, 31);
            this.txtRouteName.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.grpWayPointDetails);
            this.groupBox1.Controls.Add(this.lstWayPoints);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 227);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(849, 239);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Way Points In Order";
            // 
            // grpWayPointDetails
            // 
            this.grpWayPointDetails.Controls.Add(this.txtWayPointDetails_DepartRPM);
            this.grpWayPointDetails.Controls.Add(this.label16);
            this.grpWayPointDetails.Controls.Add(this.txtWayPointDetails_DepartVelocity);
            this.grpWayPointDetails.Controls.Add(this.label17);
            this.grpWayPointDetails.Controls.Add(this.label15);
            this.grpWayPointDetails.Controls.Add(this.txtWayPointDetails_ArrivePause);
            this.grpWayPointDetails.Controls.Add(this.label12);
            this.grpWayPointDetails.Controls.Add(this.txtWayPointDetails_ArriveRPM);
            this.grpWayPointDetails.Controls.Add(this.label13);
            this.grpWayPointDetails.Controls.Add(this.txtWayPointDetails_ArriveVelocity);
            this.grpWayPointDetails.Controls.Add(this.label14);
            this.grpWayPointDetails.Controls.Add(this.label11);
            this.grpWayPointDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpWayPointDetails.Location = new System.Drawing.Point(642, 27);
            this.grpWayPointDetails.Name = "grpWayPointDetails";
            this.grpWayPointDetails.Size = new System.Drawing.Size(200, 204);
            this.grpWayPointDetails.TabIndex = 1;
            this.grpWayPointDetails.TabStop = false;
            this.grpWayPointDetails.Text = "Way Point Details";
            // 
            // txtWayPointDetails_DepartRPM
            // 
            this.txtWayPointDetails_DepartRPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWayPointDetails_DepartRPM.Location = new System.Drawing.Point(75, 162);
            this.txtWayPointDetails_DepartRPM.Name = "txtWayPointDetails_DepartRPM";
            this.txtWayPointDetails_DepartRPM.ReadOnly = true;
            this.txtWayPointDetails_DepartRPM.Size = new System.Drawing.Size(119, 20);
            this.txtWayPointDetails_DepartRPM.TabIndex = 11;
            this.txtWayPointDetails_DepartRPM.TabStop = false;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 165);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 20);
            this.label16.TabIndex = 10;
            this.label16.Text = "RPM:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtWayPointDetails_DepartVelocity
            // 
            this.txtWayPointDetails_DepartVelocity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWayPointDetails_DepartVelocity.Location = new System.Drawing.Point(75, 136);
            this.txtWayPointDetails_DepartVelocity.Name = "txtWayPointDetails_DepartVelocity";
            this.txtWayPointDetails_DepartVelocity.ReadOnly = true;
            this.txtWayPointDetails_DepartVelocity.Size = new System.Drawing.Size(119, 20);
            this.txtWayPointDetails_DepartVelocity.TabIndex = 9;
            this.txtWayPointDetails_DepartVelocity.TabStop = false;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 139);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 20);
            this.label17.TabIndex = 8;
            this.label17.Text = "Velocity:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 121);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 20);
            this.label15.TabIndex = 7;
            this.label15.Text = "Depart";
            // 
            // txtWayPointDetails_ArrivePause
            // 
            this.txtWayPointDetails_ArrivePause.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWayPointDetails_ArrivePause.Location = new System.Drawing.Point(75, 86);
            this.txtWayPointDetails_ArrivePause.Name = "txtWayPointDetails_ArrivePause";
            this.txtWayPointDetails_ArrivePause.ReadOnly = true;
            this.txtWayPointDetails_ArrivePause.Size = new System.Drawing.Size(119, 20);
            this.txtWayPointDetails_ArrivePause.TabIndex = 6;
            this.txtWayPointDetails_ArrivePause.TabStop = false;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 20);
            this.label12.TabIndex = 5;
            this.label12.Text = "Pause:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtWayPointDetails_ArriveRPM
            // 
            this.txtWayPointDetails_ArriveRPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWayPointDetails_ArriveRPM.Location = new System.Drawing.Point(75, 61);
            this.txtWayPointDetails_ArriveRPM.Name = "txtWayPointDetails_ArriveRPM";
            this.txtWayPointDetails_ArriveRPM.ReadOnly = true;
            this.txtWayPointDetails_ArriveRPM.Size = new System.Drawing.Size(119, 20);
            this.txtWayPointDetails_ArriveRPM.TabIndex = 4;
            this.txtWayPointDetails_ArriveRPM.TabStop = false;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 20);
            this.label13.TabIndex = 3;
            this.label13.Text = "RPM:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtWayPointDetails_ArriveVelocity
            // 
            this.txtWayPointDetails_ArriveVelocity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWayPointDetails_ArriveVelocity.Location = new System.Drawing.Point(75, 35);
            this.txtWayPointDetails_ArriveVelocity.Name = "txtWayPointDetails_ArriveVelocity";
            this.txtWayPointDetails_ArriveVelocity.ReadOnly = true;
            this.txtWayPointDetails_ArriveVelocity.Size = new System.Drawing.Size(119, 20);
            this.txtWayPointDetails_ArriveVelocity.TabIndex = 2;
            this.txtWayPointDetails_ArriveVelocity.TabStop = false;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 20);
            this.label14.TabIndex = 1;
            this.label14.Text = "Velocity:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Arrive";
            // 
            // lstWayPoints
            // 
            this.lstWayPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstWayPoints.FormattingEnabled = true;
            this.lstWayPoints.ItemHeight = 20;
            this.lstWayPoints.Location = new System.Drawing.Point(7, 27);
            this.lstWayPoints.Name = "lstWayPoints";
            this.lstWayPoints.Size = new System.Drawing.Size(629, 204);
            this.lstWayPoints.TabIndex = 0;
            this.lstWayPoints.SelectedIndexChanged += new System.EventHandler(this.lstWayPoints_SelectedIndexChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(750, 476);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(112, 35);
            this.cmdSave.TabIndex = 5;
            this.cmdSave.Text = "Save...";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCancel.Location = new System.Drawing.Point(13, 476);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(112, 35);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cmdResetNewWayPointFields);
            this.groupBox2.Controls.Add(this.cmdAddNewWayPoint);
            this.groupBox2.Controls.Add(this.grpNewWayPointDetails);
            this.groupBox2.Controls.Add(this.cboCountry);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cboState);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCity);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtStreet);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(20, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(842, 159);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New Way Point";
            // 
            // cmdResetNewWayPointFields
            // 
            this.cmdResetNewWayPointFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdResetNewWayPointFields.Location = new System.Drawing.Point(373, 128);
            this.cmdResetNewWayPointFields.Name = "cmdResetNewWayPointFields";
            this.cmdResetNewWayPointFields.Size = new System.Drawing.Size(201, 23);
            this.cmdResetNewWayPointFields.TabIndex = 9;
            this.cmdResetNewWayPointFields.Text = "Reset New Way Point Fields";
            this.cmdResetNewWayPointFields.UseVisualStyleBackColor = true;
            this.cmdResetNewWayPointFields.Click += new System.EventHandler(this.cmdResetNewWayPointFields_Click);
            // 
            // cmdAddNewWayPoint
            // 
            this.cmdAddNewWayPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddNewWayPoint.Location = new System.Drawing.Point(635, 128);
            this.cmdAddNewWayPoint.Name = "cmdAddNewWayPoint";
            this.cmdAddNewWayPoint.Size = new System.Drawing.Size(201, 23);
            this.cmdAddNewWayPoint.TabIndex = 10;
            this.cmdAddNewWayPoint.Text = "Add New Way Point";
            this.cmdAddNewWayPoint.UseVisualStyleBackColor = true;
            this.cmdAddNewWayPoint.Click += new System.EventHandler(this.cmdAddNewWayPoint_Click);
            // 
            // grpNewWayPointDetails
            // 
            this.grpNewWayPointDetails.Controls.Add(this.txtLeaveSetRPM);
            this.grpNewWayPointDetails.Controls.Add(this.label9);
            this.grpNewWayPointDetails.Controls.Add(this.txtLeaveSetVelocity);
            this.grpNewWayPointDetails.Controls.Add(this.label10);
            this.grpNewWayPointDetails.Controls.Add(this.txtArrivePauseBeforeContinuing);
            this.grpNewWayPointDetails.Controls.Add(this.label8);
            this.grpNewWayPointDetails.Controls.Add(this.txtArriveSetRPM);
            this.grpNewWayPointDetails.Controls.Add(this.label6);
            this.grpNewWayPointDetails.Controls.Add(this.txtArriveSetVelocity);
            this.grpNewWayPointDetails.Controls.Add(this.label4);
            this.grpNewWayPointDetails.Location = new System.Drawing.Point(258, 22);
            this.grpNewWayPointDetails.Name = "grpNewWayPointDetails";
            this.grpNewWayPointDetails.Size = new System.Drawing.Size(577, 100);
            this.grpNewWayPointDetails.TabIndex = 8;
            this.grpNewWayPointDetails.TabStop = false;
            this.grpNewWayPointDetails.Text = "New Way Point Details";
            // 
            // txtLeaveSetRPM
            // 
            this.txtLeaveSetRPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeaveSetRPM.Location = new System.Drawing.Point(452, 49);
            this.txtLeaveSetRPM.Name = "txtLeaveSetRPM";
            this.txtLeaveSetRPM.Size = new System.Drawing.Size(111, 20);
            this.txtLeaveSetRPM.TabIndex = 9;
            this.txtLeaveSetRPM.TabStop = false;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(341, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Leave Set RPM:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtLeaveSetVelocity
            // 
            this.txtLeaveSetVelocity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeaveSetVelocity.Location = new System.Drawing.Point(452, 23);
            this.txtLeaveSetVelocity.Name = "txtLeaveSetVelocity";
            this.txtLeaveSetVelocity.Size = new System.Drawing.Size(111, 20);
            this.txtLeaveSetVelocity.TabIndex = 7;
            this.txtLeaveSetVelocity.TabStop = false;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(341, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 20);
            this.label10.TabIndex = 6;
            this.label10.Text = "Leave Set Velocity:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtArrivePauseBeforeContinuing
            // 
            this.txtArrivePauseBeforeContinuing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArrivePauseBeforeContinuing.Location = new System.Drawing.Point(205, 74);
            this.txtArrivePauseBeforeContinuing.Name = "txtArrivePauseBeforeContinuing";
            this.txtArrivePauseBeforeContinuing.Size = new System.Drawing.Size(111, 20);
            this.txtArrivePauseBeforeContinuing.TabIndex = 5;
            this.txtArrivePauseBeforeContinuing.TabStop = false;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Arrive Pause Before Continuing:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtArriveSetRPM
            // 
            this.txtArriveSetRPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArriveSetRPM.Location = new System.Drawing.Point(205, 49);
            this.txtArriveSetRPM.Name = "txtArriveSetRPM";
            this.txtArriveSetRPM.Size = new System.Drawing.Size(111, 20);
            this.txtArriveSetRPM.TabIndex = 3;
            this.txtArriveSetRPM.TabStop = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Arrive Set RPM:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtArriveSetVelocity
            // 
            this.txtArriveSetVelocity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArriveSetVelocity.Location = new System.Drawing.Point(205, 23);
            this.txtArriveSetVelocity.Name = "txtArriveSetVelocity";
            this.txtArriveSetVelocity.Size = new System.Drawing.Size(111, 20);
            this.txtArriveSetVelocity.TabIndex = 1;
            this.txtArriveSetVelocity.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Arrive Set Velocity:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.cboState.SelectedIndexChanged += new System.EventHandler(this.NewWayPointAddress_TextChanged);
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
            this.txtCity.TextChanged += new System.EventHandler(this.NewWayPointAddress_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "City:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtStreet
            // 
            this.txtStreet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreet.Location = new System.Drawing.Point(72, 22);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(158, 20);
            this.txtStreet.TabIndex = 1;
            this.txtStreet.TabStop = false;
            this.txtStreet.TextChanged += new System.EventHandler(this.NewWayPointAddress_TextChanged);
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
            // frmCreateRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 525);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtRouteName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmCreateRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Route";
            this.groupBox1.ResumeLayout(false);
            this.grpWayPointDetails.ResumeLayout(false);
            this.grpWayPointDetails.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpNewWayPointDetails.ResumeLayout(false);
            this.grpNewWayPointDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRouteName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ListBox lstWayPoints;
        private System.Windows.Forms.GroupBox grpWayPointDetails;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpNewWayPointDetails;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtArriveSetVelocity;
        private System.Windows.Forms.TextBox txtArriveSetRPM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtArrivePauseBeforeContinuing;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLeaveSetRPM;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLeaveSetVelocity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmdAddNewWayPoint;
        private System.Windows.Forms.Button cmdResetNewWayPointFields;
        private System.Windows.Forms.TextBox txtWayPointDetails_DepartRPM;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtWayPointDetails_DepartVelocity;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtWayPointDetails_ArrivePause;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtWayPointDetails_ArriveRPM;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtWayPointDetails_ArriveVelocity;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
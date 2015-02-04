namespace VehicleSimulator
{
    partial class frmRoutePlayback
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
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdPause = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.progressbarDataPoints = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalDataPoints = new System.Windows.Forms.TextBox();
            this.txtCurrentDataPoint = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressbarLegs = new System.Windows.Forms.ProgressBar();
            this.txtCurrentLeg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalLegs = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(273, 2);
            this.cmdStart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(74, 40);
            this.cmdStart.TabIndex = 6;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // cmdPause
            // 
            this.cmdPause.Location = new System.Drawing.Point(273, 48);
            this.cmdPause.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdPause.Name = "cmdPause";
            this.cmdPause.Size = new System.Drawing.Size(74, 40);
            this.cmdPause.TabIndex = 7;
            this.cmdPause.Text = "Pause";
            this.cmdPause.UseVisualStyleBackColor = true;
            this.cmdPause.Click += new System.EventHandler(this.cmdPause_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.Location = new System.Drawing.Point(273, 94);
            this.cmdStop.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(74, 40);
            this.cmdStop.TabIndex = 8;
            this.cmdStop.Text = "Stop";
            this.cmdStop.UseVisualStyleBackColor = true;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // progressbarDataPoints
            // 
            this.progressbarDataPoints.Location = new System.Drawing.Point(0, 88);
            this.progressbarDataPoints.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.progressbarDataPoints.Name = "progressbarDataPoints";
            this.progressbarDataPoints.Size = new System.Drawing.Size(269, 20);
            this.progressbarDataPoints.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(187, 112);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "/";
            // 
            // txtTotalDataPoints
            // 
            this.txtTotalDataPoints.Location = new System.Drawing.Point(205, 114);
            this.txtTotalDataPoints.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTotalDataPoints.Name = "txtTotalDataPoints";
            this.txtTotalDataPoints.ReadOnly = true;
            this.txtTotalDataPoints.Size = new System.Drawing.Size(64, 20);
            this.txtTotalDataPoints.TabIndex = 5;
            this.txtTotalDataPoints.TabStop = false;
            // 
            // txtCurrentDataPoint
            // 
            this.txtCurrentDataPoint.Location = new System.Drawing.Point(119, 114);
            this.txtCurrentDataPoint.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCurrentDataPoint.Name = "txtCurrentDataPoint";
            this.txtCurrentDataPoint.ReadOnly = true;
            this.txtCurrentDataPoint.Size = new System.Drawing.Size(64, 20);
            this.txtCurrentDataPoint.TabIndex = 3;
            this.txtCurrentDataPoint.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current Data Point:";
            // 
            // progressbarLegs
            // 
            this.progressbarLegs.Location = new System.Drawing.Point(0, 2);
            this.progressbarLegs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.progressbarLegs.Name = "progressbarLegs";
            this.progressbarLegs.Size = new System.Drawing.Size(269, 18);
            this.progressbarLegs.TabIndex = 0;
            // 
            // txtCurrentLeg
            // 
            this.txtCurrentLeg.Location = new System.Drawing.Point(119, 26);
            this.txtCurrentLeg.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCurrentLeg.Name = "txtCurrentLeg";
            this.txtCurrentLeg.ReadOnly = true;
            this.txtCurrentLeg.Size = new System.Drawing.Size(64, 20);
            this.txtCurrentLeg.TabIndex = 10;
            this.txtCurrentLeg.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Current Leg:";
            // 
            // txtTotalLegs
            // 
            this.txtTotalLegs.Location = new System.Drawing.Point(205, 26);
            this.txtTotalLegs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTotalLegs.Name = "txtTotalLegs";
            this.txtTotalLegs.ReadOnly = true;
            this.txtTotalLegs.Size = new System.Drawing.Size(64, 20);
            this.txtTotalLegs.TabIndex = 12;
            this.txtTotalLegs.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(187, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "/";
            // 
            // frmRoutePlayback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 139);
            this.Controls.Add(this.txtCurrentLeg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotalLegs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressbarLegs);
            this.Controls.Add(this.txtCurrentDataPoint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalDataPoints);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressbarDataPoints);
            this.Controls.Add(this.cmdStop);
            this.Controls.Add(this.cmdPause);
            this.Controls.Add(this.cmdStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRoutePlayback";
            this.Text = "Route Playback";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRoutePlayback_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Button cmdPause;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.ProgressBar progressbarDataPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalDataPoints;
        private System.Windows.Forms.TextBox txtCurrentDataPoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressbarLegs;
        private System.Windows.Forms.TextBox txtCurrentLeg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalLegs;
        private System.Windows.Forms.Label label4;
    }
}
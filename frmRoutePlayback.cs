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
    public partial class frmRoutePlayback : Form
    {
        private List<VehicleSimulator.WayPoint>[] m_alstLegsAndWayPoints;


        public delegate void RoutePlaybackStartedHandler();
        public event RoutePlaybackStartedHandler OnRoutePlaybackStarted;

        public delegate void RoutePlaybackStoppedHandler();
        public event RoutePlaybackStoppedHandler OnRoutePlaybackStopped;

        private int m_iCurrentLegIndex;
        private int m_iCurrentWayPointIndexInCurrentLeg;

        private readonly frmMain m_frmMain;


        public frmRoutePlayback(frmMain owner,
                                VehicleSimulator.RouteLeg[] aRouteLegs)
        {
            m_frmMain = owner;

            m_alstLegsAndWayPoints = new List<WayPoint>[aRouteLegs.Length];
            for (int legIdx = 0; legIdx < aRouteLegs.Length; ++legIdx)
            {
                VehicleSimulator.RouteLeg routeLeg = aRouteLegs[legIdx];

                m_alstLegsAndWayPoints[legIdx] = new List<WayPoint>();
                m_alstLegsAndWayPoints[legIdx].Add(routeLeg.Start);

                foreach (VehicleSimulator.WayPoint wayPoint in routeLeg.DrivingLocations)
                    m_alstLegsAndWayPoints[legIdx].Add(wayPoint);

                m_alstLegsAndWayPoints[legIdx].Add(routeLeg.End);
            }

            InitializeComponent();

            this.TopMost = true;

            m_iCurrentWayPointIndexInCurrentLeg = 0;
            m_iCurrentLegIndex = 0;

            progressbarLegs.Maximum = m_alstLegsAndWayPoints.Length;
            txtTotalLegs.Text = progressbarLegs.Maximum.ToString();

            progressbarDataPoints.Maximum = m_alstLegsAndWayPoints[m_iCurrentLegIndex].Count;
            txtTotalDataPoints.Text = progressbarDataPoints.Maximum.ToString();

            SetProgressBars();
        }


        void SetProgressBars()
        {
            progressbarDataPoints.Maximum = m_alstLegsAndWayPoints[m_iCurrentLegIndex].Count;
            txtTotalDataPoints.Text = progressbarDataPoints.Maximum.ToString();

            progressbarLegs.Value = m_iCurrentLegIndex + 1;
            txtCurrentLeg.Text = progressbarLegs.Value.ToString();

            progressbarDataPoints.Value = m_iCurrentWayPointIndexInCurrentLeg + 1;
            txtCurrentDataPoint.Text = progressbarDataPoints.Value.ToString();
        }


        private void cmdStart_Click(object sender, EventArgs e)
        {
            cmdStart.Enabled = false;
            cmdPause.Enabled = true;

            if (OnRoutePlaybackStarted != null)
                OnRoutePlaybackStarted();

            m_frmMain.Vehicle.OnArrived += new Vehicle.ArrivedHandler(Vehicle_OnArrived);
            m_frmMain.VehiclePaused = false;

            VehicleSimulator.WayPoint startWayPoint
                = m_alstLegsAndWayPoints[m_iCurrentLegIndex][m_iCurrentWayPointIndexInCurrentLeg];

            m_frmMain.CurrentAddress = startWayPoint.WayPointAddress;

            m_frmMain.DoSetVehicleLocation(false);
            Application.DoEvents();

            m_frmMain.StartScreenUpdates(true);
            Application.DoEvents();

            if (!startWayPoint.DepartVelocity.HasValue)
                startWayPoint.DepartVelocity = 10;

            m_frmMain.DoVelocityGaugeClicked((float)startWayPoint.DepartVelocity, false);
            Application.DoEvents();

            if (!startWayPoint.DepartRPM.HasValue)
                startWayPoint.DepartRPM = 500;

            m_frmMain.DoRpmGaugeClicked((float)startWayPoint.DepartRPM, true);
            Application.DoEvents();

            SetProgressBars();

            m_frmMain.Vehicle.GoHere = startWayPoint.Location;
        }



        private void cmdPause_Click(object sender, EventArgs e)
        {
            cmdStart.Enabled = true;
            cmdPause.Enabled = false;

            m_frmMain.VehiclePaused = true;
        }


        void DoStop()
        {
            m_frmMain.Vehicle.GoHere = null;

            m_bStarted = false;

            cmdStart.Enabled = true;
            cmdPause.Enabled = false;

            m_iCurrentWayPointIndexInCurrentLeg = 0;
            m_iCurrentLegIndex = 0;

            progressbarLegs.Maximum = m_alstLegsAndWayPoints.Length;
            progressbarLegs.Value = 1;

            txtCurrentLeg.Text = progressbarLegs.Value.ToString();
            txtTotalLegs.Text = m_alstLegsAndWayPoints.Length.ToString();

            progressbarDataPoints.Maximum = m_alstLegsAndWayPoints[m_iCurrentLegIndex].Count;
            progressbarDataPoints.Value = 0;

            txtTotalDataPoints.Text = progressbarDataPoints.Maximum.ToString();
            txtCurrentDataPoint.Text = progressbarDataPoints.Value.ToString();

            m_frmMain.DoVelocityGaugeClicked(0, false);
            m_frmMain.DoRpmGaugeClicked(0, true);
        }



        private void cmdStop_Click(object sender, EventArgs e)
        {
            DoStop();
        }


        private void frmRoutePlayback_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (OnRoutePlaybackStopped != null)
                OnRoutePlaybackStopped();
        }


        private DateTime m_datetimePauser = DateTime.Now;
        private double? m_dblPrevFeetToNextWayPoint = null;
        private bool m_bStarted = false;


        VehicleSimulator.WayPoint NextWayPoint(ref int iNextCurrentLegIndex, ref int iNextCurrentWayPointIndexInCurrentLeg)
        {

            int iNextLegIndex = iNextCurrentLegIndex;
            int iNextWayPointIndexInCurrentLeg = iNextCurrentWayPointIndexInCurrentLeg;

            if (iNextWayPointIndexInCurrentLeg + 1 >= m_alstLegsAndWayPoints[iNextLegIndex].Count)
            {
                if (iNextLegIndex + 1 >= m_alstLegsAndWayPoints.Length)
                    return null;

                iNextLegIndex++;
                iNextWayPointIndexInCurrentLeg = 0;
            }
            else
            {
                ++iNextWayPointIndexInCurrentLeg;
            }

            VehicleSimulator.WayPoint nextWayPoint = m_alstLegsAndWayPoints[iNextLegIndex][iNextWayPointIndexInCurrentLeg];

            iNextCurrentLegIndex = iNextLegIndex;
            iNextCurrentWayPointIndexInCurrentLeg = iNextWayPointIndexInCurrentLeg;

            return nextWayPoint;
        }


        delegate void Delegate_Vehicle_OnArrived(object objLocationArrived);

        void Vehicle_OnArrived(object objLocationArrived)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Delegate_Vehicle_OnArrived(Vehicle_OnArrived),
                            new object[] { objLocationArrived });
                return;
            }

            VehicleSimulator.Location locationArrived = objLocationArrived as VehicleSimulator.Location;
    
            int iNextCurrentLegIndex = m_iCurrentLegIndex;
            int iNextCurrentWayPointIndexInCurrentLeg = m_iCurrentWayPointIndexInCurrentLeg;

            VehicleSimulator.WayPoint nextWayPoint
                = NextWayPoint(ref iNextCurrentLegIndex, ref iNextCurrentWayPointIndexInCurrentLeg);

            if (nextWayPoint == null)
            {
                DoStop();
                return;
            }

            m_iCurrentLegIndex = iNextCurrentLegIndex;
            m_iCurrentWayPointIndexInCurrentLeg = iNextCurrentWayPointIndexInCurrentLeg;

            SetProgressBars();

            if (nextWayPoint.DepartVelocity.HasValue)
            {
                m_frmMain.DoVelocityGaugeClicked((float)nextWayPoint.DepartVelocity, false);
            }

            if (nextWayPoint.DepartRPM.HasValue)
            {
                m_frmMain.DoRpmGaugeClicked((float)nextWayPoint.DepartRPM, true);
            }

            m_frmMain.Vehicle.GoHere = nextWayPoint.Location;
        }

    }  // public partial class frmRoutePlayback : Form

}  // namespace VehicleSimulator

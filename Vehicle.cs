using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.IO;


namespace VehicleSimulator
{

    public class Vehicle : IDisposable
    {
        private volatile bool _disposed;

        private readonly ECM m_ECM;
        private readonly GpsSimulator m_GPS;


        private readonly ECM.eEcmProtocols m_EcmProtocol;

        private readonly SerialPort m_ecmSerialPort;
        private readonly SerialPort m_gpsSerialPort;

        private static readonly object m_objStateLocker = new object();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleStartingLocation">Valid lon/lat of the vehicle.</param>
        /// <param name="ecmProtocol">J1587 only supported for time being.</param>
        /// <param name="ecmSerialPort">Must be created and opened prior to Vehicle instantiation.</param>
        /// <param name="gpsSerialPort">Must be created and opened prior to Vehicle instantiation.</param>
        public Vehicle(VehicleSimulator.Location vehicleStartingLocation,
                       ECM.eEcmProtocols ecmProtocol,
                       SerialPort ecmSerialPort, 
                       SerialPort gpsSerialPort)
        {
            m_EcmProtocol = ecmProtocol;

            m_gpsSerialPort = gpsSerialPort;
            if (m_gpsSerialPort != null)
            {
                if (!m_gpsSerialPort.IsOpen)
                {
                    try
                    {
                        m_gpsSerialPort.Open();
                    }
                    catch { }
                }
            }

            m_ecmSerialPort = ecmSerialPort;

            if (m_ecmSerialPort != null)
            {
                if (!m_ecmSerialPort.IsOpen)
                {
                    try
                    {
                        m_ecmSerialPort.Open();
                    }
                    catch
                    {
                        m_ecmSerialPort = null;
                    }
                }
            }

            m_ECM = ECM.CreateEcm(m_EcmProtocol, m_ecmSerialPort);

            m_GPS = new GpsSimulator(vehicleStartingLocation);

            IsRunning = false;
            IsStopped = true;
        }


        public ECM ECM { get { return m_ECM; } }
        public GpsSimulator GPS { get { return m_GPS; } }


        bool m_bEmitEcmData = false;
        public bool EmitEcmData
        {
            get { return m_bEmitEcmData; }
            set
            {
                m_bEmitEcmData = value;
                m_ECM.AllowEmit = m_bEmitEcmData;
            }
        }


        public bool EmitGpsData { get; set; }



        /// <summary>
        /// Direction of Travel in Degrees (0 = north, 90 = east, etc.)
        /// </summary>
        public double DirectionOfTravel
        {
            get
            {
                double dblDirectionOfTravel;

                lock (m_objStateLocker)
                    dblDirectionOfTravel = m_GPS.TrackAngle;

                return dblDirectionOfTravel;
            }   
            set
            {
                lock (m_objStateLocker)
                    m_GPS.TrackAngle = value;
            }
        }


        /// <summary>
        /// Speed in KPH
        /// </summary>
        public double Speed
        {
            get
            {
                double dblSpeedKPH;
                lock (m_objStateLocker)
                    dblSpeedKPH = m_ECM.RoadSpeedKPH;

                return dblSpeedKPH;
            }
            set
            {
                lock (m_objStateLocker)
                    m_ECM.RoadSpeedKPH = value;
            }
        }


        /// <summary>
        /// Sets target speed to specified KPH.
        /// </summary>
        /// <param name="dblTargetKPH">What KPH you want vehicle to end up at.</param>
        /// <param name="dblAccelerationToUse">Acceleartion to get to target speed, in
        /// meters per second per second.</param>
        public void SetTargetSpeed(double dblTargetKPH, double dblAccelerationToUse)
        {
            lock (m_objStateLocker)
                m_ECM.SetTargetSpeedKPH(dblTargetKPH, dblAccelerationToUse);
        }


        /// <summary>
        /// Odometer in Km
        /// </summary>
        public double Odometer
        {
            get 
            {
                double dblOdometer;
                lock (m_objStateLocker)
                    dblOdometer = m_ECM.TotalVehicleDistanceKilometers;

                return dblOdometer;
            }
            set
            {
                lock (m_objStateLocker)
                    m_ECM.TotalVehicleDistanceKilometers = value;
            }
        }


        /// <summary>
        /// FuelRate in Liters/Second
        /// </summary>
        public double FuelRate
        {
            get
            {
                double dblFuelRateLitersPerSecond;
                lock (m_objStateLocker)
                    dblFuelRateLitersPerSecond = m_ECM.FuelRateLitersPerSecond;

                return dblFuelRateLitersPerSecond;
            }
            set
            {
                lock (m_objStateLocker)
                    m_ECM.FuelRateLitersPerSecond = value;
            }
        }


        /// <summary>
        /// RPM
        /// </summary>
        public double EngineRPM
        {
            get
            {
                double dblEngineRPM;
                lock (m_objStateLocker)
                    dblEngineRPM = m_ECM.EngineRPM;

                return dblEngineRPM;
            }
            set
            {
                lock (m_objStateLocker)
                    m_ECM.EngineRPM = value;
            }
        }


        public void SetTargetEngineRPM(double dblTargetRPM, double dblAccelerationToUse)
        {
            lock (m_objStateLocker)
                m_ECM.SetTargetRPM(dblTargetRPM, dblAccelerationToUse);
        }


        public bool PowerTakeOff
        {
            get
            {
                bool bPowerTakeOff;
                lock (m_objStateLocker)
                    bPowerTakeOff = m_ECM.PowerTakeOff();

                return bPowerTakeOff;
            }
            set
            {
                lock (m_objStateLocker)
                    m_ECM.PowerTakeOff(value);
            }
        }


        /// <summary>
        /// RPM
        /// </summary>
        public VehicleSimulator.Location Location
        {
            get
            {
                VehicleSimulator.Location vehicleLocation;
                lock (m_objStateLocker)
                    vehicleLocation = new VehicleSimulator.Location(m_GPS.Location);

                return vehicleLocation;
            }
            set
            {
                lock (m_objStateLocker)
                   m_GPS.Location = value;
            }
        }



        public bool IsRunning { get; private set; }
        public bool IsStopped { get; private set; }


        public void Start()
        {
            if (IsRunning)
                return;

            IsRunning = true;
            Thread t = new Thread(ThreadProc);
            t.Name = "Vehicle GPS Thread";
            t.IsBackground = true;
            t.Priority = ThreadPriority.AboveNormal;
            t.Start();

            m_ECM.Start();
        }


        public void Stop()
        {
            if (!IsRunning)
                return;

            // Thread changes IsStopped back to 'true' on exit.
            IsStopped = false;

            IsRunning = false;

            for (int i = 0; i < 10 && IsStopped == false; ++i)
                Thread.Sleep(100);
        }


        public bool IsPaused { get; set; }


        public int m_GoHereTargetRangeInFeet = 20;
        public int GoHereTargetRangeInFeet
        {
            get { return m_GoHereTargetRangeInFeet; }
            set
            {
                lock (m_objStateLocker)
                    m_GoHereTargetRangeInFeet = value;
            }
        }


        public delegate void ArrivedHandler(object objLocationArrived);
        public event ArrivedHandler OnArrived;

        private double m_dblGoHereDirectionOfTravel = 0;
        private double m_dblPreviousFeetToNextWayPoint = 0;
        private double m_dblCumulativeDistanceToNextWayPoint = 0;
        private VehicleSimulator.Location m_GoHere = null;
        public VehicleSimulator.Location GoHere
        {
            get { return m_GoHere; }
            set
            {
                lock (m_objStateLocker)
                {
                    m_dblPreviousFeetToNextWayPoint = 0;
                    m_dblCumulativeDistanceToNextWayPoint = 0;
                    m_GoHere = value;

                    if (m_GoHere != null && m_GPS.Location.IsValid)
                    {
                        m_dblGoHereDirectionOfTravel
                            = VehicleSimulator.Location
                             .GetAngleInDegrees(m_GPS.Location.Longitude.Value,
                                                m_GPS.Location.Latitude.Value,
                                                m_GoHere.Longitude.Value,
                                                m_GoHere.Latitude.Value);

                        m_GPS.TrackAngle = m_dblGoHereDirectionOfTravel;
                    }
                }
            }
        }



        private void ThreadProc()
        {
            IsStopped = false;
            IsRunning = true;

            DateTime prevGpsEmitTime = DateTime.Now;
            DateTime runTimer = DateTime.Now;

            m_ECM.Start();

            TimeSpan ts;
            double dblVelocityMetersPerSecond;
            double dblMetersTravelled;

            for (; IsRunning; Thread.Sleep(100))
            {
                if (IsPaused)
                {
                    m_ECM.PauseECM = true;

                    while (IsPaused && IsRunning)
                        Thread.Sleep(100);

                    // Is Pause turned off (we didn't just do a Stop)?
                    if (IsRunning)
                    {
                        m_ECM.PauseECM = false;

                        runTimer = DateTime.Now;
                        prevGpsEmitTime = DateTime.Now;
                    }
                    else
                    {
                        break;
                    }
                }

                lock (m_objStateLocker)
                {
                    dblVelocityMetersPerSecond = m_ECM.RoadSpeedMetersPerSecond;

                    ts = DateTime.Now - runTimer;
                    runTimer = DateTime.Now;

                    dblMetersTravelled = dblVelocityMetersPerSecond * ts.TotalSeconds;

                    // Need 360 here to translate from our rotational system to "their's"
                    m_GPS.Move(360 - m_GPS.TrackAngle, dblMetersTravelled);
                    m_GPS.Velocity = Physics.MetersPerSecond_to_KPH(dblVelocityMetersPerSecond);


                    ts = DateTime.Now - prevGpsEmitTime;
                    if (ts.TotalMilliseconds >= 1000)
                    {
                        if (   EmitGpsData
                            && m_gpsSerialPort != null 
                            && m_gpsSerialPort.IsOpen)
                        {
                            m_gpsSerialPort.Write(m_GPS.ToString());
                        }

                        prevGpsEmitTime = DateTime.Now;
                    }

                    if (m_GoHere != null)
                    {
                        ProcessGoThere();
                    }
                }  // lock (m_objStateLocker)
            }  // for (; IsRunning; Thread.Sleep(100))

            m_ECM.Stop();

            IsStopped = true;
        }


        void ProcessGoThere()
        {
            bool bArrived = false;

            if (!m_GPS.Location.IsValid)
                return;

            m_dblGoHereDirectionOfTravel
                = VehicleSimulator.Location
                 .GetAngleInDegrees(m_GPS.Location.Longitude.Value,
                                    m_GPS.Location.Latitude.Value,
                                    m_GoHere.Longitude.Value,
                                    m_GoHere.Latitude.Value);

            m_GPS.TrackAngle = m_dblGoHereDirectionOfTravel;

            double dblFeetToNextWayPoint
                = Math.Abs(VehicleSimulator.Location.GetDistanceInFeet(
                                            m_GPS.Location,
                                            m_GoHere));

            if (dblFeetToNextWayPoint <= m_GoHereTargetRangeInFeet)
            {
                bArrived = true;
            }
            else
            {
                if (   m_dblPreviousFeetToNextWayPoint == 0
                    || dblFeetToNextWayPoint < m_dblPreviousFeetToNextWayPoint)
                {
                    m_dblCumulativeDistanceToNextWayPoint = 0;
                }
                else
                {
                    // Now going away from destination?  Then we didn't
                    // get within m_dblPreviousFeetToNextWayPoint feet of
                    // it, and are simply now travelling further away from it
                    // and we'll never get closer.
//                    if (m_dblCumulativeDistanceToNextWayPoint > 5)
//                    if ((int)m_dblCumulativeDistanceToNextWayPoint > (int)(m_GoHereTargetRangeInFeet / 2))
//                    {
//                        bArrived = true;
//                    }
                }

                if (m_dblPreviousFeetToNextWayPoint != 0)
                {
                    m_dblCumulativeDistanceToNextWayPoint
                        += Math.Abs(dblFeetToNextWayPoint - m_dblPreviousFeetToNextWayPoint);
                }

                m_dblPreviousFeetToNextWayPoint = dblFeetToNextWayPoint;
            }

            if (bArrived)
            {
                m_GPS.Location = m_GoHere;

                m_GoHere = null;
                m_dblCumulativeDistanceToNextWayPoint = 0;
                m_dblPreviousFeetToNextWayPoint = 0;

                if (OnArrived != null)
                    ThreadPool.QueueUserWorkItem(new WaitCallback(OnArrived), m_GPS.Location);
            }
        }


        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
        }


        protected virtual void Dispose(bool bDisposing)
        {
            if (!_disposed)
            {
                if (bDisposing)
                {
                    Stop();

                    if (m_gpsSerialPort != null)
                    {
                        if (m_gpsSerialPort.IsOpen)
                            m_gpsSerialPort.Close();
                    }

                    if (m_ecmSerialPort != null)
                    {
                        if (m_ecmSerialPort.IsOpen)
                            m_ecmSerialPort.Close();
                    }
                }

                _disposed = true;
            }
        }

        #endregion

    }  // public class Vehicle

}  // namespace VehicleSimulator

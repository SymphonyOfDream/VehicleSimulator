using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.IO.Ports;


namespace VehicleSimulator
{

    public abstract class ECM : IEquatable<ECM>, IDisposable
    {
        private volatile bool _disposed;

        static int m_lNextID = 1;
        protected int ID { get; private set; }


        protected Stopwatch m_Stopwatch;

        public bool IsRunning { get; private set; }
        public bool IsStopped { get; private set; }


        public object m_objVehiclePropertiesLocker = new object();


        public SerialPort SerialPort { get; set; }
        public Stream StreamOutput2 { get; set; }


        #region CTORs

        internal ECM()
        {
            ID = ECM.m_lNextID++;

            IsRunning = false;
            IsStopped = true;

            SerialPort = null;
            StreamOutput2 = null;
        }

        internal ECM(SerialPort outputSerialPort)
            : this()
        {
            this.SerialPort = outputSerialPort;
            if (this.SerialPort != null)
                this.SerialPort.Encoding = Encoding.GetEncoding(28591);
        }


        internal ECM(SerialPort outputSerialPort, Stream outputStream2)
            : this(outputSerialPort)
        {
            StreamOutput2 = outputStream2;
        }

        #endregion


        
        public enum eEcmProtocols
        {
            J1587,
            J1939
        }


        static public ECM CreateEcm(eEcmProtocols desiredProtocol, SerialPort serialPort)
        {
            ECM ecm = null;

            switch (desiredProtocol)
            {
                case eEcmProtocols.J1587:
                    ecm = new J1587(serialPort);
                    break;

                case eEcmProtocols.J1939:
                    ecm = new J1939(serialPort);
                    break;
            }


            return ecm;
        }


        static public ECM CreateEcm(eEcmProtocols desiredProtocol, SerialPort serialPort, Stream outputStream2)
        {
            ECM ecm = null;

            switch (desiredProtocol)
            {
                case eEcmProtocols.J1587:
                    ecm = new J1587(serialPort, outputStream2);
                    break;

                case eEcmProtocols.J1939:
                    ecm = new J1939(serialPort, outputStream2);
                    break;
            }


            return ecm;
        }


        bool m_bAllowEmit = false;
        public bool AllowEmit
        {
            get { return m_bAllowEmit; }
            set
            {
                m_bAllowEmit = value;
            }
        }


        public void Start()
        {
            m_bECMPaused = false;

            if (!IsRunning)
            {
                IsRunning = true;
                Thread t = new Thread(ThreadProc);
                t.Name = "ECM Engine Thread";
                t.IsBackground = true;
                t.Priority = ThreadPriority.AboveNormal;
                t.Start();
            }
        }


        public void Stop()
        {
            if (!IsRunning)
                return;

            // Thread changes IsStopped back to 'true' on exit.
            IsStopped = false;
            IsRunning = false;
            m_bECMPaused = false;

            for (int i = 0; i < 10 && IsStopped == false; ++i)
                Thread.Sleep(100);
        }


        bool m_bECMPaused = false;
        public bool PauseECM
        {
            get { return m_bECMPaused; }
            set
            {
                m_bECMPaused = value;
            }
        }

        private void ThreadProc()
        {
            IsRunning = true;
            IsStopped = false;

            DateTime prevEmitTime = DateTime.Now;
            TimeSpan ts;
            double dblGallonsPerHour;

            while (IsRunning)
            {
                if (m_bECMPaused)
                {
                    while (m_bECMPaused && IsRunning)
                        Thread.Sleep(100);

                    // Is Pause turned off (we didn't just do a Stop)?
                    if (IsRunning)
                    {
                        ResetEmitTimeout();
                        prevEmitTime = DateTime.Now;
                    }
                    else
                    {
                        break;
                    }
                }

                lock (m_objVehiclePropertiesLocker)
                {
                    ts = DateTime.Now - prevEmitTime;

                    m_dblTotalVehicleDistanceMeters += m_dblVelocityMetersPerSecond * ts.TotalSeconds;

                    // From Legacy VB 6 comment:
                    // Fuel is based on 0.3 gal/min(10 gal/hr) at 120 MPH
                    dblGallonsPerHour
                        = 10.0 
                        * (Physics.MetersPerSecond_to_MPH(m_dblVelocityMetersPerSecond) 
                           / 120.0); // % of 120 mph we're currently going

                    // Now add in RPM adder (some apparently random value, as no comments in legacy code)
                    dblGallonsPerHour += m_dblEngineRPM / 150.0;

                    m_dblFuelRateLitersPerSecond = Physics.GallonsPerHour_to_LitersPerSecond(dblGallonsPerHour);

                    m_dblVelocityMetersPerSecond += m_dblVelocityAccelerationMetersPerSecondPerSecond * ts.TotalSeconds;
                    if (m_dblVelocityMetersPerSecond < 0)
                    {
                        m_dblVelocityMetersPerSecond = 0;
                        m_dblVelocityAccelerationMetersPerSecondPerSecond = 0;
                    }


                    if (m_dblTargetVelocityMetersPerSecond.HasValue)
                    {
                        bool bDone;
                        if (m_dblVelocityAccelerationMetersPerSecondPerSecond < 0)
                        {
                            bDone = m_dblVelocityMetersPerSecond <= m_dblTargetVelocityMetersPerSecond.Value;
                        }
                        else
                        {
                            bDone = m_dblVelocityMetersPerSecond >= m_dblTargetVelocityMetersPerSecond.Value;
                        }

                        if (bDone)
                        {
                            m_dblVelocityMetersPerSecond = m_dblTargetVelocityMetersPerSecond.Value;
                            m_dblVelocityAccelerationMetersPerSecondPerSecond = 0;
                            m_dblTargetVelocityMetersPerSecond = null;
                        }
                    }  // if (m_dblTargetVelocityMetersPerSecond.HasValue)

                    m_dblEngineRPM += m_dblRPMAcceleration * ts.TotalSeconds;


                    if (m_dblTargetRPM.HasValue)
                    {
                        bool bDone;
                        if (m_dblRPMAcceleration < 0)
                        {
                            bDone = m_dblEngineRPM <= m_dblTargetRPM.Value;
                        }
                        else
                        {
                            bDone = m_dblEngineRPM >= m_dblTargetRPM.Value;
                        }

                        if (bDone)
                        {
                            m_dblEngineRPM = m_dblTargetRPM.Value;
                            m_dblRPMAcceleration = 0;
                            m_dblTargetRPM = null;
                        }
                    }  // if (m_dblTargetRPM.HasValue)
                }  // lock (m_objVehiclePropertiesLocker)

                if (m_bAllowEmit)
                    Emit();

                prevEmitTime = DateTime.Now;

                Thread.Sleep(20);
            }  // while (IsRunning)

            IsRunning = false;
            IsStopped = true;
        }


        protected abstract void DoEmit(long lMillisecondsSinceLastEmitRequest);
        protected abstract void ResetEmitTimeout();

        public void Emit()
        {
            if (m_Stopwatch == null)
            {
                m_Stopwatch = new Stopwatch();
            }

            long lMillisecondsSinceLastEmitRequest;

            if (m_Stopwatch.IsRunning)
            {
                m_Stopwatch.Stop();
                lMillisecondsSinceLastEmitRequest = m_Stopwatch.ElapsedMilliseconds;
            }
            else
            {
                lMillisecondsSinceLastEmitRequest = 0;
            }

            DoEmit(lMillisecondsSinceLastEmitRequest);

            m_Stopwatch.Reset();
            m_Stopwatch.Start();
        }



        [Flags]
        protected enum ePowerTakeoffStatuses : byte
        {
            PtoMode = 128,
            ClutchSwitch = 64,
            BrakeSwitch = 32,
            AccelSwitch = 16,
            ResumeSwitch = 8,
            CoastSwitch = 4,
            SetSwitch = 2,
            PtoControlSwitch = 1,
            OFF = 0
        }

        protected ePowerTakeoffStatuses m_PowerTakeoffStatuses;


        protected double m_dblVelocityAccelerationMetersPerSecondPerSecond = 0;
        protected double m_dblRPMAcceleration = 0;

        protected double m_dblVelocityMetersPerSecond = 0;  // always in meters/second
        protected double m_dblEngineRPM = 0;
        protected double m_dblFuelRateLitersPerSecond = 0;
        protected double m_dblTotalVehicleDistanceMeters = 0;

        double? m_dblTargetVelocityMetersPerSecond = null;
        double? m_dblTargetRPM = null;



        public void SetTargetSpeedKPH(double dblTargetKPH, double dblAccelerationToUse)
        {
            lock (m_objVehiclePropertiesLocker)
            {
                double dblTargetMetersPerSecond = Physics.KPH_to_MetersPerSecond(dblTargetKPH);

                if (dblTargetMetersPerSecond == m_dblVelocityMetersPerSecond)
                {
                    m_dblVelocityAccelerationMetersPerSecondPerSecond = 0;
                    m_dblTargetVelocityMetersPerSecond = null;
                    return;
                }

                m_dblTargetVelocityMetersPerSecond = dblTargetMetersPerSecond;

                dblAccelerationToUse = Math.Abs(dblAccelerationToUse);

                if (dblTargetMetersPerSecond < m_dblVelocityMetersPerSecond)
                {
                    m_dblVelocityAccelerationMetersPerSecondPerSecond = -dblAccelerationToUse;
                }
                else
                {
                    m_dblVelocityAccelerationMetersPerSecondPerSecond = dblAccelerationToUse;
                }
            }
        }

        public void SetTargetRPM(double dblTargetRPM, double dblAccelerationToUse)
        {
            lock (m_objVehiclePropertiesLocker)
            {
                if (dblTargetRPM < 0)
                    dblTargetRPM = 0;

                if (dblTargetRPM == m_dblEngineRPM)
                {
                    m_dblRPMAcceleration = 0;
                    m_dblTargetRPM = null;
                    return;
                }

                m_dblTargetRPM = dblTargetRPM;

                dblAccelerationToUse = Math.Abs(dblAccelerationToUse);

                if (dblTargetRPM < m_dblEngineRPM)
                {
                    m_dblRPMAcceleration = -dblAccelerationToUse;
                }
                else
                {
                    m_dblRPMAcceleration = dblAccelerationToUse;
                }
            }
        }


        #region Vehicle Speed

        public double RoadSpeedMetersPerSecond
        {
            get
            {
                double dbl;
                lock (m_objVehiclePropertiesLocker)
                {
                    dbl = m_dblVelocityMetersPerSecond;
                }
                return dbl;
            }
        }


        public double RoadSpeedKPH
        {
            get
            {
                double dbl;
                lock (m_objVehiclePropertiesLocker)
                {
                    dbl = Physics.MetersPerSecond_to_KPH(m_dblVelocityMetersPerSecond);
                }
                return dbl;
            }
            set
            {
                lock (m_objVehiclePropertiesLocker)
                {
                    m_dblVelocityMetersPerSecond = Physics.KPH_to_MetersPerSecond(value);
                }
            }
        }



        public double EngineRPM
        {
            get
            {
                double dbl;
                lock (m_objVehiclePropertiesLocker)
                {
                    dbl = m_dblEngineRPM;
                }
                return dbl;
            }
            set
            {
                lock (m_objVehiclePropertiesLocker)
                {
                    m_dblEngineRPM = value;
                }
            }
        }

        #endregion



        public double FuelRateLitersPerSecond
        {
            get 
            {
                double dbl;
                lock (m_objVehiclePropertiesLocker)
                {
                    dbl = m_dblFuelRateLitersPerSecond;
                }
                return dbl;
            }
            set
            {
                lock (m_objVehiclePropertiesLocker)
                {
                    m_dblFuelRateLitersPerSecond = value;
                }
            }
        }



        #region PTO Processing






        public bool SystemActive
        {
            get
            {
                return (m_PowerTakeoffStatuses & ePowerTakeoffStatuses.PtoMode) == ePowerTakeoffStatuses.PtoMode;
            }
            set
            {
                if (value)
                {
                    m_PowerTakeoffStatuses = m_PowerTakeoffStatuses | ePowerTakeoffStatuses.PtoMode;
                }
                else
                {
                    m_PowerTakeoffStatuses = ePowerTakeoffStatuses.OFF;
                }
            }
        }


        public bool ClutchSwitch
        {
            get
            {
                return (m_PowerTakeoffStatuses & ePowerTakeoffStatuses.ClutchSwitch) == ePowerTakeoffStatuses.ClutchSwitch;
            }
            set
            {
                if (value)
                {
                    m_PowerTakeoffStatuses = m_PowerTakeoffStatuses | ePowerTakeoffStatuses.ClutchSwitch | ePowerTakeoffStatuses.PtoMode;
                }
                else
                {
                    m_PowerTakeoffStatuses = m_PowerTakeoffStatuses | (~ePowerTakeoffStatuses.ClutchSwitch);
                }
            }
        }


        public bool BrakeSwitch
        {
            get
            {
                return (m_PowerTakeoffStatuses & ePowerTakeoffStatuses.BrakeSwitch) == ePowerTakeoffStatuses.BrakeSwitch;
            }
        }


        public bool AccelSwitch
        {
            get
            {
                return (m_PowerTakeoffStatuses & ePowerTakeoffStatuses.AccelSwitch) == ePowerTakeoffStatuses.AccelSwitch;
            }
            set
            {
                if (value)
                {
                    m_PowerTakeoffStatuses = m_PowerTakeoffStatuses | ePowerTakeoffStatuses.AccelSwitch | ePowerTakeoffStatuses.PtoMode;
                }
                else
                {
                    m_PowerTakeoffStatuses = m_PowerTakeoffStatuses | (~ePowerTakeoffStatuses.AccelSwitch);
                }
            }
        }


        public bool ResumeSwitch
        {
            get
            {
                return (m_PowerTakeoffStatuses & ePowerTakeoffStatuses.ResumeSwitch) == ePowerTakeoffStatuses.ResumeSwitch;
            }
            set
            {
                if (value)
                {
                    m_PowerTakeoffStatuses = m_PowerTakeoffStatuses | ePowerTakeoffStatuses.ResumeSwitch | ePowerTakeoffStatuses.PtoMode;
                }
                else
                {
                    m_PowerTakeoffStatuses = m_PowerTakeoffStatuses | (~ePowerTakeoffStatuses.ResumeSwitch);
                }
            }
        }


        public bool CoastSwitch
        {
            get
            {
                return (m_PowerTakeoffStatuses & ePowerTakeoffStatuses.CoastSwitch) == ePowerTakeoffStatuses.CoastSwitch;
            }
            set
            {
                if (value)
                {
                    m_PowerTakeoffStatuses = m_PowerTakeoffStatuses | ePowerTakeoffStatuses.CoastSwitch | ePowerTakeoffStatuses.PtoMode;
                }
                else
                {
                    m_PowerTakeoffStatuses = m_PowerTakeoffStatuses | (~ePowerTakeoffStatuses.CoastSwitch);
                }
            }
        }


        public bool SetSwitch
        {
            get
            {
                return (m_PowerTakeoffStatuses & ePowerTakeoffStatuses.SetSwitch) == ePowerTakeoffStatuses.SetSwitch;
            }
            set
            {
                if (value)
                {
                    m_PowerTakeoffStatuses = m_PowerTakeoffStatuses | ePowerTakeoffStatuses.SetSwitch | ePowerTakeoffStatuses.PtoMode;
                }
                else
                {
                    m_PowerTakeoffStatuses = m_PowerTakeoffStatuses | (~ePowerTakeoffStatuses.SetSwitch);
                }
            }
        }


        public bool PtoControlSwitch
        {
            get
            {
                return (m_PowerTakeoffStatuses & ePowerTakeoffStatuses.PtoControlSwitch) == ePowerTakeoffStatuses.PtoControlSwitch;
            }
            set
            {
                if (value)
                {
                    m_PowerTakeoffStatuses = m_PowerTakeoffStatuses | ePowerTakeoffStatuses.PtoControlSwitch | ePowerTakeoffStatuses.PtoMode;
                }
                else
                {
                    m_PowerTakeoffStatuses = m_PowerTakeoffStatuses | (~ePowerTakeoffStatuses.PtoControlSwitch);
                }
            }
        }

        public bool PowerTakeOff()
        {
            return PtoControlSwitch;
        }
        public void PowerTakeOff(bool vValue)
        {
            PtoControlSwitch = vValue;
        }

        #endregion




        public double TotalVehicleDistanceKilometers
        {
            get 
            {
                double dbl;
                lock (m_objVehiclePropertiesLocker)
                {
                    dbl = m_dblTotalVehicleDistanceMeters / 1000;
                }
                return dbl;
            }
            set
            {
                lock (m_objVehiclePropertiesLocker)
                {
                    m_dblTotalVehicleDistanceMeters = value * 1000;
                }
            }
        }


        public void AddTotalVehicleDistanceMeters(double dblValue)
        {
            lock (m_objVehiclePropertiesLocker)
            {
                m_dblTotalVehicleDistanceMeters += dblValue;
            }
        }





        #region object overrides

        public override int GetHashCode()
        {
            return (int)this.ID;
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return this.Equals(obj as ECM);
        }

        #endregion


        #region IEquatable<ECM> Members

        public bool Equals(ECM other)
        {
            if (other == null)
                return false;

            return this.ID == other.ID;
        }

        #endregion


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
                }

                _disposed = true;
            }
        }

        #endregion

    }  // public abstract class ECM

}  // namespace VehicleSimulator

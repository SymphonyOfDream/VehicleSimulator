using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;



namespace VehicleSimulator
{

    public partial class J1587 : ECM
    {

        /// <summary>
        /// J1587 Road Speed
        /// PID: 84
        /// Data: byte
        /// Bit Resolution: 0.805 km/h (0.5 mph)
        /// Transmission Update Period: 0.1 s (100 ms)
        /// Message Priority: 1
        /// </summary>
        public class RoadSpeedMessage : J1587_MessageBase
        {
            public RoadSpeedMessage(J1587 owner)
                : base(owner)
            {
            }


            public override byte PID
            {
                get { return 84; }
            }

            public override byte MessagePriority
            {
                get { return 1; }
            }

            public override long MillisecondsBetweenEmits
            {
                get { return 100; }
            }


            public double BitResolution
            {
                get { return 0.805; }
            }

            public override byte[] EmitMessage()
            {
                lock (m_StateLocker)
                {
                    double dblRoadSpeedKPH
                        = Physics.MetersPerSecond_to_KPH(m_Owner.m_dblVelocityMetersPerSecond);

                    if (dblRoadSpeedKPH < 0)
                        dblRoadSpeedKPH = 0;
                    else if (dblRoadSpeedKPH > 0xFF*BitResolution)
                        dblRoadSpeedKPH = 0xFF * BitResolution;

                    byte byteMsgVal
                        = (byte)(dblRoadSpeedKPH / BitResolution);

                    return new byte[] {
                        (byte)PID,
                        byteMsgVal
                    };
                }  // lock (m_StateLocker)
            }

        }  // class J1587_RoadSpeed : J1587Base

    }  // public partial class J1587 : ECM

}  // namespace VehicleSimulator

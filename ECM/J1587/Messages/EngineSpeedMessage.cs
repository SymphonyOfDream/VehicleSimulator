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
        /// J1587 Engine Speed
        /// PID: 190
        /// Data: ushort (little-endian)
        /// Bit Resolution: 0.25 rpm
        /// Transmission Update Period: 0.1 s (100 ms)
        /// Message Priority: 1
        /// </summary>
        public class EngineSpeedMessage : J1587_MessageBase
        {
            public EngineSpeedMessage(J1587 owner)
                : base(owner)
            {
            }



            public override byte PID
            {
                get { return 190; }
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
                get { return 0.25; }
            }


            public override byte[] EmitMessage()
            {
                lock (m_StateLocker)
                {
                    double dblRPM
                        = m_Owner.m_dblEngineRPM;

                    if (dblRPM < 0)
                        dblRPM = 0;
                    else if (dblRPM > 16383.75)
                        dblRPM = 16383.75;

                    UInt16 ui16MessageVal
                        = (UInt16)(dblRPM / BitResolution);

                    return new byte[] {
                        (byte)PID,
                        (byte)(ui16MessageVal & 0x00FF),
                        (byte)((ui16MessageVal & 0xFF00) >> 8)
                    };
                }  // lock (m_StateLocker)
            }

        }  // class J1587_RoadSpeed : J1587Base

    }  // public partial class J1587 : ECM

}  // namespace VehicleSimulator

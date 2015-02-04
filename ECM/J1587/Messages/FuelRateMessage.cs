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
        /// J1587 Fuel Rate
        /// PID: 183
        /// Data: ushort
        /// Bit Resolution: 16.428E-6 L/s (4.34E-6 gal/s)
        /// Transmission Update Period: 0.2 s (200 ms)
        /// Message Priority: 1
        /// </summary>
        public class FuelRateMessage : J1587_MessageBase
        {
            public FuelRateMessage(J1587 owner)
                : base(owner)
            {
            }


            public override byte PID
            {
                get { return 183; }
            }

            public override byte MessagePriority
            {
                get { return 1; }
            }

            public override long MillisecondsBetweenEmits
            {
                get { return 200; }
            }

            public double BitResolution
            {
                get { return 16.428E-6; }
            }



            public override byte[] EmitMessage()
            {
                lock (m_StateLocker)
                {
                    double dblFuelRateLitersPerSecond;
                    if (m_Owner.m_dblFuelRateLitersPerSecond < 0)
                        dblFuelRateLitersPerSecond = 0;
                    else if (m_Owner.m_dblFuelRateLitersPerSecond > 1.07665)
                        dblFuelRateLitersPerSecond = 1.07665;
                    else
                        dblFuelRateLitersPerSecond = m_Owner.m_dblFuelRateLitersPerSecond;

                    UInt16 ui16MessageVal 
                        = (UInt16)(dblFuelRateLitersPerSecond / BitResolution);

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

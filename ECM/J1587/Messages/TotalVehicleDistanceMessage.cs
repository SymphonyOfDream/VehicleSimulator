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
        /// J1587 Total Vehicle Distance
        /// PID: 245
        /// Data: ulong (little-endian)
        /// Bit Resolution: 0.16 km (0.1 mi)
        /// Transmission Update Period: 10.0 s (10000 ms)
        /// Message Priority: 7
        /// </summary>
        public class TotalVehicleDistanceMessage : J1587_MessageBase
        {
            private const double MAX_KILOMETERS = 0xFFFFFFFF*0.16;

            public TotalVehicleDistanceMessage(J1587 owner)
                : base(owner)
            {
            }


            public override byte PID
            {
                get { return 245; }
            }

            public override byte MessagePriority
            {
                get { return 7; }
            }

            public override long MillisecondsBetweenEmits
            {
                get { return 10000; }
            }

            public double BitResolution
            {
                get { return 0.16; }
            }


            private UInt32? m_ui32PreviousDistanceEmitted = null;

            UInt32 CalculateUInt32TotalDistance
            {
                get
                {
                    double dblTotalDistanceKilometers
                        = m_Owner.m_dblTotalVehicleDistanceMeters / 1000.0;

                    if (dblTotalDistanceKilometers < 0)
                        dblTotalDistanceKilometers = 0;
                    else if (m_Owner.m_dblTotalVehicleDistanceMeters > MAX_KILOMETERS)
                        dblTotalDistanceKilometers = MAX_KILOMETERS;

                    return (UInt32)(dblTotalDistanceKilometers / 0.1609344);//BitResolution);
                }
            }
            public override bool SpecialCaseEmitBeforeTimeoutRequiresEmission
            {
                get
                {
                    if (!m_ui32PreviousDistanceEmitted.HasValue)
                        return false;


                    if (m_ui32PreviousDistanceEmitted != CalculateUInt32TotalDistance)
                        return true;

                    return false;
                }
            }

            public override byte[] EmitMessage()
            {
                lock (m_StateLocker)
                {
                    UInt32 ui32MessageVal = CalculateUInt32TotalDistance;

                    m_ui32PreviousDistanceEmitted = ui32MessageVal;

                    return new byte[] {
                        (byte)PID,
                        4, // byte count???  didn't see in spec, but VB 6 ECM Simulator has this...
                        (byte)(ui32MessageVal & 0x000000FF),
                        (byte)((ui32MessageVal & 0x0000FF00) >> 8),
                        (byte)((ui32MessageVal & 0x00FF0000) >> 16),
                        (byte)((ui32MessageVal & 0xFF000000) >> 24),
                    };
                }  // lock (m_StateLocker)
            }

        }  // class J1587_RoadSpeed : J1587Base

    }  // public partial class J1587 : ECM

}  // namespace VehicleSimulator

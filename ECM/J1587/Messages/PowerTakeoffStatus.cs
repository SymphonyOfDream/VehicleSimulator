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
        /// J1587 Power Takeoff Status
        /// PID: 89
        /// Data: unsigned byte
        /// Bit Resolution: n/a (bit fields)
        /// Transmission Update Period: 1.0 s (1000 ms)
        /// Message Priority: 5
        /// </summary>
        public class PowerTakeoffStatus : J1587_MessageBase
        {

            public PowerTakeoffStatus(J1587 owner)
                : base(owner)
            {
                m_Owner.m_PowerTakeoffStatuses = ePowerTakeoffStatuses.OFF;
            }



            public override byte PID
            {
                get { return 89; }
            }

            public override byte MessagePriority
            {
                get { return 5; }
            }

            public override long MillisecondsBetweenEmits
            {
                get { return 1000; }
            }

            public override byte[] EmitMessage()
            {
                lock (m_StateLocker)
                {

                    return new byte[] {
                        (byte)PID,
                        (byte)m_Owner.m_PowerTakeoffStatuses
                    };
                }  // lock (m_StateLocker)
            }

        }  // class J1587_RoadSpeed : J1587Base

    }  // public partial class J1587 : ECM

}  // namespace VehicleSimulator

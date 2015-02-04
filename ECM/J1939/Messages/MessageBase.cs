using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;



namespace VehicleSimulator
{

    public partial class J1939 : ECM
    {

        public abstract class J1939_MessageBase
        {
            protected J1939_MessageBase(J1939 owner)
            {
                MillisecondsAccumulated = 0;
                m_Owner = owner;
            }

            protected J1939 m_Owner;
            public long MillisecondsAccumulated { get; set; }

            protected object m_StateLocker = new object();

            public abstract byte PID { get; }
            public abstract byte MessagePriority { get; }
            public abstract long MillisecondsBetweenEmits { get; }

            public bool IsEmitRequired(long lMillisecondsSinceLastCheck)
            {
                MillisecondsAccumulated += lMillisecondsSinceLastCheck;

                bool bEmitRequired = MillisecondsAccumulated >= MillisecondsBetweenEmits;
                if (bEmitRequired)
                    MillisecondsAccumulated = 0;

                return bEmitRequired;
            }


            public void ResetEmitTimeout()
            {
                MillisecondsAccumulated = 0;
            }

            public abstract byte[] EmitMessage();
        }  // public abstract class J1587_MessageBase

    }  // public partial class J1939 : ECM

}  // namespace VehicleSimulator

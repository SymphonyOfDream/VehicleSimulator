using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;



namespace VehicleSimulator
{

    public partial class J1587 : ECM
    {

        public abstract class J1587_MessageBase
        {
            protected J1587_MessageBase(J1587 owner)
            {
                MillisecondsAccumulated = 0;
                m_Owner = owner;
            }

            protected J1587 m_Owner;
            public long MillisecondsAccumulated { get; private set; }

            protected object m_StateLocker = new object();

            public abstract byte PID { get; }
            public abstract byte MessagePriority { get; }
            public abstract long MillisecondsBetweenEmits { get; }

            public virtual bool SpecialCaseEmitBeforeTimeoutRequiresEmission { get { return false; } }

            public bool IsEmitRequired(long lMillisecondsSinceLastCheck)
            {
                MillisecondsAccumulated += lMillisecondsSinceLastCheck;

                bool bEmitRequired = MillisecondsAccumulated >= MillisecondsBetweenEmits;
                if (!bEmitRequired)
                    bEmitRequired = SpecialCaseEmitBeforeTimeoutRequiresEmission;

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

    }  // public partial class J1587 : ECM

}  // namespace VehicleSimulator

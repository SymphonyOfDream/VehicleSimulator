using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;



namespace VehicleSimulator
{

    public partial class J1587 : ECM
    {

        #region Message IDs (MIDs)

        public enum eMessageIDs : byte
        {
            Engine1 = 128,
            TurboCharger,
            Transmission,
            PowerTakeoff,
            AxlePowerUnit,
            AxleTrailer1,
            AxleTrailer2,
            AxleTrailer3,
            BrakesPowerUnit,
            BrakesTrailer1,
            BrakesTrailer2,
            BrakesTrailer3,
            InstrumentCluster,
            TripRecorder,
            VehicleManagementSystem,
            FuelSystem,
            CruiseControl,
            RoadSpeedIndicator,
            CabClimateControl,
            CargoRegrigerationHeadingTrailer1,
            CargoRegrigerationHeadingTrailer2,
            CargoRegrigerationHeadingTrailer3,
            SuspensionPowerUnit,
            SuspensionTrailer1,
            SuspensionTrailer2,
            SuspensionTrailer3,
            DiagnosticSystemPowerUnit,
            DiagnosticSystemTrailer1,
            DiagnosticSystemTrailer2,
            DiagnosticSystemTrailer3,
            ElectricalChargingSystem,
            ProximityDetectorFront,
            ProximityDetectorRear,
            AerodynamicControlUnit,
            VehicleNavigationUnit,
            VehicleSecurity,
            Multiplex,
            CommunicationUnitGround,
            TiresPowerUnit,
            TiresTrailer1,
            TiresTrailer2,
            TiresTrailer3,
            Electrical,
            DriverInformationCenter,
            OffboardDiagnostics1,
            EngineRetarder,
            CrankingStartingSystem,
            Engine2 = 175,
            TransmissionAdditional,
            ParticulateTrapSystem,
            VehicleSensors2DataConverter,
            DataLoggingComputer,
            OffboardDiagnostics2,
            CommunicationsUnitSatellite,
            OffboardProgrammingStation,
            Engine3,
            Engine4,
            Engine5,
            Engine6,
            VehicleControlHeadUnit,
            VehicleLogicControlUnit,
            VehicleHeadSigns = 189 //There are more, just not doing them until necessary
        }

        #endregion


        // The list is a priority-based list.  Low index items will have
        // higher ECM priority values.
        Dictionary<eMessageIDs, List<J1587_MessageBase>> m_dictMessageID2J1587
            = new Dictionary<eMessageIDs, List<J1587_MessageBase>>();





        // AddMessage turns the list of messages into a priority queue
        // based on MessagePriority property of messages.
        // This gives us auto-sorting when generating a messages group for
        // any message ID during Emit.
        private void AddMessage(List<J1587_MessageBase> lstMessages,
                                J1587_MessageBase msg)
        {
            for (int idx = 0; idx < lstMessages.Count; ++idx)
            {
                if (msg.MessagePriority <= lstMessages[idx].MessagePriority)
                {
                    lstMessages.Insert(idx, msg);
                    return;
                }
            }

            lstMessages.Add(msg);
        }




        void InitMessages()
        {
            List<J1587_MessageBase> lstMessages = new List<J1587_MessageBase>();

            AddMessage(lstMessages, new RoadSpeedMessage(this));
            AddMessage(lstMessages, new EngineSpeedMessage(this));
            AddMessage(lstMessages, new FuelRateMessage(this));
            AddMessage(lstMessages, new TotalVehicleDistanceMessage(this));
            AddMessage(lstMessages, new PowerTakeoffStatus(this));
            
            m_dictMessageID2J1587.Add(eMessageIDs.Engine1, lstMessages);
        }



        #region CTORs

        public J1587(SerialPort outputSerialPort)
            : base(outputSerialPort)
        {
            InitMessages();
        }


        public J1587(SerialPort outputSerialPort, Stream outputStream2)
            : base(outputSerialPort, outputStream2)
        {
            InitMessages();
        }

        #endregion



        protected override void ResetEmitTimeout()
        {
            foreach (KeyValuePair<eMessageIDs, List<J1587_MessageBase>> kvp in m_dictMessageID2J1587)
            {
                foreach (J1587_MessageBase msg in kvp.Value)
                    msg.ResetEmitTimeout();
            }
        }

        protected override void DoEmit(long lMillisecondsSinceLastEmitRequest)
        {
            // We create and emit a single message for each message ID.
            // For instance, Message ID 128 is Engine #1.
            // Engine #1 could be sending Road Speed (PID 84) and RPM (PID 190)

            foreach (KeyValuePair<eMessageIDs, List<J1587_MessageBase>> kvp in m_dictMessageID2J1587)
            {
                List<byte[]> lstMessages = new List<byte[]>();

                int iTotalMsgByteCount = 0;
                foreach (J1587_MessageBase msg in kvp.Value)
                {
                    // Does the current message need to be sent?
                    if (msg.IsEmitRequired(lMillisecondsSinceLastEmitRequest))
                    {
                        byte[] abyteMsgBytes = msg.EmitMessage();

                        if (abyteMsgBytes != null && abyteMsgBytes.Length > 0)
                        {
                            lstMessages.Add(abyteMsgBytes);
                            iTotalMsgByteCount += abyteMsgBytes.Length;
                        }
                    }
                }


                if (iTotalMsgByteCount < 1)
                    continue;


                // Total length = all message bytes 
                //              + 1 header byte 
                //              + 1 checksum byte
                byte[] abyteFullMsg = new byte[iTotalMsgByteCount + 1 + 1];

                // Put message ID's value into index 0
                abyteFullMsg[0] = (byte)kvp.Key;

                // Reset variable to keep track of byte array insertion index
                iTotalMsgByteCount = 0;
                foreach (byte[] abyte in lstMessages)
                {
                    // '1 +' because the Message ID is at index 0
                    abyte.CopyTo(abyteFullMsg, 1 + iTotalMsgByteCount);
                    iTotalMsgByteCount += abyte.Length;
                }

                int iRunningChecksum = 0;
                // '- 1' for check because the array has room for the 
                // checksum byte, but we don't need to include it in our
                // running calculation of checksum.
                for (int idx = 0; idx < abyteFullMsg.Length - 1; ++idx)
                {
                    iRunningChecksum += abyteFullMsg[idx];
                }

                byte byteChecksum = (byte)(0 - (byte)iRunningChecksum);

                iRunningChecksum += byteChecksum;

                abyteFullMsg[abyteFullMsg.Length - 1] = byteChecksum;

                if (SerialPort != null)
                {
                    try
                    {
                        SerialPort.Write(abyteFullMsg, 0, abyteFullMsg.Length);
                    }
                    catch { ; }
                }
                if (StreamOutput2 != null)
                {
                    try
                    {
                        StreamOutput2.Write(abyteFullMsg, 0, abyteFullMsg.Length);
                    }
                    catch { ; }
                }

            }  // foreach (KeyValuePair<eMessageIDs, List<J1587_MessageBase>> kvp in m_dictMessageID2J1587)
        }



        private List<J1587_MessageBase> GetListOfMessages(eMessageIDs messageID)
        {
            List<J1587_MessageBase> lstMessages;
            if (!m_dictMessageID2J1587.TryGetValue(messageID, out lstMessages))
            {
                lstMessages = new List<J1587_MessageBase>();
                m_dictMessageID2J1587.Add(messageID, lstMessages);
            }

            return lstMessages;
        }


    }  // public class J1587

}  // namespace VehicleSimulator

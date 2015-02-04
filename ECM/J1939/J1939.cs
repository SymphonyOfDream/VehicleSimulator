using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;



namespace VehicleSimulator
{

    public partial class J1939 : ECM
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


        // Each message ID seems to represent the source of a message
        // (i.e., 128 is Engine # 1, so any messages from Engine #1 would have
        //  a message header byte value of 128).
        Dictionary<eMessageIDs, List<J1939_MessageBase>> m_dictMessageID2J1939
            = new Dictionary<eMessageIDs, List<J1939_MessageBase>>();


        #region CTORs

        public J1939(SerialPort outputSerialPort)
            : base(outputSerialPort)
        {
        }

        public J1939(SerialPort outputSerialPort, Stream outputStream2)
            : base(outputSerialPort, outputStream2)
        {
        }

        #endregion



        protected override void ResetEmitTimeout()
        {
            foreach (KeyValuePair<eMessageIDs, List<J1939_MessageBase>> kvp in m_dictMessageID2J1939)
            {
                foreach (J1939_MessageBase msg in kvp.Value)
                    msg.ResetEmitTimeout();
            }
        }


        protected override void DoEmit(long lMillisecondsSinceLastEmitRequest)
        {
            // We create and emit a single message for each message ID.
            // For instance, Message ID 128 is Engine #1.
            // Engine #1 could be sending Road Speed (PID 84) and RPM (PID 190)

            foreach (KeyValuePair<eMessageIDs, List<J1939_MessageBase>> kvp in m_dictMessageID2J1939)
            {
                List<byte[]> lstMessages = new List<byte[]>();

                int iTotalMsgByteCount = 0;
                foreach (J1939_MessageBase msg in kvp.Value)
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

                int iChecksum = 0;
                // '- 1' for check because the array has room for the 
                // checksum byte, but we don't need to include it in our
                // running calculation of checksum.
                for (int idx = 0; idx < abyteFullMsg.Length - 1; ++idx)
                {
                    iChecksum += abyteFullMsg[idx];
                }

                abyteFullMsg[abyteFullMsg.Length - 1] = (byte)(0 - (byte)iChecksum);

                if (SerialPort != null)
                {
                    SerialPort.Write(abyteFullMsg, 0, abyteFullMsg.Length);
                }
                if (StreamOutput2 != null)
                {
                    StreamOutput2.Write(abyteFullMsg, 0, abyteFullMsg.Length);
                }

            }  // foreach (KeyValuePair<eMessageIDs, List<J1939_MessageBase>> kvp in m_dictMessageID2J1939)
        }



        private List<J1939_MessageBase> GetListOfMessages(eMessageIDs messageID)
        {
            List<J1939_MessageBase> lstMessages;
            if (!m_dictMessageID2J1939.TryGetValue(messageID, out lstMessages))
            {
                lstMessages = new List<J1939_MessageBase>();
                m_dictMessageID2J1939.Add(messageID, lstMessages);
            }

            return lstMessages;
        }


        // AddMessage turns the list of messages into a priority queue
        // based on MessagePriority property of messages.
        // This gives us auto-sorting when generating a messages group for
        // any message ID during Emit.
        private void AddMessage(List<J1939_MessageBase> lstMessages,
                                J1939_MessageBase msg)
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


/*TODO

        #region Public Methods

        private RoadSpeedMessage GetRoadSpeedMessage(eMessageIDs messageID)
        {
            List<J1939_MessageBase> lstMessages = GetListOfMessages(messageID);

            J1939_MessageBase returnMsg = null;
            foreach (J1939_MessageBase msg in lstMessages)
            {
                if (msg is RoadSpeedMessage)
                {
                    returnMsg = msg;
                    break;
                }
            }

            if (returnMsg == null)
            {
                returnMsg = new RoadSpeedMessage();
                AddMessage(lstMessages, returnMsg);
            }


            return (RoadSpeedMessage)returnMsg;
        }

        public double RoadSpeedKPH(eMessageIDs messageID)
        {
            return GetRoadSpeedMessage(messageID).RoadSpeedKPH;
        }
        public void RoadSpeedKPH(eMessageIDs messageID, double dblValue)
        {
            GetRoadSpeedMessage(messageID).RoadSpeedKPH = dblValue;
        }


        private EngineSpeedMessage GetEngineSpeedMessage(eMessageIDs messageID)
        {
            List<J1939_MessageBase> lstMessages = GetListOfMessages(messageID);

            J1939_MessageBase returnMsg = null;
            foreach (J1939_MessageBase msg in lstMessages)
            {
                if (msg is EngineSpeedMessage)
                {
                    returnMsg = msg;
                    break;
                }
            }

            if (returnMsg == null)
            {
                returnMsg = new EngineSpeedMessage();
                AddMessage(lstMessages, returnMsg);
            }


            return (EngineSpeedMessage)returnMsg;
        }

        public double EngineRPM(eMessageIDs messageID)
        {
            return GetEngineSpeedMessage(messageID).RPM;
        }
        public void EngineRPM(eMessageIDs messageID, double dblValue)
        {
            GetEngineSpeedMessage(messageID).RPM = dblValue;
        }



        private FuelRateMessage GetFuelRateMessage(eMessageIDs messageID)
        {
            List<J1939_MessageBase> lstMessages = GetListOfMessages(messageID);

            J1939_MessageBase returnMsg = null;
            foreach (J1939_MessageBase msg in lstMessages)
            {
                if (msg is FuelRateMessage)
                {
                    returnMsg = msg;
                    break;
                }
            }

            if (returnMsg == null)
            {
                returnMsg = new FuelRateMessage();
                AddMessage(lstMessages, returnMsg);
            }


            return (FuelRateMessage)returnMsg;
        }

        public double FuelRateLitersPerSecond(eMessageIDs messageID)
        {
            return GetFuelRateMessage(messageID).FuelRateLitersPerSecond;
        }
        public void FuelRateLitersPerSecond(eMessageIDs messageID, double dblValue)
        {
            GetFuelRateMessage(messageID).FuelRateLitersPerSecond = dblValue;
        }



        private TotalVehicleDistanceMessage GetTotalVehicleDistanceMessage(eMessageIDs messageID)
        {
            List<J1939_MessageBase> lstMessages = GetListOfMessages(messageID);

            J1939_MessageBase returnMsg = null;
            foreach (J1939_MessageBase msg in lstMessages)
            {
                if (msg is TotalVehicleDistanceMessage)
                {
                    returnMsg = msg;
                    break;
                }
            }

            if (returnMsg == null)
            {
                returnMsg = new TotalVehicleDistanceMessage();
                AddMessage(lstMessages, returnMsg);
            }


            return (TotalVehicleDistanceMessage)returnMsg;
        }

        public double TotalVehicleDistanceKilometers(eMessageIDs messageID)
        {
            return GetTotalVehicleDistanceMessage(messageID).TotalDistanceKilometers;
        }
        public void TotalVehicleDistanceKilometers(eMessageIDs messageID, double dblValue)
        {
            GetTotalVehicleDistanceMessage(messageID).TotalDistanceKilometers = dblValue;
        }



        private AtcControlStatusMessage GetAtcControlStatusMessage(eMessageIDs messageID)
        {
            List<J1939_MessageBase> lstMessages;
            if (!m_dictMessageID2J1939.TryGetValue(messageID, out lstMessages))
            {
                lstMessages = new List<J1939_MessageBase>();
                m_dictMessageID2J1939.Add(messageID, lstMessages);
            }

            J1939_MessageBase returnMsg = null;
            foreach (J1939_MessageBase msg in lstMessages)
            {
                if (msg is AtcControlStatusMessage)
                {
                    returnMsg = msg;
                    break;
                }
            }

            if (returnMsg == null)
            {
                returnMsg = new AtcControlStatusMessage();
                lstMessages.Add(returnMsg);
            }


            return (AtcControlStatusMessage)returnMsg;
        }

        public AtcControlStatusMessage.eAtcControlStatuses 
        AtcControlStatus(eMessageIDs messageID, 
                         AtcControlStatusMessage.eAtcControls atcControl)
        {
            return GetAtcControlStatusMessage(messageID)[atcControl];
        }


        public void AtcControlStatus(eMessageIDs messageID, 
                                     AtcControlStatusMessage.eAtcControls atcControl,
                                     AtcControlStatusMessage.eAtcControlStatuses atcControlStatus)
        {
            GetAtcControlStatusMessage(messageID)[atcControl] = atcControlStatus;
        }


        #endregion
*/
    }  // public class J1939

}  // namespace VehicleSimulator

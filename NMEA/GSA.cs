using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/* FROM:  http://www.gpsinformation.org/dale/nmea.htm#GSA

GSA - GPS DOP and active satellites. This sentence provides details on the nature of the fix.

 $GPGSA,A,3,04,05,,09,12,,,24,,,,,2.5,1.3,2.1*39

Where:
     GSA      Satellite status
     A        Auto selection of 2D or 3D fix (M = manual) 
     3        3D fix - values include: 1 = no fix
                                       2 = 2D fix
                                       3 = 3D fix
     04,05... PRNs of satellites used for fix (space for 12) 
     2.5      PDOP (dilution of precision) 
     1.3      Horizontal dilution of precision (HDOP) 
     2.1      Vertical dilution of precision (VDOP)
     *39      the checksum data, always begins with *
*/

namespace VehicleSimulator
{

    public class GSA : NMEA
    {
        public enum eFixSelectionType
        {
            Auto,
            Manual
        }

        public enum eFixType
        {
            FixNone=1,
            Fix2D=2,
            Fix3D=3
        }


        public eFixSelectionType FixSelectionType { get; set; }
        public eFixType FixType { get; set; }

        public byte?[] SatellitePRNs { get; set; }

        public float DilutionOfPrecision { get; set; }
        public float HorizontalDilutionOfPrecision { get; set; }
        public float VerticalDilutionOfPrecision { get; set; }


        #region CTORs

        public GSA()
        {
            FixSelectionType = eFixSelectionType.Auto;

            FixType = eFixType.Fix3D;

            SatellitePRNs = new byte?[12];
            for (int idx = 0; idx < SatellitePRNs.Length; ++idx)
            {
                SatellitePRNs[idx] = null;
            }
            SatellitePRNs[0] = 12;
            SatellitePRNs[1] = 4;
            SatellitePRNs[2] = 3;
            SatellitePRNs[5] = 22;
            SatellitePRNs[9] = 15;

            DilutionOfPrecision = 2.5f;
            HorizontalDilutionOfPrecision = 1.3f;
            VerticalDilutionOfPrecision = 2.1f;
        }

        #endregion


        public override string ToString()
        {
            string strNmeaSentence
                = string.Format("$GPGSA,{0},{1},",
                                (FixSelectionType == eFixSelectionType.Auto ? 'A' : 'M'),
                                (int)FixType);

            string strSatPRNs = "";
            foreach (byte? byteVal in SatellitePRNs)
            {
                if (byteVal.HasValue)
                    strSatPRNs += string.Format("{0:00},", byteVal.Value);
                else
                    strSatPRNs += ",";
            }

            strNmeaSentence += strSatPRNs;

            strNmeaSentence += string.Format("{0},{1},{2},",
                                             DilutionOfPrecision,
                                             HorizontalDilutionOfPrecision,
                                             VerticalDilutionOfPrecision);

            strNmeaSentence += "*" + CalculateNmeaSentenceChecksum(strNmeaSentence).ToString("X2");

            return strNmeaSentence;
        }

    }  // public class GSA : NMEA

}  // namespace VehicleSimulator

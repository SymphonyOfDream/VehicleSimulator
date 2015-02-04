using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/* FROM:  http://www.gpsinformation.org/dale/nmea.htm#GSA

GSV - Satellites in View shows data about the satellites that the unit might 
 *    be able to find based on its viewing mask and almanac data. It also shows 
 *    current ability to track this data. Note that one GSV sentence only can 
 *    provide data for up to 4 satellites and thus there may need to be 3 
 *    sentences for the full information. It is reasonable for the GSV sentence 
 *    to contain more satellites than GGA might indicate since GSV may include 
 *    satellites that are not used as part of the solution. It is not a requirment 
 *    that the GSV sentences all appear in sequence.

 $GPGSV,2,1,08,01,40,083,46,02,17,308,41,12,07,344,39,14,22,228,45*75

Where:
      GSV          Satellites in view
      2            Number of sentences for full data
      1            sentence 1 of 2
      08           Number of satellites in view

      01           Satellite PRN number
      40           Elevation, degrees
      083          Azimuth, degrees
      46           SNR - higher is better
           for up to 4 satellites per sentence
      *75          the checksum data, always begins with *
*/

namespace VehicleSimulator
{

    public class GSV : NMEA
    {
        public byte SentencesForFullData { get; set; }
        public byte SatellitesInViewCount { get; set; }

        public class SatelliteData
        {
            public byte PRN { get; set; }
            public int Elevation { get; set; }
            public int Azimuth { get; set; }
            public byte SNR { get; set; }
        }  // public class SatelliteData

        public List<SatelliteData> Satellites { get; set; }


        #region CTORs

        public GSV()
        {
            SentencesForFullData = 2;
            SatellitesInViewCount = 8;

            Satellites = new List<SatelliteData>();
            Satellites.Add(new SatelliteData() { PRN = 01, Elevation = 40, Azimuth = 83, SNR = 46 });
            Satellites.Add(new SatelliteData() { PRN = 02, Elevation = 50, Azimuth = 83, SNR = 47 });
        }

        #endregion


        public override string ToString()
        {
            string strNmeaSentence = "";

            for (int idx = 0; idx < Satellites.Count; ++idx)
            {
                if (strNmeaSentence.Length > 0)
                    strNmeaSentence += "\n";

                strNmeaSentence 
                    += string.Format("$GPGSV,{0},{1},{2:00},{3:00},{4:00},{5:000},{6:00},*",
                                     SentencesForFullData,
                                     idx + 1,
                                     SatellitesInViewCount,
                                     Satellites[idx].PRN,
                                     Satellites[idx].Elevation,
                                     Satellites[idx].Azimuth,
                                     Satellites[idx].SNR);

                strNmeaSentence += CalculateNmeaSentenceChecksum(strNmeaSentence).ToString("X2");
            }

            return strNmeaSentence;
        }

    }  // public class GSV : NMEA

}  // namespace VehicleSimulator


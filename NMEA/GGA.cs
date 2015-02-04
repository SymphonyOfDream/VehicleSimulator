using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



/*  FROM:  http://www.gpsinformation.org/dale/nmea.htm#GGA

GGA - essential fix data which provide 3D location and accuracy data.

 $GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M,,*47

Where:
     GGA          Global Positioning System Fix Data
     123519       Fix taken at 12:35:19 UTC
     4807.038,N   Latitude 48 deg 07.038' N
     01131.000,E  Longitude 11 deg 31.000' E
     1            Fix quality: 0 = invalid
                               1 = GPS fix (SPS)
                               2 = DGPS fix
                               3 = PPS fix
			       4 = Real Time Kinematic
			       5 = Float RTK
                               6 = estimated (dead reckoning) (2.3 feature)
			       7 = Manual input mode
			       8 = Simulation mode
     08           Number of satellites being tracked
     0.9          Horizontal dilution of position
     545.4,M      Altitude, Meters, above mean sea level
     46.9,M       Height of geoid (mean sea level) above WGS84
                      ellipsoid
     (empty field) time in seconds since last DGPS update
     (empty field) DGPS station ID number
     *47          the checksum data, always begins with *
*/

namespace VehicleSimulator
{

    public class GGA : NMEA
    {
        public enum eFixQuality
        {
            Invalid = 0,
            GPS_SPS,
            DGPS,
            PPS,
            RealTimeKinematic,
            FloatRTK,
            EstimatedDeadReckoning,
            ManualInputMode,
            SimulationMode
        }

        public DateTime FixTimeUTC { get; set; }
        public double LatitudeDecimalDegrees { get; set; }
        public double LongitudeDecimalDegrees { get; set; }
        public eFixQuality FixQuality { get; set; }
        public int SatelliteCount { get; set; }
        public double HorizontalDilutionOfPosition { get; set; }
        public float AltitudeMeters { get; set; }
        public float HeightOfGeoidMeters { get; set; }


        #region CTORs

        public GGA()
        {
            FixTimeUTC = DateTime.UtcNow;
            LatitudeDecimalDegrees = 0;
            LongitudeDecimalDegrees = 0;
            FixQuality = eFixQuality.GPS_SPS;
            SatelliteCount = 0;
            HorizontalDilutionOfPosition = 0;
            AltitudeMeters = 0;
            HeightOfGeoidMeters = 0;
        }


        public GGA(VehicleSimulator.Location location)
            : this()
        {
            if (location != null && location.IsValid)
            {
                LatitudeDecimalDegrees = location.Latitude.Value;
                LongitudeDecimalDegrees = location.Longitude.Value;
                FixQuality = eFixQuality.GPS_SPS;
                SatelliteCount = 5;
            }
        }

        #endregion


        public override string ToString()
        {
            DateTime utcNow = DateTime.UtcNow;
            string strGpsTime = string.Format("{0:00}{1:00}{2:00}", 
                                              utcNow.Hour, 
                                              utcNow.Minute, 
                                              utcNow.Second);


            double dblLatitudeNmeaFormat;
            char cLatitudeDirection;
            ConvertDecimalDegreesLatitudeToNmea(LatitudeDecimalDegrees,
                                                out dblLatitudeNmeaFormat,
                                                out cLatitudeDirection);


            double dblLongitudeNmeaFormat;
            char cLongitudeDirection;
            ConvertDecimalDegreesLongitudeToNmea(LongitudeDecimalDegrees,
                                                 out dblLongitudeNmeaFormat,
                                                 out cLongitudeDirection);

            string strNmeaSentence
                = string.Format("$GPGGA,{0},{1:0000.0000},{2},{3:00000.0000},{4},{5},{6:00},{7:0.0},{8},M,{9},M,,*",
                                 strGpsTime,  // 0
                                 dblLatitudeNmeaFormat,   // 1
                                 cLatitudeDirection,  // 2
                                 dblLongitudeNmeaFormat,   // 3
                                 cLongitudeDirection,  // 4
                                 (int)FixQuality,  // 5
                                 SatelliteCount,  // 6
                                 HorizontalDilutionOfPosition,  // 7
                                 AltitudeMeters,  // 8
                                 HeightOfGeoidMeters);  // 9

            strNmeaSentence += CalculateNmeaSentenceChecksum(strNmeaSentence).ToString("X2");

            return strNmeaSentence;
        }

    }  // public class GGA : NMEA

}  // namespace VehicleSimulator

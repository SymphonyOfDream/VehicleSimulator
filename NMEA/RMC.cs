using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



/*  FROM:  http://www.gpsinformation.org/dale/nmea.htm#RMC

RMC - essential gps pvt (position, velocity, time) data.

 $GPRMC,123519,A,4807.038,N,01131.000,E,022.4,084.4,230394,003.1,W*6A

Where:
     RMC          Recommended Minimum sentence C
     123519       Fix taken at 12:35:19 UTC
     A            Status A=active or V=Void.
     4807.038,N   Latitude 48 deg 07.038' N
     01131.000,E  Longitude 11 deg 31.000' E
     022.4        Speed over the ground in knots
     084.4        Track angle in degrees True
     230394       Date - 23rd of March 1994
     003.1,W      Magnetic Variation
     *6A          The checksum data, always begins with *
*/

namespace VehicleSimulator
{

    public class RMC : NMEA
    {
        public enum eFixStatus
        {
            Active,
            Void
        }

        public DateTime FixTimeUTC { get; set; }
        public eFixStatus FixStatus { get; set; }

        public double LatitudeDecimalDegrees { get; set; }
        public double LongitudeDecimalDegrees { get; set; }

        public double Velocity { get; set; }

        public double TrackAngle { get; set; }

        public double MagneticVariationDecimalDegrees { get; set; }


        #region CTORs

        public RMC()
        {
            FixTimeUTC = DateTime.UtcNow;
            FixStatus = eFixStatus.Void;
            LatitudeDecimalDegrees = 0;
            LongitudeDecimalDegrees = 0;
            Velocity = 0;
            TrackAngle = 0;
            MagneticVariationDecimalDegrees = 0;
        }


        public RMC(VehicleSimulator.Location location)
            : this()
        {
            if (location != null && location.IsValid)
            {
                FixStatus = eFixStatus.Active;

                LatitudeDecimalDegrees = location.Latitude.Value;
                LongitudeDecimalDegrees = location.Longitude.Value;
            }
        }


        public RMC(double dblVelocity, double dblTrackAngle, VehicleSimulator.Location location)
            : this(location)
        {
            Velocity = dblVelocity;
            TrackAngle = dblTrackAngle;
        }

        #endregion


        public override string ToString()
        {
            DateTime utcNow = DateTime.UtcNow;
            string strGpsTime = string.Format("{0:00}{1:00}{2:00}",
                                              utcNow.Hour,
                                              utcNow.Minute,
                                              utcNow.Second);

            int iYear = utcNow.Year / 100;
            iYear = utcNow.Year - (iYear * 100);

            string strGpsDate = string.Format("{0:00}{1:00}{2:00}",
                                              utcNow.Day,
                                              utcNow.Month,
                                              iYear);


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



            double dblMagneticVariation;
            char cMagneticVariationDirection;
            ConvertDecimalDegreesLatitudeToNmea(MagneticVariationDecimalDegrees,
                                                out dblMagneticVariation,
                                                out cMagneticVariationDirection);

            string strNmeaSentence
                = string.Format("$GPRMC,{0},{1},{2:0000.0000},{3},{4:00000.0000},{5},{6:000.0},{7:000.0},{8},{9:000.0},{10},*",
                                 strGpsTime,  // 0
                                 (FixStatus == eFixStatus.Active ? 'A' : 'V'),  // 1
                                 dblLatitudeNmeaFormat,   // 2
                                 cLatitudeDirection,  // 3
                                 dblLongitudeNmeaFormat,   // 4
                                 cLongitudeDirection,  // 5
                                 Velocity,
                                 TrackAngle,
                                 strGpsDate,
                                 dblMagneticVariation,
                                 cMagneticVariationDirection);


            strNmeaSentence += CalculateNmeaSentenceChecksum(strNmeaSentence).ToString("X2");

            return strNmeaSentence;
        }

    }  // public class RMC : NMEA

}  // namespace VehicleSimulator

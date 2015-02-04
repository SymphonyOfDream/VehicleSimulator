using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace VehicleSimulator
{

    public abstract class NMEA
    {

        protected static byte CalculateNmeaSentenceChecksum(string strNmeaSentence)
        {
            if (strNmeaSentence == null)
            {
                throw new ArgumentNullException();
            }
            if (strNmeaSentence[0] != '$')
            {
                throw new ArgumentOutOfRangeException("NMEA Sentence 1st character is not a '$'");
            }

            byte byteCalculatedChecksum = 0;
            bool bStartedCalculating = false;

            // Leading '$' not used in checksum calculation
            for (int idx = 1; idx < strNmeaSentence.Length; ++idx)
            {
                if (strNmeaSentence[idx] == '*')
                {
                    break;
                }

                if (!bStartedCalculating)
                {
                    bStartedCalculating = true;
                    byteCalculatedChecksum = (byte)(strNmeaSentence[idx]);
                }
                else
                {
                    byteCalculatedChecksum ^= (byte)(strNmeaSentence[idx]);
                }
            }  // for (int idx = 0; idx < strNmeaSentence.Length; ++idx)

            return byteCalculatedChecksum;
        }


        protected static double? ConvertNmeaLongitudeToDecimalDegrees(string strNmeaLongitude, string strNmeaDirection)
        {
            try
            {
                string strDMSWholeNumber = strNmeaLongitude.Substring(0, 3);
                string strDMSFractionalPart = strNmeaLongitude.Substring(3);

                double dblLongitude
                    = System.Convert.ToDouble(strDMSWholeNumber)
                    + System.Convert.ToDouble(strDMSFractionalPart) / 60.0;

                if (strNmeaDirection.ToUpper() == "W")
                {
                    dblLongitude = -dblLongitude;
                }

                return dblLongitude;
            }
            catch { ;}

            return null;
        }

        protected static double? ConvertNmeaLatitudeToDecimalDegrees(string strNmeaLatitude, string strNmeaDirection)
        {
            try
            {
                string strDMSWholeNumber = strNmeaLatitude.Substring(0, 2);
                string strDMSFractionalPart = strNmeaLatitude.Substring(2);

                double dblLatitude
                    = System.Convert.ToDouble(strDMSWholeNumber)
                    + System.Convert.ToDouble(strDMSFractionalPart) / 60.0;

                if (strNmeaDirection == "S")
                {
                    dblLatitude = -dblLatitude;
                }
                return dblLatitude;
            }
            catch { ;}

            return null;
        }


        protected static void ConvertDecimalDegreesLongitudeToNmea(double dblDecimalDegreesLongitude,
                                                                   out double dblNmeaLongitude,
                                                                   out char cDirection)
        {
            int degrees = (int)Math.Abs(dblDecimalDegreesLongitude) * 100;
            double dblRemainder = Math.Abs(dblDecimalDegreesLongitude) - ((int)Math.Abs(dblDecimalDegreesLongitude));
            dblRemainder *= 60;

            dblNmeaLongitude = degrees + dblRemainder;

            if (dblDecimalDegreesLongitude < 0)
                cDirection = 'W';
            else
                cDirection = 'E';
        }


        protected static void ConvertDecimalDegreesLatitudeToNmea(double dblDecimalDegreesLatitude,
                                                                  out double dblNmeaLatitude,
                                                                  out char cDirection)
        {
            int degrees = (int)Math.Abs(dblDecimalDegreesLatitude) * 100;
            double dblRemainder = Math.Abs(dblDecimalDegreesLatitude) - ((int)Math.Abs(dblDecimalDegreesLatitude));
            dblRemainder *= 60;

            dblNmeaLatitude = degrees + dblRemainder;

            if (dblDecimalDegreesLatitude < 0)
                cDirection = 'S';
            else
                cDirection = 'N';
        }

    }  // public abstract class NMEA

}  // namespace VehicleSimulator

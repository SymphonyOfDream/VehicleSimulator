using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;



namespace VehicleSimulator
{
    /// <summary>
    /// The Location class encapsulates a Latitude and Longitude.
    /// </summary>
    public class Location : IEquatable<Location>, ICloneable
    {
        private double? m_dblLongitude;
        /// <summary>
        /// Gets/Sets a Longitude value in decimal degrees.
        /// </summary>
        public double? Longitude
        {
            get { return m_dblLongitude; }
            set
            {
                if (value.HasValue)
                    if (m_byteLongitudePrecision < 255)
                        m_dblLongitude = Math.Round(value.Value, m_byteLongitudePrecision);
                    else
                        m_dblLongitude = value;
                else
                    m_dblLongitude = null;
            }
        }


        private double? m_dblLatitude;
        /// Gets/Sets a Latitude value in decimal degrees.
        public double? Latitude
        {
            get { return m_dblLatitude; }
            set
            {
                if (value.HasValue)
                    if (m_byteLongitudePrecision < 255)
                        m_dblLatitude = Math.Round(value.Value, m_byteLatitudePrecision);
                    else
                        m_dblLatitude = value;
                else
                    m_dblLongitude = null;
            }
        }

        /// <summary>
        /// Gets/Sets the Date/Time of a Latitude/Longitude creation/fix.
        /// </summary>
        public DateTime? DateTimeFix { get; set; }


        private byte m_byteLongitudePrecision = 255;
        public byte LongitudePrecision
        {
            get { return m_byteLongitudePrecision; }
            set
            {
                m_byteLongitudePrecision = value;
                if (m_dblLongitude.HasValue && m_byteLongitudePrecision < 255)
                    m_dblLongitude = Math.Round(m_dblLongitude.Value, m_byteLongitudePrecision);
            }
        }

        private byte m_byteLatitudePrecision = 255;
        public byte LatitudePrecision
        {
            get { return m_byteLatitudePrecision; }
            set
            {
                m_byteLatitudePrecision = value;
                if (m_dblLatitude.HasValue && m_byteLongitudePrecision < 255)
                    m_dblLatitude = Math.Round(m_dblLatitude.Value, m_byteLatitudePrecision);
            }
        }


        public byte Precision
        {
            set
            {
                m_byteLatitudePrecision = value;
                m_byteLongitudePrecision = value;

                if (m_dblLongitude.HasValue && m_byteLongitudePrecision < 255)
                    m_dblLongitude = Math.Round(m_dblLongitude.Value, m_byteLongitudePrecision);
                if (m_dblLatitude.HasValue && m_byteLongitudePrecision < 255)
                    m_dblLatitude = Math.Round(m_dblLatitude.Value, m_byteLatitudePrecision);
            }
        }

        #region CTORs

        protected Location()
        {
            this.Longitude = null;
            this.Latitude = null;
            this.DateTimeFix = null;
        }


        /// <summary>
        /// CTOR.
        /// </summary>
        /// <param name="dblLongitude">Longitude in decimal degrees.</param>
        /// <param name="dblLatitude">Latitude in decimal degrees.</param>
        /// <remarks>If either parameter is not in valid range, then an
        /// invalid Locaiton object is constructed.</remarks>
        public Location(double dblLongitude,
                        double dblLatitude)
        {
            if (Location.IsValidLongitude(dblLongitude) && Location.IsValidLatitude(dblLatitude))
            {
                this.Longitude = dblLongitude;
                this.Latitude = dblLatitude;
            }
            else
            {
                this.Longitude = null;
                this.Latitude = null;
            }
            this.DateTimeFix = null;
        }


        /// <summary>
        /// CTOR.
        /// </summary>
        /// <param name="dblLongitude">Longitude in decimal degrees.</param>
        /// <param name="dblLatitude">Latitude in decimal degrees.</param>
        /// <remarks>If either parameter is not in valid range, then an
        /// invalid Locaiton object is constructed.</remarks>
        public Location(double? dblLongitude,
                        double? dblLatitude)
        {
            if (dblLongitude.HasValue == true || dblLatitude.HasValue == true)
            {
                if (Location.IsValidLongitude(dblLongitude.Value) && Location.IsValidLatitude(dblLatitude.Value))
                {
                    this.Longitude = dblLongitude.Value;
                    this.Latitude = dblLatitude.Value;
                }
                else
                {
                    this.Longitude = null;
                    this.Latitude = null;
                }
            }
            else
            {
                this.Longitude = null;
                this.Latitude = null;
            }
            this.DateTimeFix = null;
        }


        public Location(string strLongitude,
                        string strLatitude)
        {
            double? dblLongitude = null;
            try
            {
                dblLongitude = System.Convert.ToDouble(strLongitude);
            }
            catch
            {
                ;
            }

            double? dblLatitude = null;
            try
            {
                dblLatitude = System.Convert.ToDouble(strLatitude);
            }
            catch
            {
                ;
            }

            if (dblLongitude.HasValue == true || dblLatitude.HasValue == true)
            {
                if (Location.IsValidLongitude(dblLongitude.Value) && Location.IsValidLatitude(dblLatitude.Value))
                {
                    this.Longitude = dblLongitude.Value;
                    this.Latitude = dblLatitude.Value;
                }
                else
                {
                    this.Longitude = null;
                    this.Latitude = null;
                }
            }
            else
            {
                this.Longitude = null;
                this.Latitude = null;
            }
            this.DateTimeFix = null;
        }


        /// <summary>
        /// CTOR.
        /// </summary>
        /// <param name="iDegreesLongitude">Degrees Longitude</param>
        /// <param name="iMinutesLongitude">Minutes Longitude</param>
        /// <param name="dblSecondsLongitude">Seconds Longitude</param>
        /// <param name="iDegreesLatitude">Degrees Latitude</param>
        /// <param name="iMinutesLatitude">Minutes Latitude</param>
        /// <param name="dblSecondsLatitude">Seconds Latitude</param>
        public Location(int iDegreesLongitude, int iMinutesLongitude, double dblSecondsLongitude,
                        int iDegreesLatitude, int iMinutesLatitude, double dblSecondsLatitude)
        {
            this.Longitude = Location.FromDegreesMinutesSeconds(iDegreesLongitude, iMinutesLongitude, dblSecondsLongitude);
            this.Latitude = Location.FromDegreesMinutesSeconds(iDegreesLatitude, iMinutesLatitude, dblSecondsLatitude);
            this.DateTimeFix = null;
        }


        /// <summary>
        /// Copy CTOR.
        /// </summary>
        /// <param name="source">Location object that we are making a copy of.</param>
        public Location(Location source)
        {
            this.Longitude = source.Longitude;
            this.Latitude = source.Latitude;
            this.DateTimeFix = source.DateTimeFix;
        }

        #endregion


        /// <summary>
        /// Creates a decimal degree value from Degrees/Minutes/Seconds
        /// </summary>
        /// <param name="iDegrees">Degrees</param>
        /// <param name="iMinutes">Minutes</param>
        /// <param name="dblSeconds">Seconds</param>
        /// <returns></returns>
        static public double FromDegreesMinutesSeconds(int iDegrees,
                                                       int iMinutes,
                                                       double dblSeconds)
        {
            if (dblSeconds > 60.0)
            {
                int iExtraMinutes = (int)(dblSeconds / 60);
                iMinutes += iExtraMinutes;
                dblSeconds -= iExtraMinutes * 60.0;
            }
            if (iMinutes > 60)
            {
                int iExtraDegrees = iMinutes / 60;
                iDegrees += iExtraDegrees;
                iMinutes -= iExtraDegrees * 60;
            }

            return (double)iDegrees + (iMinutes / 60.0) + (dblSeconds / 3600.0);
        }


        /// <summary>
        /// Easy way to explicitly create an invalid Location object.
        /// </summary>
        /// <returns>Invalid Location object.</returns>
        static public Location CreateInvalidLocation()
        {
            return new Location();
        }


        public void SetInvalid()
        {
            this.Longitude = null;
            this.Latitude = null;
            this.DateTimeFix = null;
        }

        /// <summary>
        /// Returns true iff both Latitude and Longitude are within their
        /// respective allowable ranges.
        /// </summary>
        public bool IsValid
        {
            get
            {
                if (this.Longitude.HasValue == false || this.Latitude.HasValue == false)
                    return false;

                return (this.Longitude >= -180.0 && this.Longitude <= 180.0
                        && this.Latitude >= -90.0 && this.Latitude <= 90.0
                        && this.Latitude != 0 && this.Latitude != 0);
            }
        }


        /// <summary>
        /// Returns true iif Longitude specified is valid.
        /// </summary>
        /// <param name="dblValue">Longitude in decimal degrees.</param>
        /// <returns>True iif Longitude specified is valid.</returns>
        static public bool IsValidLongitude(double dblValue)
        {
            return (dblValue >= -180.0 && dblValue <= 180.0 && dblValue != 0);
        }


        /// <summary>
        /// Returns true iif Longitude specified is valid.
        /// </summary>
        /// <param name="strValue">Longitude in decimal degrees as a string.</param>
        /// <returns>True iif Longitude specified is valid.</returns>
        static public bool IsValidLongitude(string strValue)
        {
            if (strValue == null)
                return false;

            strValue = strValue.Trim();
            if (strValue.Length < 1)
                return false;

            try
            {
                return Location.IsValidLongitude(double.Parse(strValue));
            }
            catch
            {
                ;
            }

            return false;
        }


        /// <summary>
        /// Returns true iif Latitude specified is valid.
        /// </summary>
        /// <param name="dblValue">Latitude in decimal degrees.</param>
        /// <returns>True iif Latitude specified is valid.</returns>
        static public bool IsValidLatitude(double dblValue)
        {
            return (dblValue >= -90.0 && dblValue <= 90.0 && dblValue != 0);
        }


        /// <summary>
        /// Returns true iif Latitude specified is valid.
        /// </summary>
        /// <param name="strValue">Latitude in decimal degrees as a string.</param>
        /// <returns>True iif Latitude specified is valid.</returns>
        static public bool IsValidLatitude(string strValue)
        {
            if (strValue == null)
                return false;

            strValue = strValue.Trim();
            if (strValue.Length < 1)
                return false;

            try
            {
                return Location.IsValidLatitude(double.Parse(strValue));
            }
            catch
            {
                ;
            }

            return false;
        }



        /// <summary>
        /// Returns Longitude/Latitude.
        /// </summary>
        /// <returns>"Longitude/Latitude"  "?" if invalid.</returns>
        public override string ToString()
        {
            return string.Format("{0}/{1}",
                                 (this.Longitude.HasValue ? this.Longitude.Value.ToString() : "?"),
                                 (this.Latitude.HasValue ? this.Latitude.Value.ToString() : "?"));
        }


        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return this.Equals(obj as Location);
        }


        public static double Mod(double y, double x)
        {
            if (x != 0)
                return y - x * Math.Floor(y / x);

            return 0;
        }


        private const double EARTH_RADIUS = 6378137.0;

        public void Move(double dblHeadingInDegrees,
                         double dblDistanceInMeters)
        {
            if (!this.IsValid)
                return;

            double dblAngularDistance = dblDistanceInMeters / EARTH_RADIUS;
            double dblHeadingInRadians = Physics.Degrees_to_Radians(dblHeadingInDegrees);
            double dblLat = Physics.Degrees_to_Radians(Latitude.Value);
            double dblLon = Physics.Degrees_to_Radians(Longitude.Value);

            double dblNewLat
                = Math.Asin((Math.Sin(dblLat) * Math.Cos(dblAngularDistance))
                            + (Math.Cos(dblLat) * Math.Sin(dblAngularDistance) * Math.Cos(dblHeadingInRadians)));

            double dlon
                = Math.Atan2(Math.Sin(dblHeadingInRadians) * Math.Sin(dblAngularDistance) * Math.Cos(dblLat),
                             Math.Cos(dblAngularDistance) - (Math.Sin(dblLat) * Math.Sin(dblNewLat)));

            double dblNewLon = Mod(dblLon - dlon + Math.PI, 2 * Math.PI) - Math.PI;

            dblNewLat = Physics.Radians_to_Degrees(dblNewLat);
            dblNewLon = Physics.Radians_to_Degrees(dblNewLon);

            this.Latitude = dblNewLat;
            this.Longitude = dblNewLon;
        }


        #region IEquatable<Location> Members

        public bool Equals(Location other)
        {
            if (other == null)
                return false;

            return other.Longitude.Equals(this.Longitude)
                   && other.Latitude.Equals(this.Latitude);
        }

        #endregion

        #region ICloneable Members

        public object Clone()
        {
            return new Location(this);
        }

        #endregion



        /*
       * Calculate distance (in m) between two points specified by latitude/longitude with Haversine formula
       *
       * Haversine formula:
       *       dblRadiusOfEarth = earth’s radius (mean radius = 6,371km)
       *       Δlat = lat2− lat1
       *       Δlong = long2− long1
       *       a = sin²(Δlat/2) + cos(lat1).cos(lat2).sin²(Δlong/2)
       *       c = 2.atan2(√a, √(1−a))
       *       distance = R.c 
       * 
       * Taken from: http://www.movable-type.co.uk/scripts/LatLong.html
       * 
       * You are welcome to re-use these scripts [without any warranty 
       * express or implied] provided you retain my copyright notice and 
       * when possible a link to my website.
       */
        static public double GetDistanceInKilometers(Location loc1, Location loc2)
        {
            if ((!loc1.IsValid) || (!loc2.IsValid))
            {
                throw new ArgumentOutOfRangeException();
            }

            double dblRadiusOfEarth = 6371.0; // earth's mean radius in km
            double dblLat = loc2.Latitude.Value * Math.PI / 180.0 - loc1.Latitude.Value * Math.PI / 180.0;
            double dblLon = loc2.Longitude.Value * Math.PI / 180.0 - loc1.Longitude.Value * Math.PI / 180.0;

            double a = Math.Sin(dblLat / 2) * Math.Sin(dblLat / 2) +
                       Math.Cos(loc1.Latitude.Value * Math.PI / 180.0) * Math.Cos(loc2.Latitude.Value * Math.PI / 180.0) *
                       Math.Sin(dblLon / 2) * Math.Sin(dblLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return dblRadiusOfEarth * c;
        }

        static public double GetDistanceInMeters(Location loc1, Location loc2)
        {
            return GetDistanceInKilometers(loc1, loc2) / 1000.0; // 1 kilometer = 1000 meters
        }

        static public double GetDistanceInMiles(Location loc1, Location loc2)
        {
            return GetDistanceInKilometers(loc1, loc2) * 1.609344; // 1 mile = 1.609344 kilometers
        }

        static public double GetDistanceInFeet(Location loc1, Location loc2)
        {
            return GetDistanceInKilometers(loc1, loc2) * 3280.8399; // 1 kilometer = 3280.8399 feet
        }



        static public double GetAngleInDegrees(double dblFromX, double dblFromY,
                                               double dblToX, double dblToY)
        {
/*
            dblToX -= dblFromX;
            dblToY -= dblFromY;

            if (dblToX == 0)
            {
                if (dblToY >= 0)
                    return 90;

                return 270;
            }

            if (dblToY == 0)
            {
                if (dblToX >= 0)
                    return 0;

                return 180;
            }

            double dblRadAngle = Math.Atan2(dblToY, dblToX);

            return Physics.Radians_to_Degrees(dblRadAngle);
*/

            double y = Math.Sin(dblToX - dblFromX)*Math.Cos(dblToY);
            double x = Math.Cos(dblFromY)*Math.Sin(dblToY) -
                       Math.Sin(dblFromY)*Math.Cos(dblToY)*Math.Cos(dblToX - dblFromX);

            double tc1 = 0;
            if (y > 0)
            {
                if (x > 0)
                    tc1 = Math.Atan((y/x));
                else if (x < 0)
                    tc1 = 180 - Math.Atan(-y/x);
                else // (x == 0)
                    tc1 = 90;
            }
            else if (y < 0)
            {
                if (x > 0)
                    tc1 = -Math.Atan(-y/x);
                else if (x < 0)
                    tc1 = Math.Atan(y/x) - 180;
                else // (x == 0)
                    tc1 = 270;
            }
            else // (y == 0)
            {
                if (x > 0)
                    tc1 = 0;
                else if (x < 0)
                    tc1 = 180;
                else // (x == 0)
                    //[the 2 points are the same]
                    ;
            }

            return Physics.Radians_to_Degrees(tc1);
        }

    }  // public class Location : IEquatable<Location>, ICloneable

}  // namespace VehicleSimulator

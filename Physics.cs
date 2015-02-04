using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace VehicleSimulator
{

    public static class Physics
    {
        const double SecondsPerHour = 3600;


        #region Conversion Factors


        #region Distance

        public static double Feet_to_Meters(double dblFeet)
        {
            return dblFeet * 0.3048;
        }
        public static double Meters_to_Feet(double dblMeters)
        {
            return dblMeters * 3.281;
        }

        public static double Inches_to_Centimeters(double dblInches)
        {
            return dblInches * 2.54;
        }
        public static double Centimeters_to_Inches(double dblCentimeters)
        {
            return dblCentimeters * 0.393700787;
        }


        public static double Miles_to_Kilometers(double dblMiles)
        {
            return dblMiles * 1.609344;
        }
        public static double Kilometers_to_Miles(double dblKilometers)
        {
            return dblKilometers * 0.621371192237334;
        }

        #endregion


        #region Time

        public static double Hours_to_Minutes(double dblHours)
        {
            return dblHours * 60;
        }
        public static double Minutes_to_Hours(double dblMinutes)
        {
            return dblMinutes / 60;
        }

        #endregion


        #region Velocity

        public static double MPH_to_KPH(double dblMPH)
        {
            return dblMPH * 1.609344;
        }
        public static double KPH_to_MPH(double dblKPH)
        {
            return dblKPH * 0.621371192;
        }

        public static double MetersPerSecond_to_MPH(double dblMetersPerSecond)
        {
            return dblMetersPerSecond * 2.23693629;
        }
        public static double MetersPerSecond_to_KPH(double dblMetersPerSecond)
        {
            return dblMetersPerSecond * 3.6;
        }


        public static double MPH_to_MetersPerSecond(double dblMPH)
        {
            // Convert miles to kilometers
            // Convert kilometers to meters
            // Convert hours to seconds
            return Physics.Miles_to_Kilometers(dblMPH) *1000 / SecondsPerHour;
        }
        public static double KPH_to_MetersPerSecond(double dblKPH)
        {
            // Convert kilometers to meters
            // Convert hours to seconds
            return dblKPH * 1000 / SecondsPerHour;
        }

        #endregion


        #region Acceleration

        public static double MetersPerSecondPerSecond_to_MPHPerSecond(double dblMetersPerSecondPerSecond)
        {
            return dblMetersPerSecondPerSecond * 2.23693629;
        }
        public static double MetersPerSecondPerSecond_to_KPHPerSecond(double dblMetersPerSecondPerSecond)
        {
            return dblMetersPerSecondPerSecond * 3.6;
        }


        public static double MPHPerSecond_to_MetersPerSecondPerSecond(double dblMPHPerSecond)
        {
            return dblMPHPerSecond * 0.44704;
        }
        public static double KPHPerSecond_to_MetersPerSecondPerSecond(double dblKPHPerSecond)
        {
            return dblKPHPerSecond * 0.277777778;
        }

        #endregion


        public static double Degrees_to_Radians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        public static double Radians_to_Degrees(double radians)
        {
            return radians * (180/Math.PI);
        }


        public static double GallonsPerMinute_to_LitersPerSecond(double dblGallonsPerMinute)
        {
            return dblGallonsPerMinute * 0.0630901964;
        }
        public static double LitersPerSecond_to_GallonsPerMinute(double dblLitersPerSecond)
        {
            return dblLitersPerSecond * 0.264172052;
        }


        public static double GallonsPerHour_to_LitersPerSecond(double GallonsPerHour)
        {
            return GallonsPerHour * 0.00105150327;
        }
        public static double LitersPerSecond_to_GallonsPerHour(double dblLitersPerSecond)
        {
            return dblLitersPerSecond * 951.019388;
        }


        public static double LitersPerSecond_to_LitersPerrHour(double dblLitersPerSecond)
        {
            return dblLitersPerSecond * 3600;
        }

        #endregion


        public static double Mod(double y, double x)
        {
            return y - x * Math.Floor(y / x);
        }

    }  // public static class Physics

}  // namespace VehicleSimulator

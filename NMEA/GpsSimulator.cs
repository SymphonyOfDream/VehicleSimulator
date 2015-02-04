using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace VehicleSimulator
{

    public class GpsSimulator
    {
        GGA m_GGA;
        GSA m_GSA;
        GSV m_GSV;
        RMC m_RMC;


        VehicleSimulator.Location m_Location;
        double m_dblVelocity;
        double m_dblTrackAngle;


        #region CTORs

        public GpsSimulator()
        {
            m_Location = VehicleSimulator.Location.CreateInvalidLocation();
            m_dblVelocity = 0;
            m_dblTrackAngle = 0;

            m_GGA = new GGA();
            m_RMC = new RMC();

            m_GSA = new GSA();
            m_GSV = new GSV();
        }


        public GpsSimulator(VehicleSimulator.Location location)
        {
            m_Location = location;
            m_dblVelocity = 0;
            m_dblTrackAngle = 0;

            m_GGA = new GGA(location);
            m_RMC = new RMC(location);

            m_GSA = new GSA();
            m_GSV = new GSV();
        }


        public GpsSimulator(float fVelocity, float fTrackAngle, VehicleSimulator.Location location)
        {
            m_Location = location;
            m_dblVelocity = fVelocity;
            m_dblTrackAngle = fTrackAngle;

            m_GGA = new GGA(location);
            m_RMC = new RMC(fVelocity, fTrackAngle, location);

            m_GSA = new GSA();
            m_GSV = new GSV();
        }


        #endregion


        public void Move(double dblHeadingInDegrees,
                         double dblDistanceInMeters)
        {
            if (dblDistanceInMeters != 0)
            {
                m_Location.Move(dblHeadingInDegrees, dblDistanceInMeters);
                DoUpdateLocation();
            }
        }

        void DoUpdateLocation()
        {
            if (m_Location.IsValid)
            {
                m_GGA.LatitudeDecimalDegrees = m_Location.Latitude.Value;
                m_GGA.LongitudeDecimalDegrees = m_Location.Longitude.Value;
                m_GGA.SatelliteCount = 5;

                m_RMC.LatitudeDecimalDegrees = m_Location.Latitude.Value;
                m_RMC.LongitudeDecimalDegrees = m_Location.Longitude.Value;
            }
            else
            {
                m_Location.SetInvalid();

                m_GGA.LatitudeDecimalDegrees = 0;
                m_GGA.LongitudeDecimalDegrees = 0;
                m_GGA.SatelliteCount = 0;

                m_RMC.LatitudeDecimalDegrees = 0;
                m_RMC.LongitudeDecimalDegrees = 0;
            }
        }

        public VehicleSimulator.Location Location
        {
            get { return m_Location; }
            set
            {
                if (value.IsValid)
                {
                    m_Location = value;
                }
                else
                {
                    m_Location.SetInvalid();
                }

                DoUpdateLocation();
            }
        }


        public double Velocity
        {
            get { return m_dblVelocity; }
            set
            {
                m_dblVelocity = value;
                m_RMC.Velocity = m_dblVelocity;
                m_RMC.Velocity = m_dblVelocity;
            }
        }


        public double TrackAngle
        {
            get { return m_dblTrackAngle; }
            set
            {
                m_dblTrackAngle = value;
                while (m_dblTrackAngle < 0)
                    m_dblTrackAngle += 360;

                m_RMC.TrackAngle = m_dblTrackAngle;
                m_RMC.TrackAngle = m_dblTrackAngle;
            }
        }


        public override string ToString()
        {
            return m_GGA.ToString() + "\r\n"
                 + m_GSA.ToString() + "\r\n"
                 + m_GSV.ToString() + "\r\n"
                 + m_RMC.ToString() + "\r\n";
        }

    }  // public class GpsSimulator

}  // VehicleSimulator

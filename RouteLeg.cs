using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleSimulator
{

    public class RouteLeg
    {
        public WayPoint Start { get; set; }

        public WayPoint End { get; set; }

        public List<VehicleSimulator.WayPoint> DrivingLocations { get; set; }


        public RouteLeg()
        {
            Start = null;
            End = null;

            DrivingLocations = new List<VehicleSimulator.WayPoint>();
        }


        public RouteLeg(WayPoint wayPointStart)
        {
            Start = wayPointStart;
            End = null;

            DrivingLocations = new List<VehicleSimulator.WayPoint>();
        }


        public RouteLeg(WayPoint wayPointStart, WayPoint wayPointEnd)
        {
            Start = wayPointStart;
            End = wayPointEnd;

            DrivingLocations = new List<VehicleSimulator.WayPoint>();
        }


    }  // public class RouteLeg

}  // namespace VehicleSimulator

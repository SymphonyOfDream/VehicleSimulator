using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;



namespace VehicleSimulator
{

    public class WayPoint
    {

        public Address WayPointAddress { get; set; }

        public double? ArriveVelocity { get; set; }
        public double? ArriveRPM { get; set; }
        public double? ArrivePauseBeforeDeparture { get; set; }

        public double? DepartVelocity { get; set; }
        public double? DepartRPM { get; set; }

        public VehicleSimulator.Location Location { get; set; }

        public override string ToString()
        {
            return WayPointAddress.ToString();
        }

    }  // public class WayPoint

}  // namespace VehicleSimulator


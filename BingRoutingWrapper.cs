using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleSimulator.BingRouteService;
using RouteSvc = VehicleSimulator.BingRouteService;



namespace VehicleSimulator
{

    public class BingRoutingWrapper
    {
        private readonly RouteSvc.RouteServiceClient m_RouteServiceClient;
        private readonly RouteSvc.RouteRequest m_RouteRequest;


        public BingRoutingWrapper()
        {
            m_RouteServiceClient = new RouteSvc.RouteServiceClient("BasicHttpBinding_IRouteService");
            m_RouteRequest = new RouteSvc.RouteRequest();

            m_RouteRequest.Credentials = new RouteSvc.Credentials();
            m_RouteRequest.Credentials.ApplicationId = Program.BingApiKey;

            // Return the route points so the route can be drawn.
            m_RouteRequest.Options = new RouteSvc.RouteOptions();
            m_RouteRequest.Options.RoutePathType = RouteSvc.RoutePathType.Points;

        }


        public RouteSvc.RouteResponse CalculateRoute(IEnumerable<object> lstWayPoints)
        {
            if (lstWayPoints == null)
                return null;

            m_RouteRequest.Waypoints = new RouteSvc.Waypoint[lstWayPoints.Count()];

            int idx = 0;
            foreach (object objWayPoint in lstWayPoints)
            {
                VehicleSimulator.WayPoint wayPoint = objWayPoint as VehicleSimulator.WayPoint;

                if (wayPoint.Location.IsValid == false)
                    continue;

                m_RouteRequest.Waypoints[idx] = new RouteSvc.Waypoint();
                m_RouteRequest.Waypoints[idx].Location = new RouteSvc.Location();
                m_RouteRequest.Waypoints[idx].Location.Latitude = wayPoint.Location.Latitude.Value;
                m_RouteRequest.Waypoints[idx].Location.Longitude = wayPoint.Location.Longitude.Value;

                ++idx;
            }

            RouteSvc.RouteResponse routeResponse = m_RouteServiceClient.CalculateRoute(m_RouteRequest);

            return routeResponse;
        }

    }  // public class BingRoutingWrapper

}  // namespace VehicleSimulator

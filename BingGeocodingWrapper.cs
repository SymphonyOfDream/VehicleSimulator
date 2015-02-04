using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleSimulator.BingGeocodeService;
using VehicleSimulator;


namespace VehicleSimulator
{

    public class BingGeocodingWrapper
    {
        private readonly GeocodeServiceClient m_GeocodeServiceClient;

        private readonly GeocodeRequest m_GeocodeRequest;
        private readonly FilterBase[] m_aConfidenceFilters;
        private readonly GeocodeOptions m_GeocodeOptions;

        public BingGeocodingWrapper()
        {
            m_GeocodeServiceClient = new GeocodeServiceClient("BasicHttpBinding_IGeocodeService");

            m_GeocodeRequest = new GeocodeRequest();

            // Set the credentials using a valid Bing Maps key
            m_GeocodeRequest.Credentials = new Credentials();
            m_GeocodeRequest.Credentials.ApplicationId = Program.BingApiKey;

            m_aConfidenceFilters = new FilterBase[1];
            m_aConfidenceFilters[0] = new ConfidenceFilter();
            ((ConfidenceFilter)m_aConfidenceFilters[0]).MinimumConfidence = Confidence.High;

            m_GeocodeOptions = new GeocodeOptions();
            m_GeocodeOptions.Filters = m_aConfidenceFilters;
            m_GeocodeRequest.Options = m_GeocodeOptions;
        }


        public VehicleSimulator.Location Geocode(Address address)
        {
            VehicleSimulator.Location location = VehicleSimulator.Location.CreateInvalidLocation();

            // Set the full address query
            m_GeocodeRequest.Query = address.ToString();


            // Make the geocode request
            GeocodeResponse geocodeResponse = m_GeocodeServiceClient.Geocode(m_GeocodeRequest);

            if (geocodeResponse.Results.Length > 0)
            {
                location = new Location(geocodeResponse.Results[0].Locations[0].Longitude,
                                        geocodeResponse.Results[0].Locations[0].Latitude);
            }

            return location;
        }


        



    }  // public class BingGeocodingWrapper

}  // namespace VehicleSimulator

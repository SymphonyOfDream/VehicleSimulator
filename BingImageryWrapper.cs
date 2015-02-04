using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImagerySvc=VehicleSimulator.BingImageryService;
using System.Windows.Forms;

namespace VehicleSimulator
{
    
    public class BingImageryWrapper
    {
        private readonly ImagerySvc.ImageryServiceClient m_ImageryServiceClient;

        private readonly ImagerySvc.MapUriRequest m_MapUriRequest;
        private readonly ImagerySvc.MapUriOptions m_MapUriOptions;


        
        public BingImageryWrapper()
        {
            m_ImageryServiceClient = new ImagerySvc.ImageryServiceClient("BasicHttpBinding_IImageryService"); 
            
            m_MapUriRequest = new ImagerySvc.MapUriRequest();

            m_MapUriRequest.Credentials = new ImagerySvc.Credentials();
            m_MapUriRequest.Credentials.ApplicationId = Program.BingApiKey;
            m_MapUriRequest.Center = new ImagerySvc.Location();

            m_MapUriOptions = new ImagerySvc.MapUriOptions();
            m_MapUriOptions.Style = ImagerySvc.MapStyle.AerialWithLabels;

            m_MapUriOptions.ImageSize = new ImagerySvc.SizeOfint();

            m_MapUriRequest.Options = m_MapUriOptions;
        }


        public bool? GetMapImage(VehicleSimulator.MapPictureBox targetPictureBox, 
                                VehicleSimulator.Location location,
                                int? iZoomLevel,
                                Label ctlToReceiveBingCopyrightNotice)
        {
            if (!location.IsValid)
                return null;

            m_MapUriRequest.Center.Latitude = location.Latitude.Value;
            m_MapUriRequest.Center.Longitude = location.Longitude.Value;

            m_MapUriRequest.Options.ImageSize.Height = targetPictureBox.Height;
            m_MapUriRequest.Options.ImageSize.Width = targetPictureBox.Width;

            m_MapUriRequest.Options.ZoomLevel = iZoomLevel;

            ImagerySvc.MapUriResponse mapUriResponse = null;
            try
            {
                mapUriResponse = m_ImageryServiceClient.GetMapUri(m_MapUriRequest);
            }
            catch (Exception ex)
            {
                Program.Logger.Error("GetMapUri Failed.", ex);
                mapUriResponse = null;
            }

            if (mapUriResponse != null)
            {
                if ((!targetPictureBox.BingCopyrightImageExists)
                    && mapUriResponse.BrandLogoUri != null)
                {
                    targetPictureBox.SetBingCopyrightImage(mapUriResponse.BrandLogoUri);
                }

                if (ctlToReceiveBingCopyrightNotice.Text.Length < 1
                    && mapUriResponse.ResponseSummary != null
                    && (!string.IsNullOrEmpty(mapUriResponse.ResponseSummary.Copyright)))
                {
                    ctlToReceiveBingCopyrightNotice.Text = mapUriResponse.ResponseSummary.Copyright;
                }


                if (!string.IsNullOrEmpty(mapUriResponse.Uri))
                {
                    targetPictureBox.ImageLocation = mapUriResponse.Uri;
                    return true;
                }
            }

            return false;
        }


    }  // public class BingImageryWrapper

}

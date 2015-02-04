using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;



namespace VehicleSimulator
{

    public class MapPictureBox : PictureBox
    {
        private static readonly object m_objVehicleLocker = new object();

        private PictureBox m_pictureboxBingCopyrightImage = new PictureBox();
        public void SetBingCopyrightImage(System.Uri uri)
        {
            m_pictureboxBingCopyrightImage.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(m_imgBingCopyrightImage_LoadCompleted);
            m_pictureboxBingCopyrightImage.ImageLocation = uri.ToString();
        }

        private bool m_bBingCopyrightImageLoaded = false;
        void m_imgBingCopyrightImage_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            m_pictureboxBingCopyrightImage.LoadCompleted -= m_imgBingCopyrightImage_LoadCompleted;
            m_bBingCopyrightImageLoaded = true;
        }

        public bool BingCopyrightImageExists
        {
            get 
            {

                return !string.IsNullOrEmpty(m_pictureboxBingCopyrightImage.ImageLocation);
            }
        }

        private Image m_VehicleImage = null;
        private Image m_VehicleRotatedImage = null;
        public Image VehicleImage
        {
            get { return m_VehicleImage; }
            set
            {
                lock (m_objVehicleLocker)
                {
                    m_VehicleImage = value;

                    RotateImage();
                }
            }
        }


        private double m_dblVehicleSymbolOrientation = 0;
        public double VehicleSymbolOrientation
        {
            get { return m_dblVehicleSymbolOrientation; }
            set
            {
                lock (m_objVehicleLocker)
                {
                    double dblOld = m_dblVehicleSymbolOrientation;

                    m_dblVehicleSymbolOrientation = value;

                    if (dblOld != m_dblVehicleSymbolOrientation)
                        RotateImage();
                }
            }
        }


        private void RotateImage()
        {
            if (m_VehicleImage == null)
                return;

            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(m_VehicleImage.Width, m_VehicleImage.Height);

            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(returnBitmap);

            //move rotation point to center of image
            g.TranslateTransform((float) m_VehicleImage.Width/2, (float) m_VehicleImage.Height/2);


            g.RotateTransform((float) m_dblVehicleSymbolOrientation); // - 90);

            //move image back
            g.TranslateTransform(-(float)m_VehicleImage.Width / 2, -(float)m_VehicleImage.Height / 2);
            g.DrawImage(m_VehicleImage, new Point(0, 0));

            m_VehicleRotatedImage = (Image)returnBitmap;
        }



        void DrawVehicleSymbolOnMap(Graphics g)
        {
            if (m_VehicleImage == null)
                return;

            lock (m_objVehicleLocker)
            {

                int iMapCenterX = this.Width / 2 - m_VehicleImage.Width / 2;
                int iMapCenterY = this.Height / 2 - m_VehicleImage.Height / 2;


                g.DrawImage(m_VehicleRotatedImage, iMapCenterX, iMapCenterY);

                System.Drawing.Drawing2D.GraphicsState graph = g.Save();
                g.Restore(graph);
            }
        }

        void DrawBingCopyrightImageOnMap(Graphics g)
        {
            int iLeft = 0;
            int iBottom = this.Size.Height - m_pictureboxBingCopyrightImage.Image.Height - 1;
            g.DrawImage(m_pictureboxBingCopyrightImage.Image, iLeft, iBottom);

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (!string.IsNullOrEmpty(this.ImageLocation))
                DrawVehicleSymbolOnMap(pe.Graphics);

            if (m_bBingCopyrightImageLoaded)
                DrawBingCopyrightImageOnMap(pe.Graphics);
        }


    }  // public class MapPictureBox : PictureBox

}

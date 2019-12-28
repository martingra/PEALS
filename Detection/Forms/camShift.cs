using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace Detector.Forms
{
    public partial class camShift : Form
    {
        private Capture grabber;
        private Image<Bgr, Byte> currentFrame;
        private Image<Bgr, Byte> roi_image;
        private Point origin;
        private Rectangle selection;

        public Image<Hsv, Byte> hsv;
        public Image<Gray, Byte> hue;
        public Image<Gray, Byte> mask;
        public Image<Gray, Byte> backproject;
        public DenseHistogram hist;
        private Rectangle trackingWindow;
        private MCvConnectedComp trackcomp;
        private MCvBox2D trackbox;

        HaarCascade face;


        #region OpticalFlow
        Image<Gray, Byte> grayframe;
        Image<Gray, Byte> prevgrayframe;
        Image<Bgr, Byte> frame;
        
        PointF[][] preFeatures;
        PointF[] curFeatures;

        MCvTermCriteria criteria = new MCvTermCriteria(10, 0.03d);
        byte[] status;
        float[] error;

        private Rectangle rectanguloOf;
        private Image<Bgr, Byte> roi_of;
        #endregion

        public camShift()
        {
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            InitializeComponent();
            iniciarGrabacion();
        }

        public void iniciarGrabacion()
        {
            selection = new Rectangle(100, 100, 50, 50);
            rectanguloOf = new Rectangle(150, 50, 80, 80);

            grabber = new Capture();
            grabber.QueryFrame();
            grabber.FlipHorizontal = true;
            Application.Idle += new EventHandler(FrameGrabber);
        }

        void FrameGrabber(object sender, EventArgs e)
        {
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            inicializarComponentes(currentFrame);
            Process(currentFrame);
        }

        private void Process(Image<Bgr, Byte> currentFrame)
        {
            Image<Bgr, Byte> copiaImg = currentFrame.Copy();

            if (chOpticalFlow.Checked == true)
            {
                opticalFlow(currentFrame.Copy());
            }


            roi_image = currentFrame.Copy(selection).Convert<Bgr, Byte>();
            currentFrame.Draw(selection, new Bgr(Color.Green), 2);

            imgBoxVideo.Image = currentFrame;
            imgBoxResultado.Image = copiaImg;

            
            obtenerHistograma(currentFrame);

            if (chSeguir.Checked == true)
            {
                selection = seguir(currentFrame);
            }

            if (chHaarCascade.Checked == true)
            {
                haarCascade(currentFrame);
            } 

            
        }

        private void opticalFlow(Image<Bgr, Byte> input)
        {
            roi_of = input.Copy(rectanguloOf).Convert<Bgr, Byte>();
            input.Draw(rectanguloOf, new Bgr(Color.Red), 2);

            frame = input.Copy();
            if (prevgrayframe == null)
            {
                prevgrayframe = roi_of.Convert<Gray, Byte>();
                preFeatures = prevgrayframe.GoodFeaturesToTrack(1000, 0.05, 5.0, 3);
                prevgrayframe.FindCornerSubPix(preFeatures, new Size(5, 5), new Size(-1, -1), new MCvTermCriteria(25, 1.5d)); //This just increase the accuracy of the points
                //mixChannel_src = input.PyrDown().PyrDown().Convert<Hsv, float>()[0];
                return;
            }

            grayframe = roi_of.Convert<Gray, Byte>();
            //apply the Optical flow
            Emgu.CV.OpticalFlow.PyrLK(prevgrayframe, grayframe, preFeatures[0], new Size(10, 10), 3, criteria, out curFeatures, out status, out error);
            Image<Gray, float> FlowX = new Image<Gray, float>(grayframe.Size),
                FlowY = new Image<Gray, float>(grayframe.Size),
                FlowAngle = new Image<Gray, float>(grayframe.Size),
                FlowLength = new Image<Gray, float>(grayframe.Size),
                FlowResult = new Image<Gray, float>(grayframe.Size);

            #region Farneback method to display movement in colour intensity
            //Same as bellow CvInvoke method but a bit simpler
            Emgu.CV.OpticalFlow.Farneback(prevgrayframe, grayframe, FlowX, FlowY, 0.5, 1, 10, 2, 5, 1.1, OPTICALFLOW_FARNEBACK_FLAG.USE_INITIAL_FLOW);

            #region This code is much simpler
            //Find the length for the whole array
            FlowY = FlowY.Mul(FlowY); //Y*Y
            FlowX = FlowX.Mul(FlowX); //X*X
            FlowResult = FlowX + FlowY; //X^2 + Y^2
            CvInvoke.cvSqrt(FlowResult, FlowResult); //SQRT(X^2 + Y^2)

            //Apply a colour map.
            Image<Bgr, Byte> Result = new Image<Bgr, Byte>(grayframe.Size);//store the result
            CvInvoke.ApplyColorMap(FlowResult.Convert<Gray, Byte>() * 5, Result, ColorMapType.Hot); //Scale the FlowResult by a factor of 5 for a better visual difference
            CvInvoke.cvShowImage("Flow Angle Colour II", Result);//Uncomment to see in external window
            CvInvoke.cvWaitKey(1); //Uncomment to see in external window (NOTE: You only need this line once)

            #endregion
            #endregion


            prevgrayframe = grayframe.Copy(); //copy current frame to previous

            float sumatoriaX = 0;
            float sumatoriaY = 0;
            float promedioX = 0;
            float promedioY = 0;
            double movimientoAbsolutoX = 0;
            double movimientoAbsolutoY = 0;

            if (curFeatures.Length > 20) //la cantidad de features depende de la cantidad de cosas que tenga en la imagen, asique no sirve para evitar error
            { 
                for (int i = 0; i < curFeatures.Length; i++)
                {
                    LineSegment2DF line = new LineSegment2DF(preFeatures[0][i], curFeatures[i]);
                    
                    double dx = line.P1.X - line.P2.X;
                    double dy = line.P1.Y - line.P2.Y;

                    movimientoAbsolutoX = Math.Abs(dx);
                    movimientoAbsolutoY = Math.Abs(dy);

                    double l = Math.Sqrt(movimientoAbsolutoX * movimientoAbsolutoX + movimientoAbsolutoY * movimientoAbsolutoY);

                    sumatoriaX += (float)dx;
                    sumatoriaY += (float)dy;

                    double spinSize = 0.1 * l;
                    if (l > 5 && l < 100)
                    {
                        frame.Draw(line, new Bgr(Color.Red), 2);

                        double angle = Math.Atan2((double)line.P1.Y - line.P2.Y, (double)line.P1.X - line.P2.X);
                        Point Tip1 = new Point((int)(line.P2.X + spinSize * Math.Cos(angle + 3.1416 / 4)), (int)(line.P2.Y + spinSize * Math.Sin(angle + 3.1416 / 4)));
                        Point Tip2 = new Point((int)(line.P2.X + spinSize * Math.Cos(angle - 3.1416 / 4)), (int)(line.P2.Y + spinSize * Math.Sin(angle - 3.1416 / 4)));
                        LineSegment2DF line1 = new LineSegment2DF(Tip1, curFeatures[i]);
                        LineSegment2DF line2 = new LineSegment2DF(Tip2, curFeatures[i]);
                        frame.Draw(line1, new Bgr(Color.Blue), 2);
                        frame.Draw(line2, new Bgr(Color.Blue), 2);
                    }

                }

            }

            promedioX = sumatoriaX / curFeatures.Length;
            promedioY = sumatoriaY / curFeatures.Length;

            //if (promedioX > 0.00001 || promedioY > 0.00001)
            //{
                lblMovimiento.Text = "Desplazamiento en X: " + promedioX + ". Desplazamiento en Y: " + promedioY;
                //rectanguloOf.X += -1 * Convert.ToInt32(promedioX);
                //rectanguloOf.Y += -1 * Convert.ToInt32(promedioY);
            //}

            preFeatures = prevgrayframe.GoodFeaturesToTrack(1000, 0.05, 5.0, 3);
            prevgrayframe.FindCornerSubPix(preFeatures, new Size(5, 5), new Size(-1, -1), new MCvTermCriteria(25, 1.5d)); //This just increase the accuracy of the points

            /*---------------------------------------------*/
            imgBoxOpticalFlow.Image = frame;
        }

        private void haarCascade(Image<Bgr, Byte> currentFrame)
        {
            Image<Gray, byte> gray = null;
            

            //Convert it to Grayscale
            gray = currentFrame.Convert<Gray, Byte>();

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
          face,
          1.2,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
          new Size(20, 20));

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);
            }
        }

        private void inicializarComponentes(Image<Bgr, Byte> image)
        {
            // Initialize parameters
            trackbox = new MCvBox2D();
            trackcomp = new MCvConnectedComp();
            hue = new Image<Gray, byte>(image.Width, image.Height);
            hue._EqualizeHist();
            mask = new Image<Gray, byte>(image.Width, image.Height);
            hist = new DenseHistogram(30, new RangeF(0, 180));
            backproject = new Image<Gray, byte>(image.Width, image.Height);

            // Assign Object's ROI from source image.
            trackingWindow = selection;
        }

        private void obtenerHistograma(Image<Bgr, Byte> image)
        {
            UpdateHue(image); //obtiene el hue a partir del bgr de la imagen

            // Set tracking object's ROI
            hue.ROI = trackingWindow;
            mask.ROI = trackingWindow;
            hist.Calculate(new Image<Gray, Byte>[] { hue }, false, mask);

            // Scale Historgram
            float max = 0, min = 0, scale = 0;
            int[] minLocations, maxLocations;
            hist.MinMax(out min, out max, out minLocations, out maxLocations);
            if (max != 0)
            {
                scale = 255 / max;
            }
            CvInvoke.cvConvertScale(hist.MCvHistogram.bins, hist.MCvHistogram.bins, scale, 0);

            // Clear ROI
            hue.ROI = System.Drawing.Rectangle.Empty;
            mask.ROI = System.Drawing.Rectangle.Empty;

            
            // Now we have Object's Histogram, called hist.
        }

        public Rectangle seguir(Image<Bgr, Byte> image)
        {
            UpdateHue(image);

            // Calucate BackProject
            backproject = hist.BackProject(new Image<Gray, Byte>[] { hue });

            // Apply mask
            backproject._And(mask);

            // Tracking windows empty means camshift lost bounding-box last time
            // here we give camshift a new start window from 0,0 (you could change it)
            if (trackingWindow.IsEmpty || trackingWindow.Width == 0 || trackingWindow.Height == 0)
            {
                trackingWindow = new Rectangle(0, 0, 100, 100);
            }
            CvInvoke.cvCamShift(backproject, trackingWindow,
                new MCvTermCriteria(10, 1), out trackcomp, out trackbox);

            // update tracking window
            trackingWindow = trackcomp.rect;

            return trackingWindow;
        }

        private void imgBoxVideo_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;

            selection.X = mouse.Location.X - selection.Width / 2;
            selection.Y = mouse.Location.Y - selection.Height / 2;

            if (selection.X < 0)
            {
                selection.X = 0;
            }
            else if (selection.X + selection.Width > imgBoxVideo.Width)
            {
                selection.X = imgBoxVideo.Width - selection.Height;
            }

            if (selection.Y < 0)
            {
                selection.Y = 0;
            }
            else if (selection.Y + selection.Height > imgBoxVideo.Height)
            {
                selection.Y = imgBoxVideo.Height - selection.Height;
            }

            //selection.X = Math.Min(mouse.Location.X, origin.X);
            //selection.Y = Math.Min(mouse.Location.Y, origin.Y);
            //selection.Width = Math.Abs(mouse.Location.X - origin.X);
            //selection.Height = Math.Abs(mouse.Location.Y - origin.Y);

            txtMouseClick.Text = "X: " + selection.X.ToString() + ". Y: " + selection.Y.ToString(); //+ ". Width: " + selection.Width.ToString() + ". Height: " + selection.Height.ToString();
        }

        private void UpdateHue(Image<Bgr, Byte> image)
        {
            // release previous image memory
            if (hsv != null) hsv.Dispose();
            hsv = image.Convert<Hsv, Byte>();

            // Drop low saturation pixels
            mask = hsv.Split()[1].ThresholdBinary(new Gray(60), new Gray(255));
            CvInvoke.cvInRangeS(hsv, new MCvScalar(0, 30, Math.Min(10, 255), 0),
                new MCvScalar(180, 256, Math.Max(10, 255), 0), mask);

            // Get Hue
            hue = hsv.Split()[0];
        }
    }
}

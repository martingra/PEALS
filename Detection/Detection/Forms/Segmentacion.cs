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
using Emgu.CV.UI;
using Emgu.CV.VideoSurveillance;
using Detector.SkinDetector;
using Detector.Motion;
using Emgu.CV.Util;
using System.Threading;
using Emgu.CV.Cvb;

namespace Detector.Forms
{
    public partial class Segmentacion : Form, FaceDetectorListener
    {
        private Capture grabber;
        private Image<Bgr, byte> originalFrame;
        private Image<Bgr, byte> prevFrame;
        private Image<Bgr, byte> currentFrame;
        private Image<Bgr, byte> testFrame;

        private Contour<Point> testContour;

        private FaceDetector _faceDetector;
        private Thread _faceThread;
        private Face face;

        private BackgroundSubtractor bgSubsIzq = null;
        private BackgroundSubtractor bgSubsDer = null;
        private BackgroundSubtractor _bgSubs = null;

        private INativeTracker _tracker= null;

        private Rectangle rIzq;
        private Rectangle rDer;
        private Rectangle rCenUp;
        private Rectangle rCenDown;

        private Rectangle rHand;

        private MemStorage convexStorage = new MemStorage();

        private const int NUM_FINGERS = 5;
        private const int NUM_DEFECTS = 8;

        int erode, dilate, smooth, thres, sat, area_max, area_mano;
        bool apertura, cierre, ecualizar, saturar, procesar, balanceBlancos;

        string metodo;

        private int frames = 500;

        public Segmentacion()
        {
            InitializeComponent();    
        }

        private void Segmentacion_Load(object sender, EventArgs e)
        {
            grabber = new Capture();            
            grabber.FlipHorizontal = true;

            int width = (int)grabber.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_WIDTH);
            int height = (int)grabber.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT);

            rIzq = new Rectangle(0, 0, width / 3, height);
            rDer = new Rectangle(width - width / 3, 0, width - (width - width / 3), height);
            rCenUp = new Rectangle(rIzq.Right, 0, rDer.Left - rIzq.Right, height - height / 4);
            rCenDown = new Rectangle(rIzq.Right, rCenUp.Bottom, rDer.Left - rIzq.Right, height - rCenUp.Bottom);
            rHand = new Rectangle(rDer.X - 50, 50, rDer.Width, 200);

            _faceDetector = new FaceDetector(10, this);

            _bgSubs = new BackgroundSubtractorMOG2(500, 16, false);

            Application.Idle += new EventHandler(FrameGrabber);
        }

        void FrameGrabber(object sender, EventArgs e)
        {
            originalFrame = grabber.RetrieveBgrFrame();
            UpdateFace();
            currentFrame = originalFrame.Clone();
            
            GetGUIData();

            if (ecualizar)
                currentFrame._EqualizeHist();            

            if (balanceBlancos)
                currentFrame._GammaCorrect(0.5);

            if (smooth > 0)
                currentFrame = currentFrame.SmoothGaussian(smooth, smooth, 0, 0);

            if (face != null)
            {
                currentFrame.Draw(face.ROI, new Bgr(0, 255, 255), 3);
                PointF[] vertices = face.Box.GetVertices();
                currentFrame.DrawPolyline(Array.ConvertAll<PointF, Point>(vertices, Point.Round), true, new Bgr(0, 255, 0), 3);

                if (prevFrame == null)
                    prevFrame = originalFrame.Clone();
                else if (frames > 498)
                {
                    Bgr color = new Bgr(face.max.Blue - face.min.Blue, face.max.Green - face.min.Green, face.max.Red - face.min.Red);
                    testFrame = originalFrame.AbsDiff(prevFrame).Mul(2);
                    prevFrame = originalFrame.Clone();
                    frames--;

                    imgBox_videoHsv.Image = testFrame;
                }
            }

            imgBox_VideoBgr.Image = currentFrame;

            //if (--frames > 0)
            //    _bgSubs.Update(currentFrame, 0.00001);
            //else
            //{
            //    _bgSubs.Update(currentFrame);
            //    imgBox_videoHsv.Image = _bgSubs.ForegroundMask;
            //    frames = 0;
            //}

            if (procesar)
                Process();

            currentFrame.Dispose();
            originalFrame.Dispose();
        }

        private void UpdateFace()
        {
            if (_faceThread == null || !_faceThread.IsAlive)
            {
                _faceDetector.UpdateImage(originalFrame);
                _faceThread = new Thread(_faceDetector.DoWork);
                _faceThread.Start();
                _faceThread.Join();
            }
        }

        public void OnFaceDetect()
        {
            bgSubsIzq = new BackgroundSubtractorMOG2(0, thres, false);
            bgSubsDer = new BackgroundSubtractorMOG2(0, thres, false);

            procesar = true;
        }

        public void OnFaceUpdate(Face face)
        {
            this.face = face;
        }

        private void GetGUIData()
        {
            erode = (int)value_erode.Value;
            dilate = (int)value_dilate.Value;
            smooth = (int)valueSmooth.Value;
            thres = (int)value_tresh.Value;
            sat = (int)value_s.Value;
            area_max = (int)value_area.Value;
            area_mano = (int)value_areaMano.Value;

            apertura = chApertura.Checked;
            cierre = chCierre.Checked;
            ecualizar = chEcualizar.Checked;
            saturar = chSaturar.Checked;
            balanceBlancos = chBalance.Checked;

            metodo = comboMetodo.Text;
        }

        private OpticalMotion opMotion = new OpticalMotion();
        private void Process()
        {
            //Image<Bgr, byte> result = new Image<Bgr,byte>(currentFrame.Width, currentFrame.Height);
            //int x, y; double total;
            //if (opMotion.GetOpticalFlow(currentFrame.Canny(20, 40), out x, out y, out total, ref result))
            //{
            //    PointF[] points = opMotion.GetFeatures();

            //    if (points == null || points.Length == 0) return;

            //    Image<Bgr, byte> r = new Image<Bgr, byte>(originalFrame.Size);
            //    foreach (PointF p in opMotion.GetFeatures())
            //    {
            //        CircleF c = new CircleF(p, 3);
            //        r.Draw(c, new Bgr(0, 255, 255), 3);
            //    }

            //    imgBox_videoHsv.Image = r;
            //}

            //if(face != null)
            //    imgBox_videoHsv.Image = currentFrame.InRange(face.min, face.max);

            //procesarLateral(rIzq, bgSubsIzq, ref imgBox_movIzq, ref imgBox_bordeIzq, ref imgBox_segIzq, ref imgBox_manoIzq, ref lbl_areaIzq);
            //procesarLateral(rDer, bgSubsDer, ref imgBox_movDer, ref imgBox_bordeDer, ref imgBox_segDer, ref imgBox_manoDer, ref lbl_areaDer);
            //ProcesarMano();
        }

        private INativeTracker manoTracker = null;
        private void ProcesarMano()
        {
            Image<Gray, byte> gray = currentFrame.Convert<Gray, byte>();

            if (manoTracker == null)
            {
                manoTracker = new CMT();
                manoTracker.SelectToTrack(gray, ref rHand);
            }
            else
            {
                manoTracker.Update(currentFrame);
                rHand = _tracker.GetTracker();
                Rectangle mano = new Rectangle(rHand.X + 10, rHand.Y + 10, rHand.Width - 20, rHand.Height - 20);
                currentFrame.Draw(mano, new Bgr(255, 0, 255), 3);
            }
        }

        private void procesarLateral(Rectangle rectangle, BackgroundSubtractor subs, ref ImageBox mogGUI, ref ImageBox borderGUI, ref ImageBox segGUI, ref ImageBox manoGUI, ref Label txtArea)
        {
            Image<Bgr, byte> frameRoi = currentFrame.Copy(rectangle);
            Image<Bgr, byte> originalRoi = originalFrame.Copy(rectangle);

            Image<Gray, Byte> imgSinFondo = sacarFondo(frameRoi, ref subs);
            imgSinFondo = aplicarOpMorph(imgSinFondo);
            mogGUI.Image = imgSinFondo;

            Contour<Point> contour; bool hayBorde; string str_area;
            Image<Bgr, Byte> imgBorde = obtenerBorder(imgSinFondo, out str_area, out contour, out hayBorde);
            lbl_maxArea.Text = str_area;
            
            //borderGUI.Image = originalRoi.InRange(min, max);
            if (hayBorde && contour != null)
            {
                MCvMoments moments = contour.GetMoments();
                float cx = (float)(rectangle.Left + moments.GravityCenter.x);
                float cy = (float)(rectangle.Top + moments.GravityCenter.y);

                currentFrame.Draw(new CircleF(new PointF(cx, cy), 5), new Bgr(255, 0, 0), 3);
                Image<Bgr, byte> mano = obtenerMano(imgBorde, contour, new Point((int)cx, (int)cy));
                manoGUI.Image = mano;
            }
        }

        private Image<Gray, byte> aplicarOpMorph(Image<Gray, byte> img)
        {
            if (apertura)
            {
                img = img.Erode(erode);
                img = img.Dilate(dilate);
            }

            if (cierre)
            {
                img = img.Dilate(dilate);
                img = img.Erode(erode);
            }

            return img;
        }        

        private Image<Gray, Byte> sacarFondo(Image<Bgr, byte> imagen, ref BackgroundSubtractor subs)
        {
            subs.Update(imagen);
            return subs.ForegroundMask;
        }

        private Image<Bgr, Byte> obtenerBorder(Image<Gray, Byte> frame, out string area, out Contour<Point> contour, out bool hayBorde)
        {
            contour = null;
            double max_area = 0;
            Image<Bgr, Byte> ret = new Image<Bgr, byte>(frame.Size);

            hayBorde = false;
            area = "";

            try
            {
                using (MemStorage storage = new MemStorage())
                {
                    for (Contour<Point> tmp_contour = frame.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL, storage); tmp_contour != null; tmp_contour = tmp_contour.HNext)
                    {
                        if (tmp_contour.Area > max_area)
                        {
                            max_area = tmp_contour.Area;
                            contour = tmp_contour;
                        }
                    }

                    contour = (contour != null) ? contour.ApproxPoly(contour.Perimeter * 0.0025, 1, storage) : null;

                    area = max_area.ToString();
                    if (contour != null && (max_area > 0 && max_area < area_max))
                    {
                        ret.Draw(contour, new Bgr(1, 1, 1), -1);
                        hayBorde = true;
                    }
                }
            }
            catch (Exception e) { }

            return ret;
        }

        private Image<Bgr, byte> obtenerMano(Image<Bgr, byte> imagenBorde, Contour<Point> contour, Point center)
        {
            Image<Bgr, byte> mano = new Image<Bgr, byte>(imagenBorde.Size);
            
            MCvConvexityDefect[] defects_points; int numDefects;
            MCvBox2D box = FindConvexHull(contour, out defects_points, out numDefects);
            if (numDefects >= 0)
            {
                box = FindConvexHull(contour, out defects_points, out numDefects);
                DrawHand(numDefects, defects_points, box, center);
            }

            return mano;
        }

        private MCvBox2D FindConvexHull(Contour<Point> contours, out MCvConvexityDefect[] defects_points, out int numDefects)
        {
            numDefects = -1;
            defects_points = null;

            try
            {
                Seq<Point> hull = contours.GetConvexHull(Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);
                MCvBox2D box = contours.GetMinAreaRect(convexStorage);
                PointF[] points = box.GetVertices();
                Point[] ps = new Point[points.Length];
                for (int i = 0; i < points.Length; i++)
                    ps[i] = new Point((int)points[i].X, (int)points[i].Y);
                
                if (hull != null)
                {
                    Seq<MCvConvexityDefect> defects = contours.GetConvexityDefacts(convexStorage, Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);
                    numDefects = defects.Total;
                    defects_points = defects.ToArray();
                    
                    Point[] defect_points = new Point[defects_points.Length];
                    for (int i = 0; i < defects_points.Length; i++)
                    {
                        defect_points[i] = new Point(defects_points[i].StartPoint.X, defects_points[i].StartPoint.Y);
                    }
                }

                return box;
            }
            catch (Exception ex)
            {
                numDefects = -1;
                defects_points = null;

                return new MCvBox2D();
            }            
        }

        private void DrawHand(int numDefects, MCvConvexityDefect[] defects_points, MCvBox2D box, Point center)
        {
            int fingerNum = 0;

            for (int i = 0; i < numDefects; i++)
            {
                //PointF startPoint = new PointF((float)defects_points[i].StartPoint.X, (float)defects_points[i].StartPoint.Y);
                //PointF depthPoint = new PointF((float)defects_points[i].DepthPoint.X, (float)defects_points[i].DepthPoint.Y);
                //PointF endPoint = new PointF((float)defects_points[i].EndPoint.X, (float)defects_points[i].EndPoint.Y);

                //LineSegment2D startDepthLine = new LineSegment2D(defects_points[i].StartPoint, defects_points[i].DepthPoint);
                //LineSegment2D depthEndLine = new LineSegment2D(defects_points[i].DepthPoint, defects_points[i].EndPoint);

                //CircleF startCircle = new CircleF(startPoint, 5f);
                //CircleF depthCircle = new CircleF(depthPoint, 5f);
                //CircleF endCircle = new CircleF(endPoint, 5f);

                PointF startPoint = new PointF((float)defects_points[i].StartPoint.X + rDer.Left, (float)defects_points[i].StartPoint.Y);
                PointF depthPoint = new PointF((float)defects_points[i].DepthPoint.X + rDer.Left, (float)defects_points[i].DepthPoint.Y);

                CircleF startCircle = new CircleF(startPoint, 5f);
                CircleF depthCircle = new CircleF(depthPoint, 5f);

                if ((startCircle.Center.Y < box.center.Y || depthCircle.Center.Y < box.center.Y) && (startCircle.Center.Y < depthCircle.Center.Y) && (Math.Sqrt(Math.Pow(startCircle.Center.X - depthCircle.Center.X, 2) + Math.Pow(startCircle.Center.Y - depthCircle.Center.Y, 2)) > box.size.Height / 6.5))
                {
                    fingerNum++;
                    //image.Draw(startDepthLine, new Bgr(Color.Green), 2); // líneas de dedos
                    //image.Draw(startCircle, new Bgr(Color.Red), 2); // puntos convexos
                    //image.Draw(depthCircle, new Bgr(Color.Yellow), 5); // puntos defectuosos                    

                    Point p = new Point(defects_points[i].StartPoint.X + rDer.Left, defects_points[i].StartPoint.Y);
                    currentFrame.Draw(startCircle, new Bgr(0, 0, 255), 2); // puntos convexos
                    currentFrame.Draw(new LineSegment2D(p, center), new Bgr(0, 255, 0), 2); // puntos convexos
                    //currentFrame.Draw(depthCircle, new Bgr(Color.Yellow), 5); // puntos defectuosos
                }
            }
        }
    }
}

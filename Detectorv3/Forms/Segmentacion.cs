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
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Detector.Motion;

namespace Detector.Forms
{
    public partial class Segmentacion : Form
    {
        private double aspectRatio;

        private Capture grabber;
        private Mat originalFrame = new Mat();
        private Mat currentFrame = new Mat();
        private Mat mask = new Mat();

        private Mat roi_izquierdo = new Mat();        
        private Mat roi_derecho = new Mat();

        private BackgroundSubtractor bgSubsIzq = null;
        private BackgroundSubtractor bgSubsDer = null;

        private INativeTracker _tracker = null;

        private Rectangle rIzq = new Rectangle();
        private Rectangle rDer = new Rectangle();
        private Rectangle rCenUp = new Rectangle();
        private Rectangle rCenDown = new Rectangle();

        private const int NUM_FINGERS = 5;
        private const int NUM_DEFECTS = 8;

        int erode, dilate, smooth, thres, sat, area_max, area_mano;
        bool apertura, cierre, ecualizar, saturar, procesar, balanceBlancos;

        string metodo;

        public Segmentacion()
        {
            InitializeComponent();    
        }

        private void Segmentacion_Load(object sender, EventArgs e)
        {
            grabber = new Capture();
            grabber.FlipHorizontal = true;

            Application.Idle += FrameGrabber;
        }

        void FrameGrabber(object sender, EventArgs e)
        {
            grabber.Retrieve(originalFrame);
            currentFrame = originalFrame.Clone();

            if (rIzq == null || rIzq.Width == 0)
            {
                rIzq = new Rectangle(0, 0, currentFrame.Width / 3, currentFrame.Height);
                rDer = new Rectangle(currentFrame.Width - currentFrame.Width / 3, 0, currentFrame.Width - (currentFrame.Width - currentFrame.Width / 3), currentFrame.Height);
                rCenUp = new Rectangle(rIzq.Right, 0, rDer.Left - rIzq.Right, currentFrame.Height - currentFrame.Height / 4);
                rCenDown = new Rectangle(rIzq.Right, rCenUp.Bottom, rDer.Left - rIzq.Right, currentFrame.Height - rCenUp.Bottom);
            }

            GetGUIData();

            if (balanceBlancos)
                CvInvoke.BalanceWhite(currentFrame, currentFrame, WhiteBalanceMethod.Simple, 0, 255, 50, 150);

            if (smooth > 0)
                CvInvoke.GaussianBlur(currentFrame, currentFrame, new Size(smooth, smooth), 0, 0);

            imgBox_VideoBgr.Image = originalFrame;
            imgBox_videoHsv.Image = currentFrame;

            if (procesar)
                Process();
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

            //metodo = comboMetodo.Text;
        }

        private void Process()
        {
            roi_izquierdo = new Mat(currentFrame, rIzq);
            roi_derecho = new Mat(currentFrame, rDer);

            //procesarLateral(roi_izquierdo, ref bgSubsIzq, ref imgBox_movIzq, ref imgBox_bordeIzq, ref imgBox_segIzq, ref imgBox_manoIzq, ref lbl_areaIzq);
            //procesarLateral(roi_derecho, ref bgSubsDer, ref imgBox_movDer, ref imgBox_bordeDer, ref imgBox_segDer, ref imgBox_manoDer, ref lbl_areaDer);            
        }

        private void procesarLateral(Mat imagenBgr, ref BackgroundSubtractor subs, ref ImageBox mogGUI, ref ImageBox borderGUI, ref ImageBox segGUI, ref ImageBox manoGUI, ref Label txtArea)
        {
            Mat imgSinFondo = sacarFondo(imagenBgr, ref subs);

            aplicarOpMorph(imgSinFondo, imgSinFondo);
            mogGUI.Image = imgSinFondo;

            VectorOfPointF contour; bool hayborde;
            Mat imgborde = obtenerBorder(imgSinFondo, ref borderGUI, ref txtArea, out contour, out hayborde);

            Mat imgHull = new Mat(imgborde.Size, imgborde.Depth, imgborde.NumberOfChannels);
            GetConvexHull(contour, ref imgHull, ref segGUI);
            segGUI.Image = imgHull;

            //if (hayborde && contour != null && contour.Area >= area_mano)
            //{
            //    obtenermano(imagenbgr, imgborde, contour, ref seggui, ref manogui);
            //}
        }

        private void aplicarOpMorph(Mat src, Mat dst)
        {
            if (apertura)
            {
                CvInvoke.Erode(src, dst, null, new Point(-1, -1), erode, Emgu.CV.CvEnum.BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
                CvInvoke.Dilate(src, dst, null, new Point(-1, -1), dilate, Emgu.CV.CvEnum.BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
            }

            if (cierre)
            {
                CvInvoke.Dilate(src, dst, null, new Point(-1, -1), dilate, Emgu.CV.CvEnum.BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
                CvInvoke.Erode(src, dst, null, new Point(-1, -1), erode, Emgu.CV.CvEnum.BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
            }
        }

        private Mat sacarFondo(Mat imagen, ref BackgroundSubtractor subs)
        {
            Mat imgSinFondo = new Mat();
            subs.Apply(imagen, imgSinFondo, 0.0001);

            return imgSinFondo;
        }

        private Mat obtenerBorder(Mat frame, ref ImageBox borderGUI, ref Label lblArea, out VectorOfPointF contour, out bool hayBorde)
        {
            double max_area = 0;
            Mat ret = new Mat(frame.Size, DepthType.Cv32F, 3);

            hayBorde = false;

            contour = new VectorOfPointF();
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(frame, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);
            int count = contours.Size;
            int idx = -1;
            for (int i = 1; i < count; i++)
            {
                using (VectorOfPoint c = contours[i])
                {
                    double area = CvInvoke.ContourArea(c);
                    if (area > max_area)
                    {
                        max_area = area;
                        idx = i;
                    }
                }

            }
            
            //lblArea.Text = max_area.ToString();
            if (max_area > 0 && max_area < area_max)
            {                
                using(Image<Bgr, byte> img = ret.ToImage<Bgr, byte>())
                {                    
                    CvInvoke.DrawContours(ret, contours, idx, new MCvScalar(0, 0, 255), -1);
                    double perimeter = CvInvoke.ArcLength(contours[idx], true);
                    CvInvoke.ApproxPolyDP(contours[idx], contour, perimeter * 0.0025, true);
                    //contour = contours[idx];
                    borderGUI.Image = ret;
                }
                hayBorde = true;
            }

            return ret;
        }

        private void GetConvexHull(VectorOfPointF contour, ref Mat imagenBgr, ref ImageBox segGUI)
        {
            if (contour.Size > 0)
            {                
                VectorOfPointF hull = new VectorOfPointF();
                CvInvoke.ConvexHull(contour, hull, true, true);
                CvInvoke.Polylines(imagenBgr, Array.ConvertAll<PointF, Point>(hull.ToArray(), Point.Round), true, new MCvScalar(255, 255, 0), 2);

                if (hull.Size > 0)
                {
                    //MCvConvexityDefect[] defects = new MCvConvexityDefect[hull.Size];
                    //CvArray<MCvConvexityDefect> defects = null;
                    //CvInvoke.ConvexityDefects(contour, hull, defects);
                    //CvInvoke.Polylines(imagenBgr, Array.ConvertAll<PointF, Point>(defects.ToArray(), Point.Round), true, new MCvScalar(0, 255, 255), 2);
                }

                segGUI.Image = imagenBgr;
            }
        }

        //private MCvBox2D FindConvexHull(Contour<Point> contours, out MCvConvexityDefect[] defects_points, out int numDefects)
        //{
        //    numDefects = -1;
        //    defects_points = null;

        //    try
        //    {
        //        Seq<Point> hull = contours.GetConvexHull(Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);
        //        MCvBox2D box = contours.GetMinAreaRect(convexStorage);
        //        PointF[] points = box.GetVertices();
        //        Point[] ps = new Point[points.Length];
        //        for (int i = 0; i < points.Length; i++)
        //            ps[i] = new Point((int)points[i].X, (int)points[i].Y);
                
        //        if (hull != null)
        //        {
        //            Seq<MCvConvexityDefect> defects = contours.GetConvexityDefacts(convexStorage, Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);
        //            numDefects = defects.Total;
        //            defects_points = defects.ToArray();

        //            Point[] defect_points = new Point[defects_points.Length];
        //            for (int i = 0; i < defects_points.Length; i++)
        //            {
        //                defect_points[i] = new Point(defects_points[i].StartPoint.X, defects_points[i].StartPoint.Y);
        //            }
        //        }

        //        return box;
        //    }
        //    catch (Exception ex)
        //    {
        //        numDefects = -1;
        //        defects_points = null;

        //        return new MCvBox2D();
        //    }            
        //}

        //private Point[] FindFinger(Contour<Point> contours)
        //{
        //    Point max_point = new Point();
        //    Point[] fingers_points = new Point[NUM_FINGERS];

        //    int dist1 = 0, dist2 = 0, numFingers = 0;
        //    int n = contours.Total;

        //    Point handCenter = new Point();
        //    for (int i = 0; i < n; i++)
        //    {
        //        int cx = handCenter.X;
        //        int cy = handCenter.Y;

        //        int dist = (cx - contours[i].X) * 2 + (cy - contours[i].Y) * 2;
        //        if (dist < dist1 && dist1 > dist2 && max_point.X != 0)
        //        {
        //            if (numFingers >= NUM_FINGERS)
        //                break;

        //            fingers_points[numFingers] = max_point;
        //            numFingers++;
        //        }

        //        dist2 = dist1;
        //        dist1 = dist;
        //        max_point = contours[i];
        //    }

        //    return fingers_points;
        //}

        //private void DrawHand(int numDefects, MCvConvexityDefect[] defects_points, MCvBox2D box, ref Image<Bgr, byte> image)
        //{
        //    int fingerNum = 0;

        //    for (int i = 0; i < numDefects; i++)
        //    {
        //        PointF startPoint = new PointF((float)defects_points[i].StartPoint.X, (float)defects_points[i].StartPoint.Y);
        //        PointF depthPoint = new PointF((float)defects_points[i].DepthPoint.X, (float)defects_points[i].DepthPoint.Y);
        //        PointF endPoint = new PointF((float)defects_points[i].EndPoint.X, (float)defects_points[i].EndPoint.Y);

        //        LineSegment2D startDepthLine = new LineSegment2D(defects_points[i].StartPoint, defects_points[i].DepthPoint);
        //        LineSegment2D depthEndLine = new LineSegment2D(defects_points[i].DepthPoint, defects_points[i].EndPoint);

        //        CircleF startCircle = new CircleF(startPoint, 5f);
        //        CircleF depthCircle = new CircleF(depthPoint, 5f);
        //        CircleF endCircle = new CircleF(endPoint, 5f);

        //        if ((startCircle.Center.Y < box.center.Y || depthCircle.Center.Y < box.center.Y) && (startCircle.Center.Y < depthCircle.Center.Y) && (Math.Sqrt(Math.Pow(startCircle.Center.X - depthCircle.Center.X, 2) + Math.Pow(startCircle.Center.Y - depthCircle.Center.Y, 2)) > box.size.Height / 6.5))
        //        {
        //            fingerNum++;
        //            image.Draw(startDepthLine, new Bgr(Color.Green), 2); // líneas de dedos
        //            image.Draw(startCircle, new Bgr(Color.Red), 2); // puntos convexos
        //            image.Draw(depthCircle, new Bgr(Color.Yellow), 5); // puntos defectuosos
        //        }
        //    }
        //}

        private void btnCaputarFondo_Click(object sender, EventArgs e)
        {
            bgSubsIzq = new BackgroundSubtractorMOG2(500, thres, false);
            bgSubsDer = new BackgroundSubtractorMOG2(500, thres, false);

            procesar = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Emgu.CV;
using Emgu.CV.Structure;

using System.Drawing;

using Detector.SkinDetector;

namespace Detector
{
    class HandDetection
    {
        private const int NUM_FINGERS = 5;
        private const int NUM_DEFECTS = 8;

        private MemStorage storage = new MemStorage();
        private int _numFingers;
        private int _numDefects;
        private double _handRadius;
        private Point _handCenter;
        private MCvConvexityDefect[] _defects_points;
        private MCvBox2D _box;
        private Seq<Point> _hull;

        private Rgb[] _Rgb;
        private Hsv[] _Hsv;
        private Ycc[] _YCrCb;
        private int _erode, _dilate;
        private int _smoothKernel;

        public void Config(int erode, int dilate, int smoothKernel, Rgb[] rgb = null, Hsv[] hsv = null, Ycc[] ycc = null)
        {
            _erode = erode;
            _dilate = dilate;
            _smoothKernel = smoothKernel;

            _Rgb = rgb;
            _Hsv = hsv;
            _YCrCb = ycc;
        }

        public Image<Gray, Byte> FilterAndThreshold(Image<Bgr, Byte> bgr_image, bool rgb, bool hsv, bool ycc, out Image<Gray, Byte>[] skins)
        {
            IColorSkinDetector rgb_skinDetector = new RGBSkinDetector();
            IColorSkinDetector hsv_skinDetector = new HsvSkinDetector();
            IColorSkinDetector ycc_skinDetector = new YCrCbSkinDetector();
            IColorSkinDetector cus_skinDetector = new CustomSkinDetection();

            Image<Gray, byte> rgb_skin = cus_skinDetector.DetectSkin(bgr_image, null, null);
            Image<Gray, byte> hsv_skin = hsv_skinDetector.DetectSkin(bgr_image, _Hsv[0], _Hsv[1]);
            Image<Gray, byte> ycc_skin = ycc_skinDetector.DetectSkin(bgr_image, _YCrCb[0], _YCrCb[1]);

            skins = new Image<Gray, byte>[] { rgb_skin, hsv_skin, ycc_skin };
            Image<Gray, Byte> skin = rgb_skin;

            if (hsv)
                skin = skin.Mul(hsv_skin);
            if (ycc)
                skin = skin.Mul(ycc_skin);

            skin = skin.Erode(_erode);
            skin = skin.Dilate(_dilate);

            skin.SmoothGaussian(_smoothKernel);

            return skin;
        }

        public Contour<System.Drawing.Point> FindContour(Image<Gray, Byte> thr_image)
        {
            double max_area = 0.0f;
            Contour<System.Drawing.Point> contour = null;
            for (Contour<System.Drawing.Point> tmp_contour = thr_image.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL, storage); tmp_contour != null; tmp_contour = tmp_contour.HNext)
            {
                if (tmp_contour.Area > max_area)
                {
                    max_area = tmp_contour.Area;
                    contour = tmp_contour;
                }
            }

            return (contour != null)? contour.ApproxPoly(contour.Perimeter * 0.0025, 1, storage) : null;
        }

        public void FindConvexHull(Contour<Point> contours, Image<Bgr, Byte> image, bool drawBorder, bool drawHandRoi, bool drawCenter)
        {
            if (contours == null) return;

            _hull = contours.GetConvexHull(Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);
            _box = contours.GetMinAreaRect();
            PointF[] points = _box.GetVertices();
            Point[] ps = new Point[points.Length];
            for (int i = 0; i < points.Length; i++)
                ps[i] = new Point((int)points[i].X, (int)points[i].Y);

            if (drawBorder) image.DrawPolyline(_hull.ToArray(), true, new Bgr(200, 125, 75), 2);
            if (drawCenter) image.Draw(new CircleF(new PointF(_box.center.X, _box.center.Y), 3), new Bgr(200, 125, 75), 2);
            if (drawHandRoi) image.DrawPolyline(ps, true, new Bgr(255, 0, 255), 2);

            if (_hull != null)
            {
                Seq<MCvConvexityDefect> defects = contours.GetConvexityDefacts(storage, Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);
                _numDefects = defects.Total;
                _defects_points = defects.ToArray();

                Point[] defect_points = new Point[_defects_points.Length];
                for (int i = 0; i < _defects_points.Length; i++)
                {
                    defect_points[i] = new Point(_defects_points[i].StartPoint.X, _defects_points[i].StartPoint.Y);
                    //image.Draw(new CircleF(defect_points[i], 2), new Bgr(255, 125, 55), 2);
                }
            }
        }

        public Point[] FindFinger(Contour<System.Drawing.Point> contours, Image<Bgr, Byte> image)
        {
            if (contours == null || _hull == null) return null;

            Point max_point = new Point();
            Point[] fingers_points = new Point[NUM_FINGERS];

            int dist1 = 0, dist2 = 0;
            int n = contours.Total;

            for (int i= 0; i< n; i++)
            {
                int cx = _handCenter.X;
                int cy = _handCenter.Y;

                int dist = (cx - contours[i].X) * 2 + (cy - contours[i].Y) * 2;
                if (dist < dist1 && dist1 > dist2 && max_point.X != 0 && max_point.Y < image.Height - 10)
                {
                    if (_numFingers >= NUM_FINGERS)
                        break;

                    fingers_points[_numFingers] = max_point;
                    _numFingers++;
                }

                dist2 = dist1;
                dist1 = dist;
                max_point = contours[i];
            }

            return fingers_points;
        }

        public void DrawHand(System.Drawing.Point[] finger_points, Image<Bgr, Byte> image, bool drawConvex, bool drawDefect, bool drawHandLine)
        {
            int fingerNum = 0;

            #region defects drawing
            
            for (int i = 0; i < _numDefects; i++)
            {
                PointF startPoint = new PointF((float)_defects_points[i].StartPoint.X, (float)_defects_points[i].StartPoint.Y);
                PointF depthPoint = new PointF((float)_defects_points[i].DepthPoint.X, (float)_defects_points[i].DepthPoint.Y);
                PointF endPoint = new PointF((float)_defects_points[i].EndPoint.X, (float)_defects_points[i].EndPoint.Y);

                LineSegment2D startDepthLine = new LineSegment2D(_defects_points[i].StartPoint, _defects_points[i].DepthPoint);
                LineSegment2D depthEndLine = new LineSegment2D(_defects_points[i].DepthPoint, _defects_points[i].EndPoint);

                CircleF startCircle = new CircleF(startPoint, 5f);
                CircleF depthCircle = new CircleF(depthPoint, 5f);
                CircleF endCircle = new CircleF(endPoint, 5f);

                if ((startCircle.Center.Y < _box.center.Y || depthCircle.Center.Y < _box.center.Y) && (startCircle.Center.Y < depthCircle.Center.Y) && (Math.Sqrt(Math.Pow(startCircle.Center.X - depthCircle.Center.X, 2) + Math.Pow(startCircle.Center.Y - depthCircle.Center.Y, 2)) > _box.size.Height / 6.5))
                {
                    fingerNum++;
                    if (drawHandLine) image.Draw(startDepthLine, new Bgr(Color.Green), 2);
                    if (drawConvex) image.Draw(startCircle, new Bgr(Color.Red), 2);
                    if (drawDefect) image.Draw(depthCircle, new Bgr(Color.Yellow), 5);
                }
            }
            
            #endregion
        }

        internal class Colors
        {
            public static Bgr Red    = new Bgr(255, 0, 0);
            public static Bgr Green  = new Bgr(0, 255, 0);
            public static Bgr Blue   = new Bgr(0, 0, 255);
            public static Bgr Yellow = new Bgr(255, 255, 0);
            public static Bgr Purple = new Bgr(255, 0, 255);
            public static Bgr Gray   = new Bgr(200, 200, 200);
        }
    }
}

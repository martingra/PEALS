using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;

namespace Detector.Image_Processing
{
    class FingerSegmentation
    {
        private MemStorage storage;
        private Contour<Point> contours;

        private PointF armCenter;
        private MCvBox2D contourCenter, palmCenter;

        private Seq<Point> hull;
        private Seq<MCvConvexityDefect> defect;

        public void DetectHand(Contour<Point> contours, Image<Bgr, byte> img)
        {
            this.contours = contours;

            contourCenter = contours.GetMinAreaRect();
            armCenter = contourCenter.center;

            CircleF circle = new CircleF(armCenter, 3);
            //img.Draw(circle, new Bgr(187, 200, 8), 2);

            //cvDrawContours(frame, contours, CV_RGB(100, 100, 100), CV_RGB(0, 255, 0), 1, 2, CV_AA, cvPoint(0, 0));
            img.DrawPolyline(contours.ToArray(), true, new Bgr(0, 0, 255), 2);

            storage = new MemStorage();

            GetConvexHull(img);
            FingerTip(img);
            Hand(img);
        }

        private void GetConvexHull(Image<Bgr, byte> image)
        {
            hull = contours.GetConvexHull(Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE, storage);
            defect = hull.GetConvexityDefacts(storage, Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);
    
            for (int i= 0; i< defect.Total; i++)
            {
                MCvConvexityDefect d = defect[i];
                if (d.Depth > 10)
                {
                    CircleF p= new CircleF(d.DepthPoint, 2);
                    image.Draw(p, new Bgr(0, 255, 0), 2);
                }
            }
        }

        /**
         * p1, p, p2 forman un triangulo y calculando el ángulo se decide si es un dedo o no
         */
        private void FingerTip(Image<Bgr, byte> image)
        {
            int dotproduct,i;
            float length1, length2, angle, minangle = -1, length;
            Point vector1, vector2, min = new Point(), minp1 = new Point(), minp2 = new Point();
            Point[] fingertip = new Point[20];
            Point p1,p2,p;
            int[] tiplocation = new int[20];
            int count = 0;
            bool signal = false;

            for (i = 0; i < contours.Total; i++)
            {
                p1 = contours[i];
                p = contours[(i + 20) % contours.Total];
                p2 = contours[(i + 40) % contours.Total];

                vector1 = new Point(p.X - p1.X, p.Y - p1.Y);
                vector2 = new Point(p.X - p2.X, p.Y - p2.Y);

                dotproduct = (vector1.X * vector2.X) + (vector1.Y * vector2.Y);
                length1 = (float)Math.Sqrt(vector1.X * vector1.X + vector1.Y * vector1.Y);
                length2 = (float)Math.Sqrt(vector2.X * vector2.X + vector2.Y * vector2.Y);
                angle = Math.Abs(dotproduct / (length1 * length2));

                if (angle < 0.2)
                {
                    //cvCircle(frame,*p,4,CV_RGB(0,255,255),-1,8,0); 
                    if (!signal)//
                    {
                        signal = true;
                        min = p;
                        minp1 = p1;
                        minp2 = p2;
                        minangle = angle;
                    }
                    else if (angle <= minangle)
                    {
                        min = p;
                        minp1 = p1;
                        minp2 = p2;
                        minangle = angle;
                    }
                }
                else
                {
                    if (signal)
                    {
                        signal = false;
                        Point l1 = new Point(), l2 = new Point(), l3 = new Point();
                        l1.X = (int)(min.X - armCenter.X);
                        l1.Y = (int)(min.Y - armCenter.Y);

                        l2.X = (int)(minp1.X - armCenter.X);
                        l2.Y = (int)(minp1.Y - armCenter.Y);

                        l3.X = (int)(minp2.X - armCenter.X);
                        l3.Y = (int)(minp2.Y - armCenter.Y);

                        length = (float)Math.Sqrt((l1.X * l1.X) + (l1.Y * l1.Y));
                        length1 = (float)Math.Sqrt((l2.X * l2.X) + (l2.Y * l2.Y));
                        length2 = (float)Math.Sqrt((l3.X * l3.X) + (l3.Y * l3.Y));

                        if (length > length1 && length > length2)
                        {
                            image.Draw(new CircleF(min, 2), new Bgr(0, 255, 0), 2);
                            fingertip[count] = min;
                            tiplocation[count] = i + 20;
                            count = count + 1;
                        }
                        else if (length < length1 && length < length2)
                        {
                            image.Draw(new CircleF(min, 2), new Bgr(255, 0, 0), 2);
                            //cvCircle(virtualhand,min,8,CV_RGB(255,255,255),-1,8,0);
                            //fingertip[count] = min;
                            //tiplocation[count] = i+20;
                            //count = count + 1;
                        }
                    }
                }
            }

            for (i = 0; i < count; i++)
            {
                if ((tiplocation[i] - tiplocation[i - 1]) > 40)
                {
                    if (fingertip[i].X >= 630 || fingertip[i].Y >= 470)
                    {
                        CircleF point = new CircleF(fingertip[i], 2);
                        image.Draw(point, new Bgr(50, 200, 250), 2);
                    }
                    else
                    {
                        //cvCircle(frame,fingertip[i],6,CV_RGB(0,255,0),-1,8,0);
                        //cvCircle(virtualhand,fingertip[i],6,CV_RGB(0,255,0),-1,8,0);
                        //cvLine(virtualhand,fingertip[i],armcenter,CV_RGB(255,0,0),3,CV_AA,0);
                    }
                }
            }
        }

        private void Hand(Image<Bgr, byte> image){ }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using System.Drawing;
using Emgu.CV.Structure;

namespace Detector
{
    class HandDetect2
    {
        private MemStorage storage = new MemStorage();
        private MemStorage defectStorage = new MemStorage();
        private MemStorage palmStorage = new MemStorage();
        private MemStorage fingerStorage = new MemStorage();

        private Contour<Point> contour;
        private MCvBox2D palmCenter, contourCenter;
        private Point pt0, pt, p, armCenter;
        private Seq<Point> hull, palm;
        private Seq<MCvConvexityDefect> defect;

        public HandDetect2(Contour<Point> contour)
        {
            this.contour = contour;
            contourCenter = contour.GetMinAreaRect();
            armCenter.X = (int) contourCenter.center.X;
            armCenter.Y = (int) contourCenter.center.Y;
            palm = new Seq<Point>(palmStorage);
        }

        public void GetConvexHull(ref Image<Bgr, byte> frame)
        {
            hull = contour.GetConvexHull(Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);
            for (int i = 0; i < hull.Total; i++)
            {
            }

            defect = hull.GetConvexityDefacts(defectStorage, Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);
            for (int i = 0; i < defect.Total; i++)
            {
                MCvConvexityDefect d = defect[i];
                if (d.Depth > 10)
                {
                    p.X = d.DepthPoint.X;
                    p.Y = d.DepthPoint.Y;
                    CircleF circle = new CircleF(p, 5);
                    frame.Draw(circle, new Bgr(Color.Blue), -1);
                    palm.Push(p);
                }
            }
        }

        public void FingerTip()
        {
        }

        public void Hand()
        {
        }
    }
}

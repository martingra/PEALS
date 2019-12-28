using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace Detector.Motion
{
    class CMT : INativeTracker
    {
        #region Native

        [DllImport("INativeTracker.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int _cmt_initialize(IntPtr img, ref Rectangle roi, bool estimate_rotation, bool estimate_scale, string detector);

        [DllImport("INativeTracker.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int _cmt_processFrame(IntPtr img);

        [DllImport("INativeTracker.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern Rectangle _cmt_getROI();

        [DllImport("INativeTracker.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr _cmt_getRotatedROI();

        [DllImport("INativeTracker.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int _cmt_getPointsCounts();

        [DllImport("INativeTracker.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr _cmt_getPoints();

        #endregion Native

        public enum DETECTOR_TYPE { FAST, BRISK }

        private bool _estimate_rotation = true;
        private bool _estimate_scale = false;
        private string _detector = "FAST";

        public CMT() { }
        public CMT(bool estimate_rotation, bool estimate_scale, DETECTOR_TYPE detector)
        {
            this._estimate_rotation = estimate_rotation;
            this._estimate_scale = estimate_scale;
            this._detector = detector.ToString();
        }

        public void SelectToTrack(IImage img, ref Rectangle roi)
        {
            Image<Gray, byte> gray = new Image<Gray, byte>(img.Size);
            if (img.NumberOfChannels > 1)
                CvInvoke.cvCvtColor(img.Ptr, gray.Ptr, Emgu.CV.CvEnum.COLOR_CONVERSION.BGR2GRAY);
            else
                gray = (Image<Gray, byte>)img;

            int i = _cmt_initialize(gray.Ptr, ref roi, _estimate_rotation, _estimate_scale, _detector);
            System.Console.WriteLine(i);
        }

        public void Update(IImage img)
        {
            Image<Gray, byte> gray = new Image<Gray, byte>(img.Size);
            if (img.NumberOfChannels > 1)
                CvInvoke.cvCvtColor(img.Ptr, gray.Ptr, Emgu.CV.CvEnum.COLOR_CONVERSION.BGR2GRAY);
            else
                gray = (Image<Gray, byte>)img;

            int i = _cmt_processFrame(gray.Ptr);
            System.Console.WriteLine(i);
        }

        public Rectangle GetTracker() 
        {
            Rectangle rect = _cmt_getROI();

            return rect;
        }

        public MCvBox2D GetRotatedTracker() 
        {             
            float[] values = new float[5];

            IntPtr ptr = _cmt_getRotatedROI();
            Marshal.Copy(ptr, values, 0, 5);

            float angle = values[0];
            PointF center = new PointF(values[1], values[2]);
            SizeF size = new SizeF(values[3], values[4]);

            MCvBox2D box = new MCvBox2D(center, size, angle);
            return box;
        }

        public PointF[] GetKeyPoints()
        {
            int count = _cmt_getPointsCounts();
            float[] values = new float[count*2];

            IntPtr ptr = _cmt_getPoints();
            Marshal.Copy(ptr, values, 0, count*2);

            PointF[] points = new PointF[count];
            for (int i = 0; i < count; i++)
                points[i] = new PointF(values[i], values[(i*2) + 1]);

            return points;
        }
    }
}

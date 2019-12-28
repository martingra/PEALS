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

        public void SelectToTrack(Mat img, ref Rectangle roi)
        {
            if (img.NumberOfChannels > 1)
                CvInvoke.CvtColor(img, img, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

            int i = _cmt_initialize(img.ToImage<Gray, byte>().Ptr, ref roi, _estimate_rotation, _estimate_scale, _detector);
            System.Console.WriteLine(i);
        }

        public void Update(Mat img)
        {
            if (img.NumberOfChannels > 1)
                CvInvoke.CvtColor(img, img, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

            int i = _cmt_processFrame(img.ToImage<Gray, byte>().Ptr);
            System.Console.WriteLine(i);
        }

        public Rectangle GetTracker()
        {
            Rectangle rect = _cmt_getROI();

            return rect;
        }

        public RotatedRect GetRotatedTracker()
        {
            float[] values = new float[5];

            IntPtr ptr = _cmt_getRotatedROI();
            Marshal.Copy(ptr, values, 0, 5);

            float angle = values[0];
            PointF center = new PointF(values[1], values[2]);
            SizeF size = new SizeF(values[3], values[4]);

            RotatedRect box = new RotatedRect(center, size, angle);
            return box;
        }
    }
}

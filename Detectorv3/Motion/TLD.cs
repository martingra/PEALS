using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Drawing;
using Emgu.CV.Util;

namespace Detector.Motion
{
    class TLD : INativeTracker
    {
        #region Native

        [DllImport("INativeTracker.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern void _tld3_selectObject(IntPtr img, ref Rectangle roi);

        [DllImport("INativeTracker.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern void _tld3_processImage(IntPtr img);

        [DllImport("INativeTracker.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr _tld_getROI();

        [DllImport("INativeTracker.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern float _tld_getCurrConfident();

        [DllImport("INativeTracker.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool _tld_isLearning();

        [DllImport("INativeTracker.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern void _tld_release();

        #endregion Native

        public TLD() { }

        ~TLD()
        {
            _tld_release();
        }

        public void SelectToTrack(Mat gray_img, ref Rectangle roi)
        {
            _tld3_selectObject(gray_img.Ptr, ref roi);            
        }

        public void Update(Mat bgr_img)
        {
            _tld3_processImage(bgr_img.Ptr);
        }

        public Rectangle GetTracker()
        {
            IntPtr ptr = _tld_getROI();
            if (ptr == IntPtr.Zero) return new Rectangle(); // devuelvo un objeto vacío

            Rectangle roi = (Rectangle)Marshal.PtrToStructure(ptr, typeof(Rectangle));
            return roi;
        }

        //public MCvBox2D GetRotatedTracker() { return new MCvBox2D(); }

        public bool IsLearning()
        {
            return _tld_isLearning();
        }

        public float GetConfident()
        {
            return _tld_getCurrConfident();
        }

        public void Dispose()
        {
            _tld_release();
        }
    }
}

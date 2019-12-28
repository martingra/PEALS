using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV.Structure;
using Emgu.CV;

namespace Detector.SkinDetector
{
    public class YCrCbSkinDetector :IColorSkinDetector
    {
        private Ycc defMin = new Ycc(0, 131, 80);
        private Ycc defMax = new Ycc(255, 185, 135);

        public override Image<Gray, byte> DetectSkin(Image<Bgr, byte> Img, IColor min = null, IColor max = null)
        {
            if (min == null) min = defMin;
            if (max == null) max = defMax;

            Image<Ycc, Byte> currentYCrCbFrame = Img.Convert<Ycc, Byte>();
            return currentYCrCbFrame.InRange((Ycc)min, (Ycc) max);
        }
    }
}

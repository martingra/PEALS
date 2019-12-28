using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Detector.SkinDetector
{
    public class HsvSkinDetector:IColorSkinDetector
    {
        private Hsv defMin = new Hsv(0, 45, 0);
        private Hsv defMax = new Hsv(20, 255, 255);

        public override Image<Gray, byte> DetectSkin(Image<Bgr, byte> Img, IColor min = null, IColor max = null)
        {
            if (min == null) min = defMin;
            if (max == null) max = defMax;

            Image<Hsv, Byte> currentHsvFrame = Img.Convert<Hsv, Byte>();
            return currentHsvFrame.InRange((Hsv)min, (Hsv)max);
        }
    }
}

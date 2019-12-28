using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV.Structure;
using Emgu.CV;

namespace Detector.SkinDetector
{
    class RGBSkinDetector : IColorSkinDetector
    {
        public override Image<Gray, byte> DetectSkin(Image<Bgr, byte> Img, IColor min, IColor max)
        {
            Image<Rgb, Byte> currentYCrCbFrame = Img.Convert<Rgb, Byte>();
            return currentYCrCbFrame.InRange((Rgb)min, (Rgb)max);
        }
    }
}

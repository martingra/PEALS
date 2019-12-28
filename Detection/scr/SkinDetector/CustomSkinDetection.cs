using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Detector.SkinDetector
{
    class CustomSkinDetection : IColorSkinDetector
    {
        public override Image<Gray, byte> DetectSkin(Image<Bgr, byte> imgSrc, IColor min, IColor max)
        {
            Image<Gray, byte> ret = new Image<Gray,byte>(imgSrc.Size);

            Image<Hsv, byte> imgHsv = imgSrc.Convert<Hsv, byte>();
            Image<Ycc, byte> imgYcc = imgSrc.Convert<Ycc, byte>();

            for (int i = 0; i < imgSrc.Rows; i++)
            {
                for (int j = 0; j < imgSrc.Cols; j++)
                {
                    float Y = (float)imgYcc[i, j].Y;
                    float Cb = (float)imgYcc[i, j].Cb;
                    float Cr = (float)imgYcc[i, j].Cr;

                    float H = (float)imgHsv[i, j].Hue;
                    float S = (float)imgHsv[i, j].Satuation;
                    float V = (float)imgHsv[i, j].Value;

                    bool b = R2(Y, Cr, Cb);
                    bool c = R3(H, S, V);

                    ret[i, j] = (b && c) ? new Gray(255) : new Gray(0);
                }
            }

            return ret;
        }

        private bool R2(float Y, float Cr, float Cb)
        {
            return (Y > 55 && Cr > 85 && Cb > 145);
        }

        private bool R3(float H, float S, float V)
        {
            return (H > 0 && H < 40) && (S > 0.27 && S < 0.6) && (V > 0.5 && V < 1);
        }
    }
}

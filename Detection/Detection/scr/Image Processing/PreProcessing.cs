using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Detector.scr.Image_Processing
{
    public class PreProcessing
    {
        public Bitmap prueba(Bitmap imagen)
        {
            Rectangle r = new Rectangle(0, 0, 20, 20);
            Image<Bgr, byte> img = new Image<Bgr, byte>(imagen);
            img.Draw(r, new Bgr(Color.Green), 2);
            return img.ToBitmap();
        }
    }
}

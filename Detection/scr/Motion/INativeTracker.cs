using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;

namespace Detector.Motion
{
    interface INativeTracker
    {
        void SelectToTrack(IImage img, ref Rectangle roi);
        void Update(IImage img);
        Rectangle GetTracker();
        MCvBox2D GetRotatedTracker();
    }
}

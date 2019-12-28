using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.VideoSurveillance;

namespace Detectorv3.Motion
{
    public enum MotionType { MOG2, KNN }

    class BackSubstractor
    {        
        private BackgroundSubtractor bg;
        private Mat mask;

        public BackSubstractor(int history, double thres, bool shadow, MotionType type)
        {            
            mask = new Mat();
            if (type == MotionType.KNN)
                bg = new BackgroundSubtractorKNN(history, thres, shadow);
            else
                bg = new BackgroundSubtractorMOG2(history, (float)thres, shadow);
        }

        public Mat GetMask(Mat bgrImg, double learning = 0.0001d)
        {
            bg.Apply(bgrImg, mask, learning);
            return mask;
        }

        public void Destroy()
        {
            if (bg != null)
            {
                bg.Dispose();
                bg = null;
            }
        }
    }
}

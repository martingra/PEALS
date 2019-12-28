using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Emgu.CV;

namespace Detectorv3.Motion
{
    class Hand
    {
        private Mat img_hand;

        public Hand()
        {
            img_hand = new Mat();
        }


    }

    public struct HandSkeleton
    {
        public PointF p_center;
        public PointF p_pulgar;
        public PointF p_indice;
        public PointF p_medio;
        public PointF p_anular;
        public PointF p_menor;
    }
}

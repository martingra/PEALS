using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

using System.Drawing;

namespace Detector.SkinDetector
{
    class OpticalMotion
    {
        private Image<Gray, byte> colourPrev = null;
        private Image<Gray, byte> model;

        private MCvTermCriteria criteria;
        private byte[] status;
        private float[] error;

        private bool _useModel;

        public bool CalculateMap { set; get; }
        public Image<Bgr, Byte> ColourMap { set; get; }

        public PointF[][] preFeatures;
        public PointF[] curFeatures;

        public OpticalMotion()
        {
            criteria = new MCvTermCriteria(10, 0.03d);
            model = null;
            _useModel = model != null;
        }

        public OpticalMotion(Image<Bgr, byte> modelo) : this()
        {
            //this.model = modelo.Convert<Gray, byte>();
            _useModel = modelo != null;

            //CalculateFeatures(this.model);
        }

        public OpticalMotion(MCvTermCriteria criteria) : this()
        {
            this.criteria = criteria;
        }

        public OpticalMotion(Image<Bgr, byte> modelo, MCvTermCriteria criteria)
        {
            this.criteria = criteria;
            //this.model = modelo.Convert<Gray, byte>();

            _useModel = modelo != null;

            //CalculateFeatures(this.model);
        }

        /// <summary>
        /// Calcula el moviento de una imágen
        /// </summary>
        /// <param name="grayFrame">Imágen usada para calcular el movimiento.</param>
        /// <returns>Devuelve true si pudo calcular el flujo óptico y false en caso contrario</returns>
        public bool Update(Image<Bgr, byte> frame)
        {            
            Image<Gray, byte> gray = frame.Convert<Gray, byte>();
            if (model == null)
            {
                CalculateFeatures(gray);
                return false;
            }

            OpticalFlow.PyrLK(model, gray, preFeatures[0], new Size(10, 10), 3, criteria, out curFeatures, out status, out error);

            if (CalculateMap)
                ColourMap = GetColourMap(model, gray);

            if (!_useModel)
                CalculateFeatures(gray);

            return true;
        }

        public void Clear(OpticalMotion obj, float tolerance = 20.0f)
        {
            for (int i = 0; i < obj.curFeatures.Length; i++)
            {
                for (int j = 0; j < curFeatures.Length; j++)
                {
                    int distanciaX = (int)Math.Abs(curFeatures[j].X - obj.curFeatures[i].X);
                    int distanciaY = (int)Math.Abs(curFeatures[j].Y - obj.curFeatures[i].Y);
                    float h = (float)Math.Sqrt(Math.Pow(distanciaX, 2) + Math.Pow(distanciaY, 2));
                    
                    if (h <= tolerance)
                    {
                        curFeatures[j] = PointF.Empty;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene el mapa de movimiento de dos entre dos imágenes
        /// </summary>
        /// <param name="prevFrame">Imágen a comparar 1</param>
        /// <param name="frame">Imágen a comparar 2</param>
        /// <returns>Devuevlo una imágen BGR con resaltando el movimiento.</returns>
        private Image<Bgr, byte> GetColourMap(Image<Gray, byte> prevFrame, Image<Gray, byte> frame)
        {
            Image<Gray, float> FlowX = new Image<Gray, float>(frame.Size);
            Image<Gray, float> FlowY = new Image<Gray, float>(frame.Size);
            Image<Gray, float> FlowResult = new Image<Gray, float>(frame.Size);

            OpticalFlow.Farneback(prevFrame, frame, FlowX, FlowY, 0.5, 1, 10, 2, 5, 1.1, OPTICALFLOW_FARNEBACK_FLAG.USE_INITIAL_FLOW);

            //Find the length for the whole array
            FlowY = FlowY.Mul(FlowY); //Y*Y
            FlowX = FlowX.Mul(FlowX); //X*X
            FlowResult = FlowX + FlowY; //X^2 + Y^2
            CvInvoke.cvSqrt(FlowResult, FlowResult); //SQRT(X^2 + Y^2)

            //Apply a colour map.
            Image<Bgr, byte> colourMap = new Image<Bgr, Byte>(frame.Size);
            CvInvoke.ApplyColorMap(FlowResult.Convert<Gray, Byte>() * 5, colourMap, ColorMapType.Jet);

            return colourMap;
        }

        private void CalculateFeatures(Image<Gray, Byte> grayFrame)
        {
            model = grayFrame.Copy();
            preFeatures = model.GoodFeaturesToTrack(1000, 0.05, 5.0, 3);
            model.FindCornerSubPix(preFeatures, new Size(5, 5), new Size(-1, -1), new MCvTermCriteria(25, 1.5d));
        }
    }
}

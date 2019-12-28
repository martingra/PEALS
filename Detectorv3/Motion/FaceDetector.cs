using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using System.Drawing;
using Emgu.CV.Structure;

namespace Detector
{
    class FaceDetector
    {
        #region ATRIBUTOS
        
        // clasificadores
        private CascadeClassifier haar_cara   = new CascadeClassifier("haarcascade_frontalface_default.xml");
        private CascadeClassifier haar_nariz  = new CascadeClassifier("haarcascade_mcs_nose.xml");

        // cuantos frames sin detección deben pasar antes de limpiar los datos. 
        // si es -1, no se limpian los datos
        private int persistent = -1;
        
        // frames sin detectar
        private int badFrames = 0;

        #endregion ATRIBUTOS

        // objeto con todos los datos de la cara
        public Face Face = new Face();

        public FaceDetector(int persistent) 
        {
            this.persistent = persistent;
        }

        ~FaceDetector()
        {
            haar_cara.Dispose();
            haar_nariz.Dispose();
        }

        /// <summary>
        /// Busca una cara en el frame actual
        /// </summary>
        /// <param name="gray_img">Frame donde se debe buscar</param>
        /// <returns>True si encuentra una cara</returns>
        public bool BuscarCara(Mat gray_img){
            bool ret = false;
            Mat img_cara = new Mat();

            Rectangle[] rects = haar_cara.DetectMultiScale(gray_img, 1.1, 3, new Size(20, 20), new Size());
            for (int i = 0; i < rects.Length; i++)
            {
                img_cara = new Mat(gray_img, rects[i]);

                // busco una nariz para confirmar que es una cara y evitar falsos positivos
                if (ret = (haar_nariz.DetectMultiScale(img_cara, 1.1, 1, new Size(), new Size()).Length > 0))
                {
                    Face.ROI = rects[i];

                    break;
                }
            }

            if (img_cara != null)
                img_cara.Dispose();

            Face.IsEmpty = !ret;
            return ret;
        }

        /// <summary>
        /// Actualiza los valores de la cara que se esta siguiendo
        /// </summary>
        /// <param name="gray_img">Frame donde se busca la cara</param>
        /// <param name="rec_face">ROI con la cara que se esta siguiendo</param>
        public void Actualizar(Mat gray_img, Rectangle rec_face)
        {
            if (rec_face.IsEmpty)
            {
                if (persistent != -1 && ++badFrames > persistent)
                {
                    Face = new Face();
                    badFrames = 0;
                }

                return;
            }

            bool checkWidth= (rec_face.X > 0 && rec_face.X + rec_face.Width < gray_img.Width);
            bool checkHeight= (rec_face.Y > 0 && rec_face.Y + rec_face.Height < gray_img.Height);
            if (checkWidth && checkHeight)
                Face.ROI = rec_face;
        }

        //public void Actualizar(Image<Gray, byte> gray_img, MCvBox2D box_face)
        //{
        //    Face.Box = box_face;
        //    Actualizar(gray_img, box_face.MinAreaRect());
        //}
    }

    /// <summary>
    /// Estructura con los puntos de interés de la cara
    /// </summary>
    public struct Face
    {
        public bool IsEmpty;        

        public Rectangle ROI;
        //public MCvBox2D Box;
    }
}

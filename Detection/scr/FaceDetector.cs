using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using System.Drawing;
using Emgu.CV.Structure;
using Detector.Motion;
using System.Threading;

namespace Detector
{
    class FaceDetector 
    {
        #region ATRIBUTOS
        
        // clasificadores
        private CascadeClassifier haar_cara   = new CascadeClassifier("C:/Peals/pruebaGabriel/peals/Detection/bin/Debug/haarcascade_frontalface_default.xml");
        private CascadeClassifier haar_nariz  = new CascadeClassifier("haarcascade_mcs_nose.xml");

        // cuantos frames sin detección deben pasar antes de limpiar los datos. 
        // si es -1, no se limpian los datos
        private int _persistent = -1;
        private int _badFrames = 0; // frames sin detectar
        private INativeTracker _tracker; // objeto que se crea una vez detectada la cara y se encarga de hacer el seguimiento

        private Image<Bgr, byte> _img;

        #endregion ATRIBUTOS

        private FaceDetectorListener _eventListener;

        // objeto con todos los datos de la cara
        private volatile Face _face;

        public FaceDetector(int persistent, FaceDetectorListener callbacks) 
        {
            this._persistent = persistent;
            this._face = new Face();
            this._eventListener = callbacks;
        }

        ~FaceDetector()
        {
            haar_cara.Dispose();
            haar_nariz.Dispose();

            if (_face != null) _face.Dispose();
            if (_img != null) _img.Dispose();
        }

        public void UpdateImage(Image<Bgr, byte> image)
        {
            this._img = image.Clone();
        }

        public void DoWork()
        {
            if (_tracker == null)
            {
                using (Image<Gray, byte> img_gray = _img.Convert<Gray, byte>())
                {
                    if (BuscarCara(img_gray))
                    {
                        _tracker = new CMT(true, false, CMT.DETECTOR_TYPE.BRISK);
                        _tracker.SelectToTrack(img_gray, ref _face.ROI);

                        if (_eventListener != null)
                            _eventListener.OnFaceDetect();
                    }
                }
            }
            else
            {
                try
                {
                    _tracker.Update(_img);
                    Actualizar(ref _img, _tracker.GetRotatedTracker());

                    if (_eventListener != null)
                        _eventListener.OnFaceUpdate(_face.Copy());
                }
                catch (Exception ex) 
                {
                    string msg = ex.Message;
                }
            }

            _img.Dispose();
        }

        /// <summary>
        /// Busca una cara en el frame actual
        /// </summary>
        /// <param name="gray_img">Frame donde se debe buscar</param>
        /// <returns>True si encuentra una cara</returns>
        public bool BuscarCara(Image<Gray, byte> gray_img){
            bool ret = false;
            
            Rectangle[] rects = haar_cara.DetectMultiScale(gray_img, 1.1, 3, new Size(20, 20), new Size());
            for (int i = 0; i < rects.Length; i++)
            {
                using (Image<Gray, byte> img_cara = gray_img.Copy(rects[i]))
                {
                    // busco una nariz para confirmar que es una cara y evitar falsos positivos
                    if (ret = (haar_nariz.DetectMultiScale(img_cara, 1.1, 1, new Size(), new Size()).Length > 0))
                    {
                        _face.ROI = rects[i];

                        break;
                    }
                }
            }

            return ret;
        }

        /// <summary>
        /// Actualiza los valores de la cara que se esta siguiendo
        /// </summary>
        /// <param name="gray_img">Frame donde se busca la cara</param>
        /// <param name="rec_face">ROI con la cara que se esta siguiendo</param>
        public void Actualizar(ref Image<Bgr, byte> img, Rectangle rec_face)
        {
            if (rec_face.IsEmpty)
            {
                if (_persistent != -1 && ++_badFrames > _persistent)
                {
                    _face.Clear();
                    _badFrames = 0;
                }

                return;
            }
            
            bool checkWidth = (rec_face.X > 0 && rec_face.X + rec_face.Width < img.Size.Width);
            bool checkHeight = (rec_face.Y > 0 && rec_face.Y + rec_face.Height < img.Size.Height);
            if (checkWidth && checkHeight)
            {
                _face.ROI = rec_face;

                double[] minValues, maxValues;
                Point[] minLoc, maxLoc;
                using (Image<Bgr, byte> img_cara = img.Copy(rec_face))
                {
                    img_cara.MinMax(out minValues, out maxValues, out minLoc, out maxLoc);

                    _face.min = new Bgr(minValues[0], minValues[1], minValues[2]);
                    _face.max = new Bgr(maxValues[0], maxValues[1], maxValues[2]);
                }
            }
        }

        public void Actualizar(ref Image<Bgr, byte> img, MCvBox2D box_face)
        {
            _face.Box = box_face;
            Actualizar(ref img, box_face.MinAreaRect());
        }
    }

    public interface FaceDetectorListener
    {
        void OnFaceDetect();
        void OnFaceUpdate(Face face);
    }

    /// <summary>
    /// Estructura con los puntos de interés de la cara
    /// </summary>
    public class Face
    {        
        public Rectangle ROI;
        public MCvBox2D Box;

        public Bgr min;
        public Bgr max;

        public void Clear()
        {
            ROI = Rectangle.Empty;
            Box = MCvBox2D.Empty;
            min = new Bgr();
            max = new Bgr();
        }

        public Face Copy()
        {
            Face copy = new Face();
            copy.ROI = ROI;
            copy.Box = Box;
            copy.min = min;
            copy.max = max;

            return copy;
        }

        public void Dispose() { Clear(); }

        ~Face() { Clear(); }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using Detector.Motion;
using Emgu.CV.Util;
using Emgu.CV.Features2D;
using Emgu.CV.VideoSurveillance;
using Detector.SkinDetector;
using Detector.ML;

namespace Detector.scr.Image_Processing
{
    public class Segmentacion
    {
        private Image<Bgr, byte> img;
        private Image<Gray, byte> imgCara;

        private CascadeClassifier cascadeCara;
        private string binPath;
        private Rectangle rCara;
        private Rectangle rCuerpo;

        private INativeTracker tracker;
        private bool detect = false;

        private BackgroundSubtractor bgSubCuerpo;
        private int refrescarMog = Int32.MinValue;
        private int limiteRefrescarMog = 20;

        private HsvSkinDetector detectorDePiel = new HsvSkinDetector();
        private YCrCbSkinDetector detectorDePielYcc = new YCrCbSkinDetector();

        private Clasificacion clasificacion = new Clasificacion();

        private int maxArea = 70000;
        private int minArea = 6000;
        private int smoothValue = 11;

        private string resultadoClasificacion = "";

        private MemStorage storage = new MemStorage();

        //----- cara ------
        private FaceSegmentacion detectorCara;
        private CascadeClassifier ccNariz;
        private PointF centroNariz = new PointF(3f, 3f);
        //-----------------

        /// <summary>
        /// Constructor
        /// </summary>
        public Segmentacion(int width, int height)
        {
            string binPath = getPath();
            cascadeCara = new CascadeClassifier(binPath + "\\Cascades\\haarcascade_frontalface_default.xml");
            ccNariz = new CascadeClassifier(binPath + "\\Cascades\\haarcascade_mcs_nose.xml");
            clasificacion.CargarEntrenamiento((int)Clasificacion.Clasificador.SVM, binPath + "\\Clasificador\\SVM.xml");

            detectorCara = new FaceSegmentacion(width, height, 11, 2, 2, false, false);
        }

        public string getPath()
        {
            binPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            return binPath.Replace("file:\\", "");
        }

        public Bitmap iniciarWeb(Bitmap imagenBmp)
        {
            Image<Bgr, byte> imagenBgr = new Image<Bgr, byte>(imagenBmp);
            Image<Gray, byte> imgMogColoreada = new Image<Gray, byte>(imagenBgr.Size);
            Image<Gray, byte> monitor;
            Rectangle r;
            bool esCara = false;
            return iniciar(imagenBgr.Flip(Emgu.CV.CvEnum.FLIP.HORIZONTAL), esCara, out r, out monitor, out imgMogColoreada, true).ToBitmap();
        }

        /// <summary>
        /// Punto de entrada desde la web para la segmentación de imágenes
        /// </summary>
        /// <param name="imagen">Imágen BMP</param>
        /// <returns>Imágen BMP</returns>
        public Image<Gray, byte> iniciar(Image<Bgr, byte> imagen, bool esCara, out Rectangle cmt, out Image<Gray, byte> monitorClasificador, out Image<Gray, byte> imgMogColoreada, bool clasificar)
        {
            String resultado = "";
            Image<Gray, byte> imgObjetivo = new Image<Gray,byte>(imagen.Size);
            Image<Gray, byte> rst = new Image<Gray, byte>(imagen.Size);
            imgMogColoreada = new Image<Gray, byte>(imagen.Size);

            monitorClasificador = imagen.Clone().Convert<Gray, byte>();

            cmt = Rectangle.Empty;

            img = imagen.Resize(640, 480, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);//new Image<Bgr, byte>(imagen);

            img = img.SmoothGaussian(smoothValue, smoothValue, 0, 0);

            if (rCara.IsEmpty)
                rCara = autodetectarCara(img);
            else
            {
                if (detect == false)
                {
                    iniciarCmt(img);
                    bgSubCuerpo = new BackgroundSubtractorMOG2(500, 16, true);

                }
                else
                {
                    tracker.Update(img);
                    rCara = tracker.GetTracker();
                    cmt = rCara;

                    bool checkWidth = (cmt.X > 0 && cmt.X + cmt.Width < imagen.Size.Width);
                    bool checkHeight = (cmt.Y > 0 && cmt.Y + cmt.Height < imagen.Size.Height);
                    if (checkWidth && checkHeight)
                        imgCara = detectarCara(imagen.Copy(cmt));

                    actualizarMog();
                    rst = detectarCuerpo(out imgMogColoreada);

                    
                    if (esCara)
                    {
                        imgObjetivo = imgCara;
                    }
                    else
                    {
                        imgObjetivo = rst;
                    }

                    if (clasificar)
                    {
                        resultado = clasificacion.clasificar(imgObjetivo, (int)Clasificacion.Clasificador.SVM, false, "", out monitorClasificador);
                        setResultadoClasificacion(resultado);
                    }
                }
            }
            return imgObjetivo;
        }

        /// <summary>
        /// Permite detectar automaticamente la cara en una imágen basandose en el haarcascade
        /// </summary>
        /// <param name="imagen"></param>
        /// <returns></returns>
        public Rectangle autodetectarCara(Image<Bgr, byte> imagen)
        {
            Rectangle roi = Rectangle.Empty;
            Rectangle[] objetosDetectados = cascadeCara.DetectMultiScale(imagen.Convert<Gray, Byte>(), 1.2d, 10, new Size(20, 20), new Size(500, 500));
            foreach (Rectangle r in objetosDetectados)
            {
                roi = r;
            }

            return roi;
        }

        /// <summary>
        /// Inicia el seguimiento con la técnica con CMT
        /// </summary>
        /// <param name="model_image">Imágen base</param>
        private void iniciarCmt(Image<Bgr, byte> model_image)
        {
            tracker = new CMT(false, false, CMT.DETECTOR_TYPE.BRISK);
            tracker.SelectToTrack(model_image, ref rCara);
            detect = true;
        }

        private Image<Gray, byte> detectarCara(Image<Bgr, byte> img_roi)
        {
            Rectangle[] nariz = ccNariz.DetectMultiScale(img_roi.Convert<Gray, Byte>(), 1.2d, 10, new Size(20, 20), new Size(500, 500));
            if (nariz.Count() > 0)
            {
                int c_x = nariz[0].X + nariz[0].Width / 2;
                int c_y = nariz[0].Y + nariz[0].Height / 2;

                centroNariz = new PointF(c_x, c_y);

                return detectorCara.ProcesarCara(img_roi, centroNariz);
            }
            return new Image<Gray, byte>(img_roi.Size);
        }

        private Image<Gray, byte> detectarCuerpo(out Image<Gray, byte> imgMogColoreada)
        {
            Image<Gray, byte> imagenPorcesada = bgSubCuerpo.ForegroundMask; //aplicarOpMorph(bgSubCuerpo.ForegroundMask, 2, 2);
            imagenPorcesada = imagenPorcesada.ThresholdToZero(new Gray(250));
            imagenPorcesada.Draw(rCara, new Gray(0), -1);
            Image<Gray, byte> imgMog = detectarManoSobreCuerpo(imagenPorcesada, out imgMogColoreada);
            return imgMog;
        }

        private Image<Gray, byte> detectarManoSobreCuerpo(Image<Gray, byte> imgMog, out Image<Gray, byte> imgMogColoreada)
        {
            Image<Gray, byte> img_piel = detectorDePiel.DetectSkin(img).Add(detectorDePielYcc.DetectSkin(img));

            //if (img_piel.CountNonzero()[0] > img.Width * img.Height * 0.5f)
            //{
            imgMog = imgMog.Mul(img_piel);
            //}

            imgMogColoreada = pintarMogCuerpo(imgMog);

            Image<Gray, Byte> imgBorde = obtenerBorder(imgMogColoreada);
            return imgBorde;
        }

        private Image<Gray, Byte> obtenerBorder(Image<Gray, Byte> imgMog)
        {
            Contour<Point> contour = null;
            double max_area = 0;
            Image<Bgr, byte> ret = new Image<Bgr, byte>(imgMog.Size);
            Image<Gray, byte> retorno = new Image<Gray, byte>(imgMog.Size);

            using (MemStorage storage = new MemStorage())
            {
                for (Contour<Point> tmp_contour = imgMog.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL, storage); tmp_contour != null; tmp_contour = tmp_contour.HNext)
                {
                    if (tmp_contour.Area > max_area)
                    {
                        max_area = tmp_contour.Area;
                        contour = tmp_contour;
                    }
                }

                if (contour != null && contour.Total > 0 && contour.Area < maxArea && contour.Area > minArea)
                {
                    ret.Draw(contour, new Bgr(1, 1, 1), -1);
                    retorno.Draw(contour, new Gray(1), -1);
                    Rectangle rMinAreaContorno = contour.GetMinAreaRect().MinAreaRect();

                    if (rMinAreaContorno.X < 0)
                        rMinAreaContorno.X = 0;
                    if (rMinAreaContorno.Y < 0)
                        rMinAreaContorno.Y = 0;
                    if (rMinAreaContorno.Right > ret.Width)
                        rMinAreaContorno.Width = ret.Width - rMinAreaContorno.X;
                    if (rMinAreaContorno.Bottom > ret.Height)
                        rMinAreaContorno.Height = ret.Height - rMinAreaContorno.Y;


                    Image<Bgr, byte> img_mano = ret.Mul(img);

                    Image<Gray, byte> imgConCanny = img_mano.Clone().Convert<Gray, byte>();

                    retorno = retorno.Mul(imgMog);
                    imgConCanny = retorno.Add(imgConCanny.Canny(20, 60));

                    retorno = separarManoDeBrazo(imgConCanny, contour);

                    refrescarMog = 0;
                }
                else
                {
                    refrescarMog++;
                    if (refrescarMog > limiteRefrescarMog)
                    {
                        bgSubCuerpo = new BackgroundSubtractorMOG2(500, 16, true);
                        refrescarMog = 0;
                    }
                }
            }

            return retorno;
        }

        private Image<Gray, byte> separarManoDeBrazo(Image<Gray, byte> retorno, Contour<Point> contour)
        {
            Image<Bgr, byte> auxRetorno = new Image<Bgr, byte>(retorno.Size);
            MCvMoments moments = contour.GetMoments();
            float cx = (float)(moments.GravityCenter.x);
            float cy = (float)(moments.GravityCenter.y);

            Seq<MCvConvexityDefect> defectos = contour.GetConvexityDefacts(storage, Emgu.CV.CvEnum.ORIENTATION.CV_COUNTER_CLOCKWISE);
            MCvConvexityDefect[] defects_points;

            Seq<PointF> ptsSobreCentro = new Seq<PointF>(storage);

            int numDefects = defectos.Total;
            defects_points = defectos.ToArray();

            Point pMasAlejado = new Point();

            for (int i = 0; i < defects_points.Length; i++)
            {
                Point p = new Point(defects_points[i].StartPoint.X, defects_points[i].StartPoint.Y);

                if (pMasAlejado == Point.Empty)
                {
                    pMasAlejado = p;
                }
                else
                {
                    if (pMasAlejado.Y > p.Y)
                        pMasAlejado = p;
                }

                if (p.Y < cy)
                {
                    ptsSobreCentro.Push(p);
                }
                else
                {
                    if (Math.Abs(cy - p.Y) < 30)
                        ptsSobreCentro.Push(p);
                }
            }

            if (ptsSobreCentro.ToArray().Length != 0)
            {
                CircleF centroMano = PointCollection.MinEnclosingCircle(ptsSobreCentro.ToArray());

                int diametro = (int)centroMano.Radius * 2;
                int xRect = (int)centroMano.Center.X - (int)centroMano.Radius;
                int yRect = (int)centroMano.Center.Y - (int)centroMano.Radius;

                Rectangle r = new Rectangle(xRect, yRect, diametro, diametro);

                if (r.X < 0)
                    r.X = 0;
                if (r.Y < 0)
                    r.Y = 0;

                if (r.Right > auxRetorno.Width)
                    r.Width = auxRetorno.Width - r.X;
                if (r.Bottom > auxRetorno.Height)
                    r.Height = auxRetorno.Height - r.Y;

                retorno = retorno.Copy(r);
            }
            return retorno;
        }


        /// <summary>
        /// Aplica apertura y cierre
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        private Image<Gray, byte> aplicarOpMorph(Image<Gray, byte> img, int ero, int dila)
        {
            //Apertura
            img = img.Erode(ero);
            img = img.Dilate(dila);
            //Cierre
            img = img.Dilate(ero);
            img = img.Erode(dila);
            return img;
        }


        public void setResultadoClasificacion(string valor)
        {
            resultadoClasificacion = valor;
        }

        public string getResultadoClasificacion()
        {
            return resultadoClasificacion;
        }


        private void actualizarMog()
        {
            bgSubCuerpo.Update(img, 0.001);
        }

        public void resetearMog()
        {
            bgSubCuerpo = new BackgroundSubtractorMOG2(500, 16, true);
            detectorCara.reset();
        }

        public Image<Gray, byte> pintarMogCuerpo(Image<Gray, byte> imgMog)
        {
            Image<Gray, byte> imagenColoreada = new Image<Gray, byte>(img.Size);

            if (rCara != Rectangle.Empty)
            {
                int medioCara = rCara.Right - (rCara.Width / 2);
                imagenColoreada.Draw(new Rectangle(0, 0, medioCara, imgMog.Height), new Gray(50), -1);
                imagenColoreada.Draw(new Rectangle(imgMog.Width - (imgMog.Width - medioCara), 0, imgMog.Width - medioCara, imgMog.Height), new Gray(150), -1);
            }
            return imgMog.Not().Add(new Gray(1)).Mul(imagenColoreada).Not();
        }
    }
}

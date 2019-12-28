using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.VideoSurveillance;
using Detector.SkinDetector;

namespace Detector.scr.Image_Processing
{
    class FaceSegmentacion
    {
        private int _smooth;
        private int _width, _height;
        private int _erode, _dilate;
        private bool _apertura, _cierre;

        private Image<Gray, byte> image_prev;

        private PointF centroNariz;
        private Rectangle[] cuadrantes = new Rectangle[4];

        private BackgroundSubtractor bgSubCara;

        private HsvSkinDetector hsv_skin = new HsvSkinDetector();
        private YCrCbSkinDetector ycc_skin = new YCrCbSkinDetector();

        public FaceSegmentacion(int width, int height, int smooth, int erode, int dilate, bool apertura, bool cierre)
        {
            _width = width; _height = height;
            _smooth = smooth;
            _erode = erode; _dilate = dilate;
            _apertura = apertura; _cierre = cierre;
            bgSubCara = new BackgroundSubtractorMOG2(500, 16, true);
        }

        public Image<Gray, byte> ProcesarCara(Image<Bgr, byte> img_roi, PointF nariz)
        {
            centroNariz = nariz;
            CalcularCuadrantes(img_roi.Width, img_roi.Height);
            Image<Gray, byte> imagenProcesada = PreprocesarImagen(img_roi);

            if (imagenProcesada != null)
            {
                Contour<Point> contour = null;
                double max_area = 0;

                Image<Rgba, byte> img_background = new Image<Rgba, byte>(imagenProcesada.Size);
                Image<Rgba, byte> img_tmp = new Image<Rgba, byte>(imagenProcesada.Size);
                Image<Rgba, byte> img_foreground = new Image<Rgba, byte>(img_roi.Size);

                using (MemStorage storage = new MemStorage())
                {
                    for (Contour<Point> tmp_contour = imagenProcesada.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL, storage); tmp_contour != null; tmp_contour = tmp_contour.HNext)
                    {
                        if (tmp_contour.Area > max_area)
                        {
                            max_area = tmp_contour.Area;
                            contour = tmp_contour;
                        }
                    }

                    if (contour != null && contour.Area > 1000)
                    {
                        img_background.Draw(contour, new Rgba(1, 1, 1, 1), -1);

                        img_tmp = img_background.Mul(img_roi.Convert<Rgba, byte>());
                        img_background = img_background.Mul(img_roi.Convert<Rgba, byte>()).SmoothGaussian(11).Canny(20, 20).Convert<Rgba, byte>();

                        img_background = img_tmp.Add(img_background);
                        img_tmp.Dispose();

                        if (contour.BoundingRectangle.IntersectsWith(cuadrantes[0]))
                            img_foreground.Draw(cuadrantes[0], new Rgba(255, 0, 0, 0.2), -1);
                        if (contour.BoundingRectangle.IntersectsWith(cuadrantes[1]))
                            img_foreground.Draw(cuadrantes[1], new Rgba(0, 255, 0, 0.2), -1);
                        if (contour.BoundingRectangle.IntersectsWith(cuadrantes[2]))
                            img_foreground.Draw(cuadrantes[2], new Rgba(0, 0, 255, 0.2), -1);
                        if (contour.BoundingRectangle.IntersectsWith(cuadrantes[3]))
                            img_foreground.Draw(cuadrantes[3], new Rgba(255, 255, 0, 0.2), -1);

                        return img_background.Mul(img_foreground).Convert<Gray, byte>();
                    }
                }
            }

            return null;
        }

        private void CalcularCuadrantes(int roi_width, int roi_height)
        {
            int c_x = (int)centroNariz.X;
            int c_y = (int)centroNariz.Y;

            cuadrantes[0] = new Rectangle(0, 0, c_x, c_y);
            cuadrantes[1] = new Rectangle(c_x, 0, roi_width - c_x, c_y);
            cuadrantes[2] = new Rectangle(c_x, c_y, roi_width - c_x, roi_height - c_y);
            cuadrantes[3] = new Rectangle(0, c_y, c_x, roi_height - c_y);
        }

        private Image<Gray, byte> PreprocesarImagen(Image<Bgr, byte> img_roi)
        {
            Image<Gray, byte> skin = hsv_skin.DetectSkin(img_roi).Add(ycc_skin.DetectSkin(img_roi));

            Image<Bgr, byte> img_smooth = img_roi.SmoothGaussian(_smooth, _smooth, 0, 0);
            bgSubCara.Update(img_smooth, 0.001);

            Image<Gray, byte> imagenProcesada = bgSubCara.ForegroundMask;
            try
            {
                imagenProcesada = aplicarOpMorph(imagenProcesada.ThresholdToZero(new Gray(250)));
                imagenProcesada = imagenProcesada.Mul(skin);

                if (image_prev != null)
                {
                    Image<Gray, byte> image_gray = image_prev.AbsDiff(img_smooth.Convert<Gray, byte>());
                    image_gray = image_gray.Mul(40).ThresholdBinary(new Gray(240), new Gray(255));//.Mul(skin);

                    if (image_gray.CountNonzero()[0] > (_width * _height * .25f))
                        imagenProcesada = imagenProcesada.Mul(image_gray);
                }

                image_prev = img_smooth.Convert<Gray, byte>();
            }
            catch (Exception ex) { }

            return imagenProcesada;
        }

        private Image<Gray, byte> aplicarOpMorph(Image<Gray, byte> img)
        {
            if (_apertura)
            {
                img = img.Erode(_erode);
                img = img.Dilate(_dilate);
            }

            if (_cierre)
            {
                img = img.Dilate(_dilate);
                img = img.Erode(_erode);
            }

            return img;
        }

        public void reset()
        {
            bgSubCara = new BackgroundSubtractorMOG2(500, 16, true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Features2D;
using Emgu.CV.Util;
using Detector.Motion;
using Emgu.CV.VideoSurveillance;

namespace Detector.Forms
{
    public partial class Occlusion : Form
    {
        private Capture capture;
        private Image<Bgr, byte> image;
        private Image<Bgr, byte> prev_image;
        private Image<Gray, byte> model_image;

        private bool drawingRoi = false;
        private bool detect = false;

        private INativeTracker tracker;

        private FastDetector fastCPU = new FastDetector(10, true);
        private BriefDescriptorExtractor descriptor = new BriefDescriptorExtractor();
        private BruteForceMatcher<Byte> _matcher;
        private Matrix<int> indices;

        private BackgroundSubtractor mog;

        private Brisk brisk = new Brisk(30, 3, 1.0f);

        private VectorOfKeyPoint modelKeyPoints;

        private Rectangle roi;
        private Rectangle rec_temp;

        private int _x1, _y1;
        private int _x2, _y2;

        private double width;
        private double height;

        CascadeClassifier nariz;
        CascadeClassifier ojo;
        CascadeClassifier cabeza;
        CascadeClassifier boca;

        Rectangle rNariz;
        Rectangle rOjoDerecho;
        Rectangle rOjoIzquierdo;
        Rectangle rCabeza;
        Rectangle rBoca;

        public Occlusion()
        {
            cabeza = new CascadeClassifier("haarcascade_frontalface_default.xml");
            nariz = new CascadeClassifier("haarcascade_mcs_nose.xml");
            ojo = new CascadeClassifier("haarcascade_mcs_lefteye.xml");
            boca = new CascadeClassifier("haarcascade_mcs_mouth.xml");
            InitializeComponent();
        }

        private void Occlusion_Load(object sender, EventArgs e)
        {
            roi = Rectangle.Empty;

            InitCamera();
        }

        private void InitCamera()
        {
            capture = new Capture();
            capture.QueryFrame();

            width = capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_WIDTH);
            height = capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT);

            Application.Idle += new EventHandler(onFrameChange);
        }

        void onFrameChange(object sender, EventArgs e)
        {
            image = capture.QueryFrame();

            if (detect && !drawingRoi)
            {
                tracker.Update(image);
                roi = tracker.GetTracker();

                //PointF[] ps = (tracker as CMT).GetKeyPoints();
                //foreach (PointF p in ps)
                //{
                //    if (p.X > roi.Left && p.X < roi.Right && p.Y > roi.Top && p.Y < roi.Bottom)
                //    {
                //        CircleF c = new CircleF(p, 3);
                //        image.Draw(c, new Bgr(0, 0, 255), 3);
                //    }
                //}




                //PointF[] ps = (tracker as CMT).GetKeyPoints();
                //foreach (PointF p in ps)
                //{
                //    CircleF c = new CircleF(p, 3);
                //    image.Draw(c, new Bgr(0, 0, 255), 3);
                //}

                try
                {
                    if (prev_image != null)
                    {
                        //Image<Gray, byte> gray = image.AbsDiff(prev_image).Convert<Gray, byte>().Copy(roi).Mul(5).ThresholdToZero(new Gray(200));
                        //gray = gray.Erode(1);
                        imageBox2.Image = image.Sobel(1, 1, 31);
                        Image<Gray, byte> gray = image.Sobel(1, 1, 11).Copy(roi).Convert<Gray, byte>();
                        imageBox1.Image = gray;

                        segmentarCara(image.Copy(roi).Clone());

                        imgBox2.Image = Draw(model_image, gray);
                    }

                    prev_image = image.Clone();
                }
                catch (Exception ex) { }
            }
            else
            {
                //Rectangle[] objetosDetectados = cabeza.DetectMultiScale(image.Convert<Gray, Byte>(), 1.2d, 10, new Size(20, 20), new Size(500, 500));
                //foreach (Rectangle r in objetosDetectados)
                //{
                //    roi = r;
                //    image.Draw(r, new Bgr(Color.Honeydew), 2);
                //}
            }

            if (!roi.IsEmpty && roi.Width > 0 && roi.Height > 0)
                image.Draw(roi, new Bgr(0, 255, 255), 3);

            imgBox1.Image = image;
        }

        public void segmentarCara(Image<Bgr, Byte> imgCara)
        {
            //detectarParteDeLaCara(imgCara, cabeza, ref rCabeza, new Bgr(Color.Blue), new Size(20, 20), new Size(500, 500), "");
            detectarParteDeLaCara(imgCara, boca, ref rBoca, new Bgr(Color.Red), new Size(20, 20), new Size(100, 50), "BOCA");
            detectarParteDeLaCara(imgCara, ojo, ref rOjoDerecho, new Bgr(Color.Green), new Size(20, 20), new Size(100, 100), "OJO_DERECHO");
            detectarParteDeLaCara(imgCara, ojo, ref rOjoIzquierdo, new Bgr(Color.Green), new Size(20, 20), new Size(100, 100), "OJO_IZQUIERDO");
            detectarParteDeLaCara(imgCara, nariz, ref rNariz, new Bgr(Color.Yellow), new Size(20, 20), new Size(100, 100), "");

            imgBoxSegmentacion.Image = imgCara;

            //dibujamos una linea horizontal y una vertical en la mitad de la nariz 
            imgCara.Draw(new LineSegment2D(new Point(0, rNariz.Y + (rNariz.Height / 2)), new Point(300, rNariz.Y + (rNariz.Height / 2))), new Bgr(Color.Gray), 2);
            imgCara.Draw(new LineSegment2D(new Point(rNariz.X + (rNariz.Width / 2), 0), new Point(rNariz.X + (rNariz.Width / 2), 300)), new Bgr(Color.Gray), 2);


            imgBoxOjoDer.Image = imgCara.Copy(rOjoDerecho);
            imgBoxOjoIzq.Image = imgCara.Copy(rOjoIzquierdo);
            imgBoxNariz.Image = imgCara.Copy(rNariz);
            imgBoxBoca.Image = imgCara.Copy(rBoca);

        }

        public void detectarParteDeLaCara(Image<Bgr, byte> img, CascadeClassifier haarCascade, ref Rectangle rectangulo, Bgr color, Size tamanioMinimo, Size tamanioMaximo, String validacion)
        {
            Rectangle[] objetosDetectados = haarCascade.DetectMultiScale(img.Convert<Gray, Byte>(), 1.2d, 10, tamanioMinimo, tamanioMaximo);
            foreach (Rectangle r in objetosDetectados)
            {
                if (validarParteCara(validacion, r, img))
                {
                    img.Draw(r, color, 2);
                    rectangulo = r;
                }
            }
        }

        public Boolean validarParteCara(String validacion, Rectangle rEncontrado, Image<Bgr, byte> img)
        {
            int medioCabezaY = 0;
            int medioCabezaX = 0;

            if (validacion == "")
            {
                return true;
            }
            else
            {
                medioCabezaY = rNariz.Y + (rNariz.Height /2);
                medioCabezaX = rNariz.X + (rNariz.Width / 2);
            }

            if (validacion.ToUpper() == "BOCA")
            {
                if (rEncontrado.Y < medioCabezaY)
                    return false;
                else
                    return true;
            }
            else if (validacion.ToUpper().Contains("OJO"))
            {
                if (rEncontrado.Y > medioCabezaY)
                {
                    return false;
                }
                else
                {
                    if (validacion.ToUpper() == "OJO_DERECHO")
                    {
                        if (rEncontrado.X > medioCabezaX)
                            return false;
                        else
                            return true;
                    }
                    else
                    {
                        if (rEncontrado.X < medioCabezaX)
                            return false;
                        else
                            return true;
                    }
                }
            }

            return false;
        }


        public Image<Bgr, Byte> Draw(Image<Gray, Byte> modelImage, Image<Gray, byte> observedImage)
        {
            //modelImage = modelImage.Not();
            //observedImage = observedImage.Not();

            VectorOfKeyPoint observedKeyPoints;

            Matrix<byte> mask;
            int k = 2;
            double uniquenessThreshold = 0.8;

            // extract features from the observed image
            //observedKeyPoints = fastCPU.DetectKeyPointsRaw(observedImage, null);
            //Matrix<Byte> observedDescriptors = descriptor.ComputeDescriptorsRaw(observedImage, null, observedKeyPoints);
            observedKeyPoints = brisk.DetectKeyPointsRaw(observedImage, null);
            Image<Bgr, Byte> result = observedImage.Convert<Bgr, byte>();

            if (observedKeyPoints.Size == 0) return result;

            Matrix<Byte> observedDescriptors = brisk.ComputeDescriptorsRaw(observedImage, null, observedKeyPoints);

            indices = new Matrix<int>(observedDescriptors.Rows, 2);
            using (Matrix<float> dist = new Matrix<float>(observedDescriptors.Rows, k))
            {                
                _matcher.KnnMatch(observedDescriptors, indices, dist, k, null);
                mask = new Matrix<byte>(dist.Rows, 1);
                mask.SetValue(255);
                Features2DToolbox.VoteForUniqueness(dist, uniquenessThreshold, mask);
            }


            List<int> list_indices = new List<int>();
            for (int i = 0; i < indices.Rows; i++)
            {
                list_indices.Add(indices[i, 0]);
                list_indices.Add(indices[i, 1]);
            }

            using (MemStorage storage = new MemStorage())
            {
                Seq<PointF> move = new Seq<PointF>(storage);
                for (int i = 0; i < observedKeyPoints.Size; i++)
                {
                    //if (list_indices.Contains(i)) continue;

                    if (observedKeyPoints[i].Angle < 90)
                    {
                        CircleF c = new CircleF(observedKeyPoints[i].Point, 2);
                        result.Draw(c, new Bgr(0, 255, 0), 2);
                    }
                    else if (observedKeyPoints[i].Angle < 180)
                    {
                        CircleF c = new CircleF(observedKeyPoints[i].Point, 2);
                        result.Draw(c, new Bgr(0, 0, 255), 2);
                    }
                    else if (observedKeyPoints[i].Angle < 270)
                    {
                        CircleF c = new CircleF(observedKeyPoints[i].Point, 2);
                        result.Draw(c, new Bgr(255, 0, 0), 2);
                    }
                    else
                    {
                        CircleF c = new CircleF(observedKeyPoints[i].Point, 2);
                        result.Draw(c, new Bgr(0, 255, 255), 2);
                    }

                    move.Push(observedKeyPoints[i].Point);
                }

                if (move.Total > 10)
                {
                    move = move.GetConvexHull(Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);
                    result.DrawPolyline(Array.ConvertAll<PointF, Point>(move.ToArray(), Point.Round), true, new Bgr(0, 0, 255), 2);
                }
            }

            return result;
        }

        private bool init = true;

        #region Mouse-Events

        private void imgBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _x1 = e.X;
            _y1 = e.Y;

            drawingRoi = true;

            rec_temp = new Rectangle();
        }

        private void imgBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!drawingRoi) return;

            _x2 = e.X;
            _y2 = e.Y;

            if (_x1 > _x2)
            {
                rec_temp.X = _x2;
                rec_temp.Width = _x1 - _x2;
            }
            else
            {
                rec_temp.X = _x1;
                rec_temp.Width = _x2 - _x1;
            }

            if (_y1 > _y2)
            {
                rec_temp.Y = _y2;
                rec_temp.Height = _y1 - _y2;
            }
            else
            {
                rec_temp.Y = _y1;
                rec_temp.Height = _y2 - _y1;
            }

            if (rec_temp.Width > 10 && rec_temp.Height > 10)
                roi = rec_temp;
        }

        private void imgBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drawingRoi = false;
            detect = false;
        }

        #endregion Mouse-Events

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            model_image = image.Copy(roi).Convert<Gray, byte>();
            imgBox_roi.Image = model_image;
        }

        Brisk b;

        private void btn_detectar_Click(object sender, EventArgs e)
        {
            //extract features from the object image
            //modelKeyPoints = fastCPU.DetectKeyPointsRaw(model_image, null);
            //Matrix<Byte> modelDescriptors = descriptor.ComputeDescriptorsRaw(model_image, null, modelKeyPoints);

            modelKeyPoints = brisk.DetectKeyPointsRaw(model_image, null);
            Matrix<Byte> modelDescriptors = brisk.ComputeDescriptorsRaw(model_image, null, modelKeyPoints);

            _matcher = new BruteForceMatcher<Byte>(DistanceType.L2Sqr);
            _matcher.Add(modelDescriptors);

            tracker = new CMT(false, false, CMT.DETECTOR_TYPE.BRISK);
            tracker.SelectToTrack(image, ref roi);

            detect = true;
        }

        private void imgBox_roi_Click(object sender, EventArgs e)
        {


        }
    }
}

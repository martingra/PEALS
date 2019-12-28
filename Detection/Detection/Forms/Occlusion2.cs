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
using Emgu.CV.UI;
using Emgu.CV.VideoSurveillance;
using Detector.SkinDetector;
using System.IO;
using System.Reflection;
using Emgu.CV.ML;
using Detector.ML;
using Detector.Motion;
using Emgu.CV.Features2D;

namespace Detector.Forms
{
    public partial class Occlusion2 : Form
    {
        Detector.scr.Image_Processing.Segmentacion seg = new Detector.scr.Image_Processing.Segmentacion(100,100);
        private Capture capture;
        private Image<Bgr, byte> image;
        private Image<Gray, byte> image_gray;
        private Image<Bgr, byte> model_image;

        private OpticalMotion flow = new OpticalMotion();
        private OpticalMotion flowCuerpo = new OpticalMotion();
        private OpticalMotion flowCara;

        private BackgroundSubtractor bgSubCuerpo;
        private int refrescarMog = Int32.MinValue;

        private MemStorage storage = new MemStorage();

        private bool drawingRoi = false;
        private bool detect = false;

        private Rectangle roi;
        private Rectangle rec_temp;
        private Rectangle rCuerpo;

        private HsvSkinDetector detectorDePiel = new HsvSkinDetector();
        private YCrCbSkinDetector detectorDePielYcc = new YCrCbSkinDetector();

        private CascadeClassifier ccCara;

        private int _x1, _y1;
        private int _x2, _y2;

        private double width;
        private double height;

        private Seq<PointF> occlusion_points;

        Matrix<float> trainData, trainClass;
        public List<string> str_clases;
        private int K = 1;
        private int sizex = 100;
        private int sizey = 100;
        private int imageSize;
        private KNearest knn;
        private ReconocimientoDeDigitos rdd;

        #region BACK_PROJECT PROP

        private Image<Hsv, Byte> hsv;
        private Image<Gray, Byte> hue;
        private Image<Gray, Byte> mask;
        private Image<Gray, Byte> backproject;
        private DenseHistogram hist;

        #endregion BACK_PROJECT PROP

        private INativeTracker tracker;

        private FastDetector fastCPU = new FastDetector(10, true);
        private BriefDescriptorExtractor descriptor = new BriefDescriptorExtractor();
        private BruteForceMatcher<Byte> _matcher;
        private Matrix<int> indices;

        private Emgu.CV.Util.VectorOfKeyPoint modelKeyPoints;

        public Occlusion2()
        {
            imageSize = sizex * sizey;
            rdd = new ReconocimientoDeDigitos();
            ccCara = new CascadeClassifier("haarcascade_frontalface_default.xml");
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

            hue = new Image<Gray, byte>((int)width, (int)height);
            hue._EqualizeHist();
            mask = new Image<Gray, byte>((int)width, (int)height);
            hist = new DenseHistogram(30, new RangeF(0, 180));
            backproject = new Image<Gray, byte>((int)width, (int)height);

            Application.Idle += new EventHandler(onFrameChange);
            Application.Idle += new EventHandler(onFrameChange1);
        }

        void onFrameChange(object sender, EventArgs e)
        {
            image = capture.QueryFrame();
            
            

            

            if (this.chbDetectarCuerpo.Checked == true)
            {
                Rectangle cmt;
                //imgBoxPrueba.Image = seg.iniciar(image, out cmt);

                detectarCuerpo(image);
            }

            if (detect && !drawingRoi)
            {
                tracker.Update(image);
                Rectangle tmp = tracker.GetTracker();

                if (!(tmp.IsEmpty || tmp.X < 0 || tmp.Y < 0 || tmp.Right >= image.Width || tmp.Bottom >= image.Height))
                {
                    roi.X = tmp.X;
                    roi.Y = tmp.Y;
                }

                Image<Bgr, byte> img_roi = image.Copy(roi);

                image_gray = img_roi.SmoothGaussian((int)txtSmooth.Value, (int)txtSmooth.Value, 0, 0).Convert<Gray, byte>().Canny((int)nro_cannyMin.Value, (int)nro_cannyMax.Value);
                image_gray = aplicarOpMorph(image_gray);
                img_harris.Image = image_gray;

                flowCara.Update(img_roi);
                if (!flow.Update(img_roi))
                    return;

                flow.Clear(flowCara);

                List<PointF> move_points = new List<PointF>();
                for (int i = 0; i < flow.curFeatures.Length; i++)
                {
                    if (flow.curFeatures[i] == PointF.Empty)
                        continue;

                    if (i < flow.preFeatures[0].Length)
                    {
                        int distanciaX = (int)Math.Abs(flow.preFeatures[0][i].X - flow.curFeatures[i].X);
                        int distanciaY = (int)Math.Abs(flow.preFeatures[0][i].Y - flow.curFeatures[i].Y);
                        float h = (float)Math.Sqrt(Math.Pow(distanciaX, 2) + Math.Pow(distanciaY, 2));

                        if (h > float.Parse(nro_movimiento.Value.ToString()))
                            move_points.Add(flow.curFeatures[i]);
                    }
                    else
                    {
                        move_points.Add(flow.curFeatures[i]);
                    }
                }

                if (move_points.Count > 0)
                {
                    int[] contador = new int[move_points.Count];
                    for (int i = 0; i < move_points.Count - 1; i++)
                    {
                        for (int j = i + 1; j < move_points.Count; j++)
                        {
                            int distanciaX = (int)Math.Abs(move_points[i].X - move_points[j].X);
                            int distanciaY = (int)Math.Abs(move_points[i].Y - move_points[j].Y);
                            float h = (float)Math.Sqrt(Math.Pow(distanciaX, 2) + Math.Pow(distanciaY, 2));

                            if (h > float.Parse(nro_distancia.Value.ToString()))
                                contador[j]++;
                        }
                    }

                    Seq<PointF> points = new Seq<PointF>(storage);
                    for (int i = 0; i < move_points.Count; i++)
                        if (contador[i] < float.Parse(nro_votos.Value.ToString()))
                            points.Push(move_points[i]);

                    if (points.Total > 0)
                    {
                        points = points.GetConvexHull(Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE, storage);
                        if (points.Area < float.Parse(nro_areaMax.Value.ToString()) && points.Area > float.Parse(nro_areaMin.Value.ToString()))
                            occlusion_points = points;
                    }
                }

                if (occlusion_points != null && occlusion_points.Total > 0)
                {
                    Rectangle rect_tmp = occlusion_points.BoundingRectangle;
                    int x = (rect_tmp.X < 0) ? 0 : rect_tmp.X;
                    int y = (rect_tmp.Y < 0) ? 0 : rect_tmp.Y;
                    int width = (rect_tmp.Right > img_roi.Width) ? img_roi.Width : rect_tmp.Width;
                    int height = (rect_tmp.Bottom > img_roi.Height) ? img_roi.Height : rect_tmp.Height;

                    Rectangle rect = new Rectangle(x, y, width, height);

                    Image<Bgr, byte> img = new Image<Bgr, byte>(img_roi.Size);
                    Emgu.CV.Util.VectorOfKeyPoint observedKeyPoints = fastCPU.DetectKeyPointsRaw(img_roi.Convert<Gray, byte>(), null);
                    for (int i = 0; i < observedKeyPoints.Size; i++)
                    {
                        CircleF c = new CircleF(observedKeyPoints[i].Point, 2);
                        img.Draw(c, new Bgr(0, 255, 0), 2);
                    }

                    Image<Gray, byte> mask = new Image<Gray, byte>(img_roi.Size);
                    mask.Draw(rect, new Gray(1), -1);
                    mask = img.Convert<Gray, byte>().Mul(mask);

                    img_features.Image = mask;
                }
            }

            if (!roi.IsEmpty && roi.Width > 0 && roi.Height > 0)
                image.Draw(roi, new Bgr(0, 255, 255), 3);

            img_original.Image = image;
        }

        void onFrameChange1(object sender, EventArgs e)
        {
            image = capture.QueryFrame();

            if (this.chbDetectarCuerpo.Checked == true)
            {
                detectarCuerpo(image);
            }

            if (chClasificar.Checked == true)
            {
                clasificar();
            }

            if (detect && !drawingRoi)
            {
                tracker.Update(image);
                Rectangle tmp = tracker.GetTracker();

                if (!(tmp.IsEmpty || tmp.X < 0 || tmp.Y < 0 || tmp.Right >= image.Width || tmp.Bottom >= image.Height))
                {
                    roi.X = tmp.X;
                    roi.Y = tmp.Y;
                }

                Image<Bgr, byte> img_roi = image.Copy(roi);

                image_gray = img_roi.SmoothGaussian((int)txtSmooth.Value, (int)txtSmooth.Value, 0, 0).Convert<Gray, byte>().Canny((int)nro_cannyMin.Value, (int)nro_cannyMax.Value);
                image_gray = aplicarOpMorph(image_gray);
                img_harris.Image = image_gray;

                flowCara.Update(img_roi);
                if (!flow.Update(img_roi))
                    return;

                flow.Clear(flowCara);

                List<PointF> move_points = new List<PointF>();
                for (int i = 0; i < flow.curFeatures.Length; i++)
                {
                    if (flow.curFeatures[i] == PointF.Empty)
                        continue;

                    if (i < flow.preFeatures[0].Length)
                    {
                        int distanciaX = (int)Math.Abs(flow.preFeatures[0][i].X - flow.curFeatures[i].X);
                        int distanciaY = (int)Math.Abs(flow.preFeatures[0][i].Y - flow.curFeatures[i].Y);
                        float h = (float)Math.Sqrt(Math.Pow(distanciaX, 2) + Math.Pow(distanciaY, 2));

                        if (h > float.Parse(nro_movimiento.Value.ToString()))
                            move_points.Add(flow.curFeatures[i]);
                    }
                    else
                    {
                        move_points.Add(flow.curFeatures[i]);
                    }
                }

                if (move_points.Count > 0)
                {
                    int[] contador = new int[move_points.Count];
                    for (int i = 0; i < move_points.Count - 1; i++)
                    {
                        for (int j = i + 1; j < move_points.Count; j++)
                        {
                            int distanciaX = (int)Math.Abs(move_points[i].X - move_points[j].X);
                            int distanciaY = (int)Math.Abs(move_points[i].Y - move_points[j].Y);
                            float h = (float)Math.Sqrt(Math.Pow(distanciaX, 2) + Math.Pow(distanciaY, 2));

                            if (h > float.Parse(nro_distancia.Value.ToString()))
                                contador[j]++;
                        }
                    }

                    Seq<PointF> points = new Seq<PointF>(storage);
                    for (int i = 0; i < move_points.Count; i++)
                        if (contador[i] < float.Parse(nro_votos.Value.ToString()))
                            points.Push(move_points[i]);

                    if (points.Total > 0)
                    {
                        points = points.GetConvexHull(Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE, storage);
                        if (points.Area < float.Parse(nro_areaMax.Value.ToString()) && points.Area > float.Parse(nro_areaMin.Value.ToString()))
                            occlusion_points = points;
                    }
                }

                if (occlusion_points != null && occlusion_points.Total > 0)
                {
                    Rectangle rect_tmp = occlusion_points.BoundingRectangle;
                    int x = (rect_tmp.X < 0) ? 0 : rect_tmp.X;
                    int y = (rect_tmp.Y < 0) ? 0 : rect_tmp.Y;
                    int width = (rect_tmp.Right > img_roi.Width) ? img_roi.Width : rect_tmp.Width;
                    int height = (rect_tmp.Bottom > img_roi.Height) ? img_roi.Height : rect_tmp.Height;

                    Rectangle rect = new Rectangle(x, y, width, height);

                    Image<Bgr, byte> img = new Image<Bgr, byte>(img_roi.Size);

                    Image<Gray, byte> mask = new Image<Gray, byte>(img_roi.Size);
                    mask.Draw(rect, new Gray(1), -1);
                    mask = img.Convert<Gray, byte>().Mul(mask);

                    img_features.Image = mask;
                }
            }

            if (!roi.IsEmpty && roi.Width > 0 && roi.Height > 0)
                image.Draw(roi, new Bgr(0, 255, 255), 3);

            img_original.Image = image;
        }


        public Image<Gray, byte> FindAndDrawContours(Image<Gray, byte> image)
        {
            Image<Gray, byte> ret = new Image<Gray, byte>(image.Size);
            using (MemStorage storage = new MemStorage())
            {
                for (Contour<Point> tmp_contour = image.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL, storage); tmp_contour != null; tmp_contour = tmp_contour.HNext)
                {
                    ret.DrawPolyline(tmp_contour.ToArray(), false, new Gray(255), 2);
                }
            }

            return ret;
        }

        public void DrawPoints(Image<Bgr, byte> image, PointF[] points, Color color)
        {
            for (int i = 0; i < points.Length; i++)
            {
                PointF p = points[i];
                CircleF c_point = new CircleF(p, 2);
                image.Draw(c_point, new Bgr(color), 2);
            }
        }

        public void DrawPoints(Image<Bgr, byte> image, PointF[] points, Color color, Rectangle rect)
        {
            for (int i = 0; i < points.Length; i++)
            {
                PointF p = points[i];
                if (p.X > rect.X && p.X < rect.Right && p.Y > rect.Y && p.Y < rect.Bottom)
                {
                    CircleF c_point = new CircleF(p, 2);
                    image.Draw(c_point, new Bgr(color), 2);
                }
            }
        }

        public Image<Bgr, Byte> Draw(Image<Gray, Byte> modelImage, Image<Gray, byte> observedImage)
        {
            Emgu.CV.Util.VectorOfKeyPoint observedKeyPoints;

            Matrix<byte> mask;
            int k = 2;
            double uniquenessThreshold = 0.8;

            // extract features from the observed image
            observedKeyPoints = fastCPU.DetectKeyPointsRaw(observedImage, null);
            Matrix<Byte> observedDescriptors = descriptor.ComputeDescriptorsRaw(observedImage, null, observedKeyPoints);

            Image<Bgr, Byte> result = observedImage.Convert<Bgr, byte>();

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

        #region Click-Events

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            model_image = image.Copy(roi);
            img_roi.Image = model_image;
        }

        private void btn_detectar_Click(object sender, EventArgs e)
        {
            Image<Gray, byte> gray = model_image.Convert<Gray, byte>();

            //extract features from the object image
            modelKeyPoints = fastCPU.DetectKeyPointsRaw(gray, null);
            Matrix<Byte> modelDescriptors = descriptor.ComputeDescriptorsRaw(gray, null, modelKeyPoints);

            _matcher = new BruteForceMatcher<Byte>(DistanceType.L2Sqr);
            _matcher.Add(modelDescriptors);

            flowCara = new OpticalMotion(model_image);

            tracker = new CMT(false, false, CMT.DETECTOR_TYPE.BRISK);
            tracker.SelectToTrack(image, ref roi);

            detect = true;
        }

        #endregion Click-Events

        #region BackProjection

        private void actualizarBackProjct(Image<Bgr, byte> img)
        {
            obtenerHistograma(img);

            // Calucate BackProject
            backproject = hist.BackProject(new Image<Gray, Byte>[] { hue });

            // Apply mask
            backproject._And(mask);
        }

        private void obtenerHistograma(Image<Bgr, Byte> image)
        {
            UpdateHue(image); //obtiene el hue a partir del bgr de la imagen

            // Set tracking object's ROI
            hue.ROI = roi;
            mask.ROI = roi;
            hist.Calculate(new Image<Gray, Byte>[] { hue }, false, mask);

            // Scale Historgram
            float max = 0, min = 0, scale = 0;
            int[] minLocations, maxLocations;

            hist.MinMax(out min, out max, out minLocations, out maxLocations);
            if (max != 0)
                scale = 255 / max;

            CvInvoke.cvConvertScale(hist.MCvHistogram.bins, hist.MCvHistogram.bins, scale, 0);

            // Clear ROI
            hue.ROI = System.Drawing.Rectangle.Empty;
            mask.ROI = System.Drawing.Rectangle.Empty;
        }

        private void UpdateHue(Image<Bgr, Byte> image)
        {
            // release previous image memory
            if (hsv != null) hsv.Dispose();
            hsv = image.Convert<Hsv, Byte>();

            // Drop low saturation pixels
            mask = hsv.Split()[1].ThresholdBinary(new Gray(60), new Gray(255));
            CvInvoke.cvInRangeS(hsv, new MCvScalar(0, 30, Math.Min(10, 255), 0),
                new MCvScalar(180, 256, Math.Max(10, 255), 0), mask);

            // Get Hue
            hue = hsv.Split()[0];
        }

        #endregion BackProjection

        private void detectarCuerpo(Image<Bgr, byte> currentFrame)
        {
            //bgSubCuerpo.Update(currentFrame, 0.00001);

            if (this.chbSmooth.Checked)
                currentFrame = currentFrame.SmoothGaussian((int)this.txtSmooth.Value, (int)this.txtSmooth.Value, 0, 0);

            bgSubCuerpo.Update(currentFrame, 0.001);
            Image<Gray, byte> imagenPorcesada = aplicarOpMorph(bgSubCuerpo.ForegroundMask);

            //img_roi.Image = imagenPorcesada;

            imagenPorcesada = imagenPorcesada.ThresholdToZero(new Gray(245));
            //img_features.Image = imagenPorcesada;

            if (chDetectarZonaCara.Checked)
                imgBoxCuerpo.Image = detectarCabeza(imagenPorcesada);
            else
            {
                Image<Bgr, byte> imgMog = detectarManoSobreCuerpo(imagenPorcesada, currentFrame);
                
                
                
                
                //Rectangle rc = new Rectangle(0, roi.Bottom, imagenPorcesada.Width, imagenPorcesada.Height - roi.Bottom);

                //Image<Gray, byte> imgPiel = detectorDePiel.DetectSkin(currentFrame).Copy(rc);
                //Image<Gray, byte> imgPielYcc = detectorDePielYcc.DetectSkin(currentFrame).Copy(rc);
                //Image<Gray, byte> imgMogBN = imgMog.Convert<Gray, Byte>().ThresholdBinary(new Gray(60), new Gray(255));

                //imgMog.FindContours();

                //imgBoxPielMog.Image = imgMogBN;
                //imgBoxPiel.Image = imgPiel.Add(imgPielYcc);
                //imgBoxCuerpo.Image = imgMogBN.Mul(imgPiel.Add(imgPielYcc));
            }
        }

        private Image<Bgr, byte> detectarCabeza(Image<Gray, byte> img)
        {
            rCuerpo = new Rectangle(0, roi.Top, img.Width, img.Height - roi.Top);
            Image<Gray, byte> img_roi = img.Copy(rCuerpo);


            Contour<Point> contour; bool hayBorde; string str_area;
            Image<Gray, byte> ca = img_roi.Canny(20, 60);
            Image<Bgr, Byte> imgBorde = obtenerBorder(img_roi, ca, ref rCuerpo, out str_area, out contour, out hayBorde);

            return imgBorde;
        }

        private Image<Bgr, byte> detectarManoSobreCuerpo(Image<Gray, byte> img, Image<Bgr, byte> imgColor)
        {
            rCuerpo = new Rectangle(0, roi.Bottom, img.Width, img.Height - roi.Bottom);
            Image<Gray, byte> img_roi = img.Copy(rCuerpo);

            imgBoxPielMog.Image = img_roi;

            imgColor = imgColor.Copy(rCuerpo);

            Image<Gray, byte> img_piel = detectorDePiel.DetectSkin(imgColor).Add(detectorDePielYcc.DetectSkin(imgColor));


            //if (img_piel.CountNonzero()[0] > width * height *0.5f)
            //{
                img_roi = img_roi.Mul(img_piel);
            //}
            //imgBoxCuerpo.Image = img_roi;
            imgBoxPiel.Image = img_piel;

            Contour<Point> contour; bool hayBorde; string str_area;
            Image<Gray, byte> ca = img_roi.Canny(20, 60);
            Image<Bgr, Byte> imgBorde = obtenerBorder(img_roi, ca, ref rCuerpo, out str_area, out contour, out hayBorde);

            imgBoxCuerpo.Image = imgBorde;
            return imgBorde;
        }

        private Image<Bgr, Byte> obtenerBorder(Image<Gray, Byte> frame, Image<Gray, Byte> roiFrame, ref Rectangle rMinAreaContorno, out string area, out Contour<Point> contour, out bool hayBorde)
        {
            contour = null;
            double max_area = 0;
            Image<Bgr, Byte> ret = new Image<Bgr, byte>(rCuerpo.Size);
            Image<Bgr, Byte> retorno = new Image<Bgr, byte>(rCuerpo.Size);
            Image<Bgr, byte> img_mano_color = image.Copy(rCuerpo);
            hayBorde = false;
            area = "";

            try
            {
                using (MemStorage storage = new MemStorage())
                {
                    for (Contour<Point> tmp_contour = frame.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL, storage); tmp_contour != null; tmp_contour = tmp_contour.HNext)
                    {
                        if (tmp_contour.Area > max_area)
                        {
                            max_area = tmp_contour.Area;
                            contour = tmp_contour;
                        }
                    }

                    //contour = (contour != null) ? contour.ApproxPoly(contour.Perimeter * 0.0025, 1, storage) : null;

                    if (contour != null)
                        contour = contour;// contour.ApproxPoly(contour.Perimeter * 0.0025, 1, storage);
                    else
                        contour = null;

                    area = max_area.ToString();
                    txtArea.Text = area;
                    txtRefrescarMog.Text = refrescarMog.ToString();

                    if (contour != null && (max_area > 0 && max_area < (int)txtMaxArea.Value && max_area > (int)txtMinArea.Value))
                    {
                        ret.Draw(contour, new Bgr(1, 1, 1), -1);
                        retorno.Draw(contour, new Bgr(Color.Red), -1);
                        rMinAreaContorno = contour.GetMinAreaRect().MinAreaRect();
                        hayBorde = true;

                        //ret.Draw(rMinAreaContorno, new Bgr(Color.Orange), 2);

                        if (rMinAreaContorno.X < 0)
                            rMinAreaContorno.X = 0;
                        if (rMinAreaContorno.Y < 0)
                            rMinAreaContorno.Y = 0;
                        if (rMinAreaContorno.Right > ret.Width)
                            rMinAreaContorno.Width = ret.Width - rMinAreaContorno.X;
                        if (rMinAreaContorno.Bottom > ret.Height)
                            rMinAreaContorno.Height = ret.Height - rMinAreaContorno.Y;


                        Image<Bgr, byte> img_mano = ret.Mul(img_mano_color);

      
                        //img_mano = img_mano.Copy(rMinAreaContorno).SmoothGaussian((int)txtSmooth.Value);
                        //img_mano = retorno.Copy(rMinAreaContorno).Add(img_mano.Canny(20, 60).Convert<Bgr, byte>());
                        //img_mano = img_mano.Canny(20, 60).Convert<Bgr, byte>();

                        Image<Bgr, byte> imgConCanny = img_mano.Clone();
                        imgConCanny = imgConCanny.SmoothGaussian((int)txtSmooth.Value);
                        imgConCanny = retorno.Add(imgConCanny.Canny(20, 60).Convert<Bgr, byte>());

                        //imgBoxSeparador.Image = separarManoDeBrazo(retorno.Clone(), contour);
                        imgBoxSeparador.Image = separarManoDeBrazo(imgConCanny, contour);

                        refrescarMog = 0;
                    }
                    else
                    {
                        refrescarMog++;
                        //verificamos si se da la condicion de reseteo del MOG2
                        if (refrescarMog > (int)txtRefrescarMog2.Value)
                        {
                            bgSubCuerpo = new BackgroundSubtractorMOG2(500, 16, true);
                            refrescarMog = 0;
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }

            return retorno;
        }

        //private Image<Bgr, byte> detectarMovimientoManoSobreCuerpo(Image<Bgr, byte> img)
        //{
        //    Rectangle rCuerpo = new Rectangle(0, roi.Bottom, img.Width, img.Height - roi.Bottom);
        //    Image<Bgr, byte> img_roi = img.Copy(rCuerpo);

        //    img_roi = aplicarOpMorph(img_roi.Convert<Gray, byte>()).Convert<Bgr, byte>();

        //    if (!flowCuerpo.Update(img_roi))
        //        return img_roi;

        //    List<PointF> move_points = new List<PointF>();
        //    for (int i = 0; i < flowCuerpo.curFeatures.Length; i++)
        //    {
        //        if (flowCuerpo.curFeatures[i] == PointF.Empty)
        //            continue;

        //        if (i < flowCuerpo.preFeatures[0].Length)
        //        {
        //            int distanciaX = (int)Math.Abs(flowCuerpo.preFeatures[0][i].X - flowCuerpo.curFeatures[i].X);
        //            int distanciaY = (int)Math.Abs(flowCuerpo.preFeatures[0][i].Y - flowCuerpo.curFeatures[i].Y);
        //            float h = (float)Math.Sqrt(Math.Pow(distanciaX, 2) + Math.Pow(distanciaY, 2));

        //            if (h > float.Parse(txtMovimientoCuerpo.Value.ToString()))
        //                move_points.Add(flowCuerpo.curFeatures[i]);

        //        }
        //        else
        //        {
        //            move_points.Add(flowCuerpo.curFeatures[i]);
        //        }
        //    }

        //    DrawPoints(img_roi, move_points.ToArray(), Color.Red);

        //    Seq<PointF> points = new Seq<PointF>(storage);
        //    for (int i = 0; i < move_points.Count; i++)
        //            points.Push(move_points[i]);

        //    img_roi.Draw(points.BoundingRectangle, new Bgr(Color.Orange), 3);

        //    return img_roi;
        //}

        private Image<Gray, byte> aplicarOpMorph(Image<Gray, byte> img)
        {
            if (this.chbApertura.Checked)
            {
                img = img.Erode((int)this.txtErosion.Value);
                img = img.Dilate((int)this.txtDilatacion.Value);
            }

            if (this.chbCierre.Checked)
            {
                img = img.Dilate((int)this.txtDilatacion.Value);
                img = img.Erode((int)this.txtErosion.Value);
            }

            return img;
        }

        private void chbDetectarCuerpo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbDetectarCuerpo.Checked == true)
            {
                bgSubCuerpo = new BackgroundSubtractorMOG2(500, 16, true);
            }
        }

        private void btnAutodetectarCara_Click(object sender, EventArgs e)
        {
            roi = Rectangle.Empty;
            Image<Bgr, byte> imgActual = (Image<Bgr, byte>)img_original.Image;
            Rectangle[] objetosDetectados = ccCara.DetectMultiScale(imgActual.Convert<Gray, Byte>(), 1.2d, 10, new Size(20, 20), new Size(500, 500));
            foreach (Rectangle r in objetosDetectados)
            {
                roi = r;
            }
        }

        public Bitmap prueba(Bitmap imagen)
        {
            Rectangle r = new Rectangle(0, 0, 20, 20);
            Image<Bgr, byte> img = new Image<Bgr, byte>(imagen);
            img.Draw(r, new Bgr(Color.Green), 2);
            return img.ToBitmap();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            btnAutodetectarCara_Click(sender, e);

            if (this.chbDetectarCuerpo.Checked == true)
                chbDetectarCuerpo.Checked = false;
            else
                chbDetectarCuerpo.Checked = true;

            chbDetectarCuerpo_CheckedChanged(sender, e);
            btn_guardar_Click(sender, e);
            btn_detectar_Click(sender, e);

            btnCargar_Click(sender, e);
            chClasificar.Checked = true;
        }


        private Image<Bgr, byte> separarManoDeBrazo(Image<Bgr, byte> retorno, Contour<Point> contour)
        {
            Image<Bgr, byte> auxRetorno = retorno.Clone();
            //dibujamos el centro de gravedad
            MCvMoments moments = contour.GetMoments();
            float cx = (float)(moments.GravityCenter.x);
            float cy = (float)(moments.GravityCenter.y);
            retorno.Draw(new CircleF(new PointF(cx, cy), 5), new Bgr(Color.Yellow), 15);

            Seq<MCvConvexityDefect> defectos = contour.GetConvexityDefacts(storage, Emgu.CV.CvEnum.ORIENTATION.CV_COUNTER_CLOCKWISE);
            MCvConvexityDefect[] defects_points;

            Seq<PointF> ptsSobreCentro = new Seq<PointF>(storage);

            int numDefects = defectos.Total;
            defects_points = defectos.ToArray();

            Point pMasAlejado = new Point();

            for (int i = 0; i < defects_points.Length; i++)
            {
                Point p = new Point(defects_points[i].StartPoint.X, defects_points[i].StartPoint.Y);
                retorno.Draw(new CircleF(p, 5), new Bgr(Color.Green), 5);

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

            foreach (PointF pf in ptsSobreCentro.ToArray())
            {
                retorno.Draw(new CircleF(pf, 5), new Bgr(Color.White), 5);
            }

            if (ptsSobreCentro.ToArray().Length != 0)
            {
                CircleF centroMano = PointCollection.MinEnclosingCircle(ptsSobreCentro.ToArray());

                //centroMano.Radius = centroMano.Radius + 10;

                int diametro = (int)centroMano.Radius * 2;
                int xRect = (int)centroMano.Center.X - (int)centroMano.Radius;
                int yRect = (int)centroMano.Center.Y - (int)centroMano.Radius;

                Rectangle r = new Rectangle(xRect, yRect, diametro, diametro);

                //retorno.Draw(centroMano, new Bgr(Color.Violet), 1);
                retorno.Draw(r, new Bgr(Color.Tomato), 3);
                //retorno.Draw(new CircleF(pMasAlejado, 5), new Bgr(Color.Blue), 15);

                if (r.X < 0)
                    r.X = 0;
                if (r.Y < 0)
                    r.Y = 0;

                if (r.Right > auxRetorno.Width)
                    r.Width = auxRetorno.Width - r.X;
                if (r.Bottom > auxRetorno.Height)
                    r.Height = auxRetorno.Height - r.Y;

                imgBoxManoCuerpoSVM.Image = auxRetorno.Copy(r);
            }
            return retorno;
        }


        #region clasificacion
        private void btnAgregarEtiqueta_Click(object sender, EventArgs e)
        {
            String binPath = txt_path.Text;//System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            String subCarpeta = "";
            if (rbTrain.Checked)
                subCarpeta = "\\train\\";
            else
                subCarpeta = "\\test\\";

            String path = binPath + "\\" + txtEtiqueta.Text + subCarpeta;
            System.IO.Directory.CreateDirectory(path);

            int cantArchivos = new DirectoryInfo(path).GetFiles("*.jpg").Count();

            Image<Bgr, byte> image = ((Image<Bgr, byte>)imgBoxManoCuerpoSVM.Image);
            //image = image.Copy(minAreaContorno);
            image = image.Resize(150, 150, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            image.Save(path + "\\" + cantArchivos++ + ".jpg");

            txtCantidadMuestras.Text = cantArchivos.ToString();
        }

        private void btn_train_Click(object sender, EventArgs e)
        {
            String clasificador = "";
            if (chSVM.Checked)
                clasificador = "SVM";
            else
                clasificador = "KNEAREST";

            int k = 0;
            int.TryParse(txt_k.Text, out k);
            if (k == 0) k = 1;

            Dictionary<int, List<Image<Gray, byte>>> train_data = LoadData(true);


            int claseEsperada = getClaseEsperada();
            rdd.LearnFromImages(train_data, k, clasificador, claseEsperada);
        }

        ////////// K-NEAREST ////////////////////////////////////////////////////////////////////
        /// <summary>
        /// K-nearest
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        public Dictionary<int, List<Image<Gray, byte>>> LoadData(bool train)
        {
            Dictionary<int, List<Image<Gray, byte>>> datos = new Dictionary<int, List<Image<Gray, byte>>>();
            str_clases = new List<string>();

            string folder = txt_path.Text.Replace("\\", "/");
            string[] dirs = Directory.GetDirectories(folder);
            for (int i = 0; i < dirs.Length; i++)
            {
                datos.Add(i, new List<Image<Gray, byte>>());
                string clase = dirs[i].Substring(dirs[i].LastIndexOf("/") + 1);
                str_clases.Add(clase);

                dirs[i] += (train) ? "/train/" : "/test/";
                string[] files = Directory.GetFiles(dirs[i]);
                for (int j = 0; j < files.Length; j++)
                {
                    if (files[j].EndsWith("jpg") || files[j].EndsWith("png"))
                    {
                        Image<Gray, byte> img = new Image<Gray, byte>(files[j]);
                        datos[i].Add(PreProcess(img.Convert<Bgr, byte>(), true));
                    }
                }
            }

            return datos;
        }

        private int getClaseEsperada()
        {
            int claseEsperada = -1;
            if (this.chSoloDosClases.Checked)
            {
                for (int i = 0; i < str_clases.Count - 1; i++)
                {
                    if (str_clases[i] == txtSoloDosClases.Text)
                    {
                        claseEsperada = i;
                        break;
                    }
                }
            }
            return claseEsperada;
        }

        /// <summary>
        /// K-nearest
        /// </summary>
        /// <param name="imageSrc"></param>
        /// <param name="draw"></param>
        /// <returns></returns>
        //public Image<Gray, Byte> PreProcess(Image<Bgr, Byte> imageSrc, bool draw)
        //{
        //    Image<Gray, Byte> img_Gray = imageSrc.Convert<Gray, Byte>();
        //    //Image<Gray, Byte> img_Canny = img_Gray.ThresholdToZero(new Gray(150)).Not();

        //    //Contour<Point> contour = new Contour<Point>(storage);
        //    //double area = 0;

        //    //for (Contour<Point> contours = img_Canny.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL, storage); contours != null; contours = contours.HNext)
        //    //{
        //    //    if (contours.Area > area)
        //    //    {
        //    //        area = contours.Area;
        //    //        contour = contours;
        //    //    }
        //    //}

        //    //Image<Gray, Byte> roi = img_Canny.Copy(contour.BoundingRectangle).Resize(sizex, sizey, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);

        //    Image<Gray, Byte> roi = imageSrc.Resize(sizex, sizey, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR).Convert<Gray,byte>();

        //    //if (draw)
        //    //{
        //    //    imageSrc.Draw(contour.BoundingRectangle, new Bgr(0, 0, 255), 3);
        //    //    img_canny.Image = roi;
        //    //}

        //    return roi;
        //}


        public Image<Gray, byte> PreProcess(Image<Bgr, byte> imageSrc, bool draw)
        {
            return imageSrc.Convert<Gray, byte>().Resize(sizex, sizey, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
        }

        private void btnActualizarMuestras_Click(object sender, EventArgs e)
        {
            String binPath = txt_path.Text;
            String subCarpeta = "";
            if (rrTest.Checked)
                subCarpeta = "\\Data\\";
            else
                subCarpeta = "\\Test\\";

            String path = binPath + "\\Imagenes\\" + txtEtiqueta.Text + subCarpeta;
            int cantArchivos = new DirectoryInfo(path).GetFiles("*.jpg").Count();
            txtCantidadMuestras.Text = cantArchivos.ToString();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            String clasificador = "";
            if (chSVM.Checked)
                clasificador = "SVM";
            else
                clasificador = "KNEAREST";

            Dictionary<int, List<Image<Gray, byte>>> test_data = LoadData(false);
            float precision = 0;

            if (this.chSoloDosClases.Checked)
                precision = rdd.RunTestDosClases(test_data, clasificador, getClaseEsperada());
            else
                precision = rdd.RunTest(test_data, clasificador);


            txt_precision.Text = precision.ToString();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            Dictionary<int, List<Image<Gray, byte>>> datos = new Dictionary<int, List<Image<Gray, byte>>>();
            str_clases = new List<string>();

            string folder = txt_path.Text.Replace("\\", "/");
            string[] dirs = Directory.GetDirectories(folder);
            for (int i = 0; i < dirs.Length; i++)
            {
                datos.Add(i, new List<Image<Gray, byte>>());
                string clase = dirs[i].Substring(dirs[i].LastIndexOf("/") + 1);
                str_clases.Add(clase);
            }

            String clasificador = "";
            String nombreArchivo = "";
            if (chSVM.Checked)
                clasificador = "SVM";
            else
                clasificador = "KNEAREST";

            if (this.chSoloDosClases.Checked)
                nombreArchivo = clasificador + "DosClases" + this.txtSoloDosClases.Text + ".xml";
            else
                nombreArchivo = clasificador + ".xml";

            rdd.CargarEntrenamiento(clasificador, nombreArchivo);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String clasificador = "";
            String nombreArchivo = "";

            if (chSVM.Checked)
                clasificador = "SVM";
            else
                clasificador = "KNEAREST";

            if (this.chSoloDosClases.Checked)
                nombreArchivo = clasificador + "DosClases" + this.txtSoloDosClases.Text + ".xml";
            else
                nombreArchivo = clasificador + ".xml";

            rdd.GuardarEntrenamiento(clasificador, nombreArchivo);
        }

        private void clasificar()
        {
            if (imgBoxManoCuerpoSVM.Image != null)
            {
                Image<Gray, byte> imgAClasificar = PreProcess((Image<Bgr, byte>)imgBoxManoCuerpoSVM.Image, false);//PreProcess((Image<Bgr, byte>)imgBoxManoCuerpoSVM.Image, false);
                img_canny.Image = imgAClasificar;

                int res = 0;

                if (chSVM.Checked == true)
                {
                    res = rdd.AnalyseImage(imgAClasificar.Resize(sizex, sizey, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC), "SVM");
                }
                else if (chKNearest.Checked == true)
                {
                    res = rdd.AnalyseImage(imgAClasificar.Resize(sizex, sizey, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC), "KNEAREST");
                }

                if (this.chSoloDosClases.Checked)
                {
                    if (res == 1)
                        txt_respuesta.Text = txtSoloDosClases.Text;
                    else
                        txt_respuesta.Text = "Otra";
                }
                else
                {
                    txt_respuesta.Text = str_clases[res];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bgSubCuerpo = new BackgroundSubtractorMOG2(500, 16, true);
        }
        #endregion

    }
}

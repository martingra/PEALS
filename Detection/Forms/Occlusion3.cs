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
using Detector.SkinDetector;

namespace Detector.Forms
{
    public partial class Occlusion3 : Form
    {
        private Capture capture;
        private Image<Bgr, byte> image;
        private Image<Gray, byte> image_prev;
        private Image<Gray, byte> image_gray;
        private Image<Bgr, byte> model_image;

        private OpticalMotion flow = new OpticalMotion();
        private OpticalMotion flowCuerpo = new OpticalMotion();
        private OpticalMotion flowCara;
        private HsvSkinDetector hsv_skin = new HsvSkinDetector();
        private YCrCbSkinDetector ycc_skin = new YCrCbSkinDetector();

        private BackgroundSubtractor bgSubCuerpo;
        private BackgroundSubtractor bgSubCara;
        private int refrescarMog = Int32.MinValue;

        private MemStorage storage = new MemStorage();

        private bool drawingRoi = false;
        private bool detect = false;

        private Rectangle roi;
        private Rectangle rec_temp;
        private Rectangle rCuerpo;

        private Rectangle[] cuadrantes = new Rectangle[4];

        private CascadeClassifier ccCara;
        private CascadeClassifier ccNariz;
        private PointF centroNariz = new PointF(3f, 3f);

        private int _x1, _y1;
        private int _x2, _y2;

        private double width;
        private double height;

        private Seq<PointF> occlusion_points;

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
        
        private VectorOfKeyPoint modelKeyPoints;

        public Occlusion3()
        {
            ccCara = new CascadeClassifier("haarcascade_frontalface_default.xml");
            ccNariz = new CascadeClassifier("haarcascade_mcs_nose.xml");
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

            //Application.Idle += new EventHandler(onFrameChange);
            Application.Idle +=new EventHandler(onFrameChange1);
        }

        void onFrameChange(object sender, EventArgs e)
        {
            image = capture.QueryFrame();

            if (this.chbDetectarCuerpo.Checked == true)
            {
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
                    VectorOfKeyPoint observedKeyPoints = fastCPU.DetectKeyPointsRaw(img_roi.Convert<Gray, byte>(), null);
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
                detectarCuerpo(image);

            if (detect && !drawingRoi)
            {
                tracker.Update(image);
                Rectangle tmp = tracker.GetTracker();
                tmp.X -= 50;
                tmp.Width+= 100;
                
                if (!(tmp.IsEmpty || tmp.X < 0 || tmp.Y < 0 || tmp.Right >= image.Width || tmp.Bottom >= image.Height))
                    roi = tmp;

                Image<Bgr, byte> img_roi = image.Copy(roi);
                actualizarBackProjct(image);

                Rectangle[] nariz = ccNariz.DetectMultiScale(img_roi.Convert<Gray, Byte>(), 1.2d, 10, new Size(20, 20), new Size(500, 500));
                if (nariz.Count() > 0)
                {
                    int c_x = nariz[0].X + nariz[0].Width  / 2;
                    int c_y = nariz[0].Y + nariz[0].Height / 2;

                    centroNariz = new PointF(c_x, c_y);  


                    // Preparo los cuadrantes de la cara
                    // |---------|---------|
                    // |    1    |    2    |
                    // |---------|---------|
                    // |    4    |    3    |
                    // |---------|---------|
                    cuadrantes[0] = new Rectangle(0, 0, c_x, c_y);
                    cuadrantes[1] = new Rectangle(c_x, 0, img_roi.Width - c_x, c_y);
                    cuadrantes[2] = new Rectangle(c_x, c_y, img_roi.Width - c_x, img_roi.Height - c_y);
                    cuadrantes[3] = new Rectangle(0, c_y, c_x, img_roi.Height - c_y);
                }

                Image<Gray, byte> skin = hsv_skin.DetectSkin(img_roi).Add(ycc_skin.DetectSkin(img_roi));

                Image<Bgr, byte> img_smooth = img_roi.SmoothGaussian((int)txtSmooth.Value, (int)txtSmooth.Value, 0, 0);
                bgSubCara.Update(img_smooth, 0.001);
                Image<Gray, byte> imagenProcesada = bgSubCara.ForegroundMask;
                imagenProcesada = aplicarOpMorph(imagenProcesada.ThresholdToZero(new Gray(250)));
                imagenProcesada = imagenProcesada.Mul(skin);

                if (image_prev != null)
                {
                    image_gray = image_prev.AbsDiff(img_smooth.Convert<Gray, byte>());
                    image_gray = image_gray.Mul(50).ThresholdBinary(new Gray(240), new Gray(255));//.Mul(skin);

                    img_mask.Image = image_gray;
                }

                image_prev = img_smooth.Convert<Gray, byte>();

                //img_harris.Image = imagenProcesada;
                img_harris.Image = backproject.Copy(roi).ThresholdBinary(new Gray(240), new Gray(255)).Erode(5).Dilate(2).Erode(3);

                if (image_gray != null)
                {
                    if (image_gray.CountNonzero()[0] > (width * height * .25f))
                        imagenProcesada = imagenProcesada.Mul(image_gray);

                    Contour<Point> contour = null;
                    double max_area = 0;

                    Image<Rgba, byte> final = new Image<Rgba, byte>(imagenProcesada.Size);
                    Image<Rgba, byte> final_2 = new Image<Rgba, byte>(imagenProcesada.Size);
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
                            final.Draw(contour, new Rgba(1, 1, 1, 1), -1);
                            //final_2.Draw(contour, new Rgba(255, 255, 255, 1), -1);

                            final_2 = final.Mul(img_roi.Convert<Rgba, byte>());
                            final = final.Mul(img_roi.Convert<Rgba, byte>()).SmoothGaussian(11).Canny(20, 20).Convert<Rgba, byte>();

                            final = final_2.Add(final);

                            img_mul.Image = final_2;
                            img_canny.Image = final;

                            Image<Rgba, byte> test = new Image<Rgba, byte>(img_roi.Size);

                            if (contour.BoundingRectangle.IntersectsWith(cuadrantes[0]))
                                test.Draw(cuadrantes[0], new Rgba(255, 0, 0, 0.2), -1);
                            if (contour.BoundingRectangle.IntersectsWith(cuadrantes[1]))
                                test.Draw(cuadrantes[1], new Rgba(0, 255, 0, 0.2), -1);
                            if (contour.BoundingRectangle.IntersectsWith(cuadrantes[2]))
                                test.Draw(cuadrantes[2], new Rgba(0, 0, 255, 0.2), -1);
                            if (contour.BoundingRectangle.IntersectsWith(cuadrantes[3]))
                                test.Draw(cuadrantes[3], new Rgba(255, 255, 0, 0.2), -1);

                            img_features.Image = final.Mul(test);
                        }
                    }
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
            VectorOfKeyPoint observedKeyPoints;

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

            bgSubCara = new BackgroundSubtractorMOG2(500, 16, true);

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
            
            //imgBoxCuerpo.Image = detectarManoSobreCuerpo(imagenPorcesada);
            imgBoxCuerpo.Image = detectarCabeza(imagenPorcesada);
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

        private Image<Bgr, byte> detectarManoSobreCuerpo(Image<Gray, byte> img)
        {
            rCuerpo = new Rectangle(0, roi.Bottom, img.Width, img.Height - roi.Bottom);
            Image<Gray, byte> img_roi = img.Copy(rCuerpo);


            Contour<Point> contour; bool hayBorde; string str_area;
            Image<Gray, byte> ca = img_roi.Canny(20, 60);
            Image<Bgr, Byte> imgBorde = obtenerBorder(img_roi, ca, ref rCuerpo, out str_area, out contour, out hayBorde);

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

                        ret.Draw(rMinAreaContorno, new Bgr(Color.Orange), 2);

                        if (rMinAreaContorno.X < 0)
                            rMinAreaContorno.X = 0;
                        if (rMinAreaContorno.Y < 0)
                            rMinAreaContorno.Y = 0;
                        if (rMinAreaContorno.Right > ret.Width)
                            rMinAreaContorno.Width = ret.Width - rMinAreaContorno.X;
                        if (rMinAreaContorno.Bottom > ret.Height)
                            rMinAreaContorno.Height = ret.Height - rMinAreaContorno.Y;


                        Image<Bgr, byte> img_mano = ret.Mul(img_mano_color);
                        img_mano = img_mano.Copy(rMinAreaContorno).SmoothGaussian((int)txtSmooth.Value);

                        img_mano = retorno.Copy(rMinAreaContorno).Add(img_mano.Canny(20, 60).Convert<Bgr, byte>());
                        //img_mano = img_mano.Canny(20, 60).Convert<Bgr, byte>();
                        
                        imgBoxManoCuerpoSVM.Image = img_mano;


                        MCvMoments moments = contour.GetMoments();
                        float cx = (float)(moments.GravityCenter.x);
                        float cy = (float)(moments.GravityCenter.y);
                        retorno.Draw(new CircleF(new PointF(cx, cy), 5), new Bgr(Color.Blue), 15);

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
            catch (Exception e) { 
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
                using (Image<Bgr, byte> tmp = imgActual.Copy(r))
                {
                    Rectangle[] n = ccNariz.DetectMultiScale(tmp.Convert<Gray, Byte>(), 1.2d, 10, new Size(20, 20), new Size(500, 500));
                    if (n.Count() > 0)
                    {
                        roi = r;
                        break;
                    }
                }
            }
        }
    }
}

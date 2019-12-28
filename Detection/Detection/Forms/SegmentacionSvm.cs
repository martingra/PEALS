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

namespace Detector.Forms
{
    public partial class SegmentacionSvm : Form
    {
        private Capture grabber;
        private Image<Bgr, Byte> originalFrame;
        private Image<Bgr, Byte> currentFrame;

        private Image<Gray, Byte> canny;

        private BackgroundSubtractor bgSubsIzq = null;
        private BackgroundSubtractor bgSubsDer = null;
        private BackgroundSubtractor bgSubsCara = null;

        private Rectangle rIzq;
        private Rectangle rDer;
        private Rectangle rCenUp;
        private Rectangle rCenDown;

        private MemStorage convexStorage = new MemStorage();

        private const int NUM_FINGERS = 5;
        private const int NUM_DEFECTS = 8;

        private int cantidadFrames = 0;

        int erode, dilate, smooth, thres, sat, area_max, area_mano;
        bool apertura, cierre, ecualizar, saturar, procesar, balanceBlancos;

        string metodo;

        //k-NEAREST ////////////////////////////////////////////////////////
        private MemStorage storage = new MemStorage();
        private KNearest knn;
        private ReconocimientoDeDigitos rdd;

        Matrix<float> trainData, trainClass;
        public List<string> str_clases;

        private int K = 1;
        private int sizex = 100;
        private int sizey = 100;
        private int imageSize;

        private int clases;
        private int imgXClases;
        private Image<Gray, byte> imgAClasificar;
        private Image<Bgr, byte> imgAClasificarBgr;

        Rectangle rectangleCapturaImagenes = new Rectangle(10, 40, 200, 340);
        Rectangle minAreaContorno;
        Rectangle rectangleCapturaImagenesIzq = new Rectangle(10, 40, 200, 340);
        Rectangle minAreaContornoIzq;
        Rectangle rectangleCapturaImagenesCen = new Rectangle(10, 40, 200, 340);
        Rectangle minAreaContornoCen;
        /// /////////////////////////////////////////////////////////////////

        public SegmentacionSvm()
        {
            InitializeComponent();
            imageSize = sizex * sizey;
            rdd = new Detector.ML.ReconocimientoDeDigitos();
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
                        Image<Bgr, byte> img = new Image<Bgr, byte>(files[j]);
                        datos[i].Add(PreProcess(img, false));
                    }
                }
            }

            return datos;
        }

        /// <summary>
        /// K-nearest
        /// </summary>
        /// <param name="imageSrc"></param>
        /// <param name="draw"></param>
        /// <returns></returns>
        public Image<Gray, Byte> PreProcess(Image<Bgr, Byte> imageSrc, bool draw)
        {
            Image<Gray, Byte> img_Gray = imageSrc.Convert<Gray, Byte>();
            Image<Gray, Byte> img_Canny = img_Gray.ThresholdToZero(new Gray(150)).Not();

            Contour<Point> contour = new Contour<Point>(storage);
            double area = 0;

            for (Contour<Point> contours = img_Canny.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL, storage); contours != null; contours = contours.HNext)
            {
                if (contours.Area > area)
                {
                    area = contours.Area;
                    contour = contours;
                }
            }

            Image<Gray, Byte> roi = img_Canny.Copy(contour.BoundingRectangle).Resize(sizex, sizey, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);

            if (draw)
            {
                imageSrc.Draw(contour.BoundingRectangle, new Bgr(0, 0, 255), 3);
                img_canny.Image = roi;
            }

            return roi;
        }


        public void Train(Dictionary<int, List<Image<Gray, byte>>> images_dictionary)
        {
            trainData = new Matrix<float>(clases * imgXClases, imageSize);
            trainClass = new Matrix<float>(clases * imgXClases, 1);

            int count = 0;
            foreach (KeyValuePair<int, List<Image<Gray, byte>>> kvp in images_dictionary)
            {
                int clase = kvp.Key;
                List<Image<Gray, byte>> images = kvp.Value;

                for (int i = 0; i < images.Count; i++)
                {
                    int pos = 0;
                    for (int w = 0; w < images[i].Width; w++)
                    {
                        for (int h = 0; h < images[i].Height; h++)
                        {
                            trainData[count, pos] = (float)images[i][h, w].Intensity;
                            trainClass[count, 0] = clase;
                            pos++;
                        }
                    }

                    count++;
                }
            }

            knn = new KNearest(trainData, trainClass, null, false, K);
        }

        public void Clasificar(Matrix<float> contours_matrix)
        {
            Matrix<float> results, neighborResponses;
            results = new Matrix<float>(contours_matrix.Rows, 1);
            neighborResponses = new Matrix<float>(contours_matrix.Rows, K);
            float response = knn.FindNearest(contours_matrix, K, results, null, neighborResponses, null);
            if (response == 0)
                txt_respuesta.Text = "Cuadrado";
            else
                txt_respuesta.Text = "Circulo";
        }

        public Matrix<float> ConvertirAMatriz(Image<Gray, byte> img)
        {
            Matrix<float> ret = new Matrix<float>(1, imageSize);

            int pos = 0;
            for (int w = 0; w < img.Width; w++)
            {
                for (int h = 0; h < img.Height; h++)
                {
                    trainData[0, pos] = (float)img[h, w].Intensity;
                    pos++;
                }
            }

            return ret;
        }



        private void btnTrainK_Click(object sender, EventArgs e)
        {
            //String clasificador;
            //if (chSVM.Checked)
            //{
            //    clasificador = "SVM";
            //}
            //else
            //{
            //    clasificador = "KNEAREST";
            //}

            //int cantidadImagenes = getCantidadImagenesEnRed();

            //Dictionary<int, List<Image<Gray, byte>>> train_data = LoadData(true);
            //Dictionary<int, List<Image<Gray, byte>>> test_data = LoadData(false);

            //int maxK = 0;
            //float valMaxK = 0;

            //for (int k = 1; k <= cantidadImagenes; k++)
            //{
            //    this.progressBar.Value = k * 100 / cantidadImagenes;
            //    rdd.LearnFromImages(train_data, k, clasificador);
            //    float precision = rdd.RunTest(test_data, clasificador);
            //    //txt_log.Text += Environment.NewLine + "Para K = " + k + " la presición fue: " + precision.ToString();

            //    if (precision > valMaxK)
            //    {
            //        valMaxK = precision;
            //        maxK = k;
            //    }
            //}
            //this.txt_k.Text = maxK.ToString();
            //this.progressBar.Value = 100;
        }

        /// <summary>
        /// devuelve la cantidad de imagenes a trabajar por la red en 
        /// el testeo de la misma.
        /// </summary>
        /// <returns></returns>
        private int getCantidadImagenesEnRed()
        {
            int contador = 0;
            string folder = txt_path.Text.Replace("\\", "/");
            string[] dirs = Directory.GetDirectories(folder);
            for (int i = 0; i < dirs.Length; i++)
            {
                dirs[i] += "/train/";
                string[] files = Directory.GetFiles(dirs[i]);
                foreach (String file in files)
                {
                    contador++;
                }
            }
            dirs = Directory.GetDirectories(folder);
            for (int i = 0; i < dirs.Length; i++)
            {
                dirs[i] += "/test/";
                string[] files = Directory.GetFiles(dirs[i]);
                foreach (String file in files)
                {
                    contador++;
                }
            }
            return contador;
        }


        /// ///////////////////////////////////////////////////////////////


        private void Segmentacion_Load(object sender, EventArgs e)
        {
            grabber = new Capture();
            grabber.FlipHorizontal = true;

            Application.Idle += new EventHandler(FrameGrabber);
        }

        void FrameGrabber(object sender, EventArgs e)
        {
            currentFrame = grabber.QueryFrame();
            originalFrame = currentFrame.Clone();

            if (rIzq == null || rIzq.Width == 0)
            {
                rIzq = new Rectangle(0, 0, currentFrame.Width / 3, currentFrame.Height);
                rDer = new Rectangle(currentFrame.Width - currentFrame.Width / 3, 0, currentFrame.Width - (currentFrame.Width - currentFrame.Width / 3), currentFrame.Height);
                rCenUp = new Rectangle(rIzq.Right, 0, rDer.Left - rIzq.Right, currentFrame.Height - currentFrame.Height / 4);
                rCenDown = new Rectangle(rIzq.Right, rCenUp.Bottom, rDer.Left - rIzq.Right, currentFrame.Height - rCenUp.Bottom);
            }

            GetGUIData();

            if (ecualizar)
                currentFrame._EqualizeHist();

            if (balanceBlancos)
                currentFrame._GammaCorrect(0.5);

            if (smooth > 0)
                currentFrame = currentFrame.SmoothGaussian(smooth, smooth, 0, 0);

            LineSegment2D lsDerecha = new LineSegment2D(new Point(currentFrame.Width / 3, 0), new Point(currentFrame.Width / 3, currentFrame.Height));
            LineSegment2D lsIzquierda = new LineSegment2D(new Point(currentFrame.Width - (currentFrame.Width / 3), 0), new Point(currentFrame.Width - (currentFrame.Width / 3), currentFrame.Height));
            LineSegment2D lsCentro = new LineSegment2D(new Point(rCenUp.Left, rCenUp.Bottom), new Point(rCenUp.Right, rCenUp.Bottom));
            currentFrame.Draw(lsDerecha, new Bgr(Color.Green), 2);
            currentFrame.Draw(lsIzquierda, new Bgr(Color.Green), 2);
            currentFrame.Draw(lsCentro, new Bgr(Color.Green), 2);

            imgBox_VideoBgr.Image = currentFrame;
            canny = currentFrame.Canny(20, 60);
            imgBox_videoHsv.Image = canny;

            if (procesar)
                Process();



            if (chClasificar.Checked == true)
            {
                if (minAreaContorno.Width != 0 && minAreaContorno.Height != 0)
                {
                    imgAClasificarBgr = (Image<Bgr, byte>)imgBox_bordeDer.Image;
                    imgAClasificarBgr = imgAClasificarBgr.Copy(minAreaContorno);

                    imgAClasificar = PreProcess(imgAClasificarBgr, false);
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

                //img_canny.Image = (Image<Bgr, byte>)imgBox_bordeDer.Image;
            }
        }

        private void GetGUIData()
        {
            erode = (int)value_erode.Value;
            dilate = (int)value_dilate.Value;
            smooth = (int)valueSmooth.Value;
            thres = (int)value_tresh.Value;
            sat = (int)value_s.Value;
            area_max = (int)value_area.Value;
            area_mano = (int)value_areaMano.Value;

            apertura = chApertura.Checked;
            cierre = chCierre.Checked;
            ecualizar = chEcualizar.Checked;
            saturar = chSaturar.Checked;
            balanceBlancos = chBalance.Checked;

            metodo = comboMetodo.Text;
        }

        private void Process()
        {
            int limiteTamano = 50;

            if ((minAreaContorno.Width < limiteTamano || minAreaContorno.Height < limiteTamano) && (minAreaContornoIzq.Width < limiteTamano || minAreaContornoIzq.Height < limiteTamano))
            {
                if (cantidadFrames > 40)
                {
                    capturarFondo();
                    cantidadFrames = 0;
                    progressBar.Value = progressBar.Value + 1;
                }
            }

            procesarLateral(rIzq, bgSubsIzq, ref imgBox_movIzq, ref imgBox_bordeIzq, ref imgBox_segIzq, ref imgBox_manoIzq, ref lbl_areaIzq, 0.0001, ref minAreaContorno, ref rectangleCapturaImagenes);
            procesarLateral(rDer, bgSubsDer, ref imgBox_movDer, ref imgBox_bordeDer, ref imgBox_segDer, ref imgBox_manoDer, ref lbl_areaDer, 0.0001, ref minAreaContornoIzq, ref rectangleCapturaImagenesIzq);
            procesarLateral(rCenUp, bgSubsCara, ref imgBox_movCara, ref imgBoxCara, ref imgBox_segDer, ref imgBox_manoDer, ref lbl_areaDer, 0.007, ref minAreaContornoCen, ref rectangleCapturaImagenesCen);

            cantidadFrames++;
        }

        private void procesarLateral(Rectangle rectangle, BackgroundSubtractor subs, ref ImageBox mogGUI, ref ImageBox borderGUI, ref ImageBox segGUI, ref ImageBox manoGUI, ref Label txtArea, double tasaAprendizajeMog, ref Rectangle rMinAreaContorno, ref Rectangle rRectangleCapturaImagen)
        {
            Image<Bgr, byte> frameRoi = currentFrame.Copy(rectangle);
            Image<Bgr, byte> originalRoi = originalFrame.Copy(rectangle);

            Image<Gray, Byte> imgSinFondo = sacarFondo(frameRoi, ref subs, tasaAprendizajeMog);
            imgSinFondo = aplicarOpMorph(imgSinFondo);
            mogGUI.Image = imgSinFondo;

            Contour<Point> contour; bool hayBorde; string str_area;
            Image<Gray, byte> ca = frameRoi.Canny(20, 60);
            Image<Bgr, Byte> imgBorde = obtenerBorder(imgSinFondo, ca, ref rMinAreaContorno, out str_area, out contour, out hayBorde);
            lbl_maxArea.Text = str_area;

            rMinAreaContorno.Intersect(rRectangleCapturaImagen);
            imgBorde.Draw(rMinAreaContorno, new Bgr(Color.Green), 3);
            //imgBorde.Draw(rectangleCapturaImagenes, new Bgr(Color.Green), 3);

            borderGUI.Image = imgBorde;//originalRoi.Mul(imgBorde);
            try
            {
                //if (hayBorde && contour != null)
                //{
                //    MCvMoments moments = contour.GetMoments();
                //    float cx = (float)(rectangle.Left + moments.GravityCenter.x);
                //    float cy = (float)(rectangle.Top + moments.GravityCenter.y);

                //    currentFrame.Draw(new CircleF(new PointF(cx, cy), 5), new Bgr(255, 0, 0), 3);
                //    Image<Bgr, byte> mano = obtenerMano(imgBorde, contour, new Point((int)cx, (int)cy));
                //    manoGUI.Image = mano;
                //}
            }
            catch (Exception e)
            {
            }
        }


        private Image<Gray, byte> aplicarOpMorph(Image<Gray, byte> img)
        {
            if (apertura)
            {
                img = img.Erode(erode);
                img = img.Dilate(dilate);
            }

            if (cierre)
            {
                img = img.Dilate(dilate);
                img = img.Erode(erode);
            }

            return img;
        }

        private Image<Gray, Byte> sacarFondo(Image<Bgr, byte> imagen, ref BackgroundSubtractor subs, double tazaAprendizajeMog)
        {
            subs.Update(imagen, tazaAprendizajeMog);
            return subs.ForegroundMask;
        }

        private Image<Bgr, Byte> obtenerBorder(Image<Gray, Byte> frame, Image<Gray, Byte> roiFrame, ref Rectangle rMinAreaContorno, out string area, out Contour<Point> contour, out bool hayBorde)
        {
            contour = null;
            double max_area = 0;
            Image<Bgr, Byte> ret = new Image<Bgr, byte>(frame.Size);

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

                    contour = (contour != null) ? contour.ApproxPoly(contour.Perimeter * 0.0025, 1, storage) : null;

                    area = max_area.ToString();
                    if (contour != null && (max_area > 0 && max_area < area_max))
                    {
                        ret.Draw(contour, new Bgr(255, 255, 255), -1);
                        rMinAreaContorno = contour.GetMinAreaRect().MinAreaRect();
                        hayBorde = true;
                    }

                    for (Contour<Point> tmp_contour = roiFrame.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL, storage); tmp_contour != null; tmp_contour = tmp_contour.HNext)
                    {
                        ret.Draw(tmp_contour, new Bgr(Color.Red), 3);
                    }
                }
            }
            catch (Exception e) { }

            return ret;
        }

        private Image<Bgr, byte> obtenerMano(Image<Bgr, byte> imagenBorde, Contour<Point> contour, Point center)
        {
            Image<Bgr, byte> mano = new Image<Bgr, byte>(imagenBorde.Size);

            MCvConvexityDefect[] defects_points; int numDefects;
            MCvBox2D box = FindConvexHull(contour, out defects_points, out numDefects);
            if (numDefects >= 0)
            {
                box = FindConvexHull(contour, out defects_points, out numDefects);
                DrawHand(numDefects, defects_points, box, center);
            }

            return mano;
        }

        private MCvBox2D FindConvexHull(Contour<Point> contours, out MCvConvexityDefect[] defects_points, out int numDefects)
        {
            numDefects = -1;
            defects_points = null;

            try
            {
                Seq<Point> hull = contours.GetConvexHull(Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);
                MCvBox2D box = contours.GetMinAreaRect(convexStorage);
                PointF[] points = box.GetVertices();
                Point[] ps = new Point[points.Length];
                for (int i = 0; i < points.Length; i++)
                    ps[i] = new Point((int)points[i].X, (int)points[i].Y);

                if (hull != null)
                {
                    Seq<MCvConvexityDefect> defects = contours.GetConvexityDefacts(convexStorage, Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);
                    numDefects = defects.Total;
                    defects_points = defects.ToArray();

                    Point[] defect_points = new Point[defects_points.Length];
                    for (int i = 0; i < defects_points.Length; i++)
                    {
                        defect_points[i] = new Point(defects_points[i].StartPoint.X, defects_points[i].StartPoint.Y);
                    }
                }

                return box;
            }
            catch (Exception ex)
            {
                numDefects = -1;
                defects_points = null;

                return new MCvBox2D();
            }
        }

        private void DrawHand(int numDefects, MCvConvexityDefect[] defects_points, MCvBox2D box, Point center)
        {
            int fingerNum = 0;

            for (int i = 0; i < numDefects; i++)
            {
                //PointF startPoint = new PointF((float)defects_points[i].StartPoint.X, (float)defects_points[i].StartPoint.Y);
                //PointF depthPoint = new PointF((float)defects_points[i].DepthPoint.X, (float)defects_points[i].DepthPoint.Y);
                //PointF endPoint = new PointF((float)defects_points[i].EndPoint.X, (float)defects_points[i].EndPoint.Y);

                //LineSegment2D startDepthLine = new LineSegment2D(defects_points[i].StartPoint, defects_points[i].DepthPoint);
                //LineSegment2D depthEndLine = new LineSegment2D(defects_points[i].DepthPoint, defects_points[i].EndPoint);

                //CircleF startCircle = new CircleF(startPoint, 5f);
                //CircleF depthCircle = new CircleF(depthPoint, 5f);
                //CircleF endCircle = new CircleF(endPoint, 5f);

                PointF startPoint = new PointF((float)defects_points[i].StartPoint.X + rDer.Left, (float)defects_points[i].StartPoint.Y);
                PointF depthPoint = new PointF((float)defects_points[i].DepthPoint.X + rDer.Left, (float)defects_points[i].DepthPoint.Y);

                CircleF startCircle = new CircleF(startPoint, 5f);
                CircleF depthCircle = new CircleF(depthPoint, 5f);

                if ((startCircle.Center.Y < box.center.Y || depthCircle.Center.Y < box.center.Y) && (startCircle.Center.Y < depthCircle.Center.Y) && (Math.Sqrt(Math.Pow(startCircle.Center.X - depthCircle.Center.X, 2) + Math.Pow(startCircle.Center.Y - depthCircle.Center.Y, 2)) > box.size.Height / 6.5))
                {
                    fingerNum++;
                    //image.Draw(startDepthLine, new Bgr(Color.Green), 2); // líneas de dedos
                    //image.Draw(startCircle, new Bgr(Color.Red), 2); // puntos convexos
                    //image.Draw(depthCircle, new Bgr(Color.Yellow), 5); // puntos defectuosos                    

                    Point p = new Point(defects_points[i].StartPoint.X + rDer.Left, defects_points[i].StartPoint.Y);
                    currentFrame.Draw(startCircle, new Bgr(0, 0, 255), 2); // puntos convexos
                    currentFrame.Draw(new LineSegment2D(p, center), new Bgr(0, 255, 0), 2); // puntos convexos
                    //currentFrame.Draw(depthCircle, new Bgr(Color.Yellow), 5); // puntos defectuosos
                }
            }
        }

        private void btnCaputarFondo_Click(object sender, EventArgs e)
        {
            capturarFondo();
        }

        private void capturarFondo()
        {
            bgSubsIzq = new BackgroundSubtractorMOG2(0, thres, false);
            bgSubsDer = new BackgroundSubtractorMOG2(0, thres, false);
            bgSubsCara = new BackgroundSubtractorMOG2(0, thres, false);
            procesar = true;
        }

        private void btnAgregarEtiqueta_Click(object sender, EventArgs e)
        {
            String binPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            String path = binPath + "\\Imagenes\\" + txtEtiqueta.Text;
            System.IO.Directory.CreateDirectory(path);

            int cantArchivos = new DirectoryInfo(path).GetFiles("*.jpg").Count();

            Image<Bgr, byte> image = ((Image<Bgr, byte>)imgBox_bordeDer.Image);
            image = image.Copy(minAreaContorno);
            image = image.Resize(150, 150, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            image.Save(path + "\\" + cantArchivos++ + ".jpg");

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
            //rdd.LearnFromImages(train_data, k, clasificador, claseEsperada);
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

        private int getClaseEsperada()
        {
            int claseEsperada = -1;
            if (this.chSoloDosClases.Checked)
            {
                for (int i = 0; i < str_clases.Count - 1; i++)
                {
                    if (str_clases[i] == "Imagenes\\" + this.txtSoloDosClases.Text)
                    {
                        claseEsperada = i;
                        break;
                    }
                }
            }

            return claseEsperada;
        }

        private void btnEntrenarMano_Click(object sender, EventArgs e)
        {
            //Image<Bgr, byte> image = ((Image<Bgr, byte>)imgBox_bordeDer.Image);
            //image = image.Copy(minAreaContorno);
            //float valor;
            //for (int w = 0; i < image.Width; i++)
            //{
            //    for (int h = 0; j < image.Height; j++)
            //    {
                    
            //    }
            //}
        }



    }
}

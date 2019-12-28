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
using Emgu.CV.ML;
using System.IO;
using Detector.ML;

namespace Detector
{
    public partial class KNearestForm : Form
    {
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

        public KNearestForm()
        {
            InitializeComponent();

            imageSize = sizex * sizey;

            rdd = new Detector.ML.ReconocimientoDeDigitos();
        }

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
                    if (files[j].EndsWith("png"))
                    {
                        Image<Bgr, byte> img = new Image<Bgr, byte>(files[j]);
                        datos[i].Add(PreProcess(img, false));
                    }
                }
            }

            return datos;
        }

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

        private void btn_cargar_Click(object sender, EventArgs e)
        {
            DialogResult result = file_dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = file_dialog.FileName;
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(file);
                img_original.Image = img;

                Image<Gray, byte> binary = rdd.PreProcessImage(img, sizex, sizey);
                img_canny.Image = binary;

                histogramBox1.ClearHistogram();
                histogramBox1.GenerateHistograms(binary, 256);
                histogramBox1.Refresh();
            }
        }

        private void btn_train_Click(object sender, EventArgs e)
        {
            //int k = 0;
            //int.TryParse(txt_k.Text, out k);
            //if (k == 0) k = 1;

            //Dictionary<int, List<Image<Gray, byte>>> train_data = LoadData(true);
            //rdd.LearnFromImages(train_data, k);

            //Dictionary<int, List<Image<Gray, byte>>> test_data = LoadData(false);
            //float precision = rdd.RunTest(test_data);

            //txt_precision.Text = precision.ToString();
        }

        private void Test_Click(object sender, EventArgs e)
        {
            //int number = int.Parse(txt_test.Text);

            //Image<Bgr, byte> image; Image<Gray, byte> binary;

            //rdd.LearnFromImages();
            //List<int> result = rdd.AnalyseImage(number, out image, out binary);

            //img_original.Image = image;
            //img_canny.Image = binary;
            //txt_respuesta.Text = result[0].ToString();
        }

        private void KNearestForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_detectar_Click(object sender, EventArgs e)
        {
            //Image<Gray, byte> binary = img_canny.Image as Image<Gray, byte>;
            ////int res = rdd.AnalyseImage(binary.Resize(sizex, sizey, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC));
            //txt_respuesta.Text = str_clases[res];
        }

        private void btnTrainK_Click(object sender, EventArgs e)
        {
            //int cantidadImagenes = getCantidadImagenesEnRed();

            //Dictionary<int, List<Image<Gray, byte>>> train_data = LoadData(true);
            //Dictionary<int, List<Image<Gray, byte>>> test_data = LoadData(false);

            //int maxK = 0;
            //float valMaxK = 0;

            //for (int k = 1; k <= cantidadImagenes; k++ )
            //{
            //    this.progressBar.Value = k * 100 / cantidadImagenes;
            //    rdd.LearnFromImages(train_data, k);
            //    float precision = rdd.RunTest(test_data);
            //    txt_log.Text += Environment.NewLine + "Para K = " + k + " la presición fue: " + precision.ToString();
                
            //    if(precision > valMaxK) {
            //        valMaxK = precision;
            //        maxK = k;
            //    }
            //}
            //this.txt_k.Text = maxK.ToString();
            //this.progressBar.Value = 100;
        }


        /// <summary>
        /// devuelve la cantidad de imagenes a trabajar por la red en el testeo de la misma.
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
    }
}

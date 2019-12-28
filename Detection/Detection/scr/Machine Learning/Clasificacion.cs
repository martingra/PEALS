using Emgu.CV;
using Emgu.CV.ML;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
namespace Detector.ML
{
    class Clasificacion
    {
        public enum Clasificador { SVM = 1, KNEAREST = 2 };

        private int K = 1;

        private MemStorage storage = new MemStorage();

        private const int sizex = 100;
        private const int sizey = 100;
        private const int ImageSize = sizex * sizey;

        private SVM svm;
        private KNearest knearest;

        public List<string> str_clases;
        private string txt_path = "C:\\Peals\\imagenes";

        public string clasificar(Image<Gray, byte> img, int clasificador, bool soloDosClases, string claseSoloDosClases, out Image<Gray, byte> imgAClasificar)
        {
            string respuesta = "";
            imgAClasificar = PreProcess(img);
            int res = 0;

            res = AnalyseImage(imgAClasificar, clasificador);

            if (soloDosClases)
            {
                if (res == 1)
                    respuesta = claseSoloDosClases;
                else
                    respuesta = "Otra";
            }
            else
            {
                respuesta = str_clases[res];
            }

            return respuesta;
        }

        public Image<Gray, byte> PreProcess(Image<Gray, byte> imageSrc)
        {
            Image<Gray, Byte> roi = new Image<Gray,byte>(sizex, sizey);
            try
            {
                roi = imageSrc.Resize(sizex, sizey, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR).Convert<Gray, byte>();
            }
            catch (Exception ex) { }
            return roi;
        }

        public int AnalyseImage(Image<Gray, byte> image, int clasificador)
        {
            Matrix<float> sample = new Matrix<float>(1, ImageSize);

            int pos = 0;
            for (int w = 0; w < image.Width; w++)
            {
                for (int h = 0; h < image.Height; h++)
                {
                    float pixel = (float)image[h, w].Intensity;
                    sample[0, pos] = pixel;
                    pos++;
                }
            }

            float result = 0;
            if (clasificador == (int)Clasificador.SVM)
            {
                result = svm.Predict(sample);
            }
            else
            {
                result = knearest.FindNearest(sample, K, null, null, null, null);
            }
            return (int)result;
        }

        public void GuardarEntrenamiento(int clasificador, String nombreArchivo)
        {
            if (clasificador == (int)Clasificador.SVM)
            {
                svm.Save(nombreArchivo);
            }
            else
            {
                knearest.Save(nombreArchivo);
            }
        }

        public void CargarEntrenamiento(int clasificador, String nombreArchivo)
        {
            Dictionary<int, List<Image<Gray, byte>>> datos = new Dictionary<int, List<Image<Gray, byte>>>();
            str_clases = new List<string>();

            string folder = txt_path.Replace("\\", "/");
            string[] dirs = Directory.GetDirectories(folder);
            for (int i = 0; i < dirs.Length; i++)
            {
                datos.Add(i, new List<Image<Gray, byte>>());
                string clase = dirs[i].Substring(dirs[i].LastIndexOf("/") + 1);
                str_clases.Add(clase);
            }

            if (clasificador == (int)Clasificador.SVM)
            {
                svm = new SVM();
                svm.Load(nombreArchivo);
            }
            else
            {
                knearest.Load(nombreArchivo);
            }
        }

        public int agregarEtiqueta(string subCarpeta, string etiqueta, Image<Gray, byte> imgEtiqueta)
        {
            subCarpeta = "\\" + subCarpeta + "\\";

            String path = txt_path + "\\" + etiqueta + "\\" + subCarpeta;
            System.IO.Directory.CreateDirectory(path);

            int cantArchivos = new DirectoryInfo(path).GetFiles("*.jpg").GetLength(0);

            imgEtiqueta = imgEtiqueta.Resize(150, 150, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            imgEtiqueta.Save(path + "\\" + cantArchivos++ + ".jpg");

            return cantArchivos;
        }

        public void train(int clasificador, int k)
        {
            Dictionary<int, List<Image<Gray, byte>>> train_data = LoadData(true, txt_path);

            int claseEsperada = getClaseEsperada();
            LearnFromImages(train_data, k, clasificador, claseEsperada);
        }

        private Dictionary<int, List<Image<Gray, byte>>> LoadData(bool train, string path)
        {
            Dictionary<int, List<Image<Gray, byte>>> datos = new Dictionary<int, List<Image<Gray, byte>>>();
            str_clases = new List<string>();

            string folder = path.Replace("\\", "/");
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
                        datos[i].Add(PreProcess(img));
                    }
                }
            }

            return datos;
        }

        private int getClaseEsperada()
        {
            int claseEsperada = -1;
            //if (this.chSoloDosClases.Checked)
            //{
            //    for (int i = 0; i < str_clases.Count - 1; i++)
            //    {
            //        if (str_clases[i] == txtSoloDosClases.Text)
            //        {
            //            claseEsperada = i;
            //            break;
            //        }
            //    }
            //}
            return claseEsperada;
        }

        /// <summary>
        /// Entrena la red neuronal. Si [claseEsperada] es -1, entonces se entrena con todas las clases por separado. Si no es -1, entonces se entrena la red
        /// solo con dos clases. La clase 1 representa la clase esperada, y la clase 2 es el resto de las imagenes.
        /// </summary>
        /// <param name="images_dictionary">diccionario de imagenes</param>
        /// <param name="k">parametro K</param>
        /// <param name="clasificador">[SVM]/[KNEAREST]</param>
        /// <param name="claseEsperada">Clase que queremos verificar. Esta se toma como una clase, y el resto de las imagenes como otra clase</param>
        private void LearnFromImages(Dictionary<int, List<Image<Gray, byte>>> images_dictionary, int k, int clasificador, int claseEsperada)
        {
            int classes, train_samples;

            classes = images_dictionary.Keys.Count;
            train_samples = images_dictionary[0].Count;

            Matrix<float> trainData = new Matrix<float>(classes * train_samples, ImageSize);
            Matrix<float> trainClasses = new Matrix<float>(classes * train_samples, 1);

            int count = 0;
            foreach (KeyValuePair<int, List<Image<Gray, byte>>> kvp in images_dictionary)
            {
                int clase = kvp.Key;
                List<Image<Gray, byte>> images = kvp.Value;

                if (claseEsperada != -1)
                {
                    if (clase == claseEsperada)
                        clase = 1;
                    else
                        clase = 2;
                }

                for (int i = 0; i < images.Count; i++)
                {
                    int pos = 0;
                    for (int w = 0; w < images[i].Width; w++)
                    {
                        for (int h = 0; h < images[i].Height; h++)
                        {
                            trainData[count, pos] = (float)images[i][h, w].Intensity;
                            trainClasses[count, 0] = clase;
                            pos++;
                        }
                    }
                    count++;
                }
            }

            K = k;

            if (clasificador == (int) Clasificacion.Clasificador.SVM)
            {
                svm = new SVM();

                SVMParams p = new SVMParams();
                p.KernelType = Emgu.CV.ML.MlEnum.SVM_KERNEL_TYPE.LINEAR;
                p.SVMType = Emgu.CV.ML.MlEnum.SVM_TYPE.C_SVC;
                p.C = 1;
                p.TermCrit = new MCvTermCriteria(100, 0.00001);

                bool trained = svm.TrainAuto(trainData, trainClasses, null, null, p.MCvSVMParams, k);
            }
            else
            {
                knearest = new KNearest(trainData, trainClasses, null, false, K);
            }
        }
    }
}
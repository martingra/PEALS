using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using Emgu.CV.ML;

namespace Detector.ML
{
    class ReconocimientoDeDigitos
    {
        private MemStorage storage = new MemStorage();

        private int K = 1;

        private int train_samples;
        private int classes;

        private const int sizex = 100;
        private const int sizey = 100;
        private const int ImageSize = sizex * sizey;

        private SVM svm;
        private KNearest knearest;

        public Dictionary<Image<Bgr, byte>, bool> ResultTest { get; set; }
        public List<int> Result { get; set; }
        public Image<Bgr, byte> ImageResult { get; set; }

        public Image<Gray, byte> PreProcessImage(Image<Bgr, byte> inImage, int sizex, int sizey)
        {
            Image<Gray, byte> grayImage, blurredImage, thresholdImage;
            Contour<Point> contour = new Contour<Point>(storage);

            grayImage = inImage.Convert<Gray, byte>();
            blurredImage = grayImage.SmoothGaussian(5, 5, 2, 2);
            thresholdImage = blurredImage.ThresholdToZero(new Gray(150)).Not();

            return GetROI(thresholdImage, sizex, sizey);
        }


        public Image<Gray, byte> GetROI(Image<Gray, byte> thresholdImage, int sizex, int sizey)
        {
            Image<Gray, byte> regionOfInterest = null;
            Contour<Point> contour = new Contour<Point>(storage);

            double area = 0;
            for (Contour<Point> c = thresholdImage.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST, storage); c != null; c = c.HNext)
            {
                if (c.Area > area)
                {
                    area = c.Area;
                    contour = c;
                }
            }

            if (contour != null)
            {
                regionOfInterest = thresholdImage.Copy(contour.BoundingRectangle);
                regionOfInterest.Resize(sizex, sizey, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
            }

            return regionOfInterest;
        }

        /// <summary>
        /// Entrena la red neuronal. Si [claseEsperada] es -1, entonces se entrena con todas las clases por separado. Si no es -1, entonces se entrena la red
        /// solo con dos clases. La clase 1 representa la clase esperada, y la clase 2 es el resto de las imagenes.
        /// </summary>
        /// <param name="images_dictionary">diccionario de imagenes</param>
        /// <param name="k">parametro K</param>
        /// <param name="clasificador">[SVM]/[KNEAREST]</param>
        /// <param name="claseEsperada">Clase que queremos verificar. Esta se toma como una clase, y el resto de las imagenes como otra clase</param>
        public void LearnFromImages(Dictionary<int, List<Image<Gray, byte>>> images_dictionary, int k, String clasificador, int claseEsperada)
        {
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

            if (clasificador == "SVM")
            {
                svm = new SVM();

                SVMParams p = new SVMParams();
                p.KernelType = Emgu.CV.ML.MlEnum.SVM_KERNEL_TYPE.LINEAR;
                p.SVMType = Emgu.CV.ML.MlEnum.SVM_TYPE.C_SVC;
                p.C = 1;
                p.TermCrit = new MCvTermCriteria(100, 0.00001);

                //bool trained = model.Train(trainData, trainClasses, null, null, p);
                //p.Gamma = 1;
                //p.Degree = 65;

                bool trained = svm.TrainAuto(trainData, trainClasses, null, null, p.MCvSVMParams, k);
            }
            else
            {
                knearest = new KNearest(trainData, trainClasses, null, false, K);
            }
        }


        public int AnalyseImage(Image<Bgr, byte> image, String clasificador)
        {
            Matrix<float> sample = new Matrix<float>(1, ImageSize);
            Image<Gray, byte> stagedImage = PreProcessImage(image, sizex, sizey).Resize(sizex, sizey, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);

            int pos = 0;
            for (int w = 0; w < stagedImage.Width; w++)
            {
                for (int h = 0; h < stagedImage.Height; h++)
                {
                    float pixel = (float)stagedImage[h, w].Intensity;
                    sample[0, pos] = pixel;
                    pos++;
                }
            }

            float result = 0;
            if (clasificador == "SVM")
            {
                result = svm.Predict(sample);
            }
            else
            {
                result = knearest.FindNearest(sample, K, null, null, null, null);
            }
            return (int)result;
        }

        public int AnalyseImage(Image<Gray, byte> image, String clasificador)
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
            if (clasificador == "SVM")
            {
                result = svm.Predict(sample);
            }
            else
            {
                result = knearest.FindNearest(sample, K, null, null, null, null);
            }
            return (int)result;
        }

        public float RunTest(Dictionary<int, List<Image<Gray, byte>>> images_dictionary, String clasificador)
        {
            float total = 0, exito = 0;
            foreach (KeyValuePair<int, List<Image<Gray, byte>>> kvp in images_dictionary)
            {
                int clase = kvp.Key;
                List<Image<Gray, byte>> images = kvp.Value;

                for (int i = 0; i < images.Count; i++)
                {
                    int result = AnalyseImage(images[i], clasificador);
                    if (result == clase) exito++;
                    total++;
                }
            }

            return (exito / total) * 100.0f;
        }

        public float RunTestDosClases(Dictionary<int, List<Image<Gray, byte>>> images_dictionary, String clasificador, int claseBuscada)
        {
            float total = 0, exito = 0;
            foreach (KeyValuePair<int, List<Image<Gray, byte>>> kvp in images_dictionary)
            {
                int clase = kvp.Key;
                List<Image<Gray, byte>> images = kvp.Value;

                for (int i = 0; i < images.Count; i++)
                {
                    int result = AnalyseImage(images[i], clasificador);
                    if (clase == claseBuscada)
                    {
                        if (result == 1)
                            exito++;
                    }
                    else
                    {
                        if (result != 1)
                            exito++;
                    }
                    total++;
                }
            }

            return (exito / total) * 100.0f;
        }

        public void GuardarEntrenamiento(String clasificador, String nombreArchivo)
        {
            if (clasificador == "SVM")
            {
                svm.Save(nombreArchivo);
            }
            else
            {
                knearest.Save(nombreArchivo);
            }
        }

        public void CargarEntrenamiento(String clasificador, String nombreArchivo)
        {
            if (clasificador == "SVM")
            {
                svm = new SVM();
                svm.Load(nombreArchivo);
            }
            else
            {
                knearest.Load(nombreArchivo);
            }
        }
    }
}

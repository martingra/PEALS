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
using Detector.ML;

namespace Detector.Forms
{
    public partial class Reconocimiento : Form
    {
        private Capture grabber;
        private Image<Bgr, Byte> currentFrame;
        private Detector.scr.Image_Processing.Segmentacion segmentacion;
        private Clasificacion clasif = new Clasificacion();
        private Rectangle rect;

        private bool iniciar = false;

        private double width;
        private double height;

        public Reconocimiento()
        {
            InitializeComponent();
            iniciarGrabacion();
        }

        public void iniciarGrabacion()
        {
            grabber = new Capture();
            grabber.QueryFrame();

            width = grabber.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_WIDTH);
            height = grabber.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT);

            segmentacion = new scr.Image_Processing.Segmentacion((int)width, (int)height);

            grabber.FlipHorizontal = true;
            Application.Idle += new EventHandler(FrameGrabber);
        }

        void FrameGrabber(object sender, EventArgs e)
        {
            currentFrame = grabber.QueryFrame();
            imgBox.Image = currentFrame;

            if (iniciar)
            {
                Image<Gray, byte> monitorClasificador;
                Image<Gray, byte> imgMogColoreada;
                Image<Gray, byte> imagenProcesada = segmentacion.iniciar(currentFrame, txtEsCara.Checked, out rect, out monitorClasificador, out imgMogColoreada, chClasificar.Checked);

                if (rect != Rectangle.Empty)
                    currentFrame.Draw(rect, new Bgr(0, 255, 255), 3);

                imgBoxPreprocess.Image = monitorClasificador;
                imgBoxResultado.Image = imagenProcesada;
                txtResultado.Text = segmentacion.getResultadoClasificacion();

                imageBoxMogColoreado.Image = imgMogColoreada;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            segmentacion.resetearMog();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            iniciar = true;
        }

        private void btnEntrenar_Click(object sender, EventArgs e)
        {
            string subcarpeta = "";
            if (rbTest.Checked)
                subcarpeta = "test";
            else
                subcarpeta = "train";

            Image<Gray, byte> imgEtiqueta = (Image<Gray, byte>)imgBoxResultado.Image;
            txtCantidad.Text = clasif.agregarEtiqueta(subcarpeta, txtEtiqueta.Text, imgEtiqueta).ToString();
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            clasif.train((int)Clasificacion.Clasificador.SVM, 5);
            clasif.GuardarEntrenamiento((int)Clasificacion.Clasificador.SVM, segmentacion.getPath() + "\\Clasificador\\SVM.xml");
        }
    }
}

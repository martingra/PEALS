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
using Detector.SkinDetector;
using System.Threading;
using Emgu.CV.Features2D;

namespace Detector.Forms
{
    public partial class OpticalFlow : Form, FaceDetectorListener
    {
        private Capture capture;

        private Image<Bgr, byte> img_original;
        private Image<Gray, byte> img_gray;
        private Image<Gray, byte> img_prev;
        
        private Image<Gray, byte> img_procesada;

        private OpticalMotion motion;
        private IColorSkinDetector skin;
        private Brisk fastDetector;

        private Rectangle roi;
        private double width;
        private double height;

        private bool seguir = false;

        private FaceDetector _faceDetector;
        private Thread _faceThread;
        private Face face;

        public OpticalFlow()
        {
            InitializeComponent();
        }

        private void OpticalFlow_Load(object sender, EventArgs e)
        {
            capture = new Capture(0);

            width = capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_WIDTH);
            height = capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT);

            roi = new Rectangle(150, 100, 250, 250);
            skin = new YCrCbSkinDetector();

            motion = new OpticalMotion();
            _faceDetector = new FaceDetector(10, this);

            fastDetector = new Brisk(16, 3, 1);
            Application.Idle += new EventHandler(capture_ImageGrabbed);            
        }

        void capture_ImageGrabbed(object sender, EventArgs e)
        {
            img_original = capture.QueryFrame();
            img_gray = capture.QueryGrayFrame();            

            UpdateFace();
            if (face != null)
            {
                img_original.Draw(face.ROI, new Bgr(0, 255, 255), 3);
                img_procesada = img_gray.Copy(face.ROI).Convert<Gray, byte>();

                imgBox2.Image = img_procesada.Clone();

                Image<Bgr, byte> img = new Image<Bgr,byte>(img_procesada.Size);

                ImageFeature<byte>[] carac = fastDetector.DetectFeatures(img_procesada, img_gray);
                foreach (ImageFeature<byte> p in carac)
                {
                    CircleF c = new CircleF(p.KeyPoint.Point, 3);
                    img.Draw(c, new Bgr(0, 255, 200), 3);
                }

                imgBox3.Image = img;
            }

            img_prev = img_gray.Clone();
            imgBox1.Image = img_original;
        }

        public void OnFaceDetect()
        {

        }

        public void OnFaceUpdate(Face face)
        {
            this.face = face;
        }

        private void btn_seguir_Click(object sender, EventArgs e)
        {
            int x, y; double total;
            Image<Bgr, byte> map = new Image<Bgr, byte>(img_original.Size);
            motion.GetOpticalFlow(img_procesada, out x, out y, out total, ref map);

            seguir = true;
        }

        private void UpdateFace()
        {
            if (_faceThread == null || !_faceThread.IsAlive)
            {
                _faceDetector.UpdateImage(img_original);
                _faceThread = new Thread(_faceDetector.DoWork);
                _faceThread.Start();
                _faceThread.Join();
            }
        }
    }
}

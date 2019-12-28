using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using Emgu.CV.ML;
using Detector.SkinDetector;

namespace Detector
{
    public partial class FrmPrincipal : Form
    {
        //Declararation of all variables, vectors and haarcascades
        private Image<Bgr, Byte> backgroundFrame;
        private Image<Bgr, Byte> roi_image;
        private Image<Bgr, Byte> blob_image;
        private Image<Bgr, Byte> currentFrame;

        private Capture grabber;
        private Rectangle roi;
        
        private bool first_bg = true;

        private HandDetection left_hand;
        private OpticalMotion optical_motion;
        private HaarCascade hand;

        private MemStorage storage = new MemStorage();

        public FrmPrincipal()
        {
            InitializeComponent();

            left_hand = new HandDetection();
            optical_motion = new OpticalMotion();
            roi = new Rectangle(10, 30, 125, 125);
            hand = new HaarCascade("D:/Peals/_Deteccion_branch/Detection/bin/Debug/Cascades/aGest.xml");

            Detector.Forms.camShift shift = new Forms.camShift();
            //shift.Show();
        }

        void FrameGrabber(object sender, EventArgs e)
        {
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            currentFrame._EqualizeHist();
            if (first_bg)
            {
                backgroundFrame = currentFrame.Copy(roi);
                first_bg = false;
            }

            if (cbox_usarROI.Checked)
            {
                roi_image = currentFrame.Copy(roi).Convert<Bgr, Byte>();
                currentFrame.Draw(roi, new Bgr(Color.Green), 2);
            }
            else
            {
                roi_image = currentFrame;
            }

            Process(currentFrame);   
        }

        private void Process(Image<Bgr, Byte> currentFrame)
        {
            imageBoxFrameGrabber.Image = currentFrame;

            if (cb_background.Checked)
                roi_image = roi_image.Sub(backgroundFrame);

            Rgb RGB_min = new Rgb((double)R_min.Value, (double)G_min.Value, (double)B_min.Value);
            Rgb RGB_max = new Rgb((double)R_max.Value, (double)G_max.Value, (double)B_max.Value);
            Rgb[] rgb = new Rgb[] { RGB_min, RGB_max };

            Hsv HSV_min = new Hsv((double)H_min.Value, (double)S_min.Value, (double)V_min.Value);
            Hsv HSV_max = new Hsv((double)H_max.Value, (double)S_max.Value, (double)V_max.Value);
            Hsv[] hsv = new Hsv[] { HSV_min, HSV_max };

            Ycc YCbCr_min = new Ycc((double)Y_min.Value, (double)Cb_min.Value, (double)Cr_min.Value);
            Ycc YCbCr_max = new Ycc((double)Y_max.Value, (double)Cb_max.Value, (double)Cr_max.Value);
            Ycc[] ycc = new Ycc[] { YCbCr_min, YCbCr_max };

            int erode = (int)value_erode.Value;
            int dilate = (int)value_dilate.Value;

            int kernelX = 0;
            int.TryParse(txt_sKernel_x.Text, out kernelX);

            //Image<Bgr, byte> colourMap = new Image<Bgr, byte>(roi_image.Size);
            //int dirX, dirY;
            //double movimientoPromedio;
            //bool mov = optical_motion.GetOpticalFlow(roi_image, out dirX, out dirY, out movimientoPromedio, ref colourMap);
            //if (mov)
            //{
            //    imageBox_OpticalFlowMap.Image = colourMap;
            //    mov_left.Visible = false;
            //    mov_right.Visible = false;
            //    mov_up.Visible = false;
            //    mov_down.Visible = false;

            //    if (dirX > 1) mov_right.Visible = true;
            //    else if (dirX < 1) mov_left.Visible = true;

            //    if (dirY > 1) mov_up.Visible = true;
            //    else if (dirY < 1) mov_down.Visible = true;

            //    Image<Gray, byte> gray = colourMap.Convert<Gray, byte>();
            //    gray = gray.ThresholdBinary(new Gray(150), new Gray(255)); 

            //    Contour<System.Drawing.Point> contour = null;
            //    double max_area = 0;
            //    for (Contour<System.Drawing.Point> tmp_contour = gray.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL, storage); tmp_contour != null; tmp_contour = tmp_contour.HNext)
            //    {
            //        if (tmp_contour.Area > max_area)
            //        {
            //            max_area = tmp_contour.Area;
            //            contour = tmp_contour;
            //        }
            //    }

            //    if (contour != null && contour.Total > 0)
            //    {
            //        Image<Gray, byte> hand_flow = new Image<Gray, byte>(colourMap.Size);
            //        hand_flow.DrawPolyline(contour.ToArray(), true, new Gray(255), -1);
            //        imageBox_OpticalFlowBorder.Image = hand_flow;
            //    }
            //    else
            //    {
            //        imageBox_OpticalFlowBorder.Image = gray;
            //    }
            //}

            Image<Gray, byte>[] skins = null;
            left_hand.Config(erode, dilate, kernelX, rgb, hsv, ycc);
            Image<Gray, Byte> thr_image = left_hand.FilterAndThreshold(roi_image, cbox_rgb.Checked, cbox_hsv.Checked, cbox_YCbCr.Checked, out skins);            

            if (cb_invert.Checked)
                thr_image = thr_image.ThresholdBinaryInv(new Gray(125), new Gray(255));

            blob_image = new Image<Bgr, byte>(roi_image.Width, roi_image.Height);
            Contour<Point> contours = left_hand.FindContour(thr_image);
            left_hand.FindConvexHull(contours, blob_image, cb_margen.Checked, cb_drawRoi.Checked, cb_center.Checked);
            Point[] finger_points = left_hand.FindFinger(contours, blob_image);
            left_hand.DrawHand(finger_points, blob_image, cb_convex.Checked, cb_defects.Checked, cb_connectPoint.Checked);

            imageBoxRGB.Image = skins[0];
            imageBoxHSV.Image = skins[1];
            imageBoxYCbCr.Image = skins[2];

            //imageBoxROI.Image = thr_image;
            imageBoxROI.Image = skins[0].Mul(skins[1]).Mul(skins[2]);
            imageBoxDetect.Image = blob_image;
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grabber = new Capture();
            grabber.QueryFrame();
            grabber.FlipHorizontal = true;

            Application.Idle += new EventHandler(FrameGrabber);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Idle -= new EventHandler(FrameGrabber);
            grabber.Dispose();
            grabber = null;
        }

        private void cargarImágenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = file_dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = file_dialog.FileName;
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(file).Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                imageBoxFrameGrabber.Image = img;

                roi_image = img.Resize(roi.Width, roi.Height, INTER.CV_INTER_CUBIC);
                Process(img);
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_agregarCascade_Click(object sender, EventArgs e)
        {
            DialogResult result = file_dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string[] file = file_dialog.FileName.Split('\\');
                //clb_cascades.Items.Add(file[file.Length-1], true);
            }
        }

        private void kNearestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KNearestForm form = new KNearestForm();
            form.Show();
        }

        private void cbox_usarROI_CheckedChanged(object sender, EventArgs e)
        {
            optical_motion = new OpticalMotion();
        }

    }
}
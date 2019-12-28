namespace Detector.Forms
{
    partial class Occlusion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imgBox1 = new Emgu.CV.UI.ImageBox();
            this.imgBox_roi = new Emgu.CV.UI.ImageBox();
            this.btn_setRoi = new System.Windows.Forms.Button();
            this.btn_detectar = new System.Windows.Forms.Button();
            this.imgBox2 = new Emgu.CV.UI.ImageBox();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.imgBoxSegmentacion = new Emgu.CV.UI.ImageBox();
            this.imgBoxOjoIzq = new Emgu.CV.UI.ImageBox();
            this.imgBoxOjoDer = new Emgu.CV.UI.ImageBox();
            this.imgBoxNariz = new Emgu.CV.UI.ImageBox();
            this.imgBoxBoca = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_roi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxSegmentacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxOjoIzq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxOjoDer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxNariz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxBoca)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBox1
            // 
            this.imgBox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBox1.Location = new System.Drawing.Point(2, 2);
            this.imgBox1.Name = "imgBox1";
            this.imgBox1.Size = new System.Drawing.Size(538, 471);
            this.imgBox1.TabIndex = 2;
            this.imgBox1.TabStop = false;
            this.imgBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgBox1_MouseDown);
            this.imgBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgBox1_MouseMove);
            this.imgBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgBox1_MouseUp);
            // 
            // imgBox_roi
            // 
            this.imgBox_roi.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBox_roi.Location = new System.Drawing.Point(1041, 292);
            this.imgBox_roi.Name = "imgBox_roi";
            this.imgBox_roi.Size = new System.Drawing.Size(130, 129);
            this.imgBox_roi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox_roi.TabIndex = 3;
            this.imgBox_roi.TabStop = false;
            this.imgBox_roi.Click += new System.EventHandler(this.imgBox_roi_Click);
            // 
            // btn_setRoi
            // 
            this.btn_setRoi.Location = new System.Drawing.Point(138, 479);
            this.btn_setRoi.Name = "btn_setRoi";
            this.btn_setRoi.Size = new System.Drawing.Size(130, 30);
            this.btn_setRoi.TabIndex = 4;
            this.btn_setRoi.Text = "Guardar ROI";
            this.btn_setRoi.UseVisualStyleBackColor = true;
            this.btn_setRoi.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_detectar
            // 
            this.btn_detectar.Location = new System.Drawing.Point(138, 515);
            this.btn_detectar.Name = "btn_detectar";
            this.btn_detectar.Size = new System.Drawing.Size(130, 30);
            this.btn_detectar.TabIndex = 5;
            this.btn_detectar.Text = "Detectar";
            this.btn_detectar.UseVisualStyleBackColor = true;
            this.btn_detectar.Click += new System.EventHandler(this.btn_detectar_Click);
            // 
            // imgBox2
            // 
            this.imgBox2.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBox2.Location = new System.Drawing.Point(1041, 95);
            this.imgBox2.Name = "imgBox2";
            this.imgBox2.Size = new System.Drawing.Size(130, 88);
            this.imgBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox2.TabIndex = 6;
            this.imgBox2.TabStop = false;
            // 
            // imageBox1
            // 
            this.imageBox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox1.Location = new System.Drawing.Point(1041, 2);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(130, 87);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox1.TabIndex = 7;
            this.imageBox1.TabStop = false;
            // 
            // imageBox2
            // 
            this.imageBox2.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox2.Location = new System.Drawing.Point(1041, 189);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(130, 87);
            this.imageBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox2.TabIndex = 8;
            this.imageBox2.TabStop = false;
            // 
            // imgBoxSegmentacion
            // 
            this.imgBoxSegmentacion.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBoxSegmentacion.Location = new System.Drawing.Point(546, 2);
            this.imgBoxSegmentacion.Name = "imgBoxSegmentacion";
            this.imgBoxSegmentacion.Size = new System.Drawing.Size(480, 315);
            this.imgBoxSegmentacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBoxSegmentacion.TabIndex = 9;
            this.imgBoxSegmentacion.TabStop = false;
            // 
            // imgBoxOjoIzq
            // 
            this.imgBoxOjoIzq.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBoxOjoIzq.Location = new System.Drawing.Point(749, 359);
            this.imgBoxOjoIzq.Name = "imgBoxOjoIzq";
            this.imgBoxOjoIzq.Size = new System.Drawing.Size(100, 62);
            this.imgBoxOjoIzq.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBoxOjoIzq.TabIndex = 10;
            this.imgBoxOjoIzq.TabStop = false;
            // 
            // imgBoxOjoDer
            // 
            this.imgBoxOjoDer.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBoxOjoDer.Location = new System.Drawing.Point(632, 359);
            this.imgBoxOjoDer.Name = "imgBoxOjoDer";
            this.imgBoxOjoDer.Size = new System.Drawing.Size(100, 62);
            this.imgBoxOjoDer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBoxOjoDer.TabIndex = 11;
            this.imgBoxOjoDer.TabStop = false;
            // 
            // imgBoxNariz
            // 
            this.imgBoxNariz.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBoxNariz.Location = new System.Drawing.Point(695, 427);
            this.imgBoxNariz.Name = "imgBoxNariz";
            this.imgBoxNariz.Size = new System.Drawing.Size(100, 62);
            this.imgBoxNariz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBoxNariz.TabIndex = 12;
            this.imgBoxNariz.TabStop = false;
            // 
            // imgBoxBoca
            // 
            this.imgBoxBoca.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBoxBoca.Location = new System.Drawing.Point(695, 495);
            this.imgBoxBoca.Name = "imgBoxBoca";
            this.imgBoxBoca.Size = new System.Drawing.Size(100, 62);
            this.imgBoxBoca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBoxBoca.TabIndex = 13;
            this.imgBoxBoca.TabStop = false;
            // 
            // Occlusion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 569);
            this.Controls.Add(this.imgBoxBoca);
            this.Controls.Add(this.imgBoxNariz);
            this.Controls.Add(this.imgBoxOjoDer);
            this.Controls.Add(this.imgBoxOjoIzq);
            this.Controls.Add(this.imgBoxSegmentacion);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.imgBox2);
            this.Controls.Add(this.btn_detectar);
            this.Controls.Add(this.btn_setRoi);
            this.Controls.Add(this.imgBox_roi);
            this.Controls.Add(this.imgBox1);
            this.Name = "Occlusion";
            this.Text = "Occlusion";
            this.Load += new System.EventHandler(this.Occlusion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_roi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxSegmentacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxOjoIzq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxOjoDer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxNariz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxBoca)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgBox1;
        private Emgu.CV.UI.ImageBox imgBox_roi;
        private System.Windows.Forms.Button btn_setRoi;
        private System.Windows.Forms.Button btn_detectar;
        private Emgu.CV.UI.ImageBox imgBox2;
        private Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox imageBox2;
        private Emgu.CV.UI.ImageBox imgBoxSegmentacion;
        private Emgu.CV.UI.ImageBox imgBoxOjoIzq;
        private Emgu.CV.UI.ImageBox imgBoxOjoDer;
        private Emgu.CV.UI.ImageBox imgBoxNariz;
        private Emgu.CV.UI.ImageBox imgBoxBoca;
    }
}
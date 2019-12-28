namespace Detector
{
    partial class KNearestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txt_respuesta = new System.Windows.Forms.TextBox();
            this.img_original = new Emgu.CV.UI.ImageBox();
            this.img_canny = new Emgu.CV.UI.ImageBox();
            this.btn_cargar = new System.Windows.Forms.Button();
            this.file_dialog = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btn_train = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbl_k = new System.Windows.Forms.Label();
            this.txt_k = new System.Windows.Forms.TextBox();
            this.gbox_resultado = new System.Windows.Forms.GroupBox();
            this.btn_detectar = new System.Windows.Forms.Button();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTrainK = new System.Windows.Forms.Button();
            this.txt_precision = new System.Windows.Forms.TextBox();
            this.cb_useHistogram = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.histogramBox1 = new Emgu.CV.UI.HistogramBox();
            this.matrixBox1 = new Emgu.CV.UI.MatrixBox();
            ((System.ComponentModel.ISupportInitialize)(this.img_original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_canny)).BeginInit();
            this.gbox_resultado.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_respuesta
            // 
            this.txt_respuesta.BackColor = System.Drawing.SystemColors.HotTrack;
            this.txt_respuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_respuesta.ForeColor = System.Drawing.SystemColors.Info;
            this.txt_respuesta.Location = new System.Drawing.Point(95, 216);
            this.txt_respuesta.Name = "txt_respuesta";
            this.txt_respuesta.Size = new System.Drawing.Size(139, 30);
            this.txt_respuesta.TabIndex = 4;
            this.txt_respuesta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // img_original
            // 
            this.img_original.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_original.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.img_original.Location = new System.Drawing.Point(6, 19);
            this.img_original.Name = "img_original";
            this.img_original.Size = new System.Drawing.Size(226, 188);
            this.img_original.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_original.TabIndex = 6;
            this.img_original.TabStop = false;
            // 
            // img_canny
            // 
            this.img_canny.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_canny.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.img_canny.Location = new System.Drawing.Point(6, 19);
            this.img_canny.Name = "img_canny";
            this.img_canny.Size = new System.Drawing.Size(228, 188);
            this.img_canny.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_canny.TabIndex = 7;
            this.img_canny.TabStop = false;
            // 
            // btn_cargar
            // 
            this.btn_cargar.Location = new System.Drawing.Point(6, 213);
            this.btn_cargar.Name = "btn_cargar";
            this.btn_cargar.Size = new System.Drawing.Size(226, 30);
            this.btn_cargar.TabIndex = 8;
            this.btn_cargar.Text = "Cargar Imágen";
            this.btn_cargar.UseVisualStyleBackColor = true;
            this.btn_cargar.Click += new System.EventHandler(this.btn_cargar_Click);
            // 
            // file_dialog
            // 
            this.file_dialog.FileName = "file_dialog";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Path:";
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(41, 20);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(276, 20);
            this.txt_path.TabIndex = 10;
            this.txt_path.Text = "D:\\Gabriel\\Proyectos\\Peals\\Peals_Deteccion_Branch\\Detection\\Resources\\Figuras\\";
            // 
            // btn_train
            // 
            this.btn_train.Location = new System.Drawing.Point(409, 15);
            this.btn_train.Name = "btn_train";
            this.btn_train.Size = new System.Drawing.Size(72, 25);
            this.btn_train.TabIndex = 11;
            this.btn_train.Text = "Train";
            this.btn_train.UseVisualStyleBackColor = true;
            this.btn_train.Click += new System.EventHandler(this.btn_train_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(5, 72);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(312, 31);
            this.progressBar.TabIndex = 12;
            // 
            // lbl_k
            // 
            this.lbl_k.AutoSize = true;
            this.lbl_k.Location = new System.Drawing.Point(322, 83);
            this.lbl_k.Name = "lbl_k";
            this.lbl_k.Size = new System.Drawing.Size(14, 13);
            this.lbl_k.TabIndex = 13;
            this.lbl_k.Text = "K";
            // 
            // txt_k
            // 
            this.txt_k.Location = new System.Drawing.Point(342, 79);
            this.txt_k.Name = "txt_k";
            this.txt_k.Size = new System.Drawing.Size(63, 20);
            this.txt_k.TabIndex = 14;
            this.txt_k.Text = "1";
            // 
            // gbox_resultado
            // 
            this.gbox_resultado.Controls.Add(this.btn_detectar);
            this.gbox_resultado.Controls.Add(this.img_canny);
            this.gbox_resultado.Controls.Add(this.txt_respuesta);
            this.gbox_resultado.Location = new System.Drawing.Point(250, 9);
            this.gbox_resultado.Name = "gbox_resultado";
            this.gbox_resultado.Size = new System.Drawing.Size(240, 254);
            this.gbox_resultado.TabIndex = 17;
            this.gbox_resultado.TabStop = false;
            this.gbox_resultado.Text = "Resultado";
            // 
            // btn_detectar
            // 
            this.btn_detectar.Location = new System.Drawing.Point(6, 216);
            this.btn_detectar.Name = "btn_detectar";
            this.btn_detectar.Size = new System.Drawing.Size(83, 30);
            this.btn_detectar.TabIndex = 9;
            this.btn_detectar.Text = "Detectar";
            this.btn_detectar.UseVisualStyleBackColor = true;
            this.btn_detectar.Click += new System.EventHandler(this.btn_detectar_Click);
            // 
            // txt_log
            // 
            this.txt_log.BackColor = System.Drawing.SystemColors.InfoText;
            this.txt_log.ForeColor = System.Drawing.Color.Linen;
            this.txt_log.Location = new System.Drawing.Point(881, 9);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_log.Size = new System.Drawing.Size(319, 343);
            this.txt_log.TabIndex = 18;
            this.txt_log.Text = "TEST";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTrainK);
            this.groupBox1.Controls.Add(this.txt_precision);
            this.groupBox1.Controls.Add(this.cb_useHistogram);
            this.groupBox1.Controls.Add(this.progressBar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_path);
            this.groupBox1.Controls.Add(this.txt_k);
            this.groupBox1.Controls.Add(this.btn_train);
            this.groupBox1.Controls.Add(this.lbl_k);
            this.groupBox1.Location = new System.Drawing.Point(3, 269);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 137);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entranamiento";
            // 
            // btnTrainK
            // 
            this.btnTrainK.Location = new System.Drawing.Point(409, 46);
            this.btnTrainK.Name = "btnTrainK";
            this.btnTrainK.Size = new System.Drawing.Size(72, 23);
            this.btnTrainK.TabIndex = 17;
            this.btnTrainK.Text = "Train-K";
            this.btnTrainK.UseVisualStyleBackColor = true;
            this.btnTrainK.Click += new System.EventHandler(this.btnTrainK_Click);
            // 
            // txt_precision
            // 
            this.txt_precision.Location = new System.Drawing.Point(409, 79);
            this.txt_precision.Name = "txt_precision";
            this.txt_precision.Size = new System.Drawing.Size(70, 20);
            this.txt_precision.TabIndex = 16;
            // 
            // cb_useHistogram
            // 
            this.cb_useHistogram.AutoSize = true;
            this.cb_useHistogram.Location = new System.Drawing.Point(325, 23);
            this.cb_useHistogram.Name = "cb_useHistogram";
            this.cb_useHistogram.Size = new System.Drawing.Size(82, 17);
            this.cb_useHistogram.TabIndex = 15;
            this.cb_useHistogram.Text = " Histograma";
            this.cb_useHistogram.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.img_original);
            this.groupBox2.Controls.Add(this.btn_cargar);
            this.groupBox2.Location = new System.Drawing.Point(3, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 254);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Entrada";
            // 
            // histogramBox1
            // 
            this.histogramBox1.Location = new System.Drawing.Point(496, 14);
            this.histogramBox1.Name = "histogramBox1";
            this.histogramBox1.Size = new System.Drawing.Size(367, 338);
            this.histogramBox1.TabIndex = 10;
            // 
            // matrixBox1
            // 
            this.matrixBox1.Location = new System.Drawing.Point(569, 201);
            this.matrixBox1.Matrix = null;
            this.matrixBox1.Name = "matrixBox1";
            this.matrixBox1.Size = new System.Drawing.Size(10, 14);
            this.matrixBox1.TabIndex = 22;
            // 
            // KNearestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 439);
            this.Controls.Add(this.matrixBox1);
            this.Controls.Add(this.histogramBox1);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbox_resultado);
            this.Name = "KNearestForm";
            this.Text = "KNearestForm";
            this.Load += new System.EventHandler(this.KNearestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.img_original)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_canny)).EndInit();
            this.gbox_resultado.ResumeLayout(false);
            this.gbox_resultado.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_respuesta;
        private Emgu.CV.UI.ImageBox img_original;
        private Emgu.CV.UI.ImageBox img_canny;
        private System.Windows.Forms.Button btn_cargar;
        private System.Windows.Forms.OpenFileDialog file_dialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button btn_train;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbl_k;
        private System.Windows.Forms.TextBox txt_k;
        private System.Windows.Forms.GroupBox gbox_resultado;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.Button btn_detectar;
        private Emgu.CV.UI.HistogramBox histogramBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_useHistogram;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_precision;
        private Emgu.CV.UI.MatrixBox matrixBox1;
        private System.Windows.Forms.Button btnTrainK;
    }
}
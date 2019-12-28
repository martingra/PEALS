namespace Detector.Forms
{
    partial class Segmentacion
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
            this.imgBox_VideoBgr = new Emgu.CV.UI.ImageBox();
            this.label4 = new System.Windows.Forms.Label();
            this.value_erode = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.value_dilate = new System.Windows.Forms.NumericUpDown();
            this.chApertura = new System.Windows.Forms.CheckBox();
            this.chCierre = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.valueSmooth = new System.Windows.Forms.NumericUpDown();
            this.comboMetodo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.value_tresh = new System.Windows.Forms.NumericUpDown();
            this.value_s = new System.Windows.Forms.NumericUpDown();
            this.chEcualizar = new System.Windows.Forms.CheckBox();
            this.imgBox_videoHsv = new Emgu.CV.UI.ImageBox();
            this.group_izq = new System.Windows.Forms.GroupBox();
            this.imgBox_manoIzq = new Emgu.CV.UI.ImageBox();
            this.imgBox_segIzq = new Emgu.CV.UI.ImageBox();
            this.imgBox_bordeIzq = new Emgu.CV.UI.ImageBox();
            this.imgBox_movIzq = new Emgu.CV.UI.ImageBox();
            this.group_der = new System.Windows.Forms.GroupBox();
            this.imgBox_manoDer = new Emgu.CV.UI.ImageBox();
            this.imgBox_segDer = new Emgu.CV.UI.ImageBox();
            this.imgBox_bordeDer = new Emgu.CV.UI.ImageBox();
            this.imgBox_movDer = new Emgu.CV.UI.ImageBox();
            this.label3 = new System.Windows.Forms.Label();
            this.value_area = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_maxArea = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_areaDer = new System.Windows.Forms.Label();
            this.lbl_areaIzq = new System.Windows.Forms.Label();
            this.chBalance = new System.Windows.Forms.CheckBox();
            this.chSaturar = new System.Windows.Forms.CheckBox();
            this.value_areaMano = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_VideoBgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_erode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_dilate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueSmooth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_tresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_s)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_videoHsv)).BeginInit();
            this.group_izq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_manoIzq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_segIzq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_bordeIzq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_movIzq)).BeginInit();
            this.group_der.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_manoDer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_segDer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_bordeDer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_movDer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_area)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_areaMano)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBox_VideoBgr
            // 
            this.imgBox_VideoBgr.Location = new System.Drawing.Point(2, 3);
            this.imgBox_VideoBgr.Name = "imgBox_VideoBgr";
            this.imgBox_VideoBgr.Size = new System.Drawing.Size(250, 195);
            this.imgBox_VideoBgr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox_VideoBgr.TabIndex = 2;
            this.imgBox_VideoBgr.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(333, 435);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Erode";
            // 
            // value_erode
            // 
            this.value_erode.Location = new System.Drawing.Point(374, 433);
            this.value_erode.Name = "value_erode";
            this.value_erode.Size = new System.Drawing.Size(60, 20);
            this.value_erode.TabIndex = 15;
            this.value_erode.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(334, 458);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Dilate";
            // 
            // value_dilate
            // 
            this.value_dilate.Location = new System.Drawing.Point(374, 457);
            this.value_dilate.Name = "value_dilate";
            this.value_dilate.Size = new System.Drawing.Size(60, 20);
            this.value_dilate.TabIndex = 18;
            this.value_dilate.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // chApertura
            // 
            this.chApertura.AutoSize = true;
            this.chApertura.Checked = true;
            this.chApertura.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chApertura.Location = new System.Drawing.Point(264, 434);
            this.chApertura.Name = "chApertura";
            this.chApertura.Size = new System.Drawing.Size(65, 17);
            this.chApertura.TabIndex = 19;
            this.chApertura.Text = "apertura";
            this.chApertura.UseVisualStyleBackColor = true;
            // 
            // chCierre
            // 
            this.chCierre.AutoSize = true;
            this.chCierre.Checked = true;
            this.chCierre.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chCierre.Location = new System.Drawing.Point(264, 457);
            this.chCierre.Name = "chCierre";
            this.chCierre.Size = new System.Drawing.Size(52, 17);
            this.chCierre.TabIndex = 20;
            this.chCierre.Text = "cierre";
            this.chCierre.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(51, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Smooth";
            // 
            // valueSmooth
            // 
            this.valueSmooth.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.valueSmooth.Location = new System.Drawing.Point(100, 409);
            this.valueSmooth.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.valueSmooth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.valueSmooth.Name = "valueSmooth";
            this.valueSmooth.Size = new System.Drawing.Size(47, 20);
            this.valueSmooth.TabIndex = 21;
            this.valueSmooth.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // comboMetodo
            // 
            this.comboMetodo.FormattingEnabled = true;
            this.comboMetodo.Items.AddRange(new object[] {
            "AbsDiff",
            "Sobel",
            "Laplace",
            "MOG2"});
            this.comboMetodo.Location = new System.Drawing.Point(264, 408);
            this.comboMetodo.Name = "comboMetodo";
            this.comboMetodo.Size = new System.Drawing.Size(58, 21);
            this.comboMetodo.TabIndex = 23;
            this.comboMetodo.Text = "MOG2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 411);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Thresh";
            // 
            // value_tresh
            // 
            this.value_tresh.Location = new System.Drawing.Point(374, 408);
            this.value_tresh.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.value_tresh.Name = "value_tresh";
            this.value_tresh.Size = new System.Drawing.Size(60, 20);
            this.value_tresh.TabIndex = 24;
            this.value_tresh.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // value_s
            // 
            this.value_s.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.value_s.Location = new System.Drawing.Point(191, 409);
            this.value_s.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.value_s.Name = "value_s";
            this.value_s.Size = new System.Drawing.Size(61, 20);
            this.value_s.TabIndex = 26;
            this.value_s.Value = new decimal(new int[] {
            175,
            0,
            0,
            0});
            // 
            // chEcualizar
            // 
            this.chEcualizar.AutoSize = true;
            this.chEcualizar.Location = new System.Drawing.Point(6, 409);
            this.chEcualizar.Name = "chEcualizar";
            this.chEcualizar.Size = new System.Drawing.Size(39, 17);
            this.chEcualizar.TabIndex = 23;
            this.chEcualizar.Text = "Eq";
            this.chEcualizar.UseVisualStyleBackColor = true;
            // 
            // imgBox_videoHsv
            // 
            this.imgBox_videoHsv.Location = new System.Drawing.Point(2, 208);
            this.imgBox_videoHsv.Name = "imgBox_videoHsv";
            this.imgBox_videoHsv.Size = new System.Drawing.Size(250, 195);
            this.imgBox_videoHsv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox_videoHsv.TabIndex = 35;
            this.imgBox_videoHsv.TabStop = false;
            // 
            // group_izq
            // 
            this.group_izq.Controls.Add(this.imgBox_manoIzq);
            this.group_izq.Controls.Add(this.imgBox_segIzq);
            this.group_izq.Controls.Add(this.imgBox_bordeIzq);
            this.group_izq.Controls.Add(this.imgBox_movIzq);
            this.group_izq.Location = new System.Drawing.Point(258, 204);
            this.group_izq.Name = "group_izq";
            this.group_izq.Size = new System.Drawing.Size(712, 199);
            this.group_izq.TabIndex = 36;
            this.group_izq.TabStop = false;
            this.group_izq.Text = "Izquierda";
            // 
            // imgBox_manoIzq
            // 
            this.imgBox_manoIzq.Location = new System.Drawing.Point(534, 23);
            this.imgBox_manoIzq.Name = "imgBox_manoIzq";
            this.imgBox_manoIzq.Size = new System.Drawing.Size(170, 170);
            this.imgBox_manoIzq.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox_manoIzq.TabIndex = 10;
            this.imgBox_manoIzq.TabStop = false;
            // 
            // imgBox_segIzq
            // 
            this.imgBox_segIzq.Location = new System.Drawing.Point(358, 23);
            this.imgBox_segIzq.Name = "imgBox_segIzq";
            this.imgBox_segIzq.Size = new System.Drawing.Size(170, 170);
            this.imgBox_segIzq.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox_segIzq.TabIndex = 9;
            this.imgBox_segIzq.TabStop = false;
            // 
            // imgBox_bordeIzq
            // 
            this.imgBox_bordeIzq.Location = new System.Drawing.Point(182, 23);
            this.imgBox_bordeIzq.Name = "imgBox_bordeIzq";
            this.imgBox_bordeIzq.Size = new System.Drawing.Size(170, 170);
            this.imgBox_bordeIzq.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox_bordeIzq.TabIndex = 8;
            this.imgBox_bordeIzq.TabStop = false;
            // 
            // imgBox_movIzq
            // 
            this.imgBox_movIzq.Location = new System.Drawing.Point(6, 23);
            this.imgBox_movIzq.Name = "imgBox_movIzq";
            this.imgBox_movIzq.Size = new System.Drawing.Size(170, 170);
            this.imgBox_movIzq.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox_movIzq.TabIndex = 7;
            this.imgBox_movIzq.TabStop = false;
            // 
            // group_der
            // 
            this.group_der.Controls.Add(this.imgBox_manoDer);
            this.group_der.Controls.Add(this.imgBox_segDer);
            this.group_der.Controls.Add(this.imgBox_bordeDer);
            this.group_der.Controls.Add(this.imgBox_movDer);
            this.group_der.Location = new System.Drawing.Point(258, 3);
            this.group_der.Name = "group_der";
            this.group_der.Size = new System.Drawing.Size(712, 195);
            this.group_der.TabIndex = 37;
            this.group_der.TabStop = false;
            this.group_der.Text = "Derecha";
            // 
            // imgBox_manoDer
            // 
            this.imgBox_manoDer.Location = new System.Drawing.Point(534, 18);
            this.imgBox_manoDer.Name = "imgBox_manoDer";
            this.imgBox_manoDer.Size = new System.Drawing.Size(170, 170);
            this.imgBox_manoDer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox_manoDer.TabIndex = 6;
            this.imgBox_manoDer.TabStop = false;
            // 
            // imgBox_segDer
            // 
            this.imgBox_segDer.Location = new System.Drawing.Point(358, 18);
            this.imgBox_segDer.Name = "imgBox_segDer";
            this.imgBox_segDer.Size = new System.Drawing.Size(170, 170);
            this.imgBox_segDer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox_segDer.TabIndex = 5;
            this.imgBox_segDer.TabStop = false;
            // 
            // imgBox_bordeDer
            // 
            this.imgBox_bordeDer.Location = new System.Drawing.Point(182, 18);
            this.imgBox_bordeDer.Name = "imgBox_bordeDer";
            this.imgBox_bordeDer.Size = new System.Drawing.Size(170, 170);
            this.imgBox_bordeDer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox_bordeDer.TabIndex = 4;
            this.imgBox_bordeDer.TabStop = false;
            // 
            // imgBox_movDer
            // 
            this.imgBox_movDer.Location = new System.Drawing.Point(6, 18);
            this.imgBox_movDer.Name = "imgBox_movDer";
            this.imgBox_movDer.Size = new System.Drawing.Size(170, 170);
            this.imgBox_movDer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox_movDer.TabIndex = 3;
            this.imgBox_movDer.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 411);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Hsv";
            // 
            // value_area
            // 
            this.value_area.Location = new System.Drawing.Point(496, 456);
            this.value_area.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.value_area.Name = "value_area";
            this.value_area.Size = new System.Drawing.Size(114, 20);
            this.value_area.TabIndex = 39;
            this.value_area.Value = new decimal(new int[] {
            40000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(440, 458);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Max Area";
            // 
            // lbl_maxArea
            // 
            this.lbl_maxArea.AutoSize = true;
            this.lbl_maxArea.Location = new System.Drawing.Point(440, 411);
            this.lbl_maxArea.Name = "lbl_maxArea";
            this.lbl_maxArea.Size = new System.Drawing.Size(76, 13);
            this.lbl_maxArea.TabIndex = 41;
            this.lbl_maxArea.Text = "Area Derecha:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(440, 435);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Area Izquierda:";
            // 
            // lbl_areaDer
            // 
            this.lbl_areaDer.AutoSize = true;
            this.lbl_areaDer.Location = new System.Drawing.Point(528, 411);
            this.lbl_areaDer.Name = "lbl_areaDer";
            this.lbl_areaDer.Size = new System.Drawing.Size(35, 13);
            this.lbl_areaDer.TabIndex = 43;
            this.lbl_areaDer.Text = "label8";
            // 
            // lbl_areaIzq
            // 
            this.lbl_areaIzq.AutoSize = true;
            this.lbl_areaIzq.Location = new System.Drawing.Point(528, 435);
            this.lbl_areaIzq.Name = "lbl_areaIzq";
            this.lbl_areaIzq.Size = new System.Drawing.Size(35, 13);
            this.lbl_areaIzq.TabIndex = 44;
            this.lbl_areaIzq.Text = "label8";
            // 
            // chBalance
            // 
            this.chBalance.AutoSize = true;
            this.chBalance.Checked = true;
            this.chBalance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBalance.Location = new System.Drawing.Point(6, 436);
            this.chBalance.Name = "chBalance";
            this.chBalance.Size = new System.Drawing.Size(121, 17);
            this.chBalance.TabIndex = 45;
            this.chBalance.Text = "Balance de Blancos";
            this.chBalance.UseVisualStyleBackColor = true;
            // 
            // chSaturar
            // 
            this.chSaturar.AutoSize = true;
            this.chSaturar.Location = new System.Drawing.Point(165, 436);
            this.chSaturar.Name = "chSaturar";
            this.chSaturar.Size = new System.Drawing.Size(60, 17);
            this.chSaturar.TabIndex = 46;
            this.chSaturar.Text = "Saturar";
            this.chSaturar.UseVisualStyleBackColor = true;
            // 
            // value_areaMano
            // 
            this.value_areaMano.Location = new System.Drawing.Point(679, 408);
            this.value_areaMano.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.value_areaMano.Name = "value_areaMano";
            this.value_areaMano.Size = new System.Drawing.Size(107, 20);
            this.value_areaMano.TabIndex = 47;
            this.value_areaMano.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(624, 411);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "Area Min";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 453);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Segmentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 482);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.value_areaMano);
            this.Controls.Add(this.chSaturar);
            this.Controls.Add(this.chBalance);
            this.Controls.Add(this.lbl_areaIzq);
            this.Controls.Add(this.lbl_areaDer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_maxArea);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.value_area);
            this.Controls.Add(this.value_dilate);
            this.Controls.Add(this.chApertura);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.value_erode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.value_tresh);
            this.Controls.Add(this.chCierre);
            this.Controls.Add(this.value_s);
            this.Controls.Add(this.group_der);
            this.Controls.Add(this.group_izq);
            this.Controls.Add(this.imgBox_videoHsv);
            this.Controls.Add(this.chEcualizar);
            this.Controls.Add(this.comboMetodo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgBox_VideoBgr);
            this.Controls.Add(this.valueSmooth);
            this.Name = "Segmentacion";
            this.Text = "Segmentacion";
            this.Load += new System.EventHandler(this.Segmentacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_VideoBgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_erode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_dilate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueSmooth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_tresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_s)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_videoHsv)).EndInit();
            this.group_izq.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_manoIzq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_segIzq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_bordeIzq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_movIzq)).EndInit();
            this.group_der.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_manoDer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_segDer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_bordeDer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_movDer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_area)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_areaMano)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgBox_VideoBgr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown value_erode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown value_dilate;
        private System.Windows.Forms.CheckBox chApertura;
        private System.Windows.Forms.CheckBox chCierre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown valueSmooth;
        private System.Windows.Forms.ComboBox comboMetodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown value_tresh;
        private System.Windows.Forms.CheckBox chEcualizar;
        private System.Windows.Forms.NumericUpDown value_s;
        private Emgu.CV.UI.ImageBox imgBox_videoHsv;
        private System.Windows.Forms.GroupBox group_izq;
        private Emgu.CV.UI.ImageBox imgBox_manoIzq;
        private Emgu.CV.UI.ImageBox imgBox_segIzq;
        private Emgu.CV.UI.ImageBox imgBox_bordeIzq;
        private Emgu.CV.UI.ImageBox imgBox_movIzq;
        private System.Windows.Forms.GroupBox group_der;
        private Emgu.CV.UI.ImageBox imgBox_manoDer;
        private Emgu.CV.UI.ImageBox imgBox_segDer;
        private Emgu.CV.UI.ImageBox imgBox_bordeDer;
        private Emgu.CV.UI.ImageBox imgBox_movDer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown value_area;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_maxArea;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_areaDer;
        private System.Windows.Forms.Label lbl_areaIzq;
        private System.Windows.Forms.CheckBox chBalance;
        private System.Windows.Forms.CheckBox chSaturar;
        private System.Windows.Forms.NumericUpDown value_areaMano;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
    }
}
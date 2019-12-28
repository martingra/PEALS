namespace Detector.Forms
{
    partial class SegmentacionSvm
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
            this.btnCaputarFondo = new System.Windows.Forms.Button();
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
            this.imgBox_movIzq = new Emgu.CV.UI.ImageBox();
            this.imgBox_manoIzq = new Emgu.CV.UI.ImageBox();
            this.imgBox_segIzq = new Emgu.CV.UI.ImageBox();
            this.imgBox_bordeIzq = new Emgu.CV.UI.ImageBox();
            this.group_der = new System.Windows.Forms.GroupBox();
            this.imgBox_movDer = new Emgu.CV.UI.ImageBox();
            this.imgBox_manoDer = new Emgu.CV.UI.ImageBox();
            this.imgBox_segDer = new Emgu.CV.UI.ImageBox();
            this.imgBox_bordeDer = new Emgu.CV.UI.ImageBox();
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
            this.btnAgregarEtiqueta = new System.Windows.Forms.Button();
            this.txtEtiqueta = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txt_precision = new System.Windows.Forms.TextBox();
            this.cb_useHistogram = new System.Windows.Forms.CheckBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.txt_k = new System.Windows.Forms.TextBox();
            this.btn_train = new System.Windows.Forms.Button();
            this.lbl_k = new System.Windows.Forms.Label();
            this.chSVM = new System.Windows.Forms.CheckBox();
            this.img_canny = new Emgu.CV.UI.ImageBox();
            this.txt_respuesta = new System.Windows.Forms.TextBox();
            this.chKNearest = new System.Windows.Forms.CheckBox();
            this.chClasificar = new System.Windows.Forms.CheckBox();
            this.chSoloDosClases = new System.Windows.Forms.CheckBox();
            this.txtSoloDosClases = new System.Windows.Forms.TextBox();
            this.imgBoxCara = new Emgu.CV.UI.ImageBox();
            this.imgBox_movCara = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_VideoBgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_erode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_dilate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueSmooth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_tresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_s)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_videoHsv)).BeginInit();
            this.group_izq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_movIzq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_manoIzq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_segIzq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_bordeIzq)).BeginInit();
            this.group_der.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_movDer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_manoDer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_segDer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_bordeDer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_area)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_areaMano)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_canny)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxCara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_movCara)).BeginInit();
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
            // btnCaputarFondo
            // 
            this.btnCaputarFondo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCaputarFondo.Location = new System.Drawing.Point(6, 456);
            this.btnCaputarFondo.Name = "btnCaputarFondo";
            this.btnCaputarFondo.Size = new System.Drawing.Size(246, 21);
            this.btnCaputarFondo.TabIndex = 12;
            this.btnCaputarFondo.Text = "Capturar Fondo";
            this.btnCaputarFondo.UseVisualStyleBackColor = true;
            this.btnCaputarFondo.Click += new System.EventHandler(this.btnCaputarFondo_Click);
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
            this.group_izq.Controls.Add(this.imgBox_movIzq);
            this.group_izq.Location = new System.Drawing.Point(258, 204);
            this.group_izq.Name = "group_izq";
            this.group_izq.Size = new System.Drawing.Size(191, 199);
            this.group_izq.TabIndex = 36;
            this.group_izq.TabStop = false;
            this.group_izq.Text = "Izquierda";
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
            // imgBox_manoIzq
            // 
            this.imgBox_manoIzq.Location = new System.Drawing.Point(904, 433);
            this.imgBox_manoIzq.Name = "imgBox_manoIzq";
            this.imgBox_manoIzq.Size = new System.Drawing.Size(60, 10);
            this.imgBox_manoIzq.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox_manoIzq.TabIndex = 10;
            this.imgBox_manoIzq.TabStop = false;
            // 
            // imgBox_segIzq
            // 
            this.imgBox_segIzq.Location = new System.Drawing.Point(838, 433);
            this.imgBox_segIzq.Name = "imgBox_segIzq";
            this.imgBox_segIzq.Size = new System.Drawing.Size(60, 10);
            this.imgBox_segIzq.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox_segIzq.TabIndex = 9;
            this.imgBox_segIzq.TabStop = false;
            // 
            // imgBox_bordeIzq
            // 
            this.imgBox_bordeIzq.Location = new System.Drawing.Point(722, 226);
            this.imgBox_bordeIzq.Name = "imgBox_bordeIzq";
            this.imgBox_bordeIzq.Size = new System.Drawing.Size(170, 170);
            this.imgBox_bordeIzq.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox_bordeIzq.TabIndex = 8;
            this.imgBox_bordeIzq.TabStop = false;
            // 
            // group_der
            // 
            this.group_der.Controls.Add(this.imgBox_movDer);
            this.group_der.Location = new System.Drawing.Point(258, 3);
            this.group_der.Name = "group_der";
            this.group_der.Size = new System.Drawing.Size(191, 195);
            this.group_der.TabIndex = 37;
            this.group_der.TabStop = false;
            this.group_der.Text = "Derecha";
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
            // imgBox_manoDer
            // 
            this.imgBox_manoDer.Location = new System.Drawing.Point(902, 414);
            this.imgBox_manoDer.Name = "imgBox_manoDer";
            this.imgBox_manoDer.Size = new System.Drawing.Size(60, 10);
            this.imgBox_manoDer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox_manoDer.TabIndex = 6;
            this.imgBox_manoDer.TabStop = false;
            // 
            // imgBox_segDer
            // 
            this.imgBox_segDer.Location = new System.Drawing.Point(838, 414);
            this.imgBox_segDer.Name = "imgBox_segDer";
            this.imgBox_segDer.Size = new System.Drawing.Size(60, 10);
            this.imgBox_segDer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox_segDer.TabIndex = 5;
            this.imgBox_segDer.TabStop = false;
            // 
            // imgBox_bordeDer
            // 
            this.imgBox_bordeDer.Location = new System.Drawing.Point(938, 226);
            this.imgBox_bordeDer.Name = "imgBox_bordeDer";
            this.imgBox_bordeDer.Size = new System.Drawing.Size(170, 170);
            this.imgBox_bordeDer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox_bordeDer.TabIndex = 4;
            this.imgBox_bordeDer.TabStop = false;
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
            // btnAgregarEtiqueta
            // 
            this.btnAgregarEtiqueta.Location = new System.Drawing.Point(679, 453);
            this.btnAgregarEtiqueta.Name = "btnAgregarEtiqueta";
            this.btnAgregarEtiqueta.Size = new System.Drawing.Size(153, 23);
            this.btnAgregarEtiqueta.TabIndex = 49;
            this.btnAgregarEtiqueta.Text = "Agregar etiqueta Derecha";
            this.btnAgregarEtiqueta.UseVisualStyleBackColor = true;
            this.btnAgregarEtiqueta.Click += new System.EventHandler(this.btnAgregarEtiqueta_Click);
            // 
            // txtEtiqueta
            // 
            this.txtEtiqueta.Location = new System.Drawing.Point(627, 456);
            this.txtEtiqueta.Name = "txtEtiqueta";
            this.txtEtiqueta.Size = new System.Drawing.Size(46, 20);
            this.txtEtiqueta.TabIndex = 50;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(409, 46);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(72, 23);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            this.cb_useHistogram.Location = new System.Drawing.Point(6, 49);
            this.cb_useHistogram.Name = "cb_useHistogram";
            this.cb_useHistogram.Size = new System.Drawing.Size(82, 17);
            this.cb_useHistogram.TabIndex = 15;
            this.cb_useHistogram.Text = " Histograma";
            this.cb_useHistogram.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(5, 72);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(312, 31);
            this.progressBar.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTest);
            this.groupBox1.Controls.Add(this.btnCargar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.txt_precision);
            this.groupBox1.Controls.Add(this.cb_useHistogram);
            this.groupBox1.Controls.Add(this.progressBar);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txt_path);
            this.groupBox1.Controls.Add(this.txt_k);
            this.groupBox1.Controls.Add(this.btn_train);
            this.groupBox1.Controls.Add(this.lbl_k);
            this.groupBox1.Location = new System.Drawing.Point(6, 492);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 119);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entranamiento";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(409, 17);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(72, 25);
            this.btnTest.TabIndex = 56;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(330, 46);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(72, 23);
            this.btnCargar.TabIndex = 56;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Path:";
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(41, 20);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(276, 20);
            this.txt_path.TabIndex = 10;
            this.txt_path.Text = "C:\\Peals\\frix\\peals\\Detection\\bin\\Debug\\Imagenes";
            // 
            // txt_k
            // 
            this.txt_k.Location = new System.Drawing.Point(342, 79);
            this.txt_k.Name = "txt_k";
            this.txt_k.Size = new System.Drawing.Size(63, 20);
            this.txt_k.TabIndex = 14;
            this.txt_k.Text = "5";
            // 
            // btn_train
            // 
            this.btn_train.Location = new System.Drawing.Point(330, 17);
            this.btn_train.Name = "btn_train";
            this.btn_train.Size = new System.Drawing.Size(72, 25);
            this.btn_train.TabIndex = 11;
            this.btn_train.Text = "Train";
            this.btn_train.UseVisualStyleBackColor = true;
            this.btn_train.Click += new System.EventHandler(this.btn_train_Click);
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
            // chSVM
            // 
            this.chSVM.AutoSize = true;
            this.chSVM.Checked = true;
            this.chSVM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chSVM.Location = new System.Drawing.Point(647, 511);
            this.chSVM.Name = "chSVM";
            this.chSVM.Size = new System.Drawing.Size(49, 17);
            this.chSVM.TabIndex = 18;
            this.chSVM.Text = "SVM";
            this.chSVM.UseVisualStyleBackColor = true;
            // 
            // img_canny
            // 
            this.img_canny.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_canny.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.img_canny.Location = new System.Drawing.Point(499, 482);
            this.img_canny.Name = "img_canny";
            this.img_canny.Size = new System.Drawing.Size(142, 129);
            this.img_canny.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_canny.TabIndex = 52;
            this.img_canny.TabStop = false;
            // 
            // txt_respuesta
            // 
            this.txt_respuesta.BackColor = System.Drawing.SystemColors.HotTrack;
            this.txt_respuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_respuesta.ForeColor = System.Drawing.SystemColors.Info;
            this.txt_respuesta.Location = new System.Drawing.Point(647, 581);
            this.txt_respuesta.Name = "txt_respuesta";
            this.txt_respuesta.Size = new System.Drawing.Size(315, 30);
            this.txt_respuesta.TabIndex = 53;
            this.txt_respuesta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chKNearest
            // 
            this.chKNearest.AutoSize = true;
            this.chKNearest.Location = new System.Drawing.Point(647, 534);
            this.chKNearest.Name = "chKNearest";
            this.chKNearest.Size = new System.Drawing.Size(73, 17);
            this.chKNearest.TabIndex = 54;
            this.chKNearest.Text = "K-Nearest";
            this.chKNearest.UseVisualStyleBackColor = true;
            // 
            // chClasificar
            // 
            this.chClasificar.AutoSize = true;
            this.chClasificar.Location = new System.Drawing.Point(647, 488);
            this.chClasificar.Name = "chClasificar";
            this.chClasificar.Size = new System.Drawing.Size(68, 17);
            this.chClasificar.TabIndex = 55;
            this.chClasificar.Text = "Clasificar";
            this.chClasificar.UseVisualStyleBackColor = true;
            // 
            // chSoloDosClases
            // 
            this.chSoloDosClases.AutoSize = true;
            this.chSoloDosClases.Checked = true;
            this.chSoloDosClases.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chSoloDosClases.Location = new System.Drawing.Point(743, 488);
            this.chSoloDosClases.Name = "chSoloDosClases";
            this.chSoloDosClases.Size = new System.Drawing.Size(89, 17);
            this.chSoloDosClases.TabIndex = 56;
            this.chSoloDosClases.Text = "Solo 2 clases";
            this.chSoloDosClases.UseVisualStyleBackColor = true;
            // 
            // txtSoloDosClases
            // 
            this.txtSoloDosClases.Location = new System.Drawing.Point(838, 485);
            this.txtSoloDosClases.Name = "txtSoloDosClases";
            this.txtSoloDosClases.Size = new System.Drawing.Size(24, 20);
            this.txtSoloDosClases.TabIndex = 57;
            this.txtSoloDosClases.Text = "a";
            // 
            // imgBoxCara
            // 
            this.imgBoxCara.Location = new System.Drawing.Point(838, 50);
            this.imgBoxCara.Name = "imgBoxCara";
            this.imgBoxCara.Size = new System.Drawing.Size(170, 170);
            this.imgBoxCara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBoxCara.TabIndex = 58;
            this.imgBoxCara.TabStop = false;
            // 
            // imgBox_movCara
            // 
            this.imgBox_movCara.Location = new System.Drawing.Point(455, 120);
            this.imgBox_movCara.Name = "imgBox_movCara";
            this.imgBox_movCara.Size = new System.Drawing.Size(170, 170);
            this.imgBox_movCara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox_movCara.TabIndex = 59;
            this.imgBox_movCara.TabStop = false;
            // 
            // Segmentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 616);
            this.Controls.Add(this.imgBox_movCara);
            this.Controls.Add(this.imgBoxCara);
            this.Controls.Add(this.imgBox_bordeIzq);
            this.Controls.Add(this.imgBox_bordeDer);
            this.Controls.Add(this.imgBox_manoIzq);
            this.Controls.Add(this.imgBox_manoDer);
            this.Controls.Add(this.imgBox_segIzq);
            this.Controls.Add(this.txtSoloDosClases);
            this.Controls.Add(this.imgBox_segDer);
            this.Controls.Add(this.chSoloDosClases);
            this.Controls.Add(this.chClasificar);
            this.Controls.Add(this.chKNearest);
            this.Controls.Add(this.chSVM);
            this.Controls.Add(this.txt_respuesta);
            this.Controls.Add(this.img_canny);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtEtiqueta);
            this.Controls.Add(this.btnAgregarEtiqueta);
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
            this.Controls.Add(this.btnCaputarFondo);
            this.Controls.Add(this.imgBox_VideoBgr);
            this.Controls.Add(this.valueSmooth);
            this.Name = "SegmentacionSvm";
            this.Text = "SegmentacionSvm";
            this.Load += new System.EventHandler(this.Segmentacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_VideoBgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_erode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_dilate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueSmooth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_tresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_s)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_videoHsv)).EndInit();
            this.group_izq.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_movIzq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_manoIzq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_segIzq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_bordeIzq)).EndInit();
            this.group_der.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_movDer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_manoDer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_segDer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_bordeDer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_area)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_areaMano)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_canny)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxCara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_movCara)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgBox_VideoBgr;
        private System.Windows.Forms.Button btnCaputarFondo;
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
        private System.Windows.Forms.Button btnAgregarEtiqueta;
        private System.Windows.Forms.TextBox txtEtiqueta;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txt_precision;
        private System.Windows.Forms.CheckBox cb_useHistogram;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.TextBox txt_k;
        private System.Windows.Forms.Button btn_train;
        private System.Windows.Forms.Label lbl_k;
        private Emgu.CV.UI.ImageBox img_canny;
        private System.Windows.Forms.TextBox txt_respuesta;
        private System.Windows.Forms.CheckBox chSVM;
        private System.Windows.Forms.CheckBox chKNearest;
        private System.Windows.Forms.CheckBox chClasificar;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.CheckBox chSoloDosClases;
        private System.Windows.Forms.TextBox txtSoloDosClases;
        private Emgu.CV.UI.ImageBox imgBoxCara;
        private Emgu.CV.UI.ImageBox imgBox_movCara;
    }
}
using System.Windows.Forms;
namespace Detector.Forms
{
    partial class Occlusion2
    {
        #region Required designer variables

        private System.ComponentModel.IContainer components = null;
        private Emgu.CV.UI.ImageBox img_original;
        private Emgu.CV.UI.ImageBox img_roi;
        private Emgu.CV.UI.ImageBox img_mask;
        private Emgu.CV.UI.ImageBox img_features;
        private Button btn_detectar;
        private Button btn_setRoi;
        private Label label1;
        private NumericUpDown nro_movimiento;
        private NumericUpDown nro_areaMax;
        private Label label3;
        private NumericUpDown nro_areaMin;
        private Label label4;
        private NumericUpDown nro_distancia;
        private Label label5;
        private NumericUpDown nro_votos;
        private Label label6;
        private Emgu.CV.UI.ImageBox imgBoxCuerpo;
        private CheckBox chbDetectarCuerpo;
        private CheckBox chbApertura;
        private CheckBox chbCierre;
        private NumericUpDown txtErosion;
        private Label label2;
        private NumericUpDown txtDilatacion;
        private Label label7;
        private Button btnAutodetectarCara;
        private NumericUpDown txtSmooth;
        private NumericUpDown txtMovimientoCuerpo;
        private Label label8;
        private Emgu.CV.UI.ImageBox img_harris;

        private CheckBox chbSmooth;
        private NumericUpDown txtMinArea;
        private Label label9;
        private NumericUpDown txtMaxArea;
        private Label label10;
        private TextBox txtArea;
        private TextBox txtRefrescarMog;
        private NumericUpDown txtRefrescarMog2;
        private Label label11;
        private Emgu.CV.UI.ImageBox imgBoxManoCuerpoSVM;

        #endregion

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
            this.img_original = new Emgu.CV.UI.ImageBox();
            this.img_roi = new Emgu.CV.UI.ImageBox();
            this.img_mask = new Emgu.CV.UI.ImageBox();
            this.img_features = new Emgu.CV.UI.ImageBox();
            this.btn_detectar = new System.Windows.Forms.Button();
            this.btn_setRoi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nro_movimiento = new System.Windows.Forms.NumericUpDown();
            this.nro_areaMax = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nro_areaMin = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nro_distancia = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nro_votos = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.imgBoxCuerpo = new Emgu.CV.UI.ImageBox();
            this.chbDetectarCuerpo = new System.Windows.Forms.CheckBox();
            this.chbApertura = new System.Windows.Forms.CheckBox();
            this.chbCierre = new System.Windows.Forms.CheckBox();
            this.txtErosion = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDilatacion = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAutodetectarCara = new System.Windows.Forms.Button();
            this.txtSmooth = new System.Windows.Forms.NumericUpDown();
            this.txtMovimientoCuerpo = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.img_harris = new Emgu.CV.UI.ImageBox();
            this.nro_cannyMin = new System.Windows.Forms.NumericUpDown();
            this.nro_cannyMax = new System.Windows.Forms.NumericUpDown();
            this.chbSmooth = new System.Windows.Forms.CheckBox();
            this.txtMinArea = new System.Windows.Forms.NumericUpDown();
            this.txtMaxArea = new System.Windows.Forms.NumericUpDown();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.txtRefrescarMog = new System.Windows.Forms.TextBox();
            this.txtRefrescarMog2 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.imgBoxManoCuerpoSVM = new Emgu.CV.UI.ImageBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnActualizarMuestras = new System.Windows.Forms.Button();
            this.txtCantidadMuestras = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.rrTest = new System.Windows.Forms.RadioButton();
            this.rbTrain = new System.Windows.Forms.RadioButton();
            this.img_canny = new Emgu.CV.UI.ImageBox();
            this.txtEtiqueta = new System.Windows.Forms.TextBox();
            this.txtSoloDosClases = new System.Windows.Forms.TextBox();
            this.btnAgregarEtiqueta = new System.Windows.Forms.Button();
            this.chSoloDosClases = new System.Windows.Forms.CheckBox();
            this.chClasificar = new System.Windows.Forms.CheckBox();
            this.chKNearest = new System.Windows.Forms.CheckBox();
            this.chSVM = new System.Windows.Forms.CheckBox();
            this.txt_respuesta = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txt_precision = new System.Windows.Forms.TextBox();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.txt_k = new System.Windows.Forms.TextBox();
            this.btn_train = new System.Windows.Forms.Button();
            this.lbl_k = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chDetectarZonaCara = new System.Windows.Forms.CheckBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.imgBoxSeparador = new Emgu.CV.UI.ImageBox();
            this.imgBoxPiel = new Emgu.CV.UI.ImageBox();
            this.imgBoxPielMog = new Emgu.CV.UI.ImageBox();
            this.imgBoxPrueba = new Emgu.CV.UI.ImageBox();
            this.imgBoxPrueba2 = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.img_original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_roi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_mask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_features)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nro_movimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nro_areaMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nro_areaMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nro_distancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nro_votos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtErosion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDilatacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSmooth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMovimientoCuerpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_harris)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nro_cannyMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nro_cannyMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefrescarMog2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxManoCuerpoSVM)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_canny)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxSeparador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxPiel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxPielMog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxPrueba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxPrueba2)).BeginInit();
            this.SuspendLayout();
            // 
            // img_original
            // 
            this.img_original.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.img_original.Location = new System.Drawing.Point(3, 6);
            this.img_original.Name = "img_original";
            this.img_original.Size = new System.Drawing.Size(538, 471);
            this.img_original.TabIndex = 3;
            this.img_original.TabStop = false;
            this.img_original.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgBox1_MouseDown);
            this.img_original.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgBox1_MouseMove);
            this.img_original.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgBox1_MouseUp);
            // 
            // img_roi
            // 
            this.img_roi.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.img_roi.Location = new System.Drawing.Point(547, 6);
            this.img_roi.Name = "img_roi";
            this.img_roi.Size = new System.Drawing.Size(151, 126);
            this.img_roi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_roi.TabIndex = 4;
            this.img_roi.TabStop = false;
            // 
            // img_mask
            // 
            this.img_mask.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.img_mask.Location = new System.Drawing.Point(548, 138);
            this.img_mask.Name = "img_mask";
            this.img_mask.Size = new System.Drawing.Size(151, 126);
            this.img_mask.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_mask.TabIndex = 5;
            this.img_mask.TabStop = false;
            // 
            // img_features
            // 
            this.img_features.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.img_features.Location = new System.Drawing.Point(704, 6);
            this.img_features.Name = "img_features";
            this.img_features.Size = new System.Drawing.Size(311, 228);
            this.img_features.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_features.TabIndex = 7;
            this.img_features.TabStop = false;
            // 
            // btn_detectar
            // 
            this.btn_detectar.Location = new System.Drawing.Point(90, 483);
            this.btn_detectar.Name = "btn_detectar";
            this.btn_detectar.Size = new System.Drawing.Size(75, 30);
            this.btn_detectar.TabIndex = 10;
            this.btn_detectar.Text = "Detectar";
            this.btn_detectar.UseVisualStyleBackColor = true;
            this.btn_detectar.Click += new System.EventHandler(this.btn_detectar_Click);
            // 
            // btn_setRoi
            // 
            this.btn_setRoi.Location = new System.Drawing.Point(8, 483);
            this.btn_setRoi.Name = "btn_setRoi";
            this.btn_setRoi.Size = new System.Drawing.Size(75, 30);
            this.btn_setRoi.TabIndex = 9;
            this.btn_setRoi.Text = "Guardar ROI";
            this.btn_setRoi.UseVisualStyleBackColor = true;
            this.btn_setRoi.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(705, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Movim";
            // 
            // nro_movimiento
            // 
            this.nro_movimiento.Location = new System.Drawing.Point(746, 239);
            this.nro_movimiento.Name = "nro_movimiento";
            this.nro_movimiento.Size = new System.Drawing.Size(49, 20);
            this.nro_movimiento.TabIndex = 12;
            this.nro_movimiento.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nro_areaMax
            // 
            this.nro_areaMax.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nro_areaMax.Location = new System.Drawing.Point(916, 270);
            this.nro_areaMax.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nro_areaMax.Name = "nro_areaMax";
            this.nro_areaMax.Size = new System.Drawing.Size(99, 20);
            this.nro_areaMax.TabIndex = 16;
            this.nro_areaMax.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(858, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Area Max";
            // 
            // nro_areaMin
            // 
            this.nro_areaMin.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nro_areaMin.Location = new System.Drawing.Point(760, 268);
            this.nro_areaMin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nro_areaMin.Name = "nro_areaMin";
            this.nro_areaMin.Size = new System.Drawing.Size(92, 20);
            this.nro_areaMin.TabIndex = 18;
            this.nro_areaMin.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(705, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Area Min";
            // 
            // nro_distancia
            // 
            this.nro_distancia.Location = new System.Drawing.Point(966, 239);
            this.nro_distancia.Name = "nro_distancia";
            this.nro_distancia.Size = new System.Drawing.Size(49, 20);
            this.nro_distancia.TabIndex = 20;
            this.nro_distancia.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(935, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Dist";
            // 
            // nro_votos
            // 
            this.nro_votos.Location = new System.Drawing.Point(861, 239);
            this.nro_votos.Name = "nro_votos";
            this.nro_votos.Size = new System.Drawing.Size(49, 20);
            this.nro_votos.TabIndex = 22;
            this.nro_votos.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(818, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Votos";
            // 
            // imgBoxCuerpo
            // 
            this.imgBoxCuerpo.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBoxCuerpo.Location = new System.Drawing.Point(545, 402);
            this.imgBoxCuerpo.Name = "imgBoxCuerpo";
            this.imgBoxCuerpo.Size = new System.Drawing.Size(307, 121);
            this.imgBoxCuerpo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBoxCuerpo.TabIndex = 23;
            this.imgBoxCuerpo.TabStop = false;
            // 
            // chbDetectarCuerpo
            // 
            this.chbDetectarCuerpo.AutoSize = true;
            this.chbDetectarCuerpo.Location = new System.Drawing.Point(175, 491);
            this.chbDetectarCuerpo.Name = "chbDetectarCuerpo";
            this.chbDetectarCuerpo.Size = new System.Drawing.Size(104, 17);
            this.chbDetectarCuerpo.TabIndex = 24;
            this.chbDetectarCuerpo.Text = "Detectar Cuerpo";
            this.chbDetectarCuerpo.UseVisualStyleBackColor = true;
            this.chbDetectarCuerpo.CheckedChanged += new System.EventHandler(this.chbDetectarCuerpo_CheckedChanged);
            // 
            // chbApertura
            // 
            this.chbApertura.AutoSize = true;
            this.chbApertura.Location = new System.Drawing.Point(175, 534);
            this.chbApertura.Name = "chbApertura";
            this.chbApertura.Size = new System.Drawing.Size(66, 17);
            this.chbApertura.TabIndex = 25;
            this.chbApertura.Text = "Apertura";
            this.chbApertura.UseVisualStyleBackColor = true;
            // 
            // chbCierre
            // 
            this.chbCierre.AutoSize = true;
            this.chbCierre.Location = new System.Drawing.Point(175, 565);
            this.chbCierre.Name = "chbCierre";
            this.chbCierre.Size = new System.Drawing.Size(53, 17);
            this.chbCierre.TabIndex = 26;
            this.chbCierre.Text = "Cierre";
            this.chbCierre.UseVisualStyleBackColor = true;
            // 
            // txtErosion
            // 
            this.txtErosion.Location = new System.Drawing.Point(272, 532);
            this.txtErosion.Name = "txtErosion";
            this.txtErosion.Size = new System.Drawing.Size(49, 20);
            this.txtErosion.TabIndex = 28;
            this.txtErosion.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 534);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Ero";
            // 
            // txtDilatacion
            // 
            this.txtDilatacion.Location = new System.Drawing.Point(270, 565);
            this.txtDilatacion.Name = "txtDilatacion";
            this.txtDilatacion.Size = new System.Drawing.Size(49, 20);
            this.txtDilatacion.TabIndex = 30;
            this.txtDilatacion.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(245, 567);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Dila";
            // 
            // btnAutodetectarCara
            // 
            this.btnAutodetectarCara.Location = new System.Drawing.Point(285, 483);
            this.btnAutodetectarCara.Name = "btnAutodetectarCara";
            this.btnAutodetectarCara.Size = new System.Drawing.Size(76, 40);
            this.btnAutodetectarCara.TabIndex = 31;
            this.btnAutodetectarCara.Text = "Autodetectar cara";
            this.btnAutodetectarCara.UseVisualStyleBackColor = true;
            this.btnAutodetectarCara.Click += new System.EventHandler(this.btnAutodetectarCara_Click);
            // 
            // txtSmooth
            // 
            this.txtSmooth.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.txtSmooth.Location = new System.Drawing.Point(116, 586);
            this.txtSmooth.Name = "txtSmooth";
            this.txtSmooth.Size = new System.Drawing.Size(49, 20);
            this.txtSmooth.TabIndex = 33;
            this.txtSmooth.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // txtMovimientoCuerpo
            // 
            this.txtMovimientoCuerpo.Location = new System.Drawing.Point(116, 560);
            this.txtMovimientoCuerpo.Name = "txtMovimientoCuerpo";
            this.txtMovimientoCuerpo.Size = new System.Drawing.Size(49, 20);
            this.txtMovimientoCuerpo.TabIndex = 36;
            this.txtMovimientoCuerpo.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(75, 562);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Movim";
            // 
            // img_harris
            // 
            this.img_harris.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.img_harris.Location = new System.Drawing.Point(549, 274);
            this.img_harris.Name = "img_harris";
            this.img_harris.Size = new System.Drawing.Size(151, 126);
            this.img_harris.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_harris.TabIndex = 6;
            this.img_harris.TabStop = false;
            // 
            // nro_cannyMin
            // 
            this.nro_cannyMin.Location = new System.Drawing.Point(757, 306);
            this.nro_cannyMin.Name = "nro_cannyMin";
            this.nro_cannyMin.Size = new System.Drawing.Size(49, 20);
            this.nro_cannyMin.TabIndex = 38;
            this.nro_cannyMin.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // nro_cannyMax
            // 
            this.nro_cannyMax.Location = new System.Drawing.Point(872, 306);
            this.nro_cannyMax.Name = "nro_cannyMax";
            this.nro_cannyMax.Size = new System.Drawing.Size(49, 20);
            this.nro_cannyMax.TabIndex = 40;
            this.nro_cannyMax.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // chbSmooth
            // 
            this.chbSmooth.AutoSize = true;
            this.chbSmooth.Checked = true;
            this.chbSmooth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSmooth.Location = new System.Drawing.Point(48, 587);
            this.chbSmooth.Name = "chbSmooth";
            this.chbSmooth.Size = new System.Drawing.Size(62, 17);
            this.chbSmooth.TabIndex = 34;
            this.chbSmooth.Text = "Smooth";
            this.chbSmooth.UseVisualStyleBackColor = true;
            // 
            // txtMinArea
            // 
            this.txtMinArea.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtMinArea.Location = new System.Drawing.Point(265, 617);
            this.txtMinArea.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtMinArea.Name = "txtMinArea";
            this.txtMinArea.Size = new System.Drawing.Size(54, 20);
            this.txtMinArea.TabIndex = 40;
            this.txtMinArea.Value = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            // 
            // txtMaxArea
            // 
            this.txtMaxArea.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtMaxArea.Location = new System.Drawing.Point(265, 591);
            this.txtMaxArea.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txtMaxArea.Name = "txtMaxArea";
            this.txtMaxArea.Size = new System.Drawing.Size(54, 20);
            this.txtMaxArea.TabIndex = 38;
            this.txtMaxArea.Value = new decimal(new int[] {
            70000,
            0,
            0,
            0});
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(801, 376);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(49, 20);
            this.txtArea.TabIndex = 41;
            // 
            // txtRefrescarMog
            // 
            this.txtRefrescarMog.Location = new System.Drawing.Point(749, 376);
            this.txtRefrescarMog.Name = "txtRefrescarMog";
            this.txtRefrescarMog.Size = new System.Drawing.Size(46, 20);
            this.txtRefrescarMog.TabIndex = 42;
            // 
            // txtRefrescarMog2
            // 
            this.txtRefrescarMog2.Location = new System.Drawing.Point(116, 534);
            this.txtRefrescarMog2.Name = "txtRefrescarMog2";
            this.txtRefrescarMog2.Size = new System.Drawing.Size(49, 20);
            this.txtRefrescarMog2.TabIndex = 43;
            this.txtRefrescarMog2.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 536);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "Refrescar MOG2";
            // 
            // imgBoxManoCuerpoSVM
            // 
            this.imgBoxManoCuerpoSVM.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBoxManoCuerpoSVM.Location = new System.Drawing.Point(1195, 318);
            this.imgBoxManoCuerpoSVM.Name = "imgBoxManoCuerpoSVM";
            this.imgBoxManoCuerpoSVM.Size = new System.Drawing.Size(166, 159);
            this.imgBoxManoCuerpoSVM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBoxManoCuerpoSVM.TabIndex = 45;
            this.imgBoxManoCuerpoSVM.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnActualizarMuestras);
            this.groupBox1.Controls.Add(this.txtCantidadMuestras);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.rrTest);
            this.groupBox1.Controls.Add(this.rbTrain);
            this.groupBox1.Controls.Add(this.img_canny);
            this.groupBox1.Controls.Add(this.txtEtiqueta);
            this.groupBox1.Controls.Add(this.txtSoloDosClases);
            this.groupBox1.Controls.Add(this.btnAgregarEtiqueta);
            this.groupBox1.Controls.Add(this.chSoloDosClases);
            this.groupBox1.Controls.Add(this.chClasificar);
            this.groupBox1.Controls.Add(this.chKNearest);
            this.groupBox1.Controls.Add(this.chSVM);
            this.groupBox1.Controls.Add(this.txt_respuesta);
            this.groupBox1.Controls.Add(this.btnTest);
            this.groupBox1.Controls.Add(this.btnCargar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.txt_precision);
            this.groupBox1.Controls.Add(this.txt_path);
            this.groupBox1.Controls.Add(this.txt_k);
            this.groupBox1.Controls.Add(this.btn_train);
            this.groupBox1.Controls.Add(this.lbl_k);
            this.groupBox1.Location = new System.Drawing.Point(336, 529);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(837, 119);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entranamiento";
            // 
            // btnActualizarMuestras
            // 
            this.btnActualizarMuestras.Location = new System.Drawing.Point(224, 73);
            this.btnActualizarMuestras.Name = "btnActualizarMuestras";
            this.btnActualizarMuestras.Size = new System.Drawing.Size(93, 23);
            this.btnActualizarMuestras.TabIndex = 69;
            this.btnActualizarMuestras.Text = "Actualizar";
            this.btnActualizarMuestras.UseVisualStyleBackColor = true;
            this.btnActualizarMuestras.Click += new System.EventHandler(this.btnActualizarMuestras_Click);
            // 
            // txtCantidadMuestras
            // 
            this.txtCantidadMuestras.Location = new System.Drawing.Point(175, 71);
            this.txtCantidadMuestras.Name = "txtCantidadMuestras";
            this.txtCantidadMuestras.Size = new System.Drawing.Size(43, 20);
            this.txtCantidadMuestras.TabIndex = 68;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(97, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 67;
            this.label14.Text = "Cant. Muestras";
            // 
            // rrTest
            // 
            this.rrTest.AutoSize = true;
            this.rrTest.Location = new System.Drawing.Point(41, 72);
            this.rrTest.Name = "rrTest";
            this.rrTest.Size = new System.Drawing.Size(46, 17);
            this.rrTest.TabIndex = 66;
            this.rrTest.Text = "Test";
            this.rrTest.UseVisualStyleBackColor = true;
            // 
            // rbTrain
            // 
            this.rbTrain.AutoSize = true;
            this.rbTrain.Checked = true;
            this.rbTrain.Location = new System.Drawing.Point(41, 48);
            this.rbTrain.Name = "rbTrain";
            this.rbTrain.Size = new System.Drawing.Size(49, 17);
            this.rbTrain.TabIndex = 65;
            this.rbTrain.TabStop = true;
            this.rbTrain.Text = "Train";
            this.rbTrain.UseVisualStyleBackColor = true;
            // 
            // img_canny
            // 
            this.img_canny.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_canny.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.img_canny.Location = new System.Drawing.Point(508, 13);
            this.img_canny.Name = "img_canny";
            this.img_canny.Size = new System.Drawing.Size(116, 99);
            this.img_canny.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_canny.TabIndex = 57;
            this.img_canny.TabStop = false;
            // 
            // txtEtiqueta
            // 
            this.txtEtiqueta.Location = new System.Drawing.Point(100, 46);
            this.txtEtiqueta.Name = "txtEtiqueta";
            this.txtEtiqueta.Size = new System.Drawing.Size(118, 20);
            this.txtEtiqueta.TabIndex = 56;
            // 
            // txtSoloDosClases
            // 
            this.txtSoloDosClases.Location = new System.Drawing.Point(806, 14);
            this.txtSoloDosClases.Name = "txtSoloDosClases";
            this.txtSoloDosClases.Size = new System.Drawing.Size(24, 20);
            this.txtSoloDosClases.TabIndex = 64;
            this.txtSoloDosClases.Text = "a";
            // 
            // btnAgregarEtiqueta
            // 
            this.btnAgregarEtiqueta.Location = new System.Drawing.Point(224, 46);
            this.btnAgregarEtiqueta.Name = "btnAgregarEtiqueta";
            this.btnAgregarEtiqueta.Size = new System.Drawing.Size(93, 23);
            this.btnAgregarEtiqueta.TabIndex = 55;
            this.btnAgregarEtiqueta.Text = "Agregar etiqueta";
            this.btnAgregarEtiqueta.UseVisualStyleBackColor = true;
            this.btnAgregarEtiqueta.Click += new System.EventHandler(this.btnAgregarEtiqueta_Click);
            // 
            // chSoloDosClases
            // 
            this.chSoloDosClases.AutoSize = true;
            this.chSoloDosClases.Location = new System.Drawing.Point(711, 17);
            this.chSoloDosClases.Name = "chSoloDosClases";
            this.chSoloDosClases.Size = new System.Drawing.Size(89, 17);
            this.chSoloDosClases.TabIndex = 63;
            this.chSoloDosClases.Text = "Solo 2 clases";
            this.chSoloDosClases.UseVisualStyleBackColor = true;
            // 
            // chClasificar
            // 
            this.chClasificar.AutoSize = true;
            this.chClasificar.Location = new System.Drawing.Point(637, 13);
            this.chClasificar.Name = "chClasificar";
            this.chClasificar.Size = new System.Drawing.Size(68, 17);
            this.chClasificar.TabIndex = 62;
            this.chClasificar.Text = "Clasificar";
            this.chClasificar.UseVisualStyleBackColor = true;
            // 
            // chKNearest
            // 
            this.chKNearest.AutoSize = true;
            this.chKNearest.Location = new System.Drawing.Point(637, 59);
            this.chKNearest.Name = "chKNearest";
            this.chKNearest.Size = new System.Drawing.Size(73, 17);
            this.chKNearest.TabIndex = 61;
            this.chKNearest.Text = "K-Nearest";
            this.chKNearest.UseVisualStyleBackColor = true;
            // 
            // chSVM
            // 
            this.chSVM.AutoSize = true;
            this.chSVM.Checked = true;
            this.chSVM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chSVM.Location = new System.Drawing.Point(637, 36);
            this.chSVM.Name = "chSVM";
            this.chSVM.Size = new System.Drawing.Size(49, 17);
            this.chSVM.TabIndex = 58;
            this.chSVM.Text = "SVM";
            this.chSVM.UseVisualStyleBackColor = true;
            // 
            // txt_respuesta
            // 
            this.txt_respuesta.BackColor = System.Drawing.SystemColors.HotTrack;
            this.txt_respuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_respuesta.ForeColor = System.Drawing.SystemColors.Info;
            this.txt_respuesta.Location = new System.Drawing.Point(637, 79);
            this.txt_respuesta.Name = "txt_respuesta";
            this.txt_respuesta.Size = new System.Drawing.Size(193, 30);
            this.txt_respuesta.TabIndex = 60;
            this.txt_respuesta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(41, 20);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(276, 20);
            this.txt_path.TabIndex = 10;
            this.txt_path.Text = "C:\\Peals\\imagenes";
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(222, 593);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "Max. A.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(222, 621);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 54;
            this.label13.Text = "Min. A.";
            // 
            // chDetectarZonaCara
            // 
            this.chDetectarZonaCara.AutoSize = true;
            this.chDetectarZonaCara.Location = new System.Drawing.Point(48, 617);
            this.chDetectarZonaCara.Name = "chDetectarZonaCara";
            this.chDetectarZonaCara.Size = new System.Drawing.Size(143, 17);
            this.chDetectarZonaCara.TabIndex = 55;
            this.chDetectarZonaCara.Text = "Detectar zona de la cara";
            this.chDetectarZonaCara.UseVisualStyleBackColor = true;
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.Red;
            this.btnIniciar.Location = new System.Drawing.Point(377, 483);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(76, 40);
            this.btnIniciar.TabIndex = 56;
            this.btnIniciar.Text = "INICIAR";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.OliveDrab;
            this.button1.Location = new System.Drawing.Point(459, 483);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 40);
            this.button1.TabIndex = 70;
            this.button1.Text = "RESET";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imgBoxSeparador
            // 
            this.imgBoxSeparador.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBoxSeparador.Location = new System.Drawing.Point(858, 331);
            this.imgBoxSeparador.Name = "imgBoxSeparador";
            this.imgBoxSeparador.Size = new System.Drawing.Size(307, 192);
            this.imgBoxSeparador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBoxSeparador.TabIndex = 71;
            this.imgBoxSeparador.TabStop = false;
            // 
            // imgBoxPiel
            // 
            this.imgBoxPiel.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBoxPiel.Location = new System.Drawing.Point(1030, 181);
            this.imgBoxPiel.Name = "imgBoxPiel";
            this.imgBoxPiel.Size = new System.Drawing.Size(307, 121);
            this.imgBoxPiel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBoxPiel.TabIndex = 72;
            this.imgBoxPiel.TabStop = false;
            // 
            // imgBoxPielMog
            // 
            this.imgBoxPielMog.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBoxPielMog.Location = new System.Drawing.Point(1030, 54);
            this.imgBoxPielMog.Name = "imgBoxPielMog";
            this.imgBoxPielMog.Size = new System.Drawing.Size(307, 121);
            this.imgBoxPielMog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBoxPielMog.TabIndex = 73;
            this.imgBoxPielMog.TabStop = false;
            // 
            // imgBoxPrueba
            // 
            this.imgBoxPrueba.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBoxPrueba.Location = new System.Drawing.Point(1195, 478);
            this.imgBoxPrueba.Name = "imgBoxPrueba";
            this.imgBoxPrueba.Size = new System.Drawing.Size(166, 159);
            this.imgBoxPrueba.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBoxPrueba.TabIndex = 74;
            this.imgBoxPrueba.TabStop = false;
            // 
            // imgBoxPrueba2
            // 
            this.imgBoxPrueba2.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBoxPrueba2.Location = new System.Drawing.Point(1367, 479);
            this.imgBoxPrueba2.Name = "imgBoxPrueba2";
            this.imgBoxPrueba2.Size = new System.Drawing.Size(166, 159);
            this.imgBoxPrueba2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBoxPrueba2.TabIndex = 75;
            this.imgBoxPrueba2.TabStop = false;
            // 
            // Occlusion2
            // 
            this.ClientSize = new System.Drawing.Size(1543, 654);
            this.Controls.Add(this.imgBoxPrueba2);
            this.Controls.Add(this.imgBoxPrueba);
            this.Controls.Add(this.imgBoxPielMog);
            this.Controls.Add(this.imgBoxPiel);
            this.Controls.Add(this.imgBoxSeparador);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.chDetectarZonaCara);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nro_cannyMax);
            this.Controls.Add(this.nro_cannyMin);
            this.Controls.Add(this.txtMovimientoCuerpo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSmooth);
            this.Controls.Add(this.btnAutodetectarCara);
            this.Controls.Add(this.txtDilatacion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtErosion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imgBoxManoCuerpoSVM);
            this.Controls.Add(this.chbCierre);
            this.Controls.Add(this.chbApertura);
            this.Controls.Add(this.chbDetectarCuerpo);
            this.Controls.Add(this.imgBoxCuerpo);
            this.Controls.Add(this.nro_votos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nro_distancia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nro_areaMin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nro_areaMax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nro_movimiento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_detectar);
            this.Controls.Add(this.btn_setRoi);
            this.Controls.Add(this.img_features);
            this.Controls.Add(this.img_harris);
            this.Controls.Add(this.img_mask);
            this.Controls.Add(this.img_roi);
            this.Controls.Add(this.img_original);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRefrescarMog2);
            this.Controls.Add(this.txtRefrescarMog);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.txtMinArea);
            this.Controls.Add(this.txtMaxArea);
            this.Controls.Add(this.chbSmooth);
            this.Name = "Occlusion2";
            this.Load += new System.EventHandler(this.Occlusion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.img_original)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_roi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_mask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_features)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nro_movimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nro_areaMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nro_areaMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nro_distancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nro_votos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtErosion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDilatacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSmooth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMovimientoCuerpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_harris)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nro_cannyMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nro_cannyMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefrescarMog2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxManoCuerpoSVM)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_canny)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxSeparador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxPiel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxPielMog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxPrueba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxPrueba2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown nro_cannyMin;
        private NumericUpDown nro_cannyMax;
        private GroupBox groupBox1;
        private Button btnTest;
        private Button btnCargar;
        private Button btnGuardar;
        private TextBox txt_precision;
        private TextBox txt_path;
        private TextBox txt_k;
        private Button btn_train;
        private Label lbl_k;
        private TextBox txtSoloDosClases;
        private CheckBox chSoloDosClases;
        private CheckBox chClasificar;
        private CheckBox chKNearest;
        private CheckBox chSVM;
        private TextBox txt_respuesta;
        private Label label12;
        private Label label13;
        private Button btnAgregarEtiqueta;
        private CheckBox chDetectarZonaCara;
        private Button btnIniciar;
        private TextBox txtEtiqueta;
        private Emgu.CV.UI.ImageBox img_canny;
        private RadioButton rrTest;
        private RadioButton rbTrain;
        private Button btnActualizarMuestras;
        private TextBox txtCantidadMuestras;
        private Label label14;
        private Button button1;
        private Emgu.CV.UI.ImageBox imgBoxSeparador;
        private Emgu.CV.UI.ImageBox imgBoxPiel;
        private Emgu.CV.UI.ImageBox imgBoxPielMog;
        private Emgu.CV.UI.ImageBox imgBoxPrueba;
        private Emgu.CV.UI.ImageBox imgBoxPrueba2;
    }
}
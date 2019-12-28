using System.Windows.Forms;
namespace Detector.Forms
{
    partial class Occlusion3
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
            this.img_mul = new Emgu.CV.UI.ImageBox();
            this.img_canny = new Emgu.CV.UI.ImageBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.img_mul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_canny)).BeginInit();
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
            this.img_features.Location = new System.Drawing.Point(705, 152);
            this.img_features.Name = "img_features";
            this.img_features.Size = new System.Drawing.Size(310, 244);
            this.img_features.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_features.TabIndex = 7;
            this.img_features.TabStop = false;
            // 
            // btn_detectar
            // 
            this.btn_detectar.Location = new System.Drawing.Point(144, 483);
            this.btn_detectar.Name = "btn_detectar";
            this.btn_detectar.Size = new System.Drawing.Size(130, 30);
            this.btn_detectar.TabIndex = 10;
            this.btn_detectar.Text = "Detectar";
            this.btn_detectar.UseVisualStyleBackColor = true;
            this.btn_detectar.Click += new System.EventHandler(this.btn_detectar_Click);
            // 
            // btn_setRoi
            // 
            this.btn_setRoi.Location = new System.Drawing.Point(8, 483);
            this.btn_setRoi.Name = "btn_setRoi";
            this.btn_setRoi.Size = new System.Drawing.Size(130, 30);
            this.btn_setRoi.TabIndex = 9;
            this.btn_setRoi.Text = "Guardar ROI";
            this.btn_setRoi.UseVisualStyleBackColor = true;
            this.btn_setRoi.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(705, 531);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Movim";
            // 
            // nro_movimiento
            // 
            this.nro_movimiento.Location = new System.Drawing.Point(746, 529);
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
            this.nro_areaMax.Location = new System.Drawing.Point(916, 560);
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
            this.label3.Location = new System.Drawing.Point(858, 562);
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
            this.nro_areaMin.Location = new System.Drawing.Point(760, 558);
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
            this.label4.Location = new System.Drawing.Point(705, 560);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Area Min";
            // 
            // nro_distancia
            // 
            this.nro_distancia.Location = new System.Drawing.Point(966, 529);
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
            this.label5.Location = new System.Drawing.Point(935, 531);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Dist";
            // 
            // nro_votos
            // 
            this.nro_votos.Location = new System.Drawing.Point(861, 529);
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
            this.label6.Location = new System.Drawing.Point(818, 531);
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
            this.chbDetectarCuerpo.Location = new System.Drawing.Point(292, 491);
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
            this.txtErosion.Location = new System.Drawing.Point(276, 534);
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
            this.label2.Location = new System.Drawing.Point(251, 536);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Ero";
            // 
            // txtDilatacion
            // 
            this.txtDilatacion.Location = new System.Drawing.Point(276, 564);
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
            this.label7.Location = new System.Drawing.Point(251, 566);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Dila";
            // 
            // btnAutodetectarCara
            // 
            this.btnAutodetectarCara.Location = new System.Drawing.Point(411, 483);
            this.btnAutodetectarCara.Name = "btnAutodetectarCara";
            this.btnAutodetectarCara.Size = new System.Drawing.Size(130, 30);
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
            this.txtSmooth.Location = new System.Drawing.Point(411, 559);
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
            this.img_harris.Location = new System.Drawing.Point(547, 272);
            this.img_harris.Name = "img_harris";
            this.img_harris.Size = new System.Drawing.Size(151, 126);
            this.img_harris.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_harris.TabIndex = 6;
            this.img_harris.TabStop = false;
            // 
            // nro_cannyMin
            // 
            this.nro_cannyMin.Location = new System.Drawing.Point(474, 534);
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
            this.nro_cannyMax.Location = new System.Drawing.Point(529, 534);
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
            this.chbSmooth.Location = new System.Drawing.Point(343, 560);
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
            this.txtMinArea.Location = new System.Drawing.Point(584, 534);
            this.txtMinArea.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtMinArea.Name = "txtMinArea";
            this.txtMinArea.Size = new System.Drawing.Size(65, 20);
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
            this.txtMaxArea.Location = new System.Drawing.Point(595, 564);
            this.txtMaxArea.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtMaxArea.Name = "txtMaxArea";
            this.txtMaxArea.Size = new System.Drawing.Size(54, 20);
            this.txtMaxArea.TabIndex = 38;
            this.txtMaxArea.Value = new decimal(new int[] {
            40000,
            0,
            0,
            0});
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(529, 560);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(49, 20);
            this.txtArea.TabIndex = 41;
            // 
            // txtRefrescarMog
            // 
            this.txtRefrescarMog.Location = new System.Drawing.Point(477, 560);
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
            this.imgBoxManoCuerpoSVM.Location = new System.Drawing.Point(861, 402);
            this.imgBoxManoCuerpoSVM.Name = "imgBoxManoCuerpoSVM";
            this.imgBoxManoCuerpoSVM.Size = new System.Drawing.Size(154, 121);
            this.imgBoxManoCuerpoSVM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBoxManoCuerpoSVM.TabIndex = 45;
            this.imgBoxManoCuerpoSVM.TabStop = false;
            // 
            // img_mul
            // 
            this.img_mul.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.img_mul.Location = new System.Drawing.Point(704, 6);
            this.img_mul.Name = "img_mul";
            this.img_mul.Size = new System.Drawing.Size(162, 140);
            this.img_mul.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_mul.TabIndex = 46;
            this.img_mul.TabStop = false;
            // 
            // img_canny
            // 
            this.img_canny.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.img_canny.Location = new System.Drawing.Point(872, 6);
            this.img_canny.Name = "img_canny";
            this.img_canny.Size = new System.Drawing.Size(143, 140);
            this.img_canny.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_canny.TabIndex = 47;
            this.img_canny.TabStop = false;
            // 
            // Occlusion3
            // 
            this.ClientSize = new System.Drawing.Size(1026, 587);
            this.Controls.Add(this.img_canny);
            this.Controls.Add(this.img_mul);
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
            this.Controls.Add(this.imgBoxManoCuerpoSVM);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRefrescarMog2);
            this.Controls.Add(this.txtRefrescarMog);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.txtMinArea);
            this.Controls.Add(this.txtMaxArea);
            this.Controls.Add(this.chbSmooth);
            this.Name = "Occlusion3";
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
            ((System.ComponentModel.ISupportInitialize)(this.img_mul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_canny)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown nro_cannyMin;
        private NumericUpDown nro_cannyMax;
        private Emgu.CV.UI.ImageBox img_mul;
        private Emgu.CV.UI.ImageBox img_canny;
    }
}
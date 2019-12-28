namespace Detector
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.imageBoxROI = new Emgu.CV.UI.ImageBox();
            this.imageBoxDetect = new Emgu.CV.UI.ImageBox();
            this.gb_original = new System.Windows.Forms.GroupBox();
            this.cbox_usarROI = new System.Windows.Forms.CheckBox();
            this.txt_senia = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.txt_etiqueta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_drawRoi = new System.Windows.Forms.CheckBox();
            this.cb_connectPoint = new System.Windows.Forms.CheckBox();
            this.cb_margen = new System.Windows.Forms.CheckBox();
            this.cb_center = new System.Windows.Forms.CheckBox();
            this.cb_defects = new System.Windows.Forms.CheckBox();
            this.cb_convex = new System.Windows.Forms.CheckBox();
            this.gb_opciones = new System.Windows.Forms.GroupBox();
            this.cb_invert = new System.Windows.Forms.CheckBox();
            this.cb_background = new System.Windows.Forms.CheckBox();
            this.value_dilate = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.value_erode = new System.Windows.Forms.NumericUpDown();
            this.file_dialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.camaraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarImágenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detecciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habilitarXmlsCascadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habilitarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kNearestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_sKernel_x = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbox_YCbCr = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Y_max = new System.Windows.Forms.NumericUpDown();
            this.Y_min = new System.Windows.Forms.NumericUpDown();
            this.Cb_max = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.Cb_min = new System.Windows.Forms.NumericUpDown();
            this.Cr_max = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.Cr_min = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gb_salida = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbox_rgb = new System.Windows.Forms.CheckBox();
            this.lbl_b = new System.Windows.Forms.Label();
            this.R_max = new System.Windows.Forms.NumericUpDown();
            this.R_min = new System.Windows.Forms.NumericUpDown();
            this.G_max = new System.Windows.Forms.NumericUpDown();
            this.lbl_g = new System.Windows.Forms.Label();
            this.G_min = new System.Windows.Forms.NumericUpDown();
            this.B_max = new System.Windows.Forms.NumericUpDown();
            this.lbl_r = new System.Windows.Forms.Label();
            this.B_min = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbox_hsv = new System.Windows.Forms.CheckBox();
            this.lbl_v = new System.Windows.Forms.Label();
            this.H_max = new System.Windows.Forms.NumericUpDown();
            this.H_min = new System.Windows.Forms.NumericUpDown();
            this.S_max = new System.Windows.Forms.NumericUpDown();
            this.lbl_s = new System.Windows.Forms.Label();
            this.S_min = new System.Windows.Forms.NumericUpDown();
            this.V_max = new System.Windows.Forms.NumericUpDown();
            this.llb_h = new System.Windows.Forms.Label();
            this.V_min = new System.Windows.Forms.NumericUpDown();
            this.imageBoxYCbCr = new Emgu.CV.UI.ImageBox();
            this.imageBoxHSV = new Emgu.CV.UI.ImageBox();
            this.imageBoxRGB = new Emgu.CV.UI.ImageBox();
            this.btn_quitarCascade = new System.Windows.Forms.Button();
            this.btn_agregarCascade = new System.Windows.Forms.Button();
            this.cb_activarROI = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cb_cascade = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lbl_cascade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbox_cascade = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.color_cascade = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mov_left = new System.Windows.Forms.PictureBox();
            this.mov_right = new System.Windows.Forms.PictureBox();
            this.mov_down = new System.Windows.Forms.PictureBox();
            this.mov_up = new System.Windows.Forms.PictureBox();
            this.lbl_direccion = new System.Windows.Forms.Label();
            this.imageBox_OpticalFlowBorder = new Emgu.CV.UI.ImageBox();
            this.imageBox_OpticalFlowMap = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxROI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxDetect)).BeginInit();
            this.gb_original.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gb_opciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.value_dilate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_erode)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Y_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cb_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cb_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cr_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cr_min)).BeginInit();
            this.gb_salida.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.R_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.G_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.G_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_min)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.H_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.H_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxYCbCr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxHSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxRGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mov_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mov_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mov_down)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mov_up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_OpticalFlowBorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_OpticalFlowMap)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.imageBoxFrameGrabber, "imageBoxFrameGrabber");
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // imageBoxROI
            // 
            this.imageBoxROI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.imageBoxROI, "imageBoxROI");
            this.imageBoxROI.Name = "imageBoxROI";
            this.imageBoxROI.TabStop = false;
            // 
            // imageBoxDetect
            // 
            this.imageBoxDetect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.imageBoxDetect, "imageBoxDetect");
            this.imageBoxDetect.Name = "imageBoxDetect";
            this.imageBoxDetect.TabStop = false;
            // 
            // gb_original
            // 
            this.gb_original.Controls.Add(this.cbox_usarROI);
            this.gb_original.Controls.Add(this.txt_senia);
            this.gb_original.Controls.Add(this.imageBoxFrameGrabber);
            resources.ApplyResources(this.gb_original, "gb_original");
            this.gb_original.Name = "gb_original";
            this.gb_original.TabStop = false;
            // 
            // cbox_usarROI
            // 
            resources.ApplyResources(this.cbox_usarROI, "cbox_usarROI");
            this.cbox_usarROI.Name = "cbox_usarROI";
            this.cbox_usarROI.UseVisualStyleBackColor = true;
            this.cbox_usarROI.CheckedChanged += new System.EventHandler(this.cbox_usarROI_CheckedChanged);
            // 
            // txt_senia
            // 
            this.txt_senia.BackColor = System.Drawing.SystemColors.InactiveCaption;
            resources.ApplyResources(this.txt_senia, "txt_senia");
            this.txt_senia.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txt_senia.Name = "txt_senia";
            this.txt_senia.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_agregar);
            this.groupBox1.Controls.Add(this.txt_etiqueta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.imageBoxROI);
            this.groupBox1.Controls.Add(this.imageBoxDetect);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btn_agregar
            // 
            resources.ApplyResources(this.btn_agregar, "btn_agregar");
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.UseVisualStyleBackColor = true;
            // 
            // txt_etiqueta
            // 
            resources.ApplyResources(this.txt_etiqueta, "txt_etiqueta");
            this.txt_etiqueta.Name = "txt_etiqueta";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cb_drawRoi
            // 
            resources.ApplyResources(this.cb_drawRoi, "cb_drawRoi");
            this.cb_drawRoi.Name = "cb_drawRoi";
            this.cb_drawRoi.UseVisualStyleBackColor = true;
            // 
            // cb_connectPoint
            // 
            resources.ApplyResources(this.cb_connectPoint, "cb_connectPoint");
            this.cb_connectPoint.Name = "cb_connectPoint";
            this.cb_connectPoint.UseVisualStyleBackColor = true;
            // 
            // cb_margen
            // 
            resources.ApplyResources(this.cb_margen, "cb_margen");
            this.cb_margen.Name = "cb_margen";
            this.cb_margen.UseVisualStyleBackColor = true;
            // 
            // cb_center
            // 
            resources.ApplyResources(this.cb_center, "cb_center");
            this.cb_center.Name = "cb_center";
            this.cb_center.UseVisualStyleBackColor = true;
            // 
            // cb_defects
            // 
            resources.ApplyResources(this.cb_defects, "cb_defects");
            this.cb_defects.Name = "cb_defects";
            this.cb_defects.UseVisualStyleBackColor = true;
            // 
            // cb_convex
            // 
            resources.ApplyResources(this.cb_convex, "cb_convex");
            this.cb_convex.Name = "cb_convex";
            this.cb_convex.UseVisualStyleBackColor = true;
            // 
            // gb_opciones
            // 
            this.gb_opciones.Controls.Add(this.cb_drawRoi);
            this.gb_opciones.Controls.Add(this.cb_invert);
            this.gb_opciones.Controls.Add(this.cb_background);
            this.gb_opciones.Controls.Add(this.cb_connectPoint);
            this.gb_opciones.Controls.Add(this.cb_convex);
            this.gb_opciones.Controls.Add(this.cb_defects);
            this.gb_opciones.Controls.Add(this.cb_margen);
            this.gb_opciones.Controls.Add(this.cb_center);
            resources.ApplyResources(this.gb_opciones, "gb_opciones");
            this.gb_opciones.Name = "gb_opciones";
            this.gb_opciones.TabStop = false;
            // 
            // cb_invert
            // 
            resources.ApplyResources(this.cb_invert, "cb_invert");
            this.cb_invert.Name = "cb_invert";
            this.cb_invert.UseVisualStyleBackColor = true;
            // 
            // cb_background
            // 
            resources.ApplyResources(this.cb_background, "cb_background");
            this.cb_background.Name = "cb_background";
            this.cb_background.UseVisualStyleBackColor = true;
            // 
            // value_dilate
            // 
            resources.ApplyResources(this.value_dilate, "value_dilate");
            this.value_dilate.Name = "value_dilate";
            this.value_dilate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // value_erode
            // 
            resources.ApplyResources(this.value_erode, "value_erode");
            this.value_erode.Name = "value_erode";
            this.value_erode.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // file_dialog
            // 
            this.file_dialog.FileName = "file_dialog";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.camaraToolStripMenuItem,
            this.detecciónToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            resources.ApplyResources(this.archivoToolStripMenuItem, "archivoToolStripMenuItem");
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            resources.ApplyResources(this.salirToolStripMenuItem, "salirToolStripMenuItem");
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // camaraToolStripMenuItem
            // 
            this.camaraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.cargarImágenToolStripMenuItem});
            this.camaraToolStripMenuItem.Name = "camaraToolStripMenuItem";
            resources.ApplyResources(this.camaraToolStripMenuItem, "camaraToolStripMenuItem");
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            resources.ApplyResources(this.playToolStripMenuItem, "playToolStripMenuItem");
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            resources.ApplyResources(this.stopToolStripMenuItem, "stopToolStripMenuItem");
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // cargarImágenToolStripMenuItem
            // 
            this.cargarImágenToolStripMenuItem.Name = "cargarImágenToolStripMenuItem";
            resources.ApplyResources(this.cargarImágenToolStripMenuItem, "cargarImágenToolStripMenuItem");
            this.cargarImágenToolStripMenuItem.Click += new System.EventHandler(this.cargarImágenToolStripMenuItem_Click);
            // 
            // detecciónToolStripMenuItem
            // 
            this.detecciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.habilitarXmlsCascadesToolStripMenuItem,
            this.habilitarToolStripMenuItem,
            this.kNearestToolStripMenuItem});
            this.detecciónToolStripMenuItem.Name = "detecciónToolStripMenuItem";
            resources.ApplyResources(this.detecciónToolStripMenuItem, "detecciónToolStripMenuItem");
            // 
            // habilitarXmlsCascadesToolStripMenuItem
            // 
            this.habilitarXmlsCascadesToolStripMenuItem.Name = "habilitarXmlsCascadesToolStripMenuItem";
            resources.ApplyResources(this.habilitarXmlsCascadesToolStripMenuItem, "habilitarXmlsCascadesToolStripMenuItem");
            // 
            // habilitarToolStripMenuItem
            // 
            this.habilitarToolStripMenuItem.Name = "habilitarToolStripMenuItem";
            resources.ApplyResources(this.habilitarToolStripMenuItem, "habilitarToolStripMenuItem");
            // 
            // kNearestToolStripMenuItem
            // 
            this.kNearestToolStripMenuItem.Name = "kNearestToolStripMenuItem";
            resources.ApplyResources(this.kNearestToolStripMenuItem, "kNearestToolStripMenuItem");
            this.kNearestToolStripMenuItem.Click += new System.EventHandler(this.kNearestToolStripMenuItem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txt_sKernel_x);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.value_erode);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.value_dilate);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txt_sKernel_x
            // 
            resources.ApplyResources(this.txt_sKernel_x, "txt_sKernel_x");
            this.txt_sKernel_x.Name = "txt_sKernel_x";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbox_YCbCr);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.Y_max);
            this.panel2.Controls.Add(this.Y_min);
            this.panel2.Controls.Add(this.Cb_max);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.Cb_min);
            this.panel2.Controls.Add(this.Cr_max);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.Cr_min);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // cbox_YCbCr
            // 
            resources.ApplyResources(this.cbox_YCbCr, "cbox_YCbCr");
            this.cbox_YCbCr.Name = "cbox_YCbCr";
            this.cbox_YCbCr.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // Y_max
            // 
            resources.ApplyResources(this.Y_max, "Y_max");
            this.Y_max.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.Y_max.Name = "Y_max";
            this.Y_max.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // Y_min
            // 
            resources.ApplyResources(this.Y_min, "Y_min");
            this.Y_min.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.Y_min.Name = "Y_min";
            // 
            // Cb_max
            // 
            resources.ApplyResources(this.Cb_max, "Cb_max");
            this.Cb_max.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.Cb_max.Name = "Cb_max";
            this.Cb_max.Value = new decimal(new int[] {
            185,
            0,
            0,
            0});
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // Cb_min
            // 
            resources.ApplyResources(this.Cb_min, "Cb_min");
            this.Cb_min.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.Cb_min.Name = "Cb_min";
            this.Cb_min.Value = new decimal(new int[] {
            131,
            0,
            0,
            0});
            // 
            // Cr_max
            // 
            resources.ApplyResources(this.Cr_max, "Cr_max");
            this.Cr_max.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.Cr_max.Name = "Cr_max";
            this.Cr_max.Value = new decimal(new int[] {
            135,
            0,
            0,
            0});
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // Cr_min
            // 
            resources.ApplyResources(this.Cr_min, "Cr_min");
            this.Cr_min.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.Cr_min.Name = "Cr_min";
            this.Cr_min.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // textBox5
            // 
            resources.ApplyResources(this.textBox5, "textBox5");
            this.textBox5.Name = "textBox5";
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // gb_salida
            // 
            this.gb_salida.Controls.Add(this.panel3);
            this.gb_salida.Controls.Add(this.panel1);
            this.gb_salida.Controls.Add(this.imageBoxYCbCr);
            this.gb_salida.Controls.Add(this.imageBoxHSV);
            this.gb_salida.Controls.Add(this.imageBoxRGB);
            this.gb_salida.Controls.Add(this.panel2);
            resources.ApplyResources(this.gb_salida, "gb_salida");
            this.gb_salida.Name = "gb_salida";
            this.gb_salida.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbox_rgb);
            this.panel3.Controls.Add(this.lbl_b);
            this.panel3.Controls.Add(this.R_max);
            this.panel3.Controls.Add(this.R_min);
            this.panel3.Controls.Add(this.G_max);
            this.panel3.Controls.Add(this.lbl_g);
            this.panel3.Controls.Add(this.G_min);
            this.panel3.Controls.Add(this.B_max);
            this.panel3.Controls.Add(this.lbl_r);
            this.panel3.Controls.Add(this.B_min);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // cbox_rgb
            // 
            resources.ApplyResources(this.cbox_rgb, "cbox_rgb");
            this.cbox_rgb.Name = "cbox_rgb";
            this.cbox_rgb.UseVisualStyleBackColor = true;
            // 
            // lbl_b
            // 
            resources.ApplyResources(this.lbl_b, "lbl_b");
            this.lbl_b.Name = "lbl_b";
            // 
            // R_max
            // 
            resources.ApplyResources(this.R_max, "R_max");
            this.R_max.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.R_max.Name = "R_max";
            this.R_max.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // R_min
            // 
            resources.ApplyResources(this.R_min, "R_min");
            this.R_min.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.R_min.Name = "R_min";
            // 
            // G_max
            // 
            resources.ApplyResources(this.G_max, "G_max");
            this.G_max.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.G_max.Name = "G_max";
            this.G_max.Value = new decimal(new int[] {
            93,
            0,
            0,
            0});
            // 
            // lbl_g
            // 
            resources.ApplyResources(this.lbl_g, "lbl_g");
            this.lbl_g.Name = "lbl_g";
            // 
            // G_min
            // 
            resources.ApplyResources(this.G_min, "G_min");
            this.G_min.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.G_min.Name = "G_min";
            this.G_min.Value = new decimal(new int[] {
            71,
            0,
            0,
            0});
            // 
            // B_max
            // 
            resources.ApplyResources(this.B_max, "B_max");
            this.B_max.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.B_max.Name = "B_max";
            this.B_max.Value = new decimal(new int[] {
            119,
            0,
            0,
            0});
            // 
            // lbl_r
            // 
            resources.ApplyResources(this.lbl_r, "lbl_r");
            this.lbl_r.Name = "lbl_r";
            // 
            // B_min
            // 
            resources.ApplyResources(this.B_min, "B_min");
            this.B_min.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.B_min.Name = "B_min";
            this.B_min.Value = new decimal(new int[] {
            92,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbox_hsv);
            this.panel1.Controls.Add(this.lbl_v);
            this.panel1.Controls.Add(this.H_max);
            this.panel1.Controls.Add(this.H_min);
            this.panel1.Controls.Add(this.S_max);
            this.panel1.Controls.Add(this.lbl_s);
            this.panel1.Controls.Add(this.S_min);
            this.panel1.Controls.Add(this.V_max);
            this.panel1.Controls.Add(this.llb_h);
            this.panel1.Controls.Add(this.V_min);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // cbox_hsv
            // 
            resources.ApplyResources(this.cbox_hsv, "cbox_hsv");
            this.cbox_hsv.Name = "cbox_hsv";
            this.cbox_hsv.UseVisualStyleBackColor = true;
            // 
            // lbl_v
            // 
            resources.ApplyResources(this.lbl_v, "lbl_v");
            this.lbl_v.Name = "lbl_v";
            // 
            // H_max
            // 
            resources.ApplyResources(this.H_max, "H_max");
            this.H_max.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.H_max.Name = "H_max";
            this.H_max.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // H_min
            // 
            resources.ApplyResources(this.H_min, "H_min");
            this.H_min.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.H_min.Name = "H_min";
            // 
            // S_max
            // 
            resources.ApplyResources(this.S_max, "S_max");
            this.S_max.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.S_max.Name = "S_max";
            this.S_max.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // lbl_s
            // 
            resources.ApplyResources(this.lbl_s, "lbl_s");
            this.lbl_s.Name = "lbl_s";
            // 
            // S_min
            // 
            resources.ApplyResources(this.S_min, "S_min");
            this.S_min.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.S_min.Name = "S_min";
            this.S_min.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // V_max
            // 
            resources.ApplyResources(this.V_max, "V_max");
            this.V_max.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.V_max.Name = "V_max";
            this.V_max.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // llb_h
            // 
            resources.ApplyResources(this.llb_h, "llb_h");
            this.llb_h.Name = "llb_h";
            // 
            // V_min
            // 
            resources.ApplyResources(this.V_min, "V_min");
            this.V_min.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.V_min.Name = "V_min";
            // 
            // imageBoxYCbCr
            // 
            this.imageBoxYCbCr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.imageBoxYCbCr, "imageBoxYCbCr");
            this.imageBoxYCbCr.Name = "imageBoxYCbCr";
            this.imageBoxYCbCr.TabStop = false;
            // 
            // imageBoxHSV
            // 
            this.imageBoxHSV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.imageBoxHSV, "imageBoxHSV");
            this.imageBoxHSV.Name = "imageBoxHSV";
            this.imageBoxHSV.TabStop = false;
            // 
            // imageBoxRGB
            // 
            this.imageBoxRGB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.imageBoxRGB, "imageBoxRGB");
            this.imageBoxRGB.Name = "imageBoxRGB";
            this.imageBoxRGB.TabStop = false;
            // 
            // btn_quitarCascade
            // 
            this.btn_quitarCascade.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btn_quitarCascade, "btn_quitarCascade");
            this.btn_quitarCascade.ForeColor = System.Drawing.Color.Transparent;
            this.btn_quitarCascade.Name = "btn_quitarCascade";
            this.btn_quitarCascade.UseVisualStyleBackColor = false;
            // 
            // btn_agregarCascade
            // 
            this.btn_agregarCascade.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btn_agregarCascade, "btn_agregarCascade");
            this.btn_agregarCascade.Name = "btn_agregarCascade";
            this.btn_agregarCascade.UseVisualStyleBackColor = false;
            this.btn_agregarCascade.Click += new System.EventHandler(this.btn_agregarCascade_Click);
            // 
            // cb_activarROI
            // 
            resources.ApplyResources(this.cb_activarROI, "cb_activarROI");
            this.cb_activarROI.Name = "cb_activarROI";
            this.cb_activarROI.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cb_cascade,
            this.lbl_cascade,
            this.cbox_cascade,
            this.color_cascade});
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            // 
            // cb_cascade
            // 
            this.cb_cascade.Frozen = true;
            resources.ApplyResources(this.cb_cascade, "cb_cascade");
            this.cb_cascade.Name = "cb_cascade";
            this.cb_cascade.ReadOnly = true;
            // 
            // lbl_cascade
            // 
            this.lbl_cascade.Frozen = true;
            resources.ApplyResources(this.lbl_cascade, "lbl_cascade");
            this.lbl_cascade.Name = "lbl_cascade";
            this.lbl_cascade.ReadOnly = true;
            // 
            // cbox_cascade
            // 
            this.cbox_cascade.Frozen = true;
            resources.ApplyResources(this.cbox_cascade, "cbox_cascade");
            this.cbox_cascade.Items.AddRange(new object[] {
            "Face",
            "Hand",
            "Body",
            "Full"});
            this.cbox_cascade.Name = "cbox_cascade";
            this.cbox_cascade.ReadOnly = true;
            // 
            // color_cascade
            // 
            this.color_cascade.Frozen = true;
            resources.ApplyResources(this.color_cascade, "color_cascade");
            this.color_cascade.Name = "color_cascade";
            this.color_cascade.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.cb_activarROI);
            this.groupBox3.Controls.Add(this.btn_agregarCascade);
            this.groupBox3.Controls.Add(this.btn_quitarCascade);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mov_left);
            this.groupBox2.Controls.Add(this.mov_right);
            this.groupBox2.Controls.Add(this.mov_down);
            this.groupBox2.Controls.Add(this.mov_up);
            this.groupBox2.Controls.Add(this.lbl_direccion);
            this.groupBox2.Controls.Add(this.imageBox_OpticalFlowBorder);
            this.groupBox2.Controls.Add(this.imageBox_OpticalFlowMap);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // mov_left
            // 
            resources.ApplyResources(this.mov_left, "mov_left");
            this.mov_left.Name = "mov_left";
            this.mov_left.TabStop = false;
            // 
            // mov_right
            // 
            resources.ApplyResources(this.mov_right, "mov_right");
            this.mov_right.Name = "mov_right";
            this.mov_right.TabStop = false;
            // 
            // mov_down
            // 
            resources.ApplyResources(this.mov_down, "mov_down");
            this.mov_down.Name = "mov_down";
            this.mov_down.TabStop = false;
            // 
            // mov_up
            // 
            resources.ApplyResources(this.mov_up, "mov_up");
            this.mov_up.Name = "mov_up";
            this.mov_up.TabStop = false;
            // 
            // lbl_direccion
            // 
            resources.ApplyResources(this.lbl_direccion, "lbl_direccion");
            this.lbl_direccion.Name = "lbl_direccion";
            // 
            // imageBox_OpticalFlowBorder
            // 
            this.imageBox_OpticalFlowBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.imageBox_OpticalFlowBorder, "imageBox_OpticalFlowBorder");
            this.imageBox_OpticalFlowBorder.Name = "imageBox_OpticalFlowBorder";
            this.imageBox_OpticalFlowBorder.TabStop = false;
            // 
            // imageBox_OpticalFlowMap
            // 
            this.imageBox_OpticalFlowMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.imageBox_OpticalFlowMap, "imageBox_OpticalFlowMap");
            this.imageBox_OpticalFlowMap.Name = "imageBox_OpticalFlowMap";
            this.imageBox_OpticalFlowMap.TabStop = false;
            // 
            // FrmPrincipal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_salida);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gb_opciones);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_original);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxROI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxDetect)).EndInit();
            this.gb_original.ResumeLayout(false);
            this.gb_original.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_opciones.ResumeLayout(false);
            this.gb_opciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.value_dilate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_erode)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Y_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cb_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cb_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cr_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cr_min)).EndInit();
            this.gb_salida.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.R_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.G_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.G_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_min)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.H_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.H_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxYCbCr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxHSV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxRGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mov_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mov_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mov_down)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mov_up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_OpticalFlowBorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_OpticalFlowMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private Emgu.CV.UI.ImageBox imageBoxROI;
        private Emgu.CV.UI.ImageBox imageBoxDetect;
        private System.Windows.Forms.GroupBox gb_original;
        private System.Windows.Forms.TextBox txt_senia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.TextBox txt_etiqueta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_opciones;
        private System.Windows.Forms.NumericUpDown value_dilate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown value_erode;
        private System.Windows.Forms.CheckBox cb_background;
        private System.Windows.Forms.CheckBox cb_invert;
        private System.Windows.Forms.OpenFileDialog file_dialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem camaraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarImágenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detecciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habilitarXmlsCascadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habilitarToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbox_YCbCr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown Y_min;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown Cb_min;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown Cr_min;
        private System.Windows.Forms.NumericUpDown Y_max;
        private System.Windows.Forms.NumericUpDown Cb_max;
        private System.Windows.Forms.NumericUpDown Cr_max;
        private System.Windows.Forms.TextBox txt_sKernel_x;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripMenuItem kNearestToolStripMenuItem;
        private System.Windows.Forms.CheckBox cb_margen;
        private System.Windows.Forms.CheckBox cb_center;
        private System.Windows.Forms.CheckBox cb_defects;
        private System.Windows.Forms.CheckBox cb_convex;
        private System.Windows.Forms.CheckBox cb_drawRoi;
        private System.Windows.Forms.CheckBox cb_connectPoint;
        private System.Windows.Forms.GroupBox gb_salida;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox cbox_rgb;
        private System.Windows.Forms.Label lbl_b;
        private System.Windows.Forms.NumericUpDown R_max;
        private System.Windows.Forms.NumericUpDown R_min;
        private System.Windows.Forms.NumericUpDown G_max;
        private System.Windows.Forms.Label lbl_g;
        private System.Windows.Forms.NumericUpDown G_min;
        private System.Windows.Forms.NumericUpDown B_max;
        private System.Windows.Forms.Label lbl_r;
        private System.Windows.Forms.NumericUpDown B_min;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbox_hsv;
        private System.Windows.Forms.Label lbl_v;
        private System.Windows.Forms.NumericUpDown H_max;
        private System.Windows.Forms.NumericUpDown H_min;
        private System.Windows.Forms.NumericUpDown S_max;
        private System.Windows.Forms.Label lbl_s;
        private System.Windows.Forms.NumericUpDown S_min;
        private System.Windows.Forms.NumericUpDown V_max;
        private System.Windows.Forms.Label llb_h;
        private System.Windows.Forms.NumericUpDown V_min;
        private Emgu.CV.UI.ImageBox imageBoxYCbCr;
        private Emgu.CV.UI.ImageBox imageBoxHSV;
        private Emgu.CV.UI.ImageBox imageBoxRGB;
        private System.Windows.Forms.CheckBox cbox_usarROI;
        private System.Windows.Forms.Button btn_quitarCascade;
        private System.Windows.Forms.Button btn_agregarCascade;
        private System.Windows.Forms.CheckBox cb_activarROI;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cb_cascade;
        private System.Windows.Forms.DataGridViewTextBoxColumn lbl_cascade;
        private System.Windows.Forms.DataGridViewComboBoxColumn cbox_cascade;
        private System.Windows.Forms.DataGridViewImageColumn color_cascade;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private Emgu.CV.UI.ImageBox imageBox_OpticalFlowBorder;
        private Emgu.CV.UI.ImageBox imageBox_OpticalFlowMap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_direccion;
        private System.Windows.Forms.PictureBox mov_left;
        private System.Windows.Forms.PictureBox mov_right;
        private System.Windows.Forms.PictureBox mov_down;
        private System.Windows.Forms.PictureBox mov_up;
    }
}


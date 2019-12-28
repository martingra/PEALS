namespace Detector.Forms
{
    partial class Reconocimiento
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
            this.imgBox = new Emgu.CV.UI.ImageBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.imgBoxResultado = new Emgu.CV.UI.ImageBox();
            this.imgBoxPreprocess = new Emgu.CV.UI.ImageBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.imageBoxPintar = new Emgu.CV.UI.ImageBox();
            this.imageBoxMogColoreado = new Emgu.CV.UI.ImageBox();
            this.btnEntrenar = new System.Windows.Forms.Button();
            this.txtEtiqueta = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.rbTest = new System.Windows.Forms.RadioButton();
            this.rbTrain = new System.Windows.Forms.RadioButton();
            this.btnTrain = new System.Windows.Forms.Button();
            this.chClasificar = new System.Windows.Forms.CheckBox();
            this.txtEsCara = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxResultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxPreprocess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxPintar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxMogColoreado)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBox
            // 
            this.imgBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBox.Location = new System.Drawing.Point(33, 21);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(501, 399);
            this.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox.TabIndex = 4;
            this.imgBox.TabStop = false;
            // 
            // txtResultado
            // 
            this.txtResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultado.Location = new System.Drawing.Point(574, 463);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(405, 31);
            this.txtResultado.TabIndex = 5;
            // 
            // imgBoxResultado
            // 
            this.imgBoxResultado.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBoxResultado.Location = new System.Drawing.Point(562, 21);
            this.imgBoxResultado.Name = "imgBoxResultado";
            this.imgBoxResultado.Size = new System.Drawing.Size(199, 175);
            this.imgBoxResultado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBoxResultado.TabIndex = 6;
            this.imgBoxResultado.TabStop = false;
            // 
            // imgBoxPreprocess
            // 
            this.imgBoxPreprocess.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBoxPreprocess.Location = new System.Drawing.Point(562, 202);
            this.imgBoxPreprocess.Name = "imgBoxPreprocess";
            this.imgBoxPreprocess.Size = new System.Drawing.Size(199, 175);
            this.imgBoxPreprocess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBoxPreprocess.TabIndex = 7;
            this.imgBoxPreprocess.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(444, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 31);
            this.button1.TabIndex = 8;
            this.button1.Text = "Reiniciar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(33, 426);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(90, 31);
            this.btnIniciar.TabIndex = 9;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // imageBoxPintar
            // 
            this.imageBoxPintar.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBoxPintar.Location = new System.Drawing.Point(780, 21);
            this.imageBoxPintar.Name = "imageBoxPintar";
            this.imageBoxPintar.Size = new System.Drawing.Size(199, 175);
            this.imageBoxPintar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxPintar.TabIndex = 10;
            this.imageBoxPintar.TabStop = false;
            // 
            // imageBoxMogColoreado
            // 
            this.imageBoxMogColoreado.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBoxMogColoreado.Location = new System.Drawing.Point(780, 202);
            this.imageBoxMogColoreado.Name = "imageBoxMogColoreado";
            this.imageBoxMogColoreado.Size = new System.Drawing.Size(199, 175);
            this.imageBoxMogColoreado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxMogColoreado.TabIndex = 11;
            this.imageBoxMogColoreado.TabStop = false;
            // 
            // btnEntrenar
            // 
            this.btnEntrenar.Location = new System.Drawing.Point(877, 389);
            this.btnEntrenar.Name = "btnEntrenar";
            this.btnEntrenar.Size = new System.Drawing.Size(102, 31);
            this.btnEntrenar.TabIndex = 12;
            this.btnEntrenar.Text = "Agregar Etiqueta";
            this.btnEntrenar.UseVisualStyleBackColor = true;
            this.btnEntrenar.Click += new System.EventHandler(this.btnEntrenar_Click);
            // 
            // txtEtiqueta
            // 
            this.txtEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEtiqueta.Location = new System.Drawing.Point(780, 389);
            this.txtEtiqueta.Name = "txtEtiqueta";
            this.txtEtiqueta.Size = new System.Drawing.Size(91, 31);
            this.txtEtiqueta.TabIndex = 13;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(877, 426);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(102, 31);
            this.txtCantidad.TabIndex = 14;
            // 
            // rbTest
            // 
            this.rbTest.AutoSize = true;
            this.rbTest.Checked = true;
            this.rbTest.Location = new System.Drawing.Point(780, 436);
            this.rbTest.Name = "rbTest";
            this.rbTest.Size = new System.Drawing.Size(42, 17);
            this.rbTest.TabIndex = 15;
            this.rbTest.TabStop = true;
            this.rbTest.Text = "test";
            this.rbTest.UseVisualStyleBackColor = true;
            // 
            // rbTrain
            // 
            this.rbTrain.AutoSize = true;
            this.rbTrain.Location = new System.Drawing.Point(826, 436);
            this.rbTrain.Name = "rbTrain";
            this.rbTrain.Size = new System.Drawing.Size(45, 17);
            this.rbTrain.TabIndex = 16;
            this.rbTrain.Text = "train";
            this.rbTrain.UseVisualStyleBackColor = true;
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(659, 426);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(102, 31);
            this.btnTrain.TabIndex = 17;
            this.btnTrain.Text = "Entrenar";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // chClasificar
            // 
            this.chClasificar.AutoSize = true;
            this.chClasificar.Location = new System.Drawing.Point(693, 397);
            this.chClasificar.Name = "chClasificar";
            this.chClasificar.Size = new System.Drawing.Size(68, 17);
            this.chClasificar.TabIndex = 18;
            this.chClasificar.Text = "Clasificar";
            this.chClasificar.UseVisualStyleBackColor = true;
            // 
            // txtEsCara
            // 
            this.txtEsCara.AutoSize = true;
            this.txtEsCara.Location = new System.Drawing.Point(142, 434);
            this.txtEsCara.Name = "txtEsCara";
            this.txtEsCara.Size = new System.Drawing.Size(63, 17);
            this.txtEsCara.TabIndex = 19;
            this.txtEsCara.Text = "Es Cara";
            this.txtEsCara.UseVisualStyleBackColor = true;
            // 
            // Reconocimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 499);
            this.Controls.Add(this.txtEsCara);
            this.Controls.Add(this.chClasificar);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.rbTrain);
            this.Controls.Add(this.rbTest);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtEtiqueta);
            this.Controls.Add(this.btnEntrenar);
            this.Controls.Add(this.imageBoxMogColoreado);
            this.Controls.Add(this.imageBoxPintar);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imgBoxPreprocess);
            this.Controls.Add(this.imgBoxResultado);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.imgBox);
            this.Name = "Reconocimiento";
            this.Text = "Reconocimiento";
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxResultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxPreprocess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxPintar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxMogColoreado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgBox;
        private System.Windows.Forms.TextBox txtResultado;
        private Emgu.CV.UI.ImageBox imgBoxResultado;
        private Emgu.CV.UI.ImageBox imgBoxPreprocess;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnIniciar;
        private Emgu.CV.UI.ImageBox imageBoxPintar;
        private Emgu.CV.UI.ImageBox imageBoxMogColoreado;
        private System.Windows.Forms.Button btnEntrenar;
        private System.Windows.Forms.TextBox txtEtiqueta;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.RadioButton rbTest;
        private System.Windows.Forms.RadioButton rbTrain;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.CheckBox chClasificar;
        private System.Windows.Forms.CheckBox txtEsCara;
    }
}
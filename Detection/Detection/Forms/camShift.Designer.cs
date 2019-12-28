namespace Detector.Forms
{
    partial class camShift
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
            this.imgBoxVideo = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMouseClick = new System.Windows.Forms.TextBox();
            this.chSeguir = new System.Windows.Forms.CheckBox();
            this.chHaarCascade = new System.Windows.Forms.CheckBox();
            this.imgBoxResultado = new Emgu.CV.UI.ImageBox();
            this.imgBoxOpticalFlow = new Emgu.CV.UI.ImageBox();
            this.chOpticalFlow = new System.Windows.Forms.CheckBox();
            this.lblMovimiento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxResultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxOpticalFlow)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBoxVideo
            // 
            this.imgBoxVideo.Location = new System.Drawing.Point(189, 35);
            this.imgBoxVideo.Margin = new System.Windows.Forms.Padding(0);
            this.imgBoxVideo.Name = "imgBoxVideo";
            this.imgBoxVideo.Size = new System.Drawing.Size(320, 240);
            this.imgBoxVideo.TabIndex = 2;
            this.imgBoxVideo.TabStop = false;
            this.imgBoxVideo.Click += new System.EventHandler(this.imgBoxVideo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Click mouse:";
            // 
            // txtMouseClick
            // 
            this.txtMouseClick.Location = new System.Drawing.Point(138, 307);
            this.txtMouseClick.Name = "txtMouseClick";
            this.txtMouseClick.Size = new System.Drawing.Size(159, 20);
            this.txtMouseClick.TabIndex = 4;
            // 
            // chSeguir
            // 
            this.chSeguir.AutoSize = true;
            this.chSeguir.Location = new System.Drawing.Point(22, 44);
            this.chSeguir.Name = "chSeguir";
            this.chSeguir.Size = new System.Drawing.Size(78, 17);
            this.chSeguir.TabIndex = 5;
            this.chSeguir.Text = "Seguir ROI";
            this.chSeguir.UseVisualStyleBackColor = true;
            // 
            // chHaarCascade
            // 
            this.chHaarCascade.AutoSize = true;
            this.chHaarCascade.Location = new System.Drawing.Point(22, 67);
            this.chHaarCascade.Name = "chHaarCascade";
            this.chHaarCascade.Size = new System.Drawing.Size(155, 17);
            this.chHaarCascade.TabIndex = 6;
            this.chHaarCascade.Text = "Seguir Cara (HaarCascade)";
            this.chHaarCascade.UseVisualStyleBackColor = true;
            // 
            // imgBoxResultado
            // 
            this.imgBoxResultado.Location = new System.Drawing.Point(625, 35);
            this.imgBoxResultado.Name = "imgBoxResultado";
            this.imgBoxResultado.Size = new System.Drawing.Size(320, 240);
            this.imgBoxResultado.TabIndex = 2;
            this.imgBoxResultado.TabStop = false;
            // 
            // imgBoxOpticalFlow
            // 
            this.imgBoxOpticalFlow.Location = new System.Drawing.Point(974, 35);
            this.imgBoxOpticalFlow.Name = "imgBoxOpticalFlow";
            this.imgBoxOpticalFlow.Size = new System.Drawing.Size(320, 240);
            this.imgBoxOpticalFlow.TabIndex = 2;
            this.imgBoxOpticalFlow.TabStop = false;
            // 
            // chOpticalFlow
            // 
            this.chOpticalFlow.AutoSize = true;
            this.chOpticalFlow.Location = new System.Drawing.Point(22, 90);
            this.chOpticalFlow.Name = "chOpticalFlow";
            this.chOpticalFlow.Size = new System.Drawing.Size(84, 17);
            this.chOpticalFlow.TabIndex = 7;
            this.chOpticalFlow.Text = "Optical Flow";
            this.chOpticalFlow.UseVisualStyleBackColor = true;
            // 
            // lblMovimiento
            // 
            this.lblMovimiento.AutoSize = true;
            this.lblMovimiento.Location = new System.Drawing.Point(980, 291);
            this.lblMovimiento.Name = "lblMovimiento";
            this.lblMovimiento.Size = new System.Drawing.Size(0, 13);
            this.lblMovimiento.TabIndex = 8;
            // 
            // camShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1441, 352);
            this.Controls.Add(this.lblMovimiento);
            this.Controls.Add(this.chOpticalFlow);
            this.Controls.Add(this.imgBoxOpticalFlow);
            this.Controls.Add(this.imgBoxResultado);
            this.Controls.Add(this.chHaarCascade);
            this.Controls.Add(this.chSeguir);
            this.Controls.Add(this.txtMouseClick);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgBoxVideo);
            this.Name = "camShift";
            this.Text = "camShift";
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxResultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxOpticalFlow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgBoxVideo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMouseClick;
        private System.Windows.Forms.CheckBox chSeguir;
        private System.Windows.Forms.CheckBox chHaarCascade;
        private Emgu.CV.UI.ImageBox imgBoxResultado;
        private Emgu.CV.UI.ImageBox imgBoxOpticalFlow;
        private System.Windows.Forms.CheckBox chOpticalFlow;
        private System.Windows.Forms.Label lblMovimiento;
    }
}
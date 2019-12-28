namespace Detector.Forms
{
    partial class OpticalFlow
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
            this.imgBox2 = new Emgu.CV.UI.ImageBox();
            this.btn_seguir = new System.Windows.Forms.Button();
            this.imgBox3 = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBox1
            // 
            this.imgBox1.Location = new System.Drawing.Point(12, 12);
            this.imgBox1.Name = "imgBox1";
            this.imgBox1.Size = new System.Drawing.Size(266, 241);
            this.imgBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox1.TabIndex = 2;
            this.imgBox1.TabStop = false;
            // 
            // imgBox2
            // 
            this.imgBox2.Location = new System.Drawing.Point(284, 12);
            this.imgBox2.Name = "imgBox2";
            this.imgBox2.Size = new System.Drawing.Size(266, 241);
            this.imgBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox2.TabIndex = 3;
            this.imgBox2.TabStop = false;
            // 
            // btn_seguir
            // 
            this.btn_seguir.Location = new System.Drawing.Point(284, 262);
            this.btn_seguir.Name = "btn_seguir";
            this.btn_seguir.Size = new System.Drawing.Size(266, 30);
            this.btn_seguir.TabIndex = 4;
            this.btn_seguir.Text = "Seguir";
            this.btn_seguir.UseVisualStyleBackColor = true;
            this.btn_seguir.Click += new System.EventHandler(this.btn_seguir_Click);
            // 
            // imgBox3
            // 
            this.imgBox3.Location = new System.Drawing.Point(556, 12);
            this.imgBox3.Name = "imgBox3";
            this.imgBox3.Size = new System.Drawing.Size(266, 241);
            this.imgBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox3.TabIndex = 5;
            this.imgBox3.TabStop = false;
            // 
            // OpticalFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 304);
            this.Controls.Add(this.imgBox3);
            this.Controls.Add(this.btn_seguir);
            this.Controls.Add(this.imgBox2);
            this.Controls.Add(this.imgBox1);
            this.Name = "OpticalFlow";
            this.Text = "OpticalFlow";
            this.Load += new System.EventHandler(this.OpticalFlow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgBox1;
        private Emgu.CV.UI.ImageBox imgBox2;
        private System.Windows.Forms.Button btn_seguir;
        private Emgu.CV.UI.ImageBox imgBox3;
    }
}
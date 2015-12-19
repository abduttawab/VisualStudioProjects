namespace ImageCollectorToMSAccess
{
    partial class RecognizerWindow
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
            this.starRegButton = new System.Windows.Forms.Button();
            this.detectedFaceNo = new System.Windows.Forms.Label();
            this.personName = new System.Windows.Forms.Label();
            this.imageLoaderbutton = new System.Windows.Forms.Button();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            this.SuspendLayout();
            // 
            // starRegButton
            // 
            this.starRegButton.Location = new System.Drawing.Point(378, 424);
            this.starRegButton.Name = "starRegButton";
            this.starRegButton.Size = new System.Drawing.Size(210, 32);
            this.starRegButton.TabIndex = 4;
            this.starRegButton.Text = "Start Recognization";
            this.starRegButton.UseVisualStyleBackColor = true;
            this.starRegButton.Click += new System.EventHandler(this.starRegButton_Click);
            // 
            // detectedFaceNo
            // 
            this.detectedFaceNo.AutoSize = true;
            this.detectedFaceNo.Location = new System.Drawing.Point(677, 442);
            this.detectedFaceNo.Name = "detectedFaceNo";
            this.detectedFaceNo.Size = new System.Drawing.Size(13, 13);
            this.detectedFaceNo.TabIndex = 5;
            this.detectedFaceNo.Text = "0";
            // 
            // personName
            // 
            this.personName.AutoSize = true;
            this.personName.Location = new System.Drawing.Point(744, 434);
            this.personName.Name = "personName";
            this.personName.Size = new System.Drawing.Size(0, 13);
            this.personName.TabIndex = 6;
            // 
            // imageLoaderbutton
            // 
            this.imageLoaderbutton.Location = new System.Drawing.Point(139, 424);
            this.imageLoaderbutton.Name = "imageLoaderbutton";
            this.imageLoaderbutton.Size = new System.Drawing.Size(145, 23);
            this.imageLoaderbutton.TabIndex = 7;
            this.imageLoaderbutton.Text = "Load Image From DB";
            this.imageLoaderbutton.UseVisualStyleBackColor = true;
            this.imageLoaderbutton.Click += new System.EventHandler(this.imageLoaderbutton_Click);
            // 
            // imageBox1
            // 
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox1.Location = new System.Drawing.Point(605, 22);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(288, 349);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox1.TabIndex = 8;
            this.imageBox1.TabStop = false;
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(12, 22);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(566, 349);
            this.imageBoxFrameGrabber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxFrameGrabber.TabIndex = 9;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // RecognizerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 468);
            this.Controls.Add(this.imageBoxFrameGrabber);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.imageLoaderbutton);
            this.Controls.Add(this.personName);
            this.Controls.Add(this.detectedFaceNo);
            this.Controls.Add(this.starRegButton);
            this.Name = "RecognizerWindow";
            this.Text = "RecognizerWindow";
            this.Load += new System.EventHandler(this.RecognizerWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button starRegButton;
        private System.Windows.Forms.Label detectedFaceNo;
        private System.Windows.Forms.Label personName;
        private System.Windows.Forms.Button imageLoaderbutton;
        private Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
    }
}
namespace Face_Recognizer
{
    partial class ImageDB
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
            this.buttonPre = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Face = new System.Windows.Forms.GroupBox();
            this.extracedFaceNextbutton = new System.Windows.Forms.Button();
            this.extracedFacePrebutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.extractedFacepictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.minDetectionScaleTextBox = new System.Windows.Forms.TextBox();
            this.minNeighborComboBox = new System.Windows.Forms.ComboBox();
            this.scaleComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonstartLiveCam = new System.Windows.Forms.Button();
            this.selectCamcomboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imageBox = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.Face.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extractedFacepictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPre
            // 
            this.buttonPre.Enabled = false;
            this.buttonPre.Location = new System.Drawing.Point(50, 201);
            this.buttonPre.Name = "buttonPre";
            this.buttonPre.Size = new System.Drawing.Size(39, 23);
            this.buttonPre.TabIndex = 4;
            this.buttonPre.Text = "Previous";
            this.buttonPre.UseVisualStyleBackColor = true;
            this.buttonPre.Click += new System.EventHandler(this.buttonPre_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Enabled = false;
            this.buttonNext.Location = new System.Drawing.Point(157, 201);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(39, 23);
            this.buttonNext.TabIndex = 5;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonDelete.Enabled = false;
            this.buttonDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonDelete.Location = new System.Drawing.Point(95, 201);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(56, 23);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(11, 257);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(221, 23);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Save To DB";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // browseButton
            // 
            this.browseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.browseButton.Location = new System.Drawing.Point(12, 488);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(96, 23);
            this.browseButton.TabIndex = 8;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = false;
            this.browseButton.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 155);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.buttonDelete);
            this.groupBox1.Controls.Add(this.buttonNext);
            this.groupBox1.Controls.Add(this.buttonPre);
            this.groupBox1.Location = new System.Drawing.Point(728, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 286);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Traning Set Viewer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Person Name:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Location = new System.Drawing.Point(9, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Update Face";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 230);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 20);
            this.textBox1.TabIndex = 10;
            // 
            // Face
            // 
            this.Face.Controls.Add(this.extracedFaceNextbutton);
            this.Face.Controls.Add(this.extracedFacePrebutton);
            this.Face.Controls.Add(this.label1);
            this.Face.Controls.Add(this.textBox2);
            this.Face.Controls.Add(this.extractedFacepictureBox);
            this.Face.Controls.Add(this.buttonSave);
            this.Face.Location = new System.Drawing.Point(484, 232);
            this.Face.Name = "Face";
            this.Face.Size = new System.Drawing.Size(238, 286);
            this.Face.TabIndex = 11;
            this.Face.TabStop = false;
            this.Face.Text = "Face Adder";
            // 
            // extracedFaceNextbutton
            // 
            this.extracedFaceNextbutton.Enabled = false;
            this.extracedFaceNextbutton.Location = new System.Drawing.Point(148, 201);
            this.extracedFaceNextbutton.Name = "extracedFaceNextbutton";
            this.extracedFaceNextbutton.Size = new System.Drawing.Size(84, 23);
            this.extracedFaceNextbutton.TabIndex = 14;
            this.extracedFaceNextbutton.Text = "Next";
            this.extracedFaceNextbutton.UseVisualStyleBackColor = true;
            // 
            // extracedFacePrebutton
            // 
            this.extracedFacePrebutton.Enabled = false;
            this.extracedFacePrebutton.Location = new System.Drawing.Point(11, 201);
            this.extracedFacePrebutton.Name = "extracedFacePrebutton";
            this.extracedFacePrebutton.Size = new System.Drawing.Size(89, 23);
            this.extracedFacePrebutton.TabIndex = 13;
            this.extracedFacePrebutton.Text = "Previous";
            this.extracedFacePrebutton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Person Name:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(88, 231);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(144, 20);
            this.textBox2.TabIndex = 12;
            // 
            // extractedFacepictureBox
            // 
            this.extractedFacepictureBox.Location = new System.Drawing.Point(11, 40);
            this.extractedFacepictureBox.Name = "extractedFacepictureBox";
            this.extractedFacepictureBox.Size = new System.Drawing.Size(221, 155);
            this.extractedFacepictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.extractedFacepictureBox.TabIndex = 12;
            this.extractedFacepictureBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.minDetectionScaleTextBox);
            this.groupBox2.Controls.Add(this.minNeighborComboBox);
            this.groupBox2.Controls.Add(this.scaleComboBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(484, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 204);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tune Detection Parameters";
            // 
            // minDetectionScaleTextBox
            // 
            this.minDetectionScaleTextBox.Location = new System.Drawing.Point(148, 155);
            this.minDetectionScaleTextBox.Name = "minDetectionScaleTextBox";
            this.minDetectionScaleTextBox.Size = new System.Drawing.Size(121, 20);
            this.minDetectionScaleTextBox.TabIndex = 5;
            this.minDetectionScaleTextBox.Text = "3";
            // 
            // minNeighborComboBox
            // 
            this.minNeighborComboBox.FormattingEnabled = true;
            this.minNeighborComboBox.Items.AddRange(new object[] {
            "2",
            "3",
            "4"});
            this.minNeighborComboBox.Location = new System.Drawing.Point(148, 109);
            this.minNeighborComboBox.Name = "minNeighborComboBox";
            this.minNeighborComboBox.Size = new System.Drawing.Size(121, 21);
            this.minNeighborComboBox.TabIndex = 4;
            this.minNeighborComboBox.Text = "1";
            // 
            // scaleComboBox
            // 
            this.scaleComboBox.FormattingEnabled = true;
            this.scaleComboBox.Items.AddRange(new object[] {
            "1.2",
            "1.3",
            "1.4"});
            this.scaleComboBox.Location = new System.Drawing.Point(148, 73);
            this.scaleComboBox.Name = "scaleComboBox";
            this.scaleComboBox.Size = new System.Drawing.Size(121, 21);
            this.scaleComboBox.TabIndex = 3;
            this.scaleComboBox.Text = "1.1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Min Detection Scale:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Min Neighbors:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Sacle Increase Rate:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(814, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 105);
            this.button2.TabIndex = 13;
            this.button2.Text = "Load Recognizer";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // buttonstartLiveCam
            // 
            this.buttonstartLiveCam.BackColor = System.Drawing.Color.Red;
            this.buttonstartLiveCam.Enabled = false;
            this.buttonstartLiveCam.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonstartLiveCam.Location = new System.Drawing.Point(312, 488);
            this.buttonstartLiveCam.Name = "buttonstartLiveCam";
            this.buttonstartLiveCam.Size = new System.Drawing.Size(166, 23);
            this.buttonstartLiveCam.TabIndex = 15;
            this.buttonstartLiveCam.Text = "Start Live Video!";
            this.buttonstartLiveCam.UseVisualStyleBackColor = false;
            this.buttonstartLiveCam.Click += new System.EventHandler(this.buttonstartLiveCam_Click);
            // 
            // selectCamcomboBox
            // 
            this.selectCamcomboBox.FormattingEnabled = true;
            this.selectCamcomboBox.Items.AddRange(new object[] {
            "0",
            "1"});
            this.selectCamcomboBox.Location = new System.Drawing.Point(216, 489);
            this.selectCamcomboBox.Name = "selectCamcomboBox";
            this.selectCamcomboBox.Size = new System.Drawing.Size(90, 21);
            this.selectCamcomboBox.TabIndex = 16;
            this.selectCamcomboBox.Text = "None";
            this.selectCamcomboBox.SelectedIndexChanged += new System.EventHandler(this.selectCamcomboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 497);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Select Camera:";
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(12, 12);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(466, 444);
            this.imageBox.TabIndex = 2;
            this.imageBox.TabStop = false;
            this.imageBox.Click += new System.EventHandler(this.imageBox_Click);
            // 
            // ImageDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 530);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectCamcomboBox);
            this.Controls.Add(this.buttonstartLiveCam);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Face);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.browseButton);
            this.Name = "ImageDB";
            this.Text = "Training Set";
            this.Load += new System.EventHandler(this.ImageDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Face.ResumeLayout(false);
            this.Face.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extractedFacepictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonPre;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox Face;
        private System.Windows.Forms.PictureBox extractedFacepictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonstartLiveCam;
        private System.Windows.Forms.ComboBox selectCamcomboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox minDetectionScaleTextBox;
        private System.Windows.Forms.ComboBox minNeighborComboBox;
        private System.Windows.Forms.ComboBox scaleComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button extracedFaceNextbutton;
        private System.Windows.Forms.Button extracedFacePrebutton;
        private Emgu.CV.UI.ImageBox imageBox;
    }
}


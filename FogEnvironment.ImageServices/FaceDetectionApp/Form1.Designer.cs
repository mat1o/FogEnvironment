
namespace FaceDetectionApp
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbParallel = new System.Windows.Forms.CheckBox();
            this.cbScaling = new System.Windows.Forms.ComboBox();
            this.lblScaling = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.lblMinSize = new System.Windows.Forms.Label();
            this.txtScaleFactor = new System.Windows.Forms.TextBox();
            this.lblScaleFactor = new System.Windows.Forms.Label();
            this.btnDetect = new System.Windows.Forms.Button();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbParallel);
            this.panel1.Controls.Add(this.cbScaling);
            this.panel1.Controls.Add(this.lblScaling);
            this.panel1.Controls.Add(this.txtSize);
            this.panel1.Controls.Add(this.lblMinSize);
            this.panel1.Controls.Add(this.txtScaleFactor);
            this.panel1.Controls.Add(this.lblScaleFactor);
            this.panel1.Controls.Add(this.btnDetect);
            this.panel1.Controls.Add(this.cbMode);
            this.panel1.Controls.Add(this.lblMode);
            this.panel1.Controls.Add(this.btnOpenImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 90);
            this.panel1.TabIndex = 4;
            // 
            // cbParallel
            // 
            this.cbParallel.AutoSize = true;
            this.cbParallel.Location = new System.Drawing.Point(703, 54);
            this.cbParallel.Name = "cbParallel";
            this.cbParallel.Size = new System.Drawing.Size(86, 24);
            this.cbParallel.TabIndex = 10;
            this.cbParallel.Text = "Parallel";
            this.cbParallel.UseVisualStyleBackColor = true;
            // 
            // cbScaling
            // 
            this.cbScaling.FormattingEnabled = true;
            this.cbScaling.Location = new System.Drawing.Point(262, 50);
            this.cbScaling.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbScaling.Name = "cbScaling";
            this.cbScaling.Size = new System.Drawing.Size(256, 28);
            this.cbScaling.TabIndex = 9;
            // 
            // lblScaling
            // 
            this.lblScaling.AutoSize = true;
            this.lblScaling.Location = new System.Drawing.Point(159, 54);
            this.lblScaling.Name = "lblScaling";
            this.lblScaling.Size = new System.Drawing.Size(97, 20);
            this.lblScaling.TabIndex = 8;
            this.lblScaling.Text = "Scale Mode:";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(634, 50);
            this.txtSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSize.Multiline = true;
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(56, 29);
            this.txtSize.TabIndex = 7;
            this.txtSize.Text = "5";
            // 
            // lblMinSize
            // 
            this.lblMinSize.AutoSize = true;
            this.lblMinSize.Location = new System.Drawing.Point(555, 54);
            this.lblMinSize.Name = "lblMinSize";
            this.lblMinSize.Size = new System.Drawing.Size(73, 20);
            this.lblMinSize.TabIndex = 6;
            this.lblMinSize.Text = "Min Size:";
            // 
            // txtScaleFactor
            // 
            this.txtScaleFactor.Location = new System.Drawing.Point(634, 12);
            this.txtScaleFactor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtScaleFactor.Multiline = true;
            this.txtScaleFactor.Name = "txtScaleFactor";
            this.txtScaleFactor.Size = new System.Drawing.Size(56, 29);
            this.txtScaleFactor.TabIndex = 5;
            this.txtScaleFactor.Text = "1.1";
            // 
            // lblScaleFactor
            // 
            this.lblScaleFactor.AutoSize = true;
            this.lblScaleFactor.Location = new System.Drawing.Point(525, 16);
            this.lblScaleFactor.Name = "lblScaleFactor";
            this.lblScaleFactor.Size = new System.Drawing.Size(103, 20);
            this.lblScaleFactor.TabIndex = 4;
            this.lblScaleFactor.Text = "Scale Factor:";
            // 
            // btnDetect
            // 
            this.btnDetect.Location = new System.Drawing.Point(703, 9);
            this.btnDetect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(86, 34);
            this.btnDetect.TabIndex = 3;
            this.btnDetect.Text = "Detect";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // cbMode
            // 
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Location = new System.Drawing.Point(262, 12);
            this.cbMode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(256, 28);
            this.cbMode.TabIndex = 2;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(195, 16);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(61, 20);
            this.lblMode.TabIndex = 1;
            this.lblMode.Text = "Detect:";
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Location = new System.Drawing.Point(15, 16);
            this.btnOpenImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(130, 54);
            this.btnOpenImage.TabIndex = 0;
            this.btnOpenImage.Text = "Open Image";
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 360);
            this.panel2.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(386, 235);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Face Detection";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbParallel;
        private System.Windows.Forms.ComboBox cbScaling;
        private System.Windows.Forms.Label lblScaling;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label lblMinSize;
        private System.Windows.Forms.TextBox txtScaleFactor;
        private System.Windows.Forms.Label lblScaleFactor;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}


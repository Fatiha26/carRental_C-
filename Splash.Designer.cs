namespace carRental
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.Mycar = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.Myprogress = new Guna.UI.WinForms.GunaCircleProgressBar();
            this.Percentage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Mycar)).BeginInit();
            this.Myprogress.SuspendLayout();
            this.SuspendLayout();
            // 
            // Mycar
            // 
            this.Mycar.BaseColor = System.Drawing.Color.White;
            this.Mycar.Image = ((System.Drawing.Image)(resources.GetObject("Mycar.Image")));
            this.Mycar.Location = new System.Drawing.Point(43, 76);
            this.Mycar.Name = "Mycar";
            this.Mycar.Size = new System.Drawing.Size(231, 145);
            this.Mycar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Mycar.TabIndex = 0;
            this.Mycar.TabStop = false;
            this.Mycar.UseTransfarantBackground = false;
            this.Mycar.Click += new System.EventHandler(this.Mycar_Click);
            // 
            // Myprogress
            // 
            this.Myprogress.AnimationSpeed = 0.6F;
            this.Myprogress.BackColor = System.Drawing.Color.Transparent;
            this.Myprogress.BaseColor = System.Drawing.Color.Transparent;
            this.Myprogress.Controls.Add(this.Percentage);
            this.Myprogress.Controls.Add(this.Mycar);
            this.Myprogress.IdleColor = System.Drawing.Color.DarkSlateGray;
            this.Myprogress.IdleOffset = 20;
            this.Myprogress.IdleThickness = 16;
            this.Myprogress.Image = null;
            this.Myprogress.ImageSize = new System.Drawing.Size(52, 52);
            this.Myprogress.Location = new System.Drawing.Point(419, 117);
            this.Myprogress.Name = "Myprogress";
            this.Myprogress.ProgressMaxColor = System.Drawing.Color.White;
            this.Myprogress.ProgressMinColor = System.Drawing.Color.White;
            this.Myprogress.ProgressOffset = 20;
            this.Myprogress.ProgressThickness = 8;
            this.Myprogress.Size = new System.Drawing.Size(307, 301);
            this.Myprogress.TabIndex = 1;
            this.Myprogress.Click += new System.EventHandler(this.gunaCircleProgressBar1_Click);
            // 
            // Percentage
            // 
            this.Percentage.AutoSize = true;
            this.Percentage.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Percentage.ForeColor = System.Drawing.Color.White;
            this.Percentage.Location = new System.Drawing.Point(143, 224);
            this.Percentage.Name = "Percentage";
            this.Percentage.Size = new System.Drawing.Size(34, 30);
            this.Percentage.TabIndex = 4;
            this.Percentage.Text = "%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(392, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "CAR RENTAL SYSTEM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(511, 465);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "LamiaFatiha";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.MyProgress_Tick);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1149, 542);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Myprogress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Mycar)).EndInit();
            this.Myprogress.ResumeLayout(false);
            this.Myprogress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaCirclePictureBox Mycar;
        private Guna.UI.WinForms.GunaCircleProgressBar Myprogress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Percentage;
    }
}


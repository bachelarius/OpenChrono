namespace OpenChrono
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.SplashVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SplashVersion
            // 
            this.SplashVersion.AutoSize = true;
            this.SplashVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(233)))), ((int)(((byte)(76)))));
            this.SplashVersion.Location = new System.Drawing.Point(12, 78);
            this.SplashVersion.Name = "SplashVersion";
            this.SplashVersion.Size = new System.Drawing.Size(91, 13);
            this.SplashVersion.TabIndex = 0;
            this.SplashVersion.Text = "Version : ";
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(300, 100);
            this.Controls.Add(this.SplashVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chronograph";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void SetVersion()
        {
            this.SplashVersion.Text += Main.Version;
        }

        private System.Windows.Forms.Label SplashVersion;
    }
}
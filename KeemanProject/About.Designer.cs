namespace KeemanProject
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.pbCosmi = new System.Windows.Forms.PictureBox();
            this.lblCosmiInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCosmi)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCosmi
            // 
            this.pbCosmi.BackColor = System.Drawing.Color.Transparent;
            this.pbCosmi.Image = global::KeemanProject.Properties.Resources.Cosmi;
            this.pbCosmi.Location = new System.Drawing.Point(300, 12);
            this.pbCosmi.Name = "pbCosmi";
            this.pbCosmi.Size = new System.Drawing.Size(349, 270);
            this.pbCosmi.TabIndex = 0;
            this.pbCosmi.TabStop = false;
            this.pbCosmi.Click += new System.EventHandler(this.pbCosmi_Click);
            // 
            // lblCosmiInfo
            // 
            this.lblCosmiInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblCosmiInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosmiInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCosmiInfo.Location = new System.Drawing.Point(49, 260);
            this.lblCosmiInfo.Name = "lblCosmiInfo";
            this.lblCosmiInfo.Size = new System.Drawing.Size(739, 239);
            this.lblCosmiInfo.TabIndex = 1;
            this.lblCosmiInfo.Text = resources.GetString("lblCosmiInfo.Text");
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KeemanProject.Properties.Resources.background2;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCosmiInfo);
            this.Controls.Add(this.pbCosmi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.Text = "Cosmi Candy";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCosmi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCosmi;
        private System.Windows.Forms.Label lblCosmiInfo;
    }
}
namespace DataMining
{
    partial class Utama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Utama));
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.preprocessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPersiapanData = new System.Windows.Forms.Button();
            this.btnPreprocessing = new System.Windows.Forms.Button();
            this.btnAsosiasi = new System.Windows.Forms.Button();
            this.btnPemaketan = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(428, 368);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(584, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "APLIKASI DATA MINING";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.preprocessingToolStripMenuItem,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1078, 37);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "Persiapan Data";
            this.menuStrip1.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(141, 31);
            this.toolStripMenuItem1.Text = "Persiapan Data";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // preprocessingToolStripMenuItem
            // 
            this.preprocessingToolStripMenuItem.Name = "preprocessingToolStripMenuItem";
            this.preprocessingToolStripMenuItem.Size = new System.Drawing.Size(135, 31);
            this.preprocessingToolStripMenuItem.Text = "Preprocessing";
            this.preprocessingToolStripMenuItem.Click += new System.EventHandler(this.preprocessingToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(145, 31);
            this.toolStripMenuItem2.Text = "Proses Asosiasi";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // btnPersiapanData
            // 
            this.btnPersiapanData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPersiapanData.Location = new System.Drawing.Point(72, 175);
            this.btnPersiapanData.Margin = new System.Windows.Forms.Padding(0);
            this.btnPersiapanData.Name = "btnPersiapanData";
            this.btnPersiapanData.Size = new System.Drawing.Size(262, 91);
            this.btnPersiapanData.TabIndex = 4;
            this.btnPersiapanData.Text = "1) Import Data";
            this.btnPersiapanData.UseVisualStyleBackColor = true;
            this.btnPersiapanData.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPreprocessing
            // 
            this.btnPreprocessing.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPreprocessing.Location = new System.Drawing.Point(72, 275);
            this.btnPreprocessing.Margin = new System.Windows.Forms.Padding(0);
            this.btnPreprocessing.Name = "btnPreprocessing";
            this.btnPreprocessing.Size = new System.Drawing.Size(262, 91);
            this.btnPreprocessing.TabIndex = 5;
            this.btnPreprocessing.Text = "2) Preprocessing";
            this.btnPreprocessing.UseVisualStyleBackColor = true;
            this.btnPreprocessing.Click += new System.EventHandler(this.btnPreprocessing_Click);
            // 
            // btnAsosiasi
            // 
            this.btnAsosiasi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAsosiasi.Location = new System.Drawing.Point(72, 375);
            this.btnAsosiasi.Margin = new System.Windows.Forms.Padding(0);
            this.btnAsosiasi.Name = "btnAsosiasi";
            this.btnAsosiasi.Size = new System.Drawing.Size(262, 91);
            this.btnAsosiasi.TabIndex = 6;
            this.btnAsosiasi.Text = "3) Proses Asosiasi";
            this.btnAsosiasi.UseVisualStyleBackColor = true;
            this.btnAsosiasi.Click += new System.EventHandler(this.btnAsosiasi_Click);
            // 
            // btnPemaketan
            // 
            this.btnPemaketan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPemaketan.Location = new System.Drawing.Point(72, 475);
            this.btnPemaketan.Margin = new System.Windows.Forms.Padding(0);
            this.btnPemaketan.Name = "btnPemaketan";
            this.btnPemaketan.Size = new System.Drawing.Size(262, 91);
            this.btnPemaketan.TabIndex = 7;
            this.btnPemaketan.Text = "4) Pemaketan";
            this.btnPemaketan.UseVisualStyleBackColor = true;
            this.btnPemaketan.Click += new System.EventHandler(this.btnPemaketan_Click);
            // 
            // Utama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.BackgroundImage = global::SkripSweet.Properties.Resources.Primkop;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1176, 709);
            this.Controls.Add(this.btnPemaketan);
            this.Controls.Add(this.btnAsosiasi);
            this.Controls.Add(this.btnPreprocessing);
            this.Controls.Add(this.btnPersiapanData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Utama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Mining";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.utama_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem preprocessingToolStripMenuItem;
        private System.Windows.Forms.Button btnPersiapanData;
        private System.Windows.Forms.Button btnPreprocessing;
        private System.Windows.Forms.Button btnAsosiasi;
        private System.Windows.Forms.Button btnPemaketan;
    }
}


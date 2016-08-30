namespace SkripSweet
{
    partial class Pemaketan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pemaketan));
            this.lihatPaket = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtMinimum = new System.Windows.Forms.TextBox();
            this.labelMinimum = new System.Windows.Forms.Label();
            this.txtMaximum = new System.Windows.Forms.TextBox();
            this.hargaMaximum = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // lihatPaket
            // 
            this.lihatPaket.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lihatPaket.Location = new System.Drawing.Point(670, 357);
            this.lihatPaket.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lihatPaket.Name = "lihatPaket";
            this.lihatPaket.Size = new System.Drawing.Size(222, 42);
            this.lihatPaket.TabIndex = 6;
            this.lihatPaket.Text = "Lihat Paket";
            this.lihatPaket.UseVisualStyleBackColor = true;
            this.lihatPaket.Click += new System.EventHandler(this.lihatPaket_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 72);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1479, 260);
            this.dataGridView1.TabIndex = 7;
            // 
            // txtMinimum
            // 
            this.txtMinimum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMinimum.Location = new System.Drawing.Point(153, 363);
            this.txtMinimum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMinimum.Name = "txtMinimum";
            this.txtMinimum.Size = new System.Drawing.Size(148, 26);
            this.txtMinimum.TabIndex = 9;
            // 
            // labelMinimum
            // 
            this.labelMinimum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMinimum.AutoSize = true;
            this.labelMinimum.Location = new System.Drawing.Point(24, 368);
            this.labelMinimum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMinimum.Name = "labelMinimum";
            this.labelMinimum.Size = new System.Drawing.Size(120, 20);
            this.labelMinimum.TabIndex = 8;
            this.labelMinimum.Text = "Harga Minimum";
            // 
            // txtMaximum
            // 
            this.txtMaximum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMaximum.Location = new System.Drawing.Point(468, 363);
            this.txtMaximum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaximum.Name = "txtMaximum";
            this.txtMaximum.Size = new System.Drawing.Size(148, 26);
            this.txtMaximum.TabIndex = 11;
            // 
            // hargaMaximum
            // 
            this.hargaMaximum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hargaMaximum.AutoSize = true;
            this.hargaMaximum.Location = new System.Drawing.Point(339, 368);
            this.hargaMaximum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hargaMaximum.Name = "hargaMaximum";
            this.hargaMaximum.Size = new System.Drawing.Size(124, 20);
            this.hargaMaximum.TabIndex = 10;
            this.hargaMaximum.Text = "Harga Maximum";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(18, 432);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1479, 335);
            this.dataGridView2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "List Paket";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 408);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "* Paket yang ditampilkan adalah 2 paket termurah";
            // 
            // Pemaketan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1515, 786);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.txtMaximum);
            this.Controls.Add(this.hargaMaximum);
            this.Controls.Add(this.txtMinimum);
            this.Controls.Add(this.labelMinimum);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lihatPaket);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Pemaketan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pemaketan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button lihatPaket;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtMinimum;
        private System.Windows.Forms.Label labelMinimum;
        private System.Windows.Forms.TextBox txtMaximum;
        private System.Windows.Forms.Label hargaMaximum;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
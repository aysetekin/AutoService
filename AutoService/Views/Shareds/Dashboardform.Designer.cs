
namespace AutoService
{
    partial class Dashboardform
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlUyeKayit = new System.Windows.Forms.Panel();
            this.btnAracKabul = new System.Windows.Forms.Button();
            this.btnKullaniciKayit = new System.Windows.Forms.Button();
            this.btnAracKayit = new System.Windows.Forms.Button();
            this.btnKullaniciListele = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlBekleyenIsEmirleri = new System.Windows.Forms.GroupBox();
            this.pnlUyeKayit.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkOrange;
            this.label1.Location = new System.Drawing.Point(522, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Auto Service";
            // 
            // pnlUyeKayit
            // 
            this.pnlUyeKayit.BackColor = System.Drawing.Color.Gray;
            this.pnlUyeKayit.Controls.Add(this.btnAracKabul);
            this.pnlUyeKayit.Controls.Add(this.btnKullaniciKayit);
            this.pnlUyeKayit.Controls.Add(this.btnAracKayit);
            this.pnlUyeKayit.Controls.Add(this.btnKullaniciListele);
            this.pnlUyeKayit.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUyeKayit.Location = new System.Drawing.Point(0, 0);
            this.pnlUyeKayit.Name = "pnlUyeKayit";
            this.pnlUyeKayit.Size = new System.Drawing.Size(147, 500);
            this.pnlUyeKayit.TabIndex = 1;
            // 
            // btnAracKabul
            // 
            this.btnAracKabul.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAracKabul.Location = new System.Drawing.Point(9, 177);
            this.btnAracKabul.Name = "btnAracKabul";
            this.btnAracKabul.Size = new System.Drawing.Size(132, 34);
            this.btnAracKabul.TabIndex = 4;
            this.btnAracKabul.Text = "Araç Kabul";
            this.btnAracKabul.UseVisualStyleBackColor = true;
            this.btnAracKabul.Click += new System.EventHandler(this.btnAracKabul_Click_1);
            // 
            // btnKullaniciKayit
            // 
            this.btnKullaniciKayit.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKullaniciKayit.Location = new System.Drawing.Point(9, 57);
            this.btnKullaniciKayit.Name = "btnKullaniciKayit";
            this.btnKullaniciKayit.Size = new System.Drawing.Size(132, 34);
            this.btnKullaniciKayit.TabIndex = 4;
            this.btnKullaniciKayit.Text = "Kullanici Kayıt";
            this.btnKullaniciKayit.UseVisualStyleBackColor = true;
            this.btnKullaniciKayit.Click += new System.EventHandler(this.btnKullaniciKayit_Click);
            // 
            // btnAracKayit
            // 
            this.btnAracKayit.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAracKayit.Location = new System.Drawing.Point(9, 137);
            this.btnAracKayit.Name = "btnAracKayit";
            this.btnAracKayit.Size = new System.Drawing.Size(132, 34);
            this.btnAracKayit.TabIndex = 4;
            this.btnAracKayit.Text = "Araç Kayıt";
            this.btnAracKayit.UseVisualStyleBackColor = true;
            this.btnAracKayit.Click += new System.EventHandler(this.btnAracKayit_Click);
            // 
            // btnKullaniciListele
            // 
            this.btnKullaniciListele.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKullaniciListele.Location = new System.Drawing.Point(9, 97);
            this.btnKullaniciListele.Name = "btnKullaniciListele";
            this.btnKullaniciListele.Size = new System.Drawing.Size(132, 34);
            this.btnKullaniciListele.TabIndex = 4;
            this.btnKullaniciListele.Text = "Kullanici Listele";
            this.btnKullaniciListele.UseVisualStyleBackColor = true;
            this.btnKullaniciListele.Click += new System.EventHandler(this.btnKullaniciListele_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(147, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(698, 58);
            this.panel1.TabIndex = 2;
            // 
            // pnlBekleyenIsEmirleri
            // 
            this.pnlBekleyenIsEmirleri.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBekleyenIsEmirleri.Location = new System.Drawing.Point(153, 97);
            this.pnlBekleyenIsEmirleri.Name = "pnlBekleyenIsEmirleri";
            this.pnlBekleyenIsEmirleri.Size = new System.Drawing.Size(1179, 199);
            this.pnlBekleyenIsEmirleri.TabIndex = 3;
            this.pnlBekleyenIsEmirleri.TabStop = false;
            this.pnlBekleyenIsEmirleri.Text = "İşlem Bekleyenler";
            this.pnlBekleyenIsEmirleri.Enter += new System.EventHandler(this.pnlBekleyenIsEmirleri_Enter);
            // 
            // Dashboardform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(845, 500);
            this.Controls.Add(this.pnlBekleyenIsEmirleri);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlUyeKayit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboardform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboardform";
            this.Load += new System.EventHandler(this.Dashboardform_Load);
            this.pnlUyeKayit.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlUyeKayit;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox pnlBekleyenIsEmirleri;
        private System.Windows.Forms.Button btnAracKabul;
        private System.Windows.Forms.Button btnKullaniciKayit;
        private System.Windows.Forms.Button btnAracKayit;
        private System.Windows.Forms.Button btnKullaniciListele;
    }
}
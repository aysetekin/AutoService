
namespace AutoService
{
    partial class AracEkleForm
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
            this.btnEkle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.cmbMarka = new System.Windows.Forms.ComboBox();
            this.txtPLaka = new System.Windows.Forms.TextBox();
            this.txtYil = new System.Windows.Forms.TextBox();
            this.txtSasiNo = new System.Windows.Forms.TextBox();
            this.txtRenk = new System.Windows.Forms.TextBox();
            this.autoServiceDataSet1 = new AutoService.AutoServiceDataSet1();
            this.markalarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.markalarTableAdapter = new AutoService.AutoServiceDataSet1TableAdapters.MarkalarTableAdapter();
            this.lblMarka = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblPLaka = new System.Windows.Forms.Label();
            this.lblYil = new System.Windows.Forms.Label();
            this.lblSasiNo = new System.Windows.Forms.Label();
            this.lblRenk = new System.Windows.Forms.Label();
            this.btnIptal = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoServiceDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.markalarBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.Black;
            this.btnEkle.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEkle.ForeColor = System.Drawing.Color.Orange;
            this.btnEkle.Location = new System.Drawing.Point(124, 348);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(80, 32);
            this.btnEkle.TabIndex = 1;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRenk);
            this.groupBox1.Controls.Add(this.lblSasiNo);
            this.groupBox1.Controls.Add(this.lblYil);
            this.groupBox1.Controls.Add(this.lblPLaka);
            this.groupBox1.Controls.Add(this.lblModel);
            this.groupBox1.Controls.Add(this.lblMarka);
            this.groupBox1.Controls.Add(this.txtRenk);
            this.groupBox1.Controls.Add(this.cmbModel);
            this.groupBox1.Controls.Add(this.txtSasiNo);
            this.groupBox1.Controls.Add(this.cmbMarka);
            this.groupBox1.Controls.Add(this.txtYil);
            this.groupBox1.Controls.Add(this.txtPLaka);
            this.groupBox1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Orange;
            this.groupBox1.Location = new System.Drawing.Point(93, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 291);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arac Ekle";
            // 
            // cmbModel
            // 
            this.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModel.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModel.ForeColor = System.Drawing.Color.Black;
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(112, 83);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(121, 26);
            this.cmbModel.TabIndex = 3;
            this.cmbModel.SelectedIndexChanged += new System.EventHandler(this.cmbModel_SelectedIndexChanged);
            // 
            // cmbMarka
            // 
            this.cmbMarka.DataSource = this.markalarBindingSource;
            this.cmbMarka.DisplayMember = "Ad";
            this.cmbMarka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarka.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMarka.FormattingEnabled = true;
            this.cmbMarka.Location = new System.Drawing.Point(112, 38);
            this.cmbMarka.Name = "cmbMarka";
            this.cmbMarka.Size = new System.Drawing.Size(121, 26);
            this.cmbMarka.TabIndex = 3;
            this.cmbMarka.ValueMember = "id";
            this.cmbMarka.SelectedIndexChanged += new System.EventHandler(this.cmbMarka_SelectedIndexChanged);
            // 
            // txtPLaka
            // 
            this.txtPLaka.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPLaka.Location = new System.Drawing.Point(112, 127);
            this.txtPLaka.Name = "txtPLaka";
            this.txtPLaka.Size = new System.Drawing.Size(121, 25);
            this.txtPLaka.TabIndex = 3;
            this.txtPLaka.Text = " ";
            // 
            // txtYil
            // 
            this.txtYil.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYil.Location = new System.Drawing.Point(112, 167);
            this.txtYil.Name = "txtYil";
            this.txtYil.Size = new System.Drawing.Size(121, 25);
            this.txtYil.TabIndex = 3;
            this.txtYil.Text = " ";
            // 
            // txtSasiNo
            // 
            this.txtSasiNo.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSasiNo.Location = new System.Drawing.Point(112, 207);
            this.txtSasiNo.Name = "txtSasiNo";
            this.txtSasiNo.Size = new System.Drawing.Size(121, 25);
            this.txtSasiNo.TabIndex = 3;
            this.txtSasiNo.Text = " ";
            // 
            // txtRenk
            // 
            this.txtRenk.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRenk.Location = new System.Drawing.Point(112, 251);
            this.txtRenk.Name = "txtRenk";
            this.txtRenk.Size = new System.Drawing.Size(121, 25);
            this.txtRenk.TabIndex = 3;
            this.txtRenk.Tag = "Renk";
            this.txtRenk.Text = " ";
            // 
            // autoServiceDataSet1
            // 
            this.autoServiceDataSet1.DataSetName = "AutoServiceDataSet1";
            this.autoServiceDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // markalarBindingSource
            // 
            this.markalarBindingSource.DataMember = "Markalar";
            this.markalarBindingSource.DataSource = this.autoServiceDataSet1;
            // 
            // markalarTableAdapter
            // 
            this.markalarTableAdapter.ClearBeforeFill = true;
            // 
            // lblMarka
            // 
            this.lblMarka.AutoSize = true;
            this.lblMarka.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarka.Location = new System.Drawing.Point(28, 41);
            this.lblMarka.Name = "lblMarka";
            this.lblMarka.Size = new System.Drawing.Size(59, 18);
            this.lblMarka.TabIndex = 4;
            this.lblMarka.Text = "Marka :";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModel.Location = new System.Drawing.Point(28, 81);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(57, 18);
            this.lblModel.TabIndex = 4;
            this.lblModel.Text = "Model :";
            // 
            // lblPLaka
            // 
            this.lblPLaka.AutoSize = true;
            this.lblPLaka.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPLaka.Location = new System.Drawing.Point(28, 125);
            this.lblPLaka.Name = "lblPLaka";
            this.lblPLaka.Size = new System.Drawing.Size(54, 18);
            this.lblPLaka.TabIndex = 4;
            this.lblPLaka.Text = "Plaka :";
            // 
            // lblYil
            // 
            this.lblYil.AutoSize = true;
            this.lblYil.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYil.Location = new System.Drawing.Point(28, 165);
            this.lblYil.Name = "lblYil";
            this.lblYil.Size = new System.Drawing.Size(39, 18);
            this.lblYil.TabIndex = 4;
            this.lblYil.Text = "Yıl :";
            // 
            // lblSasiNo
            // 
            this.lblSasiNo.AutoSize = true;
            this.lblSasiNo.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSasiNo.Location = new System.Drawing.Point(28, 205);
            this.lblSasiNo.Name = "lblSasiNo";
            this.lblSasiNo.Size = new System.Drawing.Size(67, 18);
            this.lblSasiNo.TabIndex = 4;
            this.lblSasiNo.Text = "Saşi No :";
            // 
            // lblRenk
            // 
            this.lblRenk.AutoSize = true;
            this.lblRenk.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenk.Location = new System.Drawing.Point(28, 249);
            this.lblRenk.Name = "lblRenk";
            this.lblRenk.Size = new System.Drawing.Size(51, 18);
            this.lblRenk.TabIndex = 4;
            this.lblRenk.Text = "Renk :";
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.Black;
            this.btnIptal.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIptal.ForeColor = System.Drawing.Color.Orange;
            this.btnIptal.Location = new System.Drawing.Point(246, 348);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(80, 32);
            this.btnIptal.TabIndex = 1;
            this.btnIptal.Text = "Iptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // AracEkleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(435, 464);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnEkle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AracEkleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AracEkleForm";
            this.Load += new System.EventHandler(this.AracEkleForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoServiceDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.markalarBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.ComboBox cmbMarka;
        private System.Windows.Forms.TextBox txtRenk;
        private System.Windows.Forms.TextBox txtSasiNo;
        private System.Windows.Forms.TextBox txtYil;
        private System.Windows.Forms.TextBox txtPLaka;
        private AutoServiceDataSet1 autoServiceDataSet1;
        private System.Windows.Forms.BindingSource markalarBindingSource;
        private AutoServiceDataSet1TableAdapters.MarkalarTableAdapter markalarTableAdapter;
        private System.Windows.Forms.Label lblRenk;
        private System.Windows.Forms.Label lblSasiNo;
        private System.Windows.Forms.Label lblYil;
        private System.Windows.Forms.Label lblPLaka;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblMarka;
        private System.Windows.Forms.Button btnIptal;
    }
}
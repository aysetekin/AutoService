using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoService
{
    public partial class AracEkleForm : Form
    {
        public int _kullaniciID { get; set; }

        public AracEkleForm(int KullaniciID)
        {
            _kullaniciID = KullaniciID;
            InitializeComponent();
        }

        private void AracEkleForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'autoServiceDataSet1.Markalar' table. You can move, or remove it, as needed.
            this.markalarTableAdapter.Fill(this.autoServiceDataSet1.Markalar);

        }


        private void cmbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMarka.SelectedValue != null)
            {
                cmbModel.DataSource = AracModelController.Getir((int)cmbMarka.SelectedValue);
                cmbModel.ValueMember = "id";
                cmbModel.DisplayMember = "Ad";
            }
        }

        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SqlConnection conn = db.conn();
            //SqlCommand cmd = new SqlCommand("select  idiad from Modeller Where MarkaID=@markaid) ", conn);
            //cmd.Parameters.AddWithValue("@markaid", (int)cmbMarka.SelectedValue);

            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
            //da.Fill(dt);
          


        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (AracControllers.Ekle(new Arac { KullaniciID = _kullaniciID, ModelID = (int)cmbModel.SelectedValue, Plaka = txtPLaka.Text, Renk = txtRenk.Text, SasiNo = txtSasiNo.Text, Yil = int.Parse(txtYil.Text) }))
            {
                MesajKutusu kutu = new MesajKutusu("BAŞARILI", "ARaç Başarıyla Eklenmiştir", MesajIkon.Uyari, MesajButton.Tamam);
                kutu.ShowDialog();
                kutu.Dispose();
            }
            else
            {
                MesajKutusu kutu = new MesajKutusu("HATA", "ARaçEklenirken Hata Oluştu", MesajIkon.Uyari, MesajButton.Tamam);
                kutu.ShowDialog();
            }
           ;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }
    }
}

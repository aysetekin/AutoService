using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoService
{
    public partial class KullaniciKayitformu : Form
    {
        public KullaniciKayitformu()
        {
            InitializeComponent();
        }

        private void KullaniciKayitformu_Load(object sender, EventArgs e)
        {

        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                grpKurumsal.Enabled = true;
            }
            else
            {
                grpKurumsal.Enabled = false;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (KullaniciController.Ekle(new Kullanici() { Ad = txtAd.Text, Soyad = txtSoyad.Text, Adres = txtAdres.Text, Email = txtEmail.Text, Gsm = maskedGsm.Text, Sifre = txtSifre.Text, TicariUnvan = txtTicariUnvan.Text, VergiDairesi = txtVergiDaire.Text, VergiNo = txtVergiNo.Text, Durum = true, KullaniciTipi = 1, MusteriTipi = btnKurumsal.Checked ? (short)1 : (short)0 }))
            {
                MesajKutusu kutu = new MesajKutusu("Başarılı", "Başarılı Giriş Yaptınız", MesajIkon.Hata, MesajButton.Tamam);
                kutu.ShowDialog();
                if (kutu._cevap == MesajKutusuCevap.Tamam)
                {
                    this.Dispose();
                    kutu.Dispose();
                }
                else
                {
                   kutu = new MesajKutusu("Hata", "Kullanıcı Eklenemedi", MesajIkon.Hata, MesajButton.Tamam);
                    kutu.ShowDialog();
                    kutu.Dispose();

                }
            }

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox)
                {
                    foreach (Control ctl in this.Controls)
                    {
                        if (ctl is TextBox || ctl is MaskedTextBox)
                            ctl.Text = string.Empty;
                        else if (ctl is RadioButton)
                            ((RadioButton)ctl).Checked = false;

                    }

                }
            }
        }
    }
}

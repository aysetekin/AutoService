using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoService
{
    public partial class KullaniciProfiliform : Form

    {

        public Kullanici _kul { get; set; }

        public KullaniciProfiliform(int kullaniciID)

        {
            _kul = KullaniciController.BilgileriGetir(kullaniciID);

            try
            {
                picProfilFoto.ImageLocation = Application.StartupPath + "\\dosyalar\\" + _kul.ProfilFoto;
            }
            catch
            {
            }
            string deneme = Tools.RandomString(6);
            InitializeComponent();
        }


        private void btnFotoYukle_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Title = "Lütfen bir profil fotoğrafı seçiniz";
                openFileDialog1.DefaultExt = ".png";
                openFileDialog1.Filter = "PNG|*.png|JPG|*.jpg|GIF|*.gif";


                if (!Directory.Exists(Application.StartupPath + "\\dosyalar\\"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\dosyalar\\");

                }
                DialogResult sonuc = openFileDialog1.ShowDialog();

                if (sonuc == DialogResult.OK)
                {
                    //File.Create(Aplication.);
                    Image img = Image.FromFile(openFileDialog1.FileName);

                    string extension = Path.GetExtension(openFileDialog1.FileName);
                    string dosyaAdi = _kul.id + "-" + Tools.TurkceKarakterTemizle(_kul.Ad) + "-" + Tools.TurkceKarakterTemizle(_kul.Soyad) + "-ProfilFoto-" + Tools.RandomString(6) + extension;


                    img.Save(Application.StartupPath + "\\dosyalar\\" + dosyaAdi);



                    picProfilFoto.Image = img;

                    KullaniciController.ProfilFotoGuncelle(dosyaAdi, _kul.id);

                    if (KullaniciController.ProfilFotoGuncelle(dosyaAdi, _kul.id))
                    {
                        MesajKutusu kutu = new MesajKutusu("Başarılı", "Profil fotoğrafınız yüklenmiştir.", MesajIkon.Hata, MesajButton.Tamam);
                        kutu.ShowDialog();
                        kutu.Dispose();
                    }
                    else
                    {
                        MesajKutusu kutu = new MesajKutusu("Bir Hata Oluştu", "Fotoğraf yolu veri tabanına yazılırken hata meydana geldi.", MesajIkon.Hata, MesajButton.Tamam);
                        kutu.ShowDialog();
                        kutu.Dispose();
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        private void KullaniciProfiliform_Load(object sender, EventArgs e)
        {
            AraclariDoldur();

        }

        private void AraclariDoldur()
        {
            txtAd.Text = _kul.Ad;
            txtSoyad.Text = _kul.Soyad;
            txtEmail.Text = _kul.Email;
            txtGsm.Text = _kul.Gsm;
            txtAdres.Text = _kul.Adres;
            txtTicariUnvan.Text = _kul.TicariUnvan;
            txtVD.Text = _kul.VergiDairesi;
            txtVergiNo.Text = _kul.VergiNo;

            lstAracListesi.DataSource = AracControllers.Listele(_kul.id);
            lstAracListesi.ValueMember = "id";
            lstAracListesi.DisplayMember = "Plaka";
        }


        private void btnGoruntule_Click(object sender, EventArgs e)
        {
            AracProfiliForm aracProfilForm = new AracProfiliForm((lstAracListesi.SelectedItem as Arac).id);
            aracProfilForm.ShowDialog();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            AracEkleForm frm = new AracEkleForm(_kul.id);
            frm.ShowDialog();
            AraclariDoldur();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
       

    }
}

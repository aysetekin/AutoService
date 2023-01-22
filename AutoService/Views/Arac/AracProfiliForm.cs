using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoService
{
    public partial class AracProfiliForm : Form
    {

        public Arac _arac { get; set; }
        public object HtmlConverter { get; private set; }

        public AracProfiliForm(int aracID)
        {
            _arac = AracControllers.Getir(aracID);

            InitializeComponent();

        }

        private void AracProfiliForm_Load(object sender, EventArgs e)
        {
            AracBilgileriniDoldur();

        }

        private void AracBilgileriniDoldur()
        {
            lblModel.Text = _arac.Model.Ad;
            lblPlaka.Text = _arac.Plaka;
            lblRenk.Text = _arac.Renk;
            lblSasiNo.Text = _arac.SasiNo;
            lblYil.Text = _arac.Yil.ToString();
            DosyalariDoldur();
        }

        private void DosyalariDoldur()
        {

            List<DosyaKatagori> dosyaKategoris = DosyaKategoriController.List();
            dosyaKategoris.Add(new DosyaKatagori { id = 0, Ad = "Hepsi" });
            ddlKlasorler.DataSource = dosyaKategoris;

            ddlKlasorler.ValueMember = "id";
            ddlKlasorler.DisplayMember = "Ad";
            ddlKlasorler.SelectedValue = 0;
            lstbDosyalar.DataSource = _arac.Dosyalar;
            lstbDosyalar.ValueMember = "id";
            lstbDosyalar.DisplayMember = "Ad";

            FotolariDoldur();
        }


        private void FotolariDoldur()
        {
            pnlFotolar.Controls.Clear();
            foreach (Foto f in _arac.Fotolar)
            {
                FlowLayoutPanel pnlPicture = new FlowLayoutPanel();
                pnlPicture.FlowDirection = FlowDirection.TopDown;
                pnlPicture.Width = 100;
                pnlPicture.Height = 170;




                FileStream file = new FileStream(Application.StartupPath + "\\AracFotolari\\" + f.AracID + "\\" + f.Path, FileMode.Open, FileAccess.Read);


                PictureBox pic = new PictureBox();

                pic.Image = Image.FromStream(file);

                pic.Width = 100;
                pic.Height = 100;
                pic.Name = "pictureBox-" + f.id;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.DoubleClick += Pic_DoubleClick;

                pnlPicture.Controls.Add(pic);
                file.Close();

                Button btn = new Button();
                btn.Text = "Sil";
                btn.Tag = f;
                btn.ForeColor = Color.White;
                btn.BackColor = Color.Red;
                btn.Width = 50;
                btn.Height =50;
                btn.Click += Btn_Click;
                pnlPicture.Controls.Add(btn);



                pnlFotolar.Controls.Add(pnlPicture);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {


            FotoController.Sil((((sender as Button).Tag) as Foto));
            _arac.Fotolar = FotoController.Getir(_arac.id);
            FotolariDoldur();

        }

        private void Pic_DoubleClick(object sender, EventArgs e)
        {

            FotoGosterForm frm = new FotoGosterForm((sender as PictureBox).Image);
            frm.ShowDialog();
        }

        private void btnYukle_Click(object sender, EventArgs e)
        {

            if (((DosyaKatagori)ddlKlasorler.SelectedItem).id != 0)
            {
                if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\AracDosyalari\\" + _arac.id + "\\" + ((DosyaKatagori)ddlKlasorler.SelectedItem).Ad))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\AracDosyalari\\" + _arac.id + "\\" + ((DosyaKatagori)ddlKlasorler.SelectedItem).Ad);
                }

                string dosyaAdi = Tools.TurkceKarakterTemizle(Tools.RandomString(6) + "-" + openFileDialog1.SafeFileName);

                File.Copy(openFileDialog1.FileName, Directory.GetCurrentDirectory() + "\\AracDosyalari\\" + _arac.id + "\\" + ((DosyaKatagori)ddlKlasorler.SelectedItem).Ad + "\\" + dosyaAdi);
                if (DosyaController.DosyaKaydet(new Dosya
                {
                    Ad = dosyaAdi,
                    AracID = _arac.id,
                    KategoriID = ((DosyaKatagori)ddlKlasorler.SelectedItem).id,
                    Path = dosyaAdi
                }))
                {
                    MesajKutusu kutu = new MesajKutusu("Başarılı", "Dosya yükleme başarıyla tamamlanmıştır", MesajIkon.Uyari, MesajButton.Tamam);
                    kutu.ShowDialog();

                    _arac.Dosyalar = DosyaController.ListeGetir(_arac.id);
                    lstbDosyalar.DataSource = _arac.Dosyalar.Where(d => d.KategoriID.ToString() == ddlKlasorler.SelectedValue.ToString()).ToList();
                }
            }
            else
            {
                MesajKutusu kutu = new MesajKutusu("hata", "Lütfen bir klasör seciniz", MesajIkon.Uyari, MesajButton.Tamam);
                kutu.ShowDialog();
            }

        }

        private void lstbDosyalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnSil.Visible == false)
            {
                grpDosyalar.Height += btnSil.Height + 15;
                btnSil.Visible = true;
            }
            //else
            //{
            //    grpDosyalar.Height += btnSil.Height + 15;
            //    btnSil.Visible = false;
            //}

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Dosya dosya= lstbDosyalar.SelectedItem as Dosya;
            if (dosya!=null)
            {
                DosyaController.DosyaSil(dosya);
                _arac.Dosyalar = DosyaController.ListeGetir(_arac.id);
                DosyalariDoldur();
            }
        }

        private void ddlKlasorler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlKlasorler.SelectedItem != null)
            {
                if (((DosyaKatagori)ddlKlasorler.SelectedItem).id == 0)
                {
                    lstbDosyalar.DataSource = _arac.Dosyalar;
                }
                else
                {
                    lstbDosyalar.DataSource = _arac.Dosyalar.Where(d => d.KategoriID == ((DosyaKatagori)ddlKlasorler.SelectedItem).id).ToList<Dosya>();

                    //lamda operetörü"=>" budadaki d bizim değişken adımız.(linq de oluyo bunlar)
                }
            }
        }

        private void ddlKlasor_Click(object sender, EventArgs e)
        {
            if (grpYukle.Visible == false)
            {
                grpYukle.Location = grpDosyalar.Location;
                grpDosyalar.Location = new Point
                {
                    X = grpDosyalar.Location.X,
                    Y = grpDosyalar.Location.Y + grpYukle.Size.Height
                };
                grpYukle.Visible = true;
            }
            else
            {
                grpDosyalar.Location = new Point
                {
                    X = grpDosyalar.Location.X,
                    Y = grpDosyalar.Location.Y - grpYukle.Size.Height
                };
                grpYukle.Visible = false;
            }
        }

        private void btnGozat_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textDosya.Text = openFileDialog1.FileName;

        }

        private void lstbDosyalar_DoubleClick(object sender, EventArgs e)
        {

            Dosya dosya = lstbDosyalar.SelectedItem as Dosya;
            Process.Start(Application.StartupPath + "\\AracDosyalari\\" + _arac.id + "\\" + dosya.KategoriAdi + "\\" + dosya.Path);

        }

        private void picBox_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\AracFotolari\\" + _arac.id))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\AracFotolari\\" + _arac.id);
            }

            string dosyaAdi = Tools.TurkceKarakterTemizle(Tools.RandomString(6) + "-" + openFileDialog1.SafeFileName);

            File.Copy(openFileDialog1.FileName, Directory.GetCurrentDirectory() + "\\AracFotolari\\" + _arac.id + "\\" + dosyaAdi);

            if (FotoController.FotoKaydet(new Foto
            {
                Ad = dosyaAdi,
                AracID = _arac.id,
                Path = dosyaAdi
            }))
            {
                MesajKutusu kutu = new MesajKutusu("Başarılı", "Fotoğraf yükleme başarıyla tamamlanmıştır", MesajIkon.Uyari, MesajButton.Tamam);
                kutu.ShowDialog();

                _arac.Fotolar = FotoController.ListeGetir(_arac.id);
                FotolariDoldur();
            }
            else
            {
                MesajKutusu kutu = new MesajKutusu("hata", "Lütfen bir fotoğraf seciniz", MesajIkon.Uyari, MesajButton.Tamam);
                kutu.ShowDialog();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
             this.Dispose();
        }
    }
}

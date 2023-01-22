using System;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using PdfSharp.Pdf.IO;

namespace AutoService
{
    public partial class IsEmriAracKabulForm : Form
    {
        public List<Arac> _araclar { get; set; }
        //public int _seciliAracID { get; set; }
        public Arac _seciliAracID { get; set; }
        public IsEmriAracKabulForm()
        {
            _araclar = AracControllers.TumunuGetir();

            InitializeComponent();
            ddlIsEmriTuru.DataSource = IsEmriTuruController.Listele();
            ddlIsEmriTuru.ValueMember = "id";
            ddlIsEmriTuru.DisplayMember = "Ad";

        }
        private void txtAracPlakasi_TextChanged(object sender, EventArgs e)
        {
            ////3.yol
            Arac arc = _araclar.Find(a => a.Plaka.ToUpper() == txtAracPlakasi.Text.ToUpper());
            if (arc != null)
            {
                txtModel.Text = arc.Model.Ad;
                txtPlaka.Text = arc.Plaka;
                txtRenk.Text = arc.Renk;
                txtSasiNo.Text = arc.SasiNo;
                txtYil.Text = arc.Yil.ToString();
            }
            else
            {
                txtModel.Text = "";
                txtPlaka.Text = "";
                txtRenk.Text = "";
                txtSasiNo.Text = "";
                txtYil.Text = "";
            }



            ////2.yol
            //try
            //{
            //    Arac arc = _araclar.Where(a => a.Plaka.ToUpper() == txtAracPlakasi.Text.ToUpper()).ToList().Single();

            //    txtModel.Text = arc.Model.Ad;
            //    txtPlaka.Text = arc.Plaka;
            //    txtRenk.Text = arc.Renk;
            //    txtSasiNo.Text = arc.SasiNo;
            //    txtYil.Text = arc.Yil.ToString();

            //}
            //catch 
            //{}



            ////1.yol
            //    List<Arac> liste =_araclar.Where(a => a.Plaka.ToUpper() == txtAracPlakasi.Text.ToUpper()).ToList();

            //    if (liste.Count>0)
            //    {
            //        txtModel.Text = liste[0].Model.Ad;
            //        txtPlaka.Text = liste[0].Plaka;
            //        txtRenk.Text = liste[0].Renk;
            //        txtSasiNo.Text = liste[0].SasiNo;
            //        txtYil.Text = liste[0].Yil.ToString();
            //    }




            ////Arac arac = AracControllers.Getir(txtAracPlakasi.Text);
            ////if (arac.id != 0)
            ////{
            ////    txtModel.Text = arac.Model.Ad;
            ////    txtPlaka.Text = arac.Plaka;
            ////    txtRenk.Text = arac.Renk;
            ////    txtSasiNo.Text = arac.SasiNo;
            ////    txtYil.Text = arac.Yil.ToString();
            ////}
            ////else
            ////{
            ////    txtModel.Text = "";
            ////    txtPlaka.Text = "";
            ////    txtRenk.Text = "";
            ////    txtSasiNo.Text = "";
            ////    txtYil.Text = "";
            ////}
        }
        private void btnKabul_Click(object sender, EventArgs e)
        {
            if (ddlIsEmriTuru.SelectedValue.ToString() != "0")
            {
                if (IsEmriController.Ekle(new IsEmri { Aciklama = txtAciklama.Text, TeslimAlan = txtTeslimAlan.Text, TeslimEden = txtTeslimEden.Text, IsEmriTuru = (IsEmriTuru)ddlIsEmriTuru.SelectedItem, Durum = 0,   Arac=_seciliAracID}))
                {
                    PdfOlustur();
                    MesajKutusu kutu = new MesajKutusu("Başarılı", "Kayıt Başarılı. Farklı bir kayıt eklemek istiyor musunuz?", MesajIkon.Bilgi, MesajButton.EvetHayır);
                    kutu.ShowDialog();
                    if (kutu._cevap == MesajKutusuCevap.Evet)
                    {
                        Temizle();
                    }
                    else
                    {
                        this.Dispose();
                    }
                }
                else
                {
                    MesajKutusu kutu = new MesajKutusu("Hata", "Kayıt Eklenemedi", MesajIkon.Hata, MesajButton.Tamam);
                    kutu.ShowDialog();
                }
            }

        }
        private void Temizle()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
                ddlIsEmriTuru.SelectedValue = 0;
            }
        }
        private void PdfOlustur()
        {

            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "Araç Kabul Formu";

            PdfPage sayfa = pdf.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(sayfa);
            XFont h1 = new XFont("verdna", 25, XFontStyle.Bold);
            XFont h3 = new XFont("verdna", 15, XFontStyle.Underline);
            XBrush KirmiziFirca = XBrushes.Red;
            XBrush Siyah = XBrushes.Black;
            gfx.DrawString("Arac Kabul Formu", h1, KirmiziFirca, new XRect(0, 0, sayfa.Width, sayfa.Height), XStringFormat.TopCenter);
            gfx.DrawString(DateTime.Now.ToShortDateString(), h3, Siyah, new XRect(0, 0, sayfa.Width, sayfa.Height), XStringFormat.TopLeft);
            int offsetX = 100;
            int offsetY = 100;
            gfx.DrawString("Araç Plakası", h3, Siyah, offsetX, offsetY);
            gfx.DrawString(_seciliAracID.Plaka, h3, Siyah, offsetX + 120, offsetY);
            offsetY += 20;
            gfx.DrawString("Araç Modeli", h3, Siyah, offsetX, offsetY);
            gfx.DrawString(_seciliAracID.Model.Ad, h3, Siyah, offsetX + 120, offsetY);
            offsetY += 20;
            gfx.DrawString("Açıklama", h3, Siyah, offsetX, offsetY);
            gfx.DrawString(txtAciklama.Text, h3, Siyah, offsetX + 100, offsetY);
            offsetY += 20;
            gfx.DrawString("Geliş Sebebi", h3, Siyah, offsetX, offsetY);
            gfx.DrawString((ddlIsEmriTuru.SelectedItem as IsEmriTuru).Ad, h3, Siyah, offsetX + 100, offsetY);
            offsetY += 50;
            gfx.DrawString("Teslim Alan", h3, Siyah, offsetX - 20, offsetY);
            gfx.DrawString(txtTeslimAlan.Text, h3, Siyah, offsetX - 200, offsetY - 20);
            gfx.DrawString("Teslim Alan : ", h3, Siyah, offsetX + 240, offsetY);
            gfx.DrawString(txtTeslimAlan.Text, h3, Siyah, offsetX + 240, offsetY + 20);
            string dosyaAdi = Tools.TurkceKarakterTemizle(_seciliAracID.Plaka) + "-" + Tools.RandomString(10) + ".pdf";
            pdf.Save(Directory.GetCurrentDirectory() + "\\PDFs\\" + dosyaAdi);
            Process.Start(Directory.GetCurrentDirectory() + "\\PDFs\\" + dosyaAdi);
        }
        private void btnPdf_Click(object sender, EventArgs e)
        {
            PdfOlustur();
        }
     }
}

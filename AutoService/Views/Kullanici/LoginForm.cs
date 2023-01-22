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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.KullaniciAdi!=String.Empty)
            {
                if (Properties.Settings.Default.BeniHatirla==true)
                {
                    txtKullaniciAdi.Text = Properties.Settings.Default.KullaniciAdi;
                    txtSifre.Text=Properties.Settings.Default.Sifre;
                    chkBeniHatirla.Checked = true;
                }
                else
                {
                    chkBeniHatirla.Checked = false;
                }
            }

            //string kullaniciadi = Properties.Settings.Default.KullaniciAdi;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Kullanici kul = KullaniciController.login(txtKullaniciAdi.Text, txtSifre.Text);
            if (kul.id!=0)
            {
                if (chkBeniHatirla.Checked)
                {
                    Properties.Settings.Default.KullaniciAdi = txtKullaniciAdi.Text;
                    Properties.Settings.Default.Sifre = txtSifre.Text;
                    Properties.Settings.Default.BeniHatirla = true;
                    Properties.Settings.Default.Save();


                }
                MessageBox.Show("Giriş başarılı");
            }
            else
            {
                // MessageBox.Show("Test","Başlık",MessageBoxButtons);
                MesajKutusu kutu = new MesajKutusu("Hata", "Kullanıcı adı veya şifreniz hatalıdır",MesajIkon.Hata,MesajButton.Tamam);
                kutu.ShowDialog();
                kutu.Dispose();

                
            }

            //Properties.Settings.Default.KullaniciAdi = "Ayşe";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttumForm sifremiUnutttum = new SifremiUnuttumForm();
            sifremiUnutttum.ShowDialog();
        }
    }
}

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
    public partial class Dashboardform : Form
    {
        public Dashboardform()
        {
            InitializeComponent();
        }

        private void Dashboardform_Load(object sender, EventArgs e)
        {
            BekleyenIsEmirleriniDoldur();
        }
        public void BekleyenIsEmirleriniDoldur()
        {
            pnlBekleyenIsEmirleri.Controls.Clear();

            List<IsEmri> liste = IsEmriController.Listele(0);

            foreach (IsEmri emir in liste)
            {
                IsEmriItem emr = new IsEmriItem(emir,this);
                emr.Width = 600;

                pnlBekleyenIsEmirleri.Controls.Add(emr);
            }
        }
      

     

      

        private void btnKullaniciKayit_Click(object sender, EventArgs e)
        {
            KullaniciKayitformu frm = new KullaniciKayitformu();
            frm.Show();

        }

        private void btnKullaniciListele_Click_1(object sender, EventArgs e)
        {
            KullaniciListeleform kul = new KullaniciListeleform();
            kul.ShowDialog();
        }

        private void btnAracKayit_Click(object sender, EventArgs e)
        {

        }

        private void btnAracKabul_Click_1(object sender, EventArgs e)
        {
            IsEmriAracKabulForm frm = new IsEmriAracKabulForm();
            frm.ShowDialog();

        }

        private void pnlBekleyenIsEmirleri_Enter(object sender, EventArgs e)
        {

        }
    }
}

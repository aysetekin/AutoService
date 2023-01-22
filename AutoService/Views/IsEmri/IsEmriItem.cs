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
    public partial class IsEmriItem : UserControl
    {
        public IsEmri _isEmri { get; set; }

        public Dashboardform _anaForm { get; set; }

        public IsEmriItem(IsEmri isEmri, Dashboardform anaForm)
        {
            _anaForm=anaForm  ;

            InitializeComponent();

            _isEmri = isEmri; 

            lblAciklama.Text = isEmri.Aciklama;
            lblGelisSebebi.Text = isEmri.IsEmriTuru.Ad;
            lblPlaka.Text = isEmri.Arac.Plaka;
        }

        private void pnlAciklama_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(lblAciklama.Text);
        }

        private void btnAc_Click(object sender, EventArgs e)
        {
            IslemEkleForm frm = new IslemEkleForm(_isEmri);
            frm.ShowDialog();

            _anaForm.BekleyenIsEmirleriniDoldur();

               //FlowLayoutPanel pnl = this.Parent as FlowLayoutPanel;
            //GroupBox group = pnl.Parent as GroupBox;
            //Dashboardform dashbord = group.Parent as Dashboardform;
            //dashbord.BekleyenIsEmirleriniDoldur();


        }
    }
}

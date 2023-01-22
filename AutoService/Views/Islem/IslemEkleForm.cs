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
    public partial class IslemEkleForm : Form
    {
        public List<Islem> islemListesiDDL { get; set; } = IslemControler.Listele();

        public BindingList<Islem> islemListesiLst { get; set; } = new BindingList<Islem>();
        public IsEmri IsEmri { get; set; }

        public IslemEkleForm(IsEmri emr)
        {
            IsEmri = emr;
            InitializeComponent();
        }

        

        private void IslemEkleForm_Load(object sender, EventArgs e)
        {
            lstYapilacakIslemler.DataSource = islemListesiLst;
            lstYapilacakIslemler.ValueMember = "Id";
            lstYapilacakIslemler.DisplayMember = "Ad";

            cmbIslemler.DataSource = islemListesiDDL.Where(i => !islemListesiLst.Any(x => x.Id == i.Id)).ToList<Islem>();
            cmbIslemler.DisplayMember = "Ad";
            cmbIslemler.ValueMember = "Id";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            islemListesiLst.Add(cmbIslemler.SelectedItem as Islem);
            Bind();

            //lstYapilacakIslemler.DataSource = islemListesiLst;
            //lstYapilacakIslemler.ValueMember = "Id";
            //lstYapilacakIslemler.DisplayMember = "Ad";
            //lstYapilacakIslemler.Refresh();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            islemListesiLst.Remove(lstYapilacakIslemler.SelectedItem as Islem);
            Bind();
        }

        private void Bind()
        {
            cmbIslemler.DataSource = islemListesiDDL.Where(i => !islemListesiLst.Any(x => x.Id == i.Id)).ToList<Islem>();
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            IslemControler.TopluEkle(IsEmri, islemListesiLst);
            this.Dispose();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {

        }
    }
}

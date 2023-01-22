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
    public partial class MesajKutusu : Form
    {
        public string _baslik { get; set; }

        public string _mesaj { get; set; }

        public  MesajIkon _ikon { get; set; }

        public MesajKutusuCevap _cevap { get; set; }

        public MesajKutusu(string mesaj,string baslik, MesajIkon ikon,MesajButton button)
        {
            InitializeComponent();
            
            _baslik = baslik;
            _mesaj = mesaj;
            _ikon = ikon;


            lblBaslik.Text = _baslik;
            lblMesaj.Text = _mesaj;

            if (ikon==MesajIkon.Hata)
            {
                picIkon.Image = Properties.Resources.error;
            }
            if (button==MesajButton.Tamam)
            {
                btnTamam.Visible = true;

            }
            else if (button == MesajButton.EvetHayır)
            {
               btnEvet.Visible = true;
                btnHayir.Visible = true;
            }


        }
        
        

        public void Goster()
        {


        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            _cevap = MesajKutusuCevap.Tamam;
            this.Close();
        }

        private void MesajKutusu_Load(object sender, EventArgs e)
        {
            
        }

        private void btnHayir_Click(object sender, EventArgs e)
        {
            _cevap = MesajKutusuCevap.Hayır;
            this.Close();
        }

        private void btnEvet_Click(object sender, EventArgs e)
        {
            _cevap = MesajKutusuCevap.Evet;
            this.Close();

        }
    }
}

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
    public partial class KullaniciListeleform : Form
    {
        public KullaniciListeleform()
        {
            InitializeComponent();
        }

        private void KullaniciListeleform_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'autoServiceDataSet.Kullanicilar' table. You can move, or remove it, as needed.
            this.kullanicilarTableAdapter.Fill(this.autoServiceDataSet.Kullanicilar);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 9)
            {

                int i = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                KullaniciProfiliform kullanici = new KullaniciProfiliform(i);
                kullanici.ShowDialog();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

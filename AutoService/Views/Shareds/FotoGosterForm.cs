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
    public partial class FotoGosterForm : Form
    {
        public FotoGosterForm(Image img)
        {
            InitializeComponent();
            picFoto.Image = img;
        }

        private void FotoGosterForm_Load(object sender, EventArgs e)
        {

        }

        private void picFoto_Click(object sender, EventArgs e)
        {

        }
    }
}

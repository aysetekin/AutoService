using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoService.Views.Shareds
{
    public partial class MenuItem : UserControl
    {
        public MenuItem()
        {
            InitializeComponent();
            WireAllControls(this);
        }
        private void WireAllControls(Control cont)
        {
            foreach (Control ctl in cont.Controls)
            {
                ctl.Click += ctl_Click;
                if (ctl.HasChildren)
                {
                    WireAllControls(ctl);
                }
            }
        }

        private void ctl_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty);
        }
        public string Yazi
        {
            get { return lblMenuItem.Text; }
            set { lblMenuItem.Text = value; }
        }
        private void MenuItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            lblMenuItem.BackColor = Color.White;
        }

        private void lblMenuItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            lblMenuItem.BackColor = Color.White;
        }

        private void MenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkOrange;
            lblMenuItem.BackColor = Color.DarkOrange;
        }
    }
}

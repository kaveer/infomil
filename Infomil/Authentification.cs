using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infomil
{
    public partial class frmAuthentification : Form
    {
        public frmAuthentification()
        {
            InitializeComponent();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {

            frmGestionDesPersonnes r = new frmGestionDesPersonnes();
            r.btnAjouter.Text = "sdfvdfbv";
            r.Text = "fgbfgnswert6y";
            r.Show();
            r.testmodel = "dfgvdfgdfb";
            this.Hide();
        }

        private void btnAbandonner_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

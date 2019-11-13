using ConteneurDeDonnees;
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
    public partial class frmInfoClients : Form
    {
        public clsPersonne personne = new clsPersonne();
        public clsPersonne mode = new clsPersonne();

        public frmInfoClients()
        {
            InitializeComponent();
        }

        private void rdbHomme_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbFemme_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class frmGestionDesPersonnes : Form
    {
        public clsPersonne personne = new clsPersonne();

        public frmGestionDesPersonnes()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
           
        }

        private void btnVisualiser_Click(object sender, EventArgs e)
        {

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {

        }

        private void btnSeDeconnecter_Click(object sender, EventArgs e)
        {

        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {

        }

        private void frmGestionDesPersonnes_Load(object sender, EventArgs e)
        {
            var t = personne;
        }
    }
}

using ConteneurDeDonnees;
using LogiqueMetier;
using System;
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
            try
            {
                string utilisatueur = txtUtilisateur.Text.Trim();
                string motDePasse = txtMotDePasse.Text.Trim();
                clsPersonne authentifier = new clsPersonne();
                clsGestionPersonnes gestion;

                if (string.IsNullOrWhiteSpace(utilisatueur) && string.IsNullOrWhiteSpace(motDePasse))
                    throw new Exception("nom de utilisateur obligatoire");

                gestion = new clsGestionSuperviseur();
                authentifier = gestion.AuthentifierPersonne(utilisatueur, motDePasse);

                if (authentifier == null)
                    throw new Exception("Utilidateur et mot de passe invalide");

                switch (authentifier.eNiveau)
                {
                    case clsPersonne.enuNiveau.iCLIENT:
                        SupprimerEntree();

                        break;
                    case clsPersonne.enuNiveau.iCHEF_RAYON:
                        SupprimerEntree();

                        break;
                    case clsPersonne.enuNiveau.iSUPERVISEUR:
                        SupprimerEntree();

                        break;
                    default:
                        throw new Exception("Utilisateur invalide");
                }

            }
            catch (Exception ex)
            {
                SupprimerEntree();
                MessageBox.Show(ex.Message);
            }


            //if (true)
            //{

            //}
            //frmGestionDesPersonnes r = new frmGestionDesPersonnes();
            //r.btnAjouter.Text = "sdfvdfbv";
            //r.Text = "fgbfgnswert6y";
            //r.Show();
            //r.testmodel = "dfgvdfgdfb";
            //this.Hide();
        }

        private void SupprimerEntree()
        {
            txtMotDePasse.Clear();
            txtUtilisateur.Clear();
        }

        private void btnAbandonner_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

using ConteneurDeDonnees;
using LogiqueMetier;
using LogiqueMetier.Assistant;
using System;
using System.Windows.Forms;

namespace Infomil
{
    public partial class frmAuthentification : Form
    {
        /// <summary>
        /// initialization
        /// </summary>
        public frmAuthentification()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button event to validate ans exit application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValider_Click(object sender, EventArgs e)
        {
            try
            {
                string utilisatueur = txtUtilisateur.Text.Trim();
                string motDePasse = txtMotDePasse.Text.Trim();
                clsPersonne authentifier = new clsPersonne();
                clsGestionPersonnes gestion;

                if (string.IsNullOrWhiteSpace(utilisatueur) || (string.IsNullOrWhiteSpace(utilisatueur) && string.IsNullOrWhiteSpace(motDePasse)))
                    throw new Exception(clsCommun.ErreurUtilisateur);

                gestion = new clsGestionSuperviseur();
                authentifier = gestion.AuthentifierPersonne(utilisatueur, motDePasse);

                if (authentifier == null)
                    throw new Exception(clsCommun.ErreurEntree);

                switch (authentifier.eNiveau)
                {
                    case clsPersonne.enuNiveau.iCLIENT:
                        SupprimerEntree();
                        Routage(authentifier);
                        break;
                    case clsPersonne.enuNiveau.iCHEF_RAYON:
                        SupprimerEntree();
                        Routage(authentifier);
                        break;
                    case clsPersonne.enuNiveau.iSUPERVISEUR:
                        SupprimerEntree();
                        Routage(authentifier);
                        break;
                    default:
                        throw new Exception(clsCommun.ErreurUtilisateurInvalide);
                }

            }
            catch (Exception ex)
            {
                SupprimerEntree();
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAbandonner_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Routage(clsPersonne personne)
        {
            frmGestionDesPersonnes gestionDesPersonnes = new frmGestionDesPersonnes();
            frmInfoClients infoClients = new frmInfoClients();

            switch (personne.eNiveau)
            {
                case clsPersonne.enuNiveau.iCLIENT:
                    infoClients.Text = clsCommun.TitreModeclient;
                    infoClients.personne = personne;
                    infoClients.btnPrecedent.Hide();
                    infoClients.btnSuivant.Hide();
                    infoClients.personneTransaction = personne;
                    infoClients.Show();
                    this.Hide();
                    break;
                case clsPersonne.enuNiveau.iCHEF_RAYON:
                    gestionDesPersonnes.Text = clsCommun.TitreModeChefRayon;
                    gestionDesPersonnes.lblInformation.Text = clsCommun.InformationModeChefRayon;
                    gestionDesPersonnes.personne = personne;
                    gestionDesPersonnes.btnAjouter.Hide();
                    gestionDesPersonnes.btnSupprimer.Hide();
                    gestionDesPersonnes.btnVisualiser.Text = "Modifier";
                    gestionDesPersonnes.Show();
                    this.Hide();
                    break;
                default:
                    gestionDesPersonnes.Text = clsCommun.TitreModeSuperviseur;
                    gestionDesPersonnes.lblInformation.Text = clsCommun.InformationModeSuperviseur;
                    gestionDesPersonnes.personne = personne;
                    gestionDesPersonnes.Show();
                    this.Hide();
                    break;
            }
        }

        private void SupprimerEntree()
        {
            txtMotDePasse.Clear();
            txtUtilisateur.Clear();
        }

       
    }
}

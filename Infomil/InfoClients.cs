using ConteneurDeDonnees;
using LogiqueMetier;
using LogiqueMetier.Assistant;
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
        public clsPersonne personneTransaction = new clsPersonne();
        public clsPersonne personne = new clsPersonne();
        List<int> listePersonneId = new List<int>();
        clsGestionPersonnes gestion;
        clsPanier panier = new clsPanier();


        public frmInfoClients()
        {
            InitializeComponent();
            this.dgPanier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgPanier.MultiSelect = false;
            this.dgPanier.RowHeadersVisible = false;
        }

        private void rdbHomme_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbFemme_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmInfoClients_Load(object sender, EventArgs e)
        {
            try
            {
                if (personne == null || personne.iID <= 0)
                    throw new Exception(clsCommun.ErreurApplicationGeneric);

                if (personne.eNiveau == clsPersonne.enuNiveau.iCLIENT)
                    personneTransaction = personne;

                if (personneTransaction.iID > 0)
                {
                    RecupererPersonneParNiveau();

                    if (panier == null || panier.objPersonnes == null || panier.objPersonnes.iID <= 0)
                        throw new Exception(clsCommun.ErreurRecupererPersonne);

                    AttribuerValeur(panier);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                frmAuthentification authentification = new frmAuthentification();
                authentification.Show();
                this.Hide();
            }
        }

        private void RecupererPersonneParNiveau(bool estAnnuler = false)
        {
            switch (personne.eNiveau)
            {
                case clsPersonne.enuNiveau.iCLIENT:
                case clsPersonne.enuNiveau.iSUPERVISEUR:
                    gestion = new clsGestionSuperviseur();
                    panier = gestion.RecupererPanierPersonne(personneTransaction.iID);
                    if (!estAnnuler)
                        listePersonneId = RecupererListPersonParId(personne);
                    break;
                case clsPersonne.enuNiveau.iCHEF_RAYON:
                    gestion = new clsGestionChefRayon();
                    panier = gestion.RecupererPanierPersonne(personneTransaction.iID);
                    if (!estAnnuler)
                        listePersonneId = RecupererListPersonParId(personne);
                    break;
                default:
                    throw new Exception(clsCommun.ErreurApplicationGeneric);
            }
        }

        private List<int> RecupererListPersonParId(clsPersonne personne)
        {
            List<int> resultat = new List<int>();
            clsGestionPersonnes gestion;
            DataTable tableDeDonnees = new DataTable();

            switch (personne.eNiveau)
            {
                case clsPersonne.enuNiveau.iCLIENT:
                    break;
                case clsPersonne.enuNiveau.iCHEF_RAYON:
                    gestion = new clsGestionChefRayon();
                    tableDeDonnees = gestion.RecupererListePersonnes(personne.iID);
                    break;
                case clsPersonne.enuNiveau.iSUPERVISEUR:
                    gestion = new clsGestionSuperviseur();
                    tableDeDonnees = gestion.RecupererListePersonnes(personne.iID);
                    break;
                default:
                    break;
            }

            if (tableDeDonnees == null || tableDeDonnees.Rows.Count <= 0)
                return resultat;

            foreach (DataRow item in tableDeDonnees.Rows)
            {
                resultat.Add(Convert.ToInt32(item[0]));
            }

            return resultat;
        }

        private void AttribuerValeur(clsPanier resultat)
        {
            if (personneTransaction.iID == 0)
            {
                txtNom.Clear();
                txtPrenom.Clear();
                txtAddresse.Clear();
                rdbHomme.Checked = false;
                rdbFemme.Checked = false;
                dpDateNaissance.Value = DateTime.Now;

                return;
            }

            if (resultat.lstArticles.Count > 0)
                dgPanier.DataSource = resultat.lstArticles;

            if (resultat.objPersonnes != null || resultat.objPersonnes.iID > 0)
            {
                txtNom.Text = resultat.objPersonnes.sNom;
                txtPrenom.Text = resultat.objPersonnes.sPrenom;
                txtAddresse.Text = resultat.objPersonnes.sAdresse;

                switch (resultat.objPersonnes.eSexe)
                {
                    case clsPersonne.enuSexe.iHOMME:
                        rdbHomme.Checked = true;
                        break;
                    case clsPersonne.enuSexe.iFEMME:
                        rdbFemme.Checked = true;
                        break;
                    default:
                        break;
                }

                dpDateNaissance.Value = resultat.objPersonnes.dDateNaissance;
            }
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            try
            {
                if (personne == null || personne.iID <= 0)
                    throw new Exception(clsCommun.ErreurApplicationGeneric);

                if (personne.eNiveau == clsPersonne.enuNiveau.iCLIENT)
                    personneTransaction = personne;

                if (personneTransaction.iID > 0)
                {
                    RecupererPersonneParNiveau();

                    if (panier == null || panier.objPersonnes == null || panier.objPersonnes.iID <= 0)
                        throw new Exception(clsCommun.ErreurRecupererPersonne);

                }

                AttribuerValeur(panier);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                frmAuthentification authentification = new frmAuthentification();
                authentification.Show();
                this.Hide();
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            try
            {
                if (personneTransaction == null || personneTransaction.iID < 0)
                    throw new Exception(clsCommun.ErreurApplicationGeneric);

                if(!EstValabe())
                {
                    MessageBox.Show(clsCommun.ErreurValidationClients);
                    return;
                }

                switch (personne.eNiveau)
                {

                    case clsPersonne.enuNiveau.iSUPERVISEUR:
                    case clsPersonne.enuNiveau.iCLIENT:
                        if (personneTransaction.iID == 0 && personne.eNiveau == clsPersonne.enuNiveau.iCLIENT)
                            goto default;

                        gestion = new clsGestionSuperviseur();
                        if (personneTransaction.iID == 0)
                            gestion.CreerPersonne(personneTransaction);
                        else
                            gestion.ModifierPersonnes(personneTransaction);

                        break;
                    case clsPersonne.enuNiveau.iCHEF_RAYON:
                        if (personneTransaction.iID == 0)
                            goto default;

                        gestion = new clsGestionChefRayon();
                        gestion.ModifierPersonnes(personneTransaction);

                        break;
                    default:
                        throw new Exception(clsCommun.ErreurUtilisateurInvalide);
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                frmAuthentification authentification = new frmAuthentification();
                authentification.Show();
                this.Hide();
            }
        }

        private bool EstValabe()
        {
            bool resultat = true;

            if (string.IsNullOrWhiteSpace(txtNom.Text))
                return false;
            if (string.IsNullOrWhiteSpace(txtPrenom.Text))
                return false;
            if (string.IsNullOrWhiteSpace(txtAddresse.Text))
                return false;
            if (!rdbHomme.Checked && !rdbFemme.Checked)
                return false;

            personneTransaction.sNom = txtNom.Text.Trim();
            personneTransaction.sPrenom = txtPrenom.Text.Trim();
            personneTransaction.sAdresse = txtAddresse.Text.Trim();

            if (rdbHomme.Checked)
                personneTransaction.eSexe = clsPersonne.enuSexe.iHOMME;
            else
                personneTransaction.eSexe = clsPersonne.enuSexe.iFEMME;

            personneTransaction.dDateNaissance = dpDateNaissance.Value;

            return resultat;
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {

        }

        private void btnPrecedent_Click(object sender, EventArgs e)
        {

        }
    }
}

using ConteneurDeDonnees;
using LogiqueMetier;
using LogiqueMetier.Assistant;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Infomil
{
    public partial class frmInfoClients : Form
    {
        /// <summary>
        /// declare and initialize global variable
        /// </summary>
        public clsPersonne personneTransaction = new clsPersonne();
        public clsPersonne personne = new clsPersonne();
        List<int> listePersonneId = new List<int>();
        clsGestionPersonnes gestion;
        clsPanier panier = new clsPanier();
        int ConteurIndice;

        /// <summary>
        /// initialization of components
        /// </summary>
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

        /// <summary>
        /// retrieve client information if id > 0
        /// skip retrieve if id = 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// retrieve client details based on id
        /// assign value to textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// perform validation of input data
        /// if id > 0 update client info based on id
        /// if id = 0 add new client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValider_Click(object sender, EventArgs e)
        {
            try
            {
                if (personneTransaction == null || personneTransaction.iID < 0)
                    throw new Exception(clsCommun.ErreurApplicationGeneric);

                if (!ValiderEtAttribuerValeur())
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

        /// <summary>
        /// navigate through clients 
        /// clients are retrieve based on user role in load method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuivant_Click(object sender, EventArgs e)
        {
            try
            {
                ConteurIndice++;
                RecupererIdParIndice(ConteurIndice, "suivant");

                if (panier == null || panier.objPersonnes == null || panier.objPersonnes.iID <= 0)
                    throw new Exception(clsCommun.ErreurRecupererPersonne);

                AttribuerValeur(panier);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            try
            {
                ConteurIndice--;
                RecupererIdParIndice(ConteurIndice, "precedent");

                if (panier == null || panier.objPersonnes == null || panier.objPersonnes.iID <= 0)
                    throw new Exception(clsCommun.ErreurRecupererPersonne);

                AttribuerValeur(panier);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecupererIdParIndice(int indice, string SufixerreurSufix)
        {

            if (listePersonneId.Count == 0)
                throw new Exception(string.Format(clsCommun.ErreurNavigationClient, "pour naviguer"));
            if (indice < 0)
            {
                ConteurIndice = 0;
                throw new Exception(string.Format(clsCommun.ErreurNavigationClient, SufixerreurSufix));
            }
            if (indice > (listePersonneId.Count - 1))
            {
                ConteurIndice = listePersonneId.Count - 1;
                throw new Exception(string.Format(clsCommun.ErreurNavigationClient, SufixerreurSufix));
            }

            //int iID = listePersonneId[indexCounter];
            personneTransaction.iID = listePersonneId.ElementAt(indice);
            RecupererPersonneParNiveau(true);
        }

        /// <summary>
        /// assign value to text box
        /// </summary>
        /// <param name="resultat"></param>
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

            if (resultat.lstArticles?.Count > 0)
                dgPanier.DataSource = resultat.lstArticles;
            else
                dgPanier.DataSource = null;

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

        /// <summary>
        /// retrieve client info baased on id 
        /// retrieve list of clients based on authenticator role
        /// </summary>
        /// <param name="SauterRecupererlistPersonne"></param>
        private void RecupererPersonneParNiveau(bool SauterRecupererlistPersonne = false)
        {
            switch (personne.eNiveau)
            {
                case clsPersonne.enuNiveau.iCLIENT:
                case clsPersonne.enuNiveau.iSUPERVISEUR:
                    gestion = new clsGestionSuperviseur();
                    panier = gestion.RecupererPanierPersonne(personneTransaction.iID);
                    if (!SauterRecupererlistPersonne && personne.eNiveau == clsPersonne.enuNiveau.iSUPERVISEUR)
                        listePersonneId = RecupererListPersonParId(personne);
                    break;
                case clsPersonne.enuNiveau.iCHEF_RAYON:
                    gestion = new clsGestionChefRayon();
                    panier = gestion.RecupererPanierPersonne(personneTransaction.iID);
                    if (!SauterRecupererlistPersonne)
                        listePersonneId = RecupererListPersonParId(personne);
                    break;
                default:
                    throw new Exception(clsCommun.ErreurApplicationGeneric);
            }

            if (listePersonneId.Count > 0)
                ConteurIndice = listePersonneId.FindIndex(x => x == personneTransaction.iID);
        }

        /// <summary>
        /// call method in business layer to retrieve list of clients
        /// retrieve list of clients based on authenticator role
        /// </summary>
        /// <param name="personne"></param>
        /// <returns></returns>
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

        /// <summary>
        /// validate input data
        /// assign textbox value to model 
        /// </summary>
        /// <returns></returns>
        private bool ValiderEtAttribuerValeur()
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

            if (personneTransaction.dDateNaissance.Date.AddYears(18) > DateTime.Today.Date)
                return false;

            return resultat;
        }

    }
}

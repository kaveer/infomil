﻿using ConteneurDeDonnees;
using LogiqueMetier;
using LogiqueMetier.Assistant;
using System;
using System.Data;
using System.Windows.Forms;

namespace Infomil
{
    public partial class frmGestionDesPersonnes : Form
    {
        public clsPersonne personne = new clsPersonne();
        private clsGestionPersonnes gestion;
        private int iID = 0;

        public frmGestionDesPersonnes()
        {
            InitializeComponent();
            this.dgDetaileClient.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDetaileClient_CellClick);
            this.dgDetaileClient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgDetaileClient.MultiSelect = false;
            this.dgDetaileClient.RowHeadersVisible = false;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            frmInfoClients clients = new frmInfoClients();
            clients.personneTransaction.iID = 0;
            clients.personne = personne;
            clients.btnPrecedent.Hide();
            clients.btnSuivant.Hide();
            clients.Text = clsCommun.TitreModeclient;
            clients.Show();
        }

        private void btnVisualiser_Click(object sender, EventArgs e)
        {
            try
            {
                if (personne == null || personne.iID <= 0)
                    throw new Exception();

                if (iID <= 0)
                    throw new NoNullAllowedException(clsCommun.ErreurClientNonSelectionner);

                frmInfoClients infoClients = new frmInfoClients();

                switch (personne.eNiveau)
                {
                    case clsPersonne.enuNiveau.iCLIENT:
                        throw new Exception();
                    case clsPersonne.enuNiveau.iCHEF_RAYON:
                        infoClients.Text = clsCommun.TitreModeChefRayon;
                        break;
                    case clsPersonne.enuNiveau.iSUPERVISEUR:
                        infoClients.Text = clsCommun.TitreModeSuperviseur;
                        break;
                    default:
                        throw new Exception();
                }

                infoClients.personne = personne;
                infoClients.personneTransaction.iID = iID;
                infoClients.Show();
                this.Close();
            }
            catch (NoNullAllowedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(clsCommun.ErreurGeneriqueQuitterApplication);
                frmAuthentification authentification = new frmAuthentification();
                authentification.Show();
                this.Close();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogue = MessageBox.Show(clsCommun.InformationSupprimerClient, clsCommun.TitreDialogueSupprimerClient, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogue == DialogResult.Yes)
                {
                    if (iID <= 0)
                        throw new Exception(clsCommun.ErreurClientNonSelectionner);

                    gestion = new clsGestionSuperviseur();
                    gestion.SupprimerPersonne(iID);

                    gestion.RecupererListePersonnes(personne.iID);
                    dgDetaileClient.DataSource = RecupereListeClients(personne);
                    ConfigureDatasource();

                    MessageBox.Show(clsCommun.SuccesSupprimerClient);
                }

                if (dialogue == DialogResult.No)
                    throw new Exception(clsCommun.InformationSupprimerClientAnnuler);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSeDeconnecter_Click(object sender, EventArgs e)
        {
            frmAuthentification authentification = new frmAuthentification();
            authentification.Show();
            this.Close();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmGestionDesPersonnes_Load(object sender, EventArgs e)
        {
            try
            {
                if (personne == null || personne.iID <= 0)
                    throw new Exception();

                switch (personne.eNiveau)
                {
                    case clsPersonne.enuNiveau.iCLIENT:
                        throw new Exception();
                    case clsPersonne.enuNiveau.iCHEF_RAYON:
                        dgDetaileClient.DataSource = RecupereListeClients(personne);
                        break;
                    case clsPersonne.enuNiveau.iSUPERVISEUR:
                        dgDetaileClient.DataSource = RecupereListeClients(personne);
                        break;
                    default:
                        throw new Exception();
                }

                ConfigureDatasource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(clsCommun.ErreurGeneriqueQuitterApplication);
                frmAuthentification authentification = new frmAuthentification();
                authentification.Show();
                this.Close();
            }
        }

        private void ConfigureDatasource()
        {
            if (dgDetaileClient.Rows.Count > 0)
            {
                this.dgDetaileClient.Columns[0].Visible = false;
                iID = Convert.ToInt32(dgDetaileClient.SelectedRows[0].Cells[0].Value);
            }
        }

        private DataTable RecupereListeClients(clsPersonne personne)
        {
            DataTable resultat = new DataTable();

            switch (personne.eNiveau)
            {
                case clsPersonne.enuNiveau.iSUPERVISEUR:
                    gestion = new clsGestionSuperviseur();
                    resultat = gestion.RecupererListePersonnes(personne.iID);
                    break;
                case clsPersonne.enuNiveau.iCHEF_RAYON:
                    gestion = new clsGestionChefRayon();
                    resultat = gestion.RecupererListePersonnes(personne.iID);
                    break;
            }

            return resultat;
        }

        private void dgDetaileClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetaileClient.Rows.Count > 0)
            {
                iID = Convert.ToInt32(dgDetaileClient.SelectedRows[0].Cells[0].Value);
            }

        }
    }
}

﻿using ConteneurDeDonnees;
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
    public partial class frmGestionDesPersonnes : Form
    {
        public clsPersonne personne = new clsPersonne();
        private clsGestionPersonnes gestion;

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
            try
            {
                if (personne == null || personne.iID <= 0)
                    throw new Exception();

                switch (personne.eNiveau)
                {
                    case clsPersonne.enuNiveau.iCLIENT:
                        throw new Exception();
                    case clsPersonne.enuNiveau.iCHEF_RAYON:
                        dgDetaileClient.DataSource = RecupereListeClients(personne.iID);
                        break;
                    case clsPersonne.enuNiveau.iSUPERVISEUR:
                        dgDetaileClient.DataSource = RecupereListeClients();
                        break;
                    default:
                        throw new Exception();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(clsCommun.ErreurGeneriqueQuitterApplication);
                frmAuthentification authentification = new frmAuthentification();
                authentification.Show();
                this.Close();
            }
        }

        private DataTable RecupereListeClients(int iID = 0)
        {
            DataTable resultat = new DataTable();

            if (iID == 0)
            {
                gestion = new clsGestionSuperviseur();
                resultat = gestion.RecupererListePersonnes();
            }
            else
            {
                gestion = new clsGestionChefRayon();
                resultat = gestion.RecupererListePersonnes(iID);
            }

            return resultat;
        }
    }
}

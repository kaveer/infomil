using AccesAuxDonnees;
using ConteneurDeDonnees;
using LogiqueMetier.Assistant;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public class clsGestionSuperviseur : clsGestionPersonnes
    {
        private clsPersonnesAccesDonnees accesDonnees;

        public override void CreerPersonne(clsPersonne personne)
        {
            if (!EstValabe(personne))
                throw new Exception(clsCommun.ErreurValidationClients);

            accesDonnees = new clsSuperviseurAccesDonnees();
            accesDonnees.CreerPersonnes(personne);
            
        }

        private bool EstValabe(clsPersonne personne)
        {
            bool resultat = true;
            var date = DateTime.Now;

            if (personne.iID > 0)
                return false;
            if (string.IsNullOrWhiteSpace(personne.sNom))
                return false;
            if (string.IsNullOrWhiteSpace(personne.sAdresse))
                return false;
            switch (personne.eSexe)
            {
                case clsPersonne.enuSexe.iHOMME:
                case clsPersonne.enuSexe.iFEMME:
                    break;
                default:
                    return false;
            }

            if (personne.dDateNaissance == null)
                return false;

            return resultat;
        }

        public override DataTable RecupererListePersonnes(int iID)
        {
            DataTable resultat = new DataTable();
            accesDonnees = new clsSuperviseurAccesDonnees();

            resultat = accesDonnees.RecupererListePersonnes(iID);

            return resultat;
        }

        public override void SupprimerPersonne(int iID)
        {
            accesDonnees = new clsSuperviseurAccesDonnees();
            accesDonnees.SupprimerPersonne(iID);
        }
    }
}

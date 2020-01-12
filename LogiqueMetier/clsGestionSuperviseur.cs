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

        /// <summary>
        /// over ride adbstract method to create a new client
        /// validate  client info
        /// instanciate data layer abstract class
        /// call method to save client data in data layer
        /// </summary>
        /// <param name="personne"></param>
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

            if (personne.dDateNaissance.Date.AddYears(18) > DateTime.Today.Date)
                return false;

            return resultat;
        }

        /// <summary>
        /// retrieve list of client by id
        /// call method from data layer
        /// </summary>
        /// <param name="iID"></param>
        /// <returns></returns>
        public override DataTable RecupererListePersonnes(int iID)
        {
            DataTable resultat = new DataTable();
            accesDonnees = new clsSuperviseurAccesDonnees();

            resultat = accesDonnees.RecupererListePersonnes(iID);

            return resultat;
        }

        /// <summary>
        /// delete client by its id
        /// call data layer method
        /// </summary>
        /// <param name="iID"></param>
        public override void SupprimerPersonne(int iID)
        {
            accesDonnees = new clsSuperviseurAccesDonnees();
            accesDonnees.SupprimerPersonne(iID);
        }
    }
}

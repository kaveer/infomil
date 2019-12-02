using AccesAuxDonnees;
using ConteneurDeDonnees;
using System;
using System.Data;

namespace LogiqueMetier
{
    public class clsGestionChefRayon : clsGestionPersonnes
    {
        private clsPersonnesAccesDonnees accesDonnees;

        public override void CreerPersonne(clsPersonne personne)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// call method from data layer to retrieve list og clients
        /// return datatable as data type
        /// </summary>
        /// <param name="iID"></param>
        /// <returns></returns>
        public override DataTable RecupererListePersonnes(int iID)
        {
            DataTable resultat = new DataTable();
            accesDonnees = new clsChefRayonAccesDonnees();

            resultat = accesDonnees.RecupererListePersonnes(iID);

            return resultat;
        }

        public override void SupprimerPersonne(int iID)
        {
            throw new NotImplementedException();
        }
    }
}

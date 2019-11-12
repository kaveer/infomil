using AccesAuxDonnees;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public class clsGestionChefRayon : clsGestionPersonnes
    {
        private clsPersonnesAccesDonnees accesDonnees;

        public override void CreerPersonne()
        {
            throw new NotImplementedException();
        }

        public override DataTable RecupererListePersonnes(int iID)
        {
            DataTable resultat = new DataTable();
            accesDonnees = new clsChefRayonAccesDonnees();

            resultat = accesDonnees.RecupererListePersonnes(iID);

            return resultat;
        }

        public override void SupprimerPersonne()
        {
            throw new NotImplementedException();
        }
    }
}

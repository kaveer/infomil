using AccesAuxDonnees;
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

        public override void CreerPersonne()
        {
            throw new NotImplementedException();
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

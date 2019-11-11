using ConteneurDeDonnees;
using AccesAuxDonnees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LogiqueMetier
{
    public abstract class clsGestionPersonnes
    {
        public abstract void CreerPersonne();
        public abstract void RecupererListePersonnes();
        public abstract void SupprimerPersonne();

        public clsPersonne AuthentifierPersonne(string utilisatueur, string motDePasse)
        {
            clsPersonne resultat = new clsPersonne();

            try
            {
                clsPersonnesAccesDonnees gestion;
                DataTable tableDeDonnees = new DataTable();

                gestion = new clsSuperviseurAccesDonnees();
                tableDeDonnees = gestion.AuthentifierPersonne(utilisatueur, motDePasse);
                return resultat;
            }
            catch (Exception)
            {
                return resultat = null;
            }
        }

        public void ModifierPersonnes()
        {

        }

        public void RecupererPanierPersonne()
        {

        }

    }
}

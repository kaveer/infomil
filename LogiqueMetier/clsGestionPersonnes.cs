using ConteneurDeDonnees;
using AccesAuxDonnees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                clsSuperviseurAccesDonnees personne = new clsSuperviseurAccesDonnees();
                
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

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
        public abstract DataTable RecupererListePersonnes(int iID);
        public abstract void SupprimerPersonne();

        public clsPersonne AuthentifierPersonne(string utilisatueur, string motDePasse)
        {
            clsPersonne resultat = new clsPersonne();

            try
            {
                if (!Valider(utilisatueur, motDePasse))
                    throw new Exception();

                clsPersonnesAccesDonnees gestion;
                DataTable tableDeDonnees = new DataTable();

                gestion = new clsSuperviseurAccesDonnees();
                tableDeDonnees = gestion.AuthentifierPersonne(utilisatueur, motDePasse);

                if (tableDeDonnees == null)
                    throw new Exception();
                
                resultat.iID = Convert.ToInt32(tableDeDonnees.Rows[0][0]);
                resultat.eNiveau = RecupereNiveauUtilisateur(Convert.ToInt32(tableDeDonnees.Rows[0][1]));
                resultat.sNom = tableDeDonnees.Rows[0][2].ToString();
                resultat.sPrenom = tableDeDonnees.Rows[0][3].ToString();
                resultat.dDateNaissance = Convert.ToDateTime(tableDeDonnees.Rows[0][4]);
                resultat.eSexe = RecupereSexe(tableDeDonnees.Rows[0][5].ToString());
                resultat.sAdresse = tableDeDonnees.Rows[0][7].ToString();

                return resultat;
            }
            catch (Exception)
            {
                return resultat = null;
            }
        }

        private clsPersonne.enuSexe RecupereSexe(string sexe)
        {
            clsPersonne.enuSexe resultat = new clsPersonne.enuSexe();
            switch (sexe.ToUpper())
            {
                case "F":
                    resultat = clsPersonne.enuSexe.iFEMME;
                    break;
                default:
                    resultat = clsPersonne.enuSexe.iHOMME;
                    break;
            }

            return resultat;
        }

        private clsPersonne.enuNiveau RecupereNiveauUtilisateur(int niveau)
        {
            clsPersonne.enuNiveau resultat = new clsPersonne.enuNiveau();
            switch (niveau)
            {
                case (int)clsPersonne.enuNiveau.iCLIENT:
                    resultat = clsPersonne.enuNiveau.iCLIENT;
                    break;
                case (int)clsPersonne.enuNiveau.iCHEF_RAYON:
                    resultat = clsPersonne.enuNiveau.iCHEF_RAYON;
                    break;
                default:
                    resultat = clsPersonne.enuNiveau.iSUPERVISEUR;
                    break;
            }

            return resultat;
        }

        private bool Valider(string utilisatueur, string motDePasse)
        {
            bool resultat = true;
            int number;

            bool isNumeric = int.TryParse(utilisatueur, out number);
            if (!isNumeric)
                return false;

            if (!string.IsNullOrWhiteSpace(motDePasse) && motDePasse.Count() > 10)
                return false;

            return resultat;
        }

        public void ModifierPersonnes()
        {

        }

        public void RecupererPanierPersonne()
        {

        }

    }
}

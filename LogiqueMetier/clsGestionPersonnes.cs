using ConteneurDeDonnees;
using AccesAuxDonnees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LogiqueMetier.Assistant;

namespace LogiqueMetier
{
    public abstract class clsGestionPersonnes
    {
        public abstract void CreerPersonne(clsPersonne personne);
        public abstract DataTable RecupererListePersonnes(int iID);
        public abstract void SupprimerPersonne(int iID);

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

        public void ModifierPersonnes(clsPersonne personne)
        {

        }

        public clsPanier RecupererPanierPersonne(int iID)
        {
            clsPanier resultat = new clsPanier();
            DataSet dataSet = new DataSet();
            clsPersonnesAccesDonnees gestion;

            gestion = new clsSuperviseurAccesDonnees();
            dataSet = gestion.RecupererPanierPersonne(iID);

            if (dataSet?.Tables[0] == null || dataSet?.Tables[1] == null)
                throw new Exception(clsCommun.ErreurGeneriqueQuitterApplication);
            if (dataSet?.Tables[0]?.Rows.Count == 0)
                throw new Exception(clsCommun.ErreurGeneriqueQuitterApplication);

            resultat = AttribuerValeur(dataSet);
            return resultat;
        }

        private clsPanier AttribuerValeur(DataSet dataSet)
        {
            clsPanier resultat = new clsPanier();

            if (dataSet?.Tables[0]?.Rows.Count > 0)
            {
                resultat.objPersonnes = new clsPersonne()
                {
                    iID = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]),
                    eNiveau = RecupereNiveauUtilisateur(Convert.ToInt32(dataSet.Tables[0].Rows[0][1])),
                    sNom = dataSet.Tables[0].Rows[0][2].ToString(),
                    sPrenom = dataSet.Tables[0].Rows[0][3].ToString(),
                    eSexe = RecupereSexe(dataSet.Tables[0].Rows[0][4].ToString()),
                    sAdresse = dataSet.Tables[0].Rows[0][5].ToString(),
                    dDateNaissance = Convert.ToDateTime(dataSet.Tables[0].Rows[0][3].ToString()),
                };
            }

            if (dataSet?.Tables[1]?.Rows.Count > 0)
            {
                resultat.lstArticles = new List<clsArticle>();

                foreach (DataRow item in dataSet.Tables[1].Rows)
                {
                    clsArticle article = new clsArticle()
                    {
                        sNom = item[0].ToString(),
                        iQuantite = Convert.ToInt32(item[1]),
                        rPrix = Convert.ToDecimal(item[2]),
                    };

                    article.rPrixTotal = article.rPrix * article.iQuantite;
                    resultat.lstArticles.Add(article);
                }
            }

            return resultat;
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

    }
}

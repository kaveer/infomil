using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesAuxDonnees
{
  public abstract class clsPersonnesAccesDonnees
   {
        public abstract void CreerPersonnes();
        public abstract void RecupererListePersonnes();
        public abstract void SupprimerPersonne();

        public DataTable AuthentifierPersonne(string utilisatueur, string motDePasse)
        {
            DataTable resultat = new DataTable();

            try
            {
                clsCommunAccesDonnees commun = new clsCommunAccesDonnees();
                SqlConnection connexion = new SqlConnection();

                connexion = commun.OuvirConnexion();
                if (connexion == null)
                    throw new Exception();


                return resultat;
            }
            catch (Exception)
            {
                return resultat = null;
            }
        }

        public void MAJPersonne()
        {

        }

        public void RecupererPanierPersonne()
        {

        }
   }
}

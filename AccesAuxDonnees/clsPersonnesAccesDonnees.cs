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
            clsCommunAccesDonnees commun = new clsCommunAccesDonnees();
            SqlConnection connexion = new SqlConnection();

            try
            {
                

                connexion = commun.OuvirConnexion();
                if (connexion == null)
                    throw new Exception();

                SqlCommand command = new SqlCommand("tblPersonnesRechercherParUtilisateurMotDePasse", connexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("@utilisateur", Convert.ToInt32(utilisatueur)));
                command.Parameters.Add(new SqlParameter("@motdepasse", motDePasse));

                resultat.Load(command.ExecuteReader());
                if (resultat == null || resultat.Rows.Count <= 0)
                    throw new Exception();

                return resultat;
            }
            catch (Exception ex)
            {
                return resultat = null;
            }
            finally
            {
                commun.FermerConnexion();
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

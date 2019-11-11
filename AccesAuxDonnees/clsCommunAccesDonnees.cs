using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesAuxDonnees
{
   public class clsCommunAccesDonnees
    {
        private readonly string connectionString;
        private SqlConnection connexion = new SqlConnection();

        public clsCommunAccesDonnees()
        {
            connectionString = ConfigurationManager.AppSettings["appctxt"];

        }

        public SqlConnection OuvirConnexion()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(connectionString))
                    throw new Exception();

                connexion = new SqlConnection(connectionString);
                connexion.Open();

                return connexion;
            }
            catch (Exception)
            {
                return connexion = null;
            }
        }

        public void FermerConnexion()
        {
            if (connexion != null)
            {
                connexion.Close();
            }
        }
    }
}

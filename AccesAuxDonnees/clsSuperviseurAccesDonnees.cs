using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesAuxDonnees
{
    public class clsSuperviseurAccesDonnees : clsPersonnesAccesDonnees
    {
        public override void CreerPersonnes()
        {
            throw new NotImplementedException();
        }

        public override DataTable RecupererListePersonnes(int iID)
        {
            DataTable resultat = new DataTable();
            clsCommunAccesDonnees commun = new clsCommunAccesDonnees();
            SqlConnection connexion = new SqlConnection();


            connexion = commun.OuvirConnexion();
            if (connexion == null)
                return resultat;

            SqlCommand command = new SqlCommand("tblPersonnesRecuperePersonneParSuperviseur", connexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@idpersonne", iID));

            resultat.Load(command.ExecuteReader());

            commun.FermerConnexion();

            return resultat;
        }

        public override void SupprimerPersonne()
        {
            throw new NotImplementedException();
        }
    }
}

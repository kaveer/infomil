using ConteneurDeDonnees;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AccesAuxDonnees
{
    public class clsChefRayonAccesDonnees : clsPersonnesAccesDonnees
    {
        public override void CreerPersonnes(clsPersonne personne)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// retrieve clients by chef de rayon id
        /// </summary>
        /// <param name="iID"></param>
        /// <returns></returns>
        public override DataTable RecupererListePersonnes(int iID)
        {
            DataTable resultat = new DataTable();
            clsCommunAccesDonnees commun = new clsCommunAccesDonnees();
            SqlConnection connexion = new SqlConnection();


            connexion = commun.OuvirConnexion();
            if (connexion == null)
                return resultat;

            SqlCommand command = new SqlCommand("tblPersonnesRecuperePersonneParChefRayon", connexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@idpersonne", iID));

            resultat.Load(command.ExecuteReader());

            commun.FermerConnexion();

            return resultat;
        }

        public override void SupprimerPersonne(int iID)
        {
            throw new NotImplementedException();
        }
    }
}

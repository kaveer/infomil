using ConteneurDeDonnees;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AccesAuxDonnees
{
    public abstract class clsPersonnesAccesDonnees
    {
        /// <summary>
        /// declare abstract classes
        /// mathod to: 
        ///     create client
        ///     retrieve list of vlients
        ///     delete client
        /// </summary>
        /// <param name="personne"></param>
        public abstract void CreerPersonnes(clsPersonne personne);
        public abstract DataTable RecupererListePersonnes(int iID);
        public abstract void SupprimerPersonne(int iID);

        /// <summary>
        /// open connection
        /// retrieve client info by id and password
        /// close connection
        /// </summary>
        /// <param name="utilisatueur"></param>
        /// <param name="motDePasse"></param>
        /// <returns></returns>
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

        /// <summary>
        /// update client by client id and client object
        /// </summary>
        /// <param name="personne"></param>
        public void MAJPersonne(clsPersonne personne)
        {
            clsCommunAccesDonnees commun = new clsCommunAccesDonnees();
            SqlConnection connexion = new SqlConnection();


            connexion = commun.OuvirConnexion();
            if (connexion == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblPersonneMisAJour", connexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@idpersonne", personne.iID));
            command.Parameters.Add(new SqlParameter("@nom", personne.sNom));
            command.Parameters.Add(new SqlParameter("@prenom", personne.sPrenom));
            command.Parameters.Add(new SqlParameter("@adresses", personne.sAdresse));
            command.Parameters.Add(new SqlParameter("@naissance", personne.dDateNaissance));
            command.Parameters.Add(new SqlParameter("@niveau", (int)clsPersonne.enuNiveau.iCLIENT));
            command.Parameters.Add(new SqlParameter("@sexe", personne.eSexe == clsPersonne.enuSexe.iHOMME ? "M" : "F"));
            command.ExecuteNonQuery();

            commun.FermerConnexion();
        }

        /// <summary>
        /// retrieve client by id
        /// retrieve cart by id 
        /// return all data as dataset
        /// </summary>
        /// <param name="iID"></param>
        /// <returns></returns>
        public DataSet RecupererPanierPersonne(int iID)
        {
            DataSet resultat = new DataSet();
            DataTable personne = new DataTable();
            DataTable article = new DataTable();

            personne = RecupererPersonneParIid(iID);
            article = RecupererArticleParIid(iID);

            resultat.Tables.Add(personne);
            resultat.Tables.Add(article);

            return resultat;
        }

        private DataTable RecupererArticleParIid(int iID)
        {
            DataTable resultat = new DataTable();
            clsCommunAccesDonnees commun = new clsCommunAccesDonnees();
            SqlConnection connexion = new SqlConnection();

            connexion = commun.OuvirConnexion();
            if (connexion == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblPanierRecupererParId", connexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@iid", iID));

            resultat.Load(command.ExecuteReader());

            commun.FermerConnexion();

            return resultat;
        }

        private DataTable RecupererPersonneParIid(int iID)
        {
            DataTable resultat = new DataTable();
            clsCommunAccesDonnees commun = new clsCommunAccesDonnees();
            SqlConnection connexion = new SqlConnection();

            connexion = commun.OuvirConnexion();
            if (connexion == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblPersonneRecupererParId", connexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@iid", iID));

            resultat.Load(command.ExecuteReader());
            if (resultat == null || resultat.Rows.Count <= 0)
                throw new Exception();

            commun.FermerConnexion();

            return resultat;
        }
    }
}

using ConteneurDeDonnees;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AccesAuxDonnees
{
    public class clsSuperviseurAccesDonnees : clsPersonnesAccesDonnees
    {
        public override void CreerPersonnes(clsPersonne personne)
        {
            clsCommunAccesDonnees commun = new clsCommunAccesDonnees();
            SqlConnection connexion = new SqlConnection();


            connexion = commun.OuvirConnexion();
            if (connexion == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblPersonneAjouter", connexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@nom", personne.sNom));
            command.Parameters.Add(new SqlParameter("@prenom", personne.sPrenom));
            command.Parameters.Add(new SqlParameter("@adresses", personne.sAdresse));
            command.Parameters.Add(new SqlParameter("@naissance", personne.dDateNaissance));
            command.Parameters.Add(new SqlParameter("@niveau", (int)clsPersonne.enuNiveau.iCLIENT));
            command.Parameters.Add(new SqlParameter("@sexe", personne.eSexe == clsPersonne.enuSexe.iHOMME? "M": "F"));

            command.ExecuteNonQuery();

            commun.FermerConnexion();
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

        public override void SupprimerPersonne(int iID)
        {
            SuppprimerPersonneParID(iID);
            SupprimerPanierParID(iID);
        }

        private void SupprimerPanierParID(int iID)
        {
            clsCommunAccesDonnees commun = new clsCommunAccesDonnees();
            SqlConnection connexion = new SqlConnection();


            connexion = commun.OuvirConnexion();
            if (connexion == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblPanierSupprimerParId", connexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@idpersonne", iID));
            command.ExecuteNonQuery();

            commun.FermerConnexion();
        }

        private void SuppprimerPersonneParID(int iID)
        {
            clsCommunAccesDonnees commun = new clsCommunAccesDonnees();
            SqlConnection connexion = new SqlConnection();


            connexion = commun.OuvirConnexion();
            if (connexion == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblPersonnesSupprimerParId", connexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@idpersonne", iID));
            command.ExecuteNonQuery();

            commun.FermerConnexion();
        }
    }
}

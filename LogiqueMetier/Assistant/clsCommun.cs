using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier.Assistant
{
    public static class clsCommun
    {
        public const string ErreurUtilisateur = "Nom de utilisateur obligatoire";
        public const string ErreurEntree = "Utilidateur et mot de passe invalide";
        public const string ErreurUtilisateurInvalide = "Utilisateur invalide";
        public const string ErreurGeneriqueQuitterApplication = "une erreur inconnue s'est produite. Rediriger vers authentification";
        public const string ErreurClientNonSelectionner = "Selection de client obligatoire";
        public const string ErreurApplicationGeneric = "Erreur application";
        public const string ErreurRecupererPersonne = "Erreur d'application en recuperant les informations du client";
        public const string ErreurValidationClients = "informations client manquantes";
        public const string ErreurNavigationClient = "Pas de client {0}";

        public const string SuccesSupprimerClient = "suppression du client avec succès";

        public const string TitreModeSuperviseur = "Gestion des personnes (Accès superviseur)";
        public const string TitreModeChefRayon = "Gestion des personnes (Chef de rayon)";
        public const string TitreModeclient = "Gestion infos clients";
        public const string TitreDialogueSupprimerClient = "supprimer client";


        public const string InformationModeSuperviseur = "Superviseur - Accès aux données de tous les rayons et clients du magasin";
        public const string InformationModeChefRayon = "chef du rayon fruits et légumes - Accès aux données des clients du rayon fruits et légumes";
        public const string InformationSupprimerClient = "Voulez vous supprimer le client selectionne";
        public const string InformationSupprimerClientAnnuler = "Supprimer client annuler";
    }
}

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

        public const string TitreModeSuperviseur = "Gestion des personnes (Accès superviseur)";
        public const string TitreModeChefRayon = "Gestion des personnes (Chef de rayon)";
        public const string TitreModeclient = "Gestion infos clients";


        public const string InformationModeSuperviseur = "Superviseur - Accès aux données de tous les rayons et clients du magasin";
        public const string InformationModeChefRayon = "chef du rayon fruits et légumes - Accès aux données des clients du rayon fruits et légumes";
    }
}

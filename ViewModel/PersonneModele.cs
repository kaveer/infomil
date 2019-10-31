using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PersonneModele
    {
        public int Id_Personne { get; set; }
        public int Niveau_Utilisateur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime Date_Naissance { get; set; }
        public char Sexe { get; set; }
        public string Addresse { get; set; }
    }
}

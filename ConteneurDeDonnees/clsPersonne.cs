using System;

namespace ConteneurDeDonnees
{
    public class clsPersonne
    {
        public int iID { get; set; }
        public string sNom { get; set; }
        public string sPrenom { get; set; }
        public string sAdresse { get; set; }
        public DateTime dDateNaissance { get; set; }
        public enuSexe eSexe { get; set; }
        public enuNiveau eNiveau { get; set; }

        public enum enuSexe
        {
            iHOMME = 1,
            iFEMME = 2
        }

        public enum enuNiveau
        {
            iCLIENT = 0,
            iCHEF_RAYON = 1,
            iSUPERVISEUR = 2
        }
    }
}

namespace ConteneurDeDonnees
{
    public class clsArticle
    {
        public string sNom { get; set; }
        public decimal rPrix { get; set; }
        public int iQuantite { get; set; }
        public decimal rPrixTotal { get; set; }
        public clsRayon objRayon { get; set; }
    }
}

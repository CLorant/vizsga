namespace Utasszallitok
{
    class SebessegKategoria
    {
        private int Utazosebesseg;
        public string Kategorianev
        {
            get
            {
                if (Utazosebesseg < 500) return "Alacsony sebességű";
                else if (Utazosebesseg < 1000) return "Szubszonikus";
                else if (Utazosebesseg < 1200) return "Transzszonikus";
                else return "Szuperszonikus";
            }
        }
        public SebessegKategoria(int utazosebesseg)
        {
            Utazosebesseg = utazosebesseg;
        }
    }

}

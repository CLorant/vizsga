namespace Utasszallitok
{
    class UtasSzallito
    {
        public string? tipus { get; private set; }
        public int ev { get; private set; }
        public int[]? utasok { get; private set; }
        public int[]? szemelyzet { get; private set; }
        public int utazosebesseg { get; private set; }
        public int felszallotomeg { get; private set; }
        public double fesztav { get; private set; }

        public UtasSzallito(string sor)
        { 
            string[] elemek = sor.Split(';');
            tipus = elemek[0];
            ev = int.Parse(elemek[1]);
            utasok = elemek[2].Split("-").Select(int.Parse).ToArray();
            szemelyzet = elemek[3].Split("-").Select(int.Parse).ToArray();
            utazosebesseg = int.Parse(elemek[4]);
            felszallotomeg = int.Parse(elemek[5]);
            fesztav = double.Parse(elemek[6]);
        }

        public static IEnumerable<UtasSzallito> txtOlvas(string fajlnev)
        {
            foreach (string sor in File.ReadAllLines(fajlnev).Skip(1))
            {
                yield return new UtasSzallito(sor);
            }
        }
    }
}
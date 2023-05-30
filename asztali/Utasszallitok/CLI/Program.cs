namespace Utasszallitok
{
    internal class Program
    {
        static IEnumerable<UtasSzallito> utasSzallitoLista = UtasSzallito.txtOlvas("utasszallitok.txt");
        static void Main(string[] args)
        {
            Console.WriteLine("4. feladat: Adatsorok száma: {0}", utasSzallitoLista.Count());

            Console.WriteLine("5. feladat: Boeing típusok száma: {0}", utasSzallitoLista.Count(x=>x.tipus.Contains("Boeing")));

            Console.WriteLine("6. feladat: A legtöbb utast szállító repülőgéptípus");
            UtasSzallito max = utasSzallitoLista.OrderByDescending(x => x.utasok?.Length == 1 ? x.utasok[0] : x.utasok?[1]).First();
            Console.WriteLine("\tTípus: {0}", max.tipus);
            Console.WriteLine("\tElső felszállás: {0}", max.ev);
            Console.WriteLine("\tUtasok: {0}", max.utasok?.Length == 1 ?
                max.utasok?[0] : max.utasok?[0] + "-" + max.utasok?[1]);
            Console.WriteLine("\tSzemélyzet: {0}", max.szemelyzet?.Length == 1 ?
                max.szemelyzet[0] : max.szemelyzet?[0] + "-" + max.szemelyzet?[1]);
            Console.WriteLine("\tUtazósebesség: {0}", max.utazosebesseg);

            List<string> osszesSebesseg = new List<string>() { "Alacsony sebességű", "Szubszonikus", "Transzszonikus", "Szuperszonikus" };
            List<string> hasznaltSebesseg = new List<string>();
            foreach (var x in utasSzallitoLista)
            {
                SebessegKategoria kategoria = new SebessegKategoria(x.utazosebesseg);
                hasznaltSebesseg.Add(kategoria.Kategorianev);
            }
            Console.WriteLine("7. feladat:");
            if (osszesSebesseg.Except(hasznaltSebesseg).Count() > 1)
            {
                foreach (var x in osszesSebesseg.Except(hasznaltSebesseg))
                {
                    Console.Write(x + " ");
                }
            }
            else
            {
                Console.WriteLine("Minden sebességkategóriából van repülőgéptípus.");
            }

            StreamWriter writer = new StreamWriter("utasszallitok_new.txt");
            writer.WriteLine("típus;év;utas;személyzet;utazósebesség;felszállótömeg;fesztáv");
            foreach (var x in utasSzallitoLista)
            {
                writer.WriteLine($"{x.tipus} {x.ev} {(x.utasok?.Length == 1 ? x.utasok[0] : x.utasok?[1])} {(x.szemelyzet?.Length == 1 ? x.szemelyzet[0] : x.szemelyzet?[1])} {x.utazosebesseg} {Math.Round((double)x.felszallotomeg / 1000)} {Math.Round(x.fesztav/3.2808)}");
            }
            writer.Close();
            Console.ReadLine();
        }
    }
}
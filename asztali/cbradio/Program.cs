using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbradio
{
    internal class Program
    {
        static IEnumerable<Adas> adasLista = Adas.txtOlvas("cb.txt");

        static int AtszamolPercre(int ora, int perc)
        {
            return ora * 60 + perc;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("3. feladat: Bejegyzések száma: {0} db", adasLista.Count());
            bool vane = false;
            foreach (var x in adasLista)
            {
                if (x.adasdb == 4)
                {
                    vane = true;
                    break;
                }
            }
            Console.WriteLine("4. feladat: {0} négy adást indító sofőr.", vane ? "Volt" : "Nem volt");
            Console.Write("5. feladat: Kérek egy nevet: ");
            string nev = Console.ReadLine().ToLower();
            vane = false;
            foreach (var x in adasLista)
            {
                if (x.nev.ToLower() == nev)
                {
                    vane = true;
                    break;
                }
            }
            Console.WriteLine("\t{0}", vane ? $"{nev} {adasLista.Sum(x => x.nev.ToLower() == nev ? x.adasdb : 0)}x használta a CB-rádiót." : "Nincs ilyen nevű sofőr!");
            using (var writer = new StreamWriter("cb2.txt"))
            {
                writer.WriteLine("Kezdes;Nev;AdasDb");
                foreach (Adas x in adasLista)
                {
                    writer.WriteLine($"{AtszamolPercre(x.ora, x.perc)};{x.nev};{x.adasdb}");
                }
            }
            Console.WriteLine("8. feladat: Sofőrök száma: {0} fő", adasLista.GroupBy(x => x.nev).Count());
            Console.WriteLine("9. feladat: Legtöbb adást indító sofőr");
            
            // dictionary nélkül
            var max = adasLista
                .GroupBy(x => x.nev)
                .Select(g => new { Sofor = g.Key, AdasokSzama = g.Sum(a => a.adasdb) })
                .OrderByDescending(a => a.AdasokSzama)
                .First();
            Console.WriteLine("\tNév: {0}", max.Sofor);
            Console.WriteLine("\tAdások száma: {0} alkalom", max.AdasokSzama);
            Console.ReadKey();
        }
    }
}

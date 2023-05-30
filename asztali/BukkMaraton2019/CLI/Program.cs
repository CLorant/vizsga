using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BukkMaraton2019
{
    internal class Program
    {
        static IEnumerable<Versenyzo> versenyzoLista = Versenyzo.txtOlvas("bukkm2019.txt");
        static void Main(string[] args)
        {
            Console.WriteLine("4. feladat: Versenytávot nem teljesítők: {0}%", (1 - versenyzoLista.Count() / 691.0) * 100);
            Console.WriteLine("5. feladat: Női versenyzők száma a rövid távú versenyen: {0} fő", versenyzoLista.Count(x => new Versenytav(x.rajtszam).Tav == "Rövid" && x.kategoria.Last() == 'n'));
            
            bool vane = false;
            foreach (var x in versenyzoLista)
            {
                if (x.ido.Hours >= 6)
                {
                    vane = true;
                    break;
                }
            }
            Console.WriteLine("6. feladat: {0} ilyen versenyző", vane ? "Volt" : "Nem volt");
            Console.WriteLine("7. feladat: A felnőtt (ff) kategória győztese rövid távon:");
            Versenyzo gyoztes = versenyzoLista.OrderBy(x => x.ido).Where(x => new Versenytav(x.rajtszam).Tav == "Rövid" && x.kategoria == "ff").First();
            Console.WriteLine("\tRajtszám: {0}", gyoztes.rajtszam);
            Console.WriteLine("\tNév: {0}", gyoztes.nev);
            Console.WriteLine("\tEgyesület: {0}", gyoztes.egyesulet);
            Console.WriteLine("\tIdő: {0}:{1}:{2}", gyoztes.ido.Hours, gyoztes.ido.Minutes, gyoztes.ido.Seconds);
            Console.WriteLine("8. feladat: Statisztika");
            ConcurrentDictionary<string, int> statisztika = new ConcurrentDictionary<string, int>();
            foreach (var x in versenyzoLista.Where(x => x.kategoria.Last() == 'f'))
            {
                statisztika.AddOrUpdate(x.kategoria, 1, (key, value) => ++value);
            }
            foreach (var x in statisztika)
            {
                Console.WriteLine("\t{0} - {1} fő", x.Key, x.Value);
            }
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BukkMaraton2019
{
    internal class Versenyzo
    {
        public string rajtszam { get; private set; }
        public string kategoria { get; private set; }
        public string nev { get; private set; }
        public string egyesulet { get; private set; }
        public TimeSpan ido { get; private set; }

        public static IEnumerable<Versenyzo> txtOlvas(string fajlnev)
        {
            foreach (string sor in File.ReadAllLines(fajlnev).Skip(1))
            {
                yield return new Versenyzo(sor);
            }
        }

        public Versenyzo(string sor)
        {
            string[] elemek = sor.Split(';');
            rajtszam = elemek[0];
            kategoria = elemek[1];
            nev = elemek[2];
            egyesulet = elemek[3];
            int[] temp = elemek[4].Split(':').Select(int.Parse).ToArray();
            ido = new TimeSpan(temp[0], temp[1], temp[2]);
        }
    }
}

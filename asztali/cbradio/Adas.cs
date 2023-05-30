using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cbradio
{
    internal class Adas
    {
        public int ora { get; private set; }
        public int perc { get; private set; }
        public int adasdb { get; private set; }
        public string nev { get; private set; }

        public static IEnumerable<Adas> txtOlvas(string fajlnev)
        {
            foreach (string sor in File.ReadAllLines(fajlnev).Skip(1))
            {
                yield return new Adas(sor);
            }
        }

        public Adas(string sor)
        {
            string[] elemek = sor.Split(';');
            ora = int.Parse(elemek[0]);
            perc = int.Parse(elemek[1]);
            adasdb = int.Parse(elemek[2]);
            nev = elemek[3];
        }
    }
}

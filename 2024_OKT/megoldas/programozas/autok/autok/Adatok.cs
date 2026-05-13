using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autok
{
    internal class Adatok
    {
        public string Rendszam {  get; set; }
        public int Ora {  get; set; }
        public int Perc {  get; set; }
        public int Sebesseg { get; set; }

        public Adatok(string rendszam, int ora, int perc, int sebesseg)
        {
            Rendszam = rendszam;
            Ora = ora;
            Perc = perc;
            Sebesseg = sebesseg;
        }
    }
}

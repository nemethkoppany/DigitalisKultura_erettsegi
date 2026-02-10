using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvek
{
    internal class Konyv
    {

        public int Ev { get; set; }
        public int Nyegyedev { get; set; }
        public string Nyelv { get; set; }
        public string Adatok { get; set; }
        public int Peldanyszam { get; set; }

        public Konyv(int ev, int nyegyedecv, string nyelv, string adatok, int peldanyszam)
        {
            Ev = ev;
            Nyegyedev = nyegyedecv;
            Nyelv = nyelv;
            Adatok = adatok;
            Peldanyszam = peldanyszam;
        }
    }
}
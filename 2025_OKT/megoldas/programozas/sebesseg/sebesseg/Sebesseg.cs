using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sebesseg
{
    internal class Sebesseg
    {
        public int Tavolsag { get; set; }
        public string Ertek {  get; set; }
        public string Tipus { get; set; }

        public Sebesseg(int tavolsag, string ertek)
        {
            Tavolsag = tavolsag;
            Ertek = ertek;
            if(ertek == "]")
            {
                Tipus = "vege";
            }
            else if (ertek == "#")
                Tipus = "keresztezo";
            else if (ertek == "%")
                Tipus = "feloldo";
            else if (int.TryParse(ertek, out _))
                Tipus = "sebesseg";
            else
                Tipus = "varos";
        }
    }
}

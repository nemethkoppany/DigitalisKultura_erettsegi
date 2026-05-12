using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belepteto
{
    internal class Esemenyek
    {
        public string Diak_Kod {  get; set; }
        public DateTime IdoPont {  get; set; }
        public int Esemeny {  get; set; }

        public Esemenyek(string diak_Kod, DateTime idoPont, int esemeny)
        {
            Diak_Kod = diak_Kod;
            IdoPont = idoPont;
            Esemeny = esemeny;
        }
    }
}

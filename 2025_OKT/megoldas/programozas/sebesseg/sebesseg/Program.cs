using System.Text;

namespace sebesseg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int osszhossz;

            List<Sebesseg> sebessegek = new List<Sebesseg>();
            string[] lines = File.ReadAllLines("ut.txt");
            osszhossz = int.Parse(lines[0]);

            foreach (string line in lines.Skip(1))
            {
                string[] lineparts = line.Split(" ");
                int tavolsag = int.Parse(lineparts[0]);
                string ertek = lineparts[1];
                sebessegek.Add(new Sebesseg(tavolsag, ertek));
            }

            Console.WriteLine("2. feladat");
            Console.WriteLine("A települések neve:");

            var varosok = sebessegek.Where(x => x.Tipus == "varos").ToList();
            foreach(var s in varosok)
            {
                Console.WriteLine(s.Ertek);
            }


            Console.WriteLine("3. feladat");
            Console.WriteLine("Adja meg a vizsgált szakasz hosszát km-ben! ");
            double vizsgalt_hossz = double.Parse(Console.ReadLine());

            int aktualisSebesseg = 90;
            int minSebesseg = 999;
            bool telepulesben = false;

            foreach (var s in sebessegek)
            {
                if (s.Tavolsag < vizsgalt_hossz * 1000)
                {
                    if (s.Tipus == "vege")
                    {
                        aktualisSebesseg = 90;
                        telepulesben = false;
                    }
                    else if (s.Tipus == "feloldo")
                    {
                        aktualisSebesseg = telepulesben ? 50 : 90;
                    }
                    else if (s.Tipus == "varos")
                    {
                        aktualisSebesseg = 50;
                        telepulesben = true;
                    }
                    else if (s.Tipus == "sebesseg")
                    {
                        aktualisSebesseg = int.Parse(s.Ertek);
                    }
                    else if (s.Tipus == "keresztezo")
                    {
                        aktualisSebesseg = telepulesben ? 50 : 90;
                    }
                    if (aktualisSebesseg < minSebesseg)
                    {
                        minSebesseg = aktualisSebesseg;
                    }
                }
            }

            Console.WriteLine($"Az első {vizsgalt_hossz} km-en {minSebesseg} km/h volt a legalacsonyabb megengedett sebesség.");


            Console.WriteLine("4. feladat");

            double varosi_szakasz = 0;
            int varos = 0;

            foreach(var s in sebessegek)
            {
                if(s.Tipus == "varos")
                {
                    varos = s.Tavolsag;
                }

                if(s.Tipus == "vege")
                {
                    var szakasz = s.Tavolsag - varos;
                    varosi_szakasz += szakasz;
                }
            }

            Console.WriteLine($"Az út {(varosi_szakasz/osszhossz)*100:F2} százaléka vezet településen belül.");

            Console.WriteLine("5. feladat");
            Console.WriteLine("Adja meg egy település nevét! ");
            var bekert_varos = Console.ReadLine();

            bool bekert_varosban_e = false;
            var sebessegKorlatozo_tablak = 0;
            var varosSzakasz_Hossz = 0;
            var varos_e = 0;
            foreach (var s in sebessegek)
            {
                if (s.Ertek == bekert_varos)
                {
                    bekert_varosban_e = true;
                    varos_e = s.Tavolsag;
                }
                if (bekert_varosban_e)
                {
                    if (s.Tipus == "sebesseg")
                    {
                        sebessegKorlatozo_tablak++;
                    }
                    if (s.Tipus == "vege")
                    {
                        varosSzakasz_Hossz = s.Tavolsag - varos_e;
                        bekert_varosban_e = false;
                    }
                }
            }
            Console.WriteLine($"A sebességkorlátozó táblák száma: {sebessegKorlatozo_tablak}");
            Console.WriteLine($"Az út hossza a településen belül {varosSzakasz_Hossz} méter.");

            Console.WriteLine("6. feladat");
            var bekert = varosok.FirstOrDefault(x => x.Ertek == bekert_varos);
            var index = varosok.IndexOf(bekert);
            var bekert_sebessegek_index = sebessegek.FirstOrDefault(x => x.Ertek == bekert_varos);
            var index_a_sebessegekben = sebessegek.IndexOf(bekert_sebessegek_index);
            int vege_index_tavolsag = 0;
            for (int i = index_a_sebessegekben; i < sebessegek.Count; i++)
            {
                if (sebessegek[i].Tipus == "vege")
                {
                    vege_index_tavolsag = sebessegek[i].Tavolsag;
                    break;
                }
            }
            if (index == 0)
            {
                Console.WriteLine($"A legközelebbi település: {varosok[index + 1].Ertek}");
            }
            else if (index == varosok.Count - 1)
            {
                Console.WriteLine($"A legközelebbi település: {varosok[index - 1].Ertek}");
            }
            else
            {
                int bekert_varos_elotti_varos_vege_tavolsag = 0;
                var elotti_varos = varosok[index - 1];
                var elotti_varos_sebessegek_index = sebessegek.IndexOf(sebessegek.FirstOrDefault(x => x.Ertek == elotti_varos.Ertek));
                for (int i = elotti_varos_sebessegek_index; i < sebessegek.Count; i++)
                {
                    if (sebessegek[i].Tipus == "vege")
                    {
                        bekert_varos_elotti_varos_vege_tavolsag = sebessegek[i].Tavolsag;
                        break;
                    }
                }
                var elso_szomszed = bekert.Tavolsag - bekert_varos_elotti_varos_vege_tavolsag;
                var kovetkezo_szomszed = varosok[index + 1].Tavolsag - vege_index_tavolsag;
                if (elso_szomszed < kovetkezo_szomszed)
                {
                    Console.WriteLine($"A legközelebbi település: {elotti_varos.Ertek}");
                }
                else if (elso_szomszed > kovetkezo_szomszed)
                {
                    Console.WriteLine($"A legközelebbi település: {varosok[index + 1].Ertek}");
                }
                else
                {
                    Console.WriteLine($"A legközelebbi település: {elotti_varos.Ertek}");
                }
            }

        }
    }
}

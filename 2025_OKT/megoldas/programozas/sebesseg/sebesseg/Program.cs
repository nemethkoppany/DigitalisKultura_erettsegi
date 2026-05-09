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
        }
    }
}

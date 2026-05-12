using System.Runtime.InteropServices.ComTypes;

namespace belepteto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Esemenyek> esemenyek = new List<Esemenyek>();
            string[] lines = File.ReadAllLines("bedat.txt");
            foreach (string line in lines)
            {
                string[] lineparts = line.Split(" ");
                Esemenyek esemeny = new Esemenyek(
                    diak_Kod: lineparts[0],
                    idoPont: DateTime.Parse(lineparts[1]),
                    esemeny: int.Parse(lineparts[2])
                    );
                esemenyek.Add(esemeny);

            }

            var elso = esemenyek.Where(x => x.Esemeny == 1).Select(x => x.IdoPont).First();  
            var utolso = esemenyek.Where(x => x.Esemeny == 2).Select(x => x.IdoPont).Last();

            Console.WriteLine("2.feladat");
            Console.WriteLine($"Az első tanuló {elso.Hour}:{elso.Minute:D2}-kor lépett be a főkapun.");
            Console.WriteLine($"Az utolsó tanuló {utolso.Hour}:{utolso.Minute}-kor lépett ki a főkapun.");


            List<string> kesok = new List<string>();

            foreach(var k in esemenyek)
            {
                if(k.Esemeny == 1 && k.IdoPont.TimeOfDay > new TimeSpan(7,50,0) && k.IdoPont.TimeOfDay <= new TimeSpan(8,15,0))
                {
                    kesok.Add($"{k.IdoPont:HH:mm} {k.Diak_Kod}");
                }
            }

            File.WriteAllLines("kesok.txt",kesok);


            Console.WriteLine("4. feladat");

            var menzas = esemenyek.Where(x => x.Esemeny == 3).Count();
            Console.WriteLine($"A menzán aznap {menzas} tanuló ebédelt.");

            Console.WriteLine("5. feladat");

            var kolcsonzes = esemenyek.Where(x => x.Esemeny == 4).Select(x => x.Diak_Kod).Distinct().Count();

            Console.WriteLine($"Aznap {kolcsonzes} tanuló kölcsönzött a könyvtárban.");
            if (menzas > kolcsonzes)
            {
                Console.WriteLine("Többen nvoltak, mint a menzán.");
            }
            else
            {
                Console.WriteLine("Nem voltak többen, mint a menzán.");
            }

            Console.WriteLine("6. feladat");

            var tilosban_kilepok = esemenyek.Where(diak => esemenyek.Any(x => x.Diak_Kod == diak.Diak_Kod && x.Esemeny == 1 && x.IdoPont.TimeOfDay < new TimeSpan(10, 45, 0))
            && esemenyek.Any(x => x.Diak_Kod == diak.Diak_Kod && x.Esemeny == 1 && x.IdoPont.TimeOfDay > new TimeSpan(10, 50, 0) && x.IdoPont.TimeOfDay < new TimeSpan(11, 00, 0))
            && !esemenyek.Any(x => x.Diak_Kod == diak.Diak_Kod && x.Esemeny == 2 && x.IdoPont.TimeOfDay > new TimeSpan(10, 45, 0) && x.IdoPont.TimeOfDay < new TimeSpan(10, 50, 0))
            ).Select(x => x.Diak_Kod).Distinct();
            Console.WriteLine($"Az érintett tanulók: ");
            foreach (var d in tilosban_kilepok)
            {
                Console.Write($"{d} ");
            }

            Console.WriteLine("7. feladat");

            Console.Write("Egy tanuló azonosytója=");
            var bekert = Console.ReadLine();
            

            if (esemenyek.Any(x => x.Diak_Kod == bekert))
            {
                var elso_belepes = esemenyek.Where(x => x.Esemeny == 1 && x.Diak_Kod == bekert).Select(x => x.IdoPont.TimeOfDay).First();
                var utolso_kilepes = esemenyek.Where(x => x.Esemeny == 2 && x.Diak_Kod == bekert).Select(x => x.IdoPont.TimeOfDay).Last();
                var eltelt_ido = utolso_kilepes - elso_belepes;
                Console.WriteLine($"A tanuló érkezése és távozása között {eltelt_ido.Hours} óra {eltelt_ido.Minutes} perc telt el.");
            }
            else
            {
                Console.WriteLine("Ilyen azonosítójú tanuló aznap nem volt az iskolában.");
            }

        }
    }
}

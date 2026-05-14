namespace autok
{
    internal class Program
    {
        static void Main(string[] args)
        {
         
            List<Adatok> adatok = new List<Adatok>();
            string[] lines = File.ReadAllLines("jeladas.txt");

            foreach (string line in lines)
            {
                string[] lineparts = line.Split("\t");
                Adatok adat = new Adatok(
                        rendszam: lineparts[0],
                        ora: int.Parse(lineparts[1]),
                        perc: int.Parse(lineparts[2]),
                        sebesseg: int.Parse(lineparts[3])
                );
                adatok.Add(adat);
            }


            Console.WriteLine("2. feladat: ");
            var utolso = adatok.Last();

            Console.WriteLine($"Az utolsó jeladás időpontja {utolso.Ora}:{utolso.Perc}, a jármű rendszáma {utolso.Rendszam}");

            Console.WriteLine("3. feladat: ");
            var elso = adatok.First();


            Console.WriteLine($"Az első jármű: {elso.Rendszam}");
            Console.Write($"Jeladásainak időpontja: ");
            foreach(var e in adatok)
            {
                if(e.Rendszam == elso.Rendszam)
                {
                    Console.Write($" {e.Ora}:{e.Perc} ");
                }
            }


            Console.WriteLine("4. feladat:");
            Console.Write("Kérem, adja meg az órát: ");
            int bekert_ora = int.Parse( Console.ReadLine());
            Console.Write("Kérem, adja meg a percet: ");
            int bekert_perc = int.Parse( Console.ReadLine());

            int jeladasok = 0;

            foreach(var e in adatok)
            {
                if(e.Ora == bekert_ora && e.Perc == bekert_perc)
                {
                    jeladasok++;
                }
            }

            Console.WriteLine($"Jeladások száma: {jeladasok}");

            Console.WriteLine("5. feladat:");
            var leggyorsabb = adatok.Max(x => x.Sebesseg);
            Console.WriteLine($"A legnagyobb sebesség km/h: {leggyorsabb}");
            Console.Write($"A járművek: ");
            foreach (var e in adatok)
            {
                if(e.Sebesseg == leggyorsabb)
                {
                    Console.Write($"{e.Rendszam} ");
                }
            }


            Console.WriteLine("6. feladat:");
            Console.WriteLine("Kérem adja meg a rendszámot: ");
            var bekert_rendszam = Console.ReadLine();

            if (adatok.Any(x => x.Rendszam == bekert_rendszam))
            {
                var szurtAdatok = adatok.Where(x => x.Rendszam == bekert_rendszam);

                double osszTav = 0;
                Adatok elozo = null;

                foreach (var e in szurtAdatok)
                {
                    if (elozo != null)
                    {
                        double elteltPerc =
                            (e.Ora * 60 + e.Perc) -
                            (elozo.Ora * 60 + elozo.Perc);

                        double elteltOra = elteltPerc / 60.0;

                        osszTav += elteltOra * elozo.Sebesseg;
                    }

                    Console.WriteLine($"{e.Ora}:{e.Perc:D2} {osszTav:F1} km");

                    elozo = e;
                }
            }
            else
            {
                Console.WriteLine("Nincs ilyen rendszám!");
            }

            //7. feladat
                
            var szurt = adatok.Select(x=>x.Rendszam).Distinct().ToList();
            List<string>elso_utolso_adatok = new List<string>();
            foreach(var e in szurt)
            {
                var elso_jeladas = adatok.Where(x=>x.Rendszam == e).First();
                var utolso_jeladas = adatok.Where(x=>x.Rendszam == e).Last();
                elso_utolso_adatok.Add($"{elso_jeladas.Rendszam} {elso_jeladas.Ora} {elso_jeladas.Perc} {utolso_jeladas.Ora} {utolso_jeladas.Perc}");
            }
            File.WriteAllLines("ido.txt",elso_utolso_adatok);
        }
    }
}

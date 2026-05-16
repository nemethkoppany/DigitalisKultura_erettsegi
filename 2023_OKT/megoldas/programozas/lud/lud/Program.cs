namespace lud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Dobasok> dobasok = new List<Dobasok>();
            string[] lines = File.ReadAllLines("dobasok.txt");
            foreach (string line in lines)
            {
                string[] lineparts = line.Split(" ");
                foreach (string part in lineparts)
                {
                    dobasok.Add(new Dobasok(int.Parse(part)));
                }


            }

            List<Osvenyek> osvenyek = new List<Osvenyek>();
            string[] osveny_lines = File.ReadAllLines("osvenyek.txt");
            foreach (string line in osveny_lines)
            {
                Osvenyek osveny = new Osvenyek(
                        lepesek: line
                    );

                osvenyek.Add(osveny);
            }


            Console.WriteLine("2. feladat");
            Console.WriteLine($"A dobások száma: {dobasok.Count}");
            Console.WriteLine($"Az ösvények száma: {osvenyek.Count}");

            Console.WriteLine("3. feladat");

            var leghosszabb = 0;

            foreach (var osv in osvenyek)
            {
                if (osv.Lepesek.Length > leghosszabb)
                {
                    leghosszabb = osv.Lepesek.Length;
                }
            }



            for (int i = 0; i < osvenyek.Count; i++)
            {
                if (leghosszabb == osvenyek[i].Lepesek.Length)
                {
                    Console.WriteLine($"Az egyik leghosszabb a(z) {i + 1}.ösvény, hossza: {leghosszabb}");
                    break;
                }
            }

            Console.WriteLine("4. feladat");
            int osveny_sorszam = 0;
            int jatekosok_szama = 0;

            while (osvenyek.Count < osveny_sorszam || osveny_sorszam < 1)
            {
                Console.Write("Adja meg egy ösvény sorszámát! ");
                int bekert = int.Parse(Console.ReadLine());
                osveny_sorszam = bekert;
            }

            while(jatekosok_szama > 5 || jatekosok_szama < 2)
            {
                Console.Write("Adja meg a játékosok számát! ");
                int bekert_jatekos = int.Parse(Console.ReadLine());
                jatekosok_szama = bekert_jatekos;
            }

            Console.WriteLine("5. feladat");

            Dictionary<string, int> tipusok = new Dictionary<string, int>();

            for (int i = 0; i < osvenyek.Count; i++)
            {
                if (i + 1 == osveny_sorszam)
                {
                    for (int j = 0; j < osvenyek[i].Lepesek.Length; j++)
                    {
                        if (!tipusok.ContainsKey(osvenyek[i].Lepesek[j].ToString()))
                        {
                            tipusok.Add(osvenyek[i].Lepesek[j].ToString(),1);
                    }
                        else
                        {
                            tipusok[osvenyek[i].Lepesek[j].ToString()]++;
                        }
                    }
                    
                }
               
            }
            foreach (var (k, v) in tipusok)
            {
                Console.WriteLine($"{k}: {v} darab");

            }


            List<string> kulonleges = new List<string>();
            for(int i = 0; i < osvenyek[osveny_sorszam - 1].Lepesek.Length; i++)
            {
                if(osvenyek[osveny_sorszam - 1].Lepesek[i] != 'M')
                {
                    kulonleges.Add($"{i + 1}\t{osvenyek[osveny_sorszam - 1].Lepesek[i]}");
                }
            }

            File.WriteAllLines("kulonleges.txt",kulonleges);

            Console.WriteLine("7. feladat");

            List<int> lista = new List<int>();

            while (lista.Count < jatekosok_szama)
            {
                lista.Add(0);
            }

            int l = 0;
            for( l = 0; l < dobasok.Count; l++)
            {
                int jatekos = l % jatekosok_szama;
                lista[jatekos] += dobasok[l].Dobasok_;

                if((l + 1) % jatekosok_szama == 0 && lista.Max() >= osvenyek[osveny_sorszam - 1].Lepesek.Length)
                {
                    break;
                }
            }
            int legtavolabb = lista.IndexOf(lista.Max()) + 1;
            Console.WriteLine($"A legtávolabb jutó játékos sorszáma: {legtavolabb}, a(z) {(l + 1) / jatekosok_szama}. körben.");

            Console.WriteLine("8. feladat");
            List<int> poziciok = new List<int>();
            while (poziciok.Count < jatekosok_szama) poziciok.Add(0);

            string osvenyStr = osvenyek[osveny_sorszam - 1].Lepesek;
            int osvenyHossz = osvenyStr.Length;
            int kor = 0;

            for (int i = 0; i < dobasok.Count; i++)
            {
                int jatekos = i % jatekosok_szama;
                int dobas = dobasok[i].Dobasok_;
                int regi_poz = poziciok[jatekos];
                int uj_poz = regi_poz + dobas;

                if (uj_poz < osvenyHossz)
                {
                    char mezo = osvenyStr[uj_poz];
                    if (mezo == 'E') uj_poz += dobas;
                    else if (mezo == 'V') uj_poz = regi_poz;
                }

                poziciok[jatekos] = uj_poz;

                if ((i + 1) % jatekosok_szama == 0)
                {
                    kor++;
                    if (poziciok.Max() >= osvenyHossz) break;
                }
            }

            Console.Write("Nyertes(ek): ");
            for (int i = 0; i < jatekosok_szama; i++)
                if (poziciok[i] >= osvenyHossz) Console.Write($"{i + 1} ");

            Console.WriteLine("\nA többiek pozíciója:");
            for (int i = 0; i < jatekosok_szama; i++)
                if (poziciok[i] < osvenyHossz)
                    Console.WriteLine($"{i + 1}. játékos, {poziciok[i] + 1}. mező");
        }
    }
}

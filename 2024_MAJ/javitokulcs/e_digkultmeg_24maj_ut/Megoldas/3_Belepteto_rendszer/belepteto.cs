namespace belepteto
{
    internal class Program
    {
        struct Tesemeny
        {
            public string ki;
            public string mikor;
            public int mit;
        }
        static List<Tesemeny> dat = new List<Tesemeny>();
        static int db = 0;

        static void Main(string[] args)
        {
            Feladat1();
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
        }

        static void Feladat7()
        {
            Console.WriteLine("7. feladat");
            Console.Write("Egy tanuló azonosítója=");
            string azon = Console.ReadLine();
            string elso = "";
            string utolso = "";
            int ora = 0;
            int perc = 0;
            int i = 0;
            while (i < dat.Count && dat[i].ki != azon)
                i++;
            if (i == dat.Count)
                Console.WriteLine("Ilyen azonosítójú tanuló aznap nem volt az iskolában.");
            else
            {
                elso = dat[i].mikor;
                i = dat.Count - 1;
                while (i > 0 && dat[i].ki != azon)
                    i--;
                utolso = dat[i].mikor;
                perc = Convert.ToInt32(utolso.Substring(0, 2)) * 60 + Convert.ToInt32(utolso.Substring(3, 2));
                perc = perc - Convert.ToInt32(elso.Substring(0, 2)) * 60 - Convert.ToInt32(elso.Substring(3, 2));
                ora = perc / 60;
                perc = perc % 60;
                Console.WriteLine($"A tanuló érkezése és távozása között {ora} óra {perc} perc telt el.");
            }
        }

        static void Feladat6()
        {
            Console.WriteLine("6. feladat\nAz érintett tanulók:");
            int tol = -1;
            int ig = dat.Count;
            for (int i = 0; i < dat.Count; i++)
                if (string.Compare(dat[i].mikor, "10:50") > 0 && string.Compare(dat[i].mikor, "11:00") < 0 && dat[i].mit == 1)
                {
                    //ezt megelőzően utoljára mikor lépett be
                    int j = i - 1;
                    while (j >= 0 && !(dat[i].ki == dat[j].ki && dat[j].mit == 1))
                        j--;
                    //a két belépés között szabályosan kiment-e
                    int k = j + 1;
                    while (k < i && !(dat[k].ki == dat[i].ki && dat[k].mit == 2))
                        k++;
                    if (j > -1 && k == i)
                        Console.Write(dat[i].ki + " ");
                }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void Feladat5()
        {
            List<string> kvt = new List<string>();
            foreach (var x in dat)
                if (x.mit == 4 && !kvt.Contains(x.ki))
                    kvt.Add(x.ki);
            Console.WriteLine($"5. feladat\nAznap {kvt.Count} tanuló kölcsönzött a könyvtárban.");
            if (kvt.Count > db)
                Console.WriteLine("Többen voltak, mint a menzán.\n");
            else
                Console.WriteLine("Nem voltak többen, mint a menzán.\n");
        }

        static void Feladat4()
        {
            foreach (var x in dat)
                if (x.mit == 3) db++;
            Console.WriteLine($"4. feladat\nA menzán aznap {db} tanuló ebédelt.\n");
        }

        static void Feladat3()
        {
            Console.WriteLine("3. feladat\nA késők listájának előállítása\n");
            StreamWriter sw = new StreamWriter("kesok.txt");
            foreach (var x in dat)
                if (string.Compare(x.mikor, "07:50") > 0 && string.Compare(x.mikor.ToString(), "08:15") <= 0 && x.mit == 1)
                    sw.WriteLine(x.mikor + " " + x.ki);
            sw.Close();
        }

        static void Feladat2()
        {
            Console.WriteLine("2. feladat");
            Console.WriteLine($"Az első tanuló {dat[0].mikor}-kor lépett be a főkapun.");
            Console.WriteLine($"Az utolsó tanuló {dat[dat.Count - 1].mikor}-kor lépett ki a főkapun.\n");
        }

        static void Feladat1()
        {
            Console.WriteLine("1. feladat\nAz adatok beolvasása\n");
            StreamReader be = new StreamReader("bedat.txt");
            while (be.Peek() != -1)
            {
                string[] sor = be.ReadLine().Split(' ');
                Tesemeny esemeny = new Tesemeny();
                esemeny.ki = sor[0];
                esemeny.mikor = sor[1];
                esemeny.mit = int.Parse(sor[2]);
                dat.Add(esemeny);
            }
        }
    }
}

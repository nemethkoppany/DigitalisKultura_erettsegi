using System.Net.Sockets;

namespace konyvek
{
    public class Program
    {
        static List<Konyv> konyvek = new List<Konyv>();

        static void F1()
        {
            using (StreamReader sr = new StreamReader("kiadas.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] s = sr.ReadLine().Split(";");
                    konyvek.Add(new Konyv(Convert.ToInt32(s[0]), Convert.ToInt32(s[1]), s[2], s[3], Convert.ToInt32(s[4])));
                }
            }
           
        }

        static void F2()
        {
            Console.WriteLine("2. feladat");
            Console.Write("Szerző: ");
            string bekertSzerzo = Console.ReadLine();
            int kiadasDB = 0;
            for (int i = 0; i < konyvek.Count; i++)
            {
                if(konyvek[i].Adatok.Contains(bekertSzerzo))
                    kiadasDB++;

               
            }
            if (kiadasDB > 0)
            {
                Console.WriteLine($"{kiadasDB} konykiadás");
            }
            else
            {
                Console.WriteLine("Nincs kiadás!");
            }
            
        }

        static void F3()
        {
            Console.WriteLine("3. feladat");
            int maxPeldanyszam = 0;
            for (int i = 0; i < konyvek.Count; i++)
            {
                if (konyvek[i].Peldanyszam > maxPeldanyszam)
                {
                    maxPeldanyszam = konyvek[i].Peldanyszam;
                }
            }
            int maxPeldanyszamDb = 0;
            for (int i = 0; i < konyvek.Count; i++)
            {
                if (konyvek[i].Peldanyszam == maxPeldanyszam)
                {
                    maxPeldanyszamDb++;
                }
            }
            Console.WriteLine($"Legnagyobb példányszám: {maxPeldanyszam} és előfordult {maxPeldanyszamDb} alkalmommal");
        }

        static void F4()
        {
            Console.WriteLine("4. feladat");
            for(int i = 0;i < konyvek.Count;i++)
            {
                if (konyvek[i].Nyelv == "kf" && konyvek[i].Peldanyszam > 40000)
                {
                    Console.WriteLine($"{konyvek[i].Ev}/{konyvek[i].Nyegyedev}  {konyvek[i].Adatok}");
                    break;
                }
            }
        }

        static void F5()
        {
            Console.WriteLine("5. feladat");
            int[] evek = { 2020, 2021, 2022, 2023 };
            using (StreamWriter sw = new StreamWriter("table.html"))
            {
                Console.WriteLine("Év \t Magyar kiadás \t Magyar példányszám \t Külföldi kiadás \t Külföldi példányszám");
                sw.WriteLine("<table>\r\n<tr><th>Év</th><th>Magyar kiadás</th><th>Magyar példányszám</th><th>Külföldi\r\nkiadás</th><th>Külföldi példányszám</th></tr>");
                for(int i = 0; i< evek.Length; i++)
                {
                    int magyarKiadas = 0;
                    int magyarPeldanyszam = 0;
                    int kulfoldiKiadas = 0;
                    int kulfoldiPeldanyszam = 0;
                    for(int j = 0; j < konyvek.Count; j++)
                    {
                        if (konyvek[j].Ev == evek[i])
                        {
                            if (konyvek[j].Nyelv == "ma")
                            {
                                magyarKiadas++;
                                magyarPeldanyszam += konyvek[j].Peldanyszam;
                            }
                            else
                            {
                                kulfoldiKiadas++;
                                kulfoldiPeldanyszam += konyvek[j].Peldanyszam;
                            }
                        }
                    }
                    Console.WriteLine($"{evek[i]} \t \t{magyarKiadas} \t \t{magyarPeldanyszam} \t \t{kulfoldiKiadas} \t \t{kulfoldiPeldanyszam}");
                    sw.WriteLine($"<tr><td>{evek[i]}</td><td>{magyarKiadas}</td><td>{magyarPeldanyszam}</td><td>{kulfoldiKiadas}</td><td>{kulfoldiPeldanyszam}</td></tr>");

                }
                sw.WriteLine("</table>");
            }
        }

        static void F6()
        {
            Console.WriteLine("6. feladat");
            Console.WriteLine("Legalább kétszer, nagyobb példányszámban újra kiadott könyvek: ");
            List<string> konyvAdatok = new List<string>();  
            for(int i = 0; i < konyvek.Count; i++)
            {
                if (!konyvAdatok.Contains(konyvek[i].Adatok))
                {
                    konyvAdatok.Add(konyvek[i].Adatok);
                }
            }

            for(int i = 0;i < konyvAdatok.Count; i++)
            {
                int elsoKiadasPeldanyszam = 0;
                int elsoKiadasSorszam = 0;
                for(int j = 0; j < konyvek.Count; j++)
                {
                    if (konyvek[j].Adatok == konyvAdatok[i])
                    {
                        elsoKiadasPeldanyszam = konyvek[j].Peldanyszam;
                        elsoKiadasSorszam = j;
                        break;
                    }
                }

                int nagyobbKiadasok = 0;
                for (int j = 0; j < konyvek.Count; j++)
                {
                    if (konyvek[j].Adatok == konyvAdatok[i])
                    {
                        if(j > elsoKiadasSorszam && konyvek[j].Peldanyszam > elsoKiadasPeldanyszam)
                        {
                            nagyobbKiadasok++;
                        }

                    }
                }
                if(nagyobbKiadasok >= 2)
                {
                    Console.WriteLine($"{konyvAdatok[i]}");
                }
            }
        }

        static void Main(string[] args)
        {
            F1();
            F2();
            F3();
            F4();
            F5();
            F6();
        }
    }
}

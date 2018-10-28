using System;
/* using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; */

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] számtömb = new int[10];
            számtömb[0] = 3;
            string[] stringtömb = new string[10]; // mindegyik eleme null
            char[] karakterek = new char[] {'a', 'b', 'c', 'd', 'e'};
            Console.WriteLine(karakterek[0]); // a
            Console.WriteLine(karakterek[karakterek.Length - 1]); // e
            karakterek[2] = 'f';
            karakterek[számtömb[0]] = karakterek[2];
            // karakterek['a'] = '_';
            foreach (char elem in karakterek)
            {
                Console.Write(elem);
            }
            Console.Write('\n');
            for (int i = 0; i < karakterek.Length; i++) // vagy hátulról bejárva: int i = t.Length -1; i >= 0; i--
            {
                Console.Write(karakterek[i]);
            }
            Console.Write('\n');
            Console.WriteLine("Minden második elem: ");
            for (int i = 1; i < karakterek.Length; i += 2)
            {
                Console.Write(karakterek[i]);
            }
            Console.Write('\n');

            // Tömb megfordítása:
            for (int i = 0; i < karakterek.Length / 2; i++)
            {
                char temp = karakterek[i];
                karakterek[i] = karakterek[karakterek.Length - 1 - i];
                karakterek[karakterek.Length - 1 - i] = temp;
            }
            for (int i = 0; i < karakterek.Length; i++)
            {
                Console.Write(karakterek[i]);
            }
            Console.Write('\n');

            string[] hónapok = new string[] { "jan", "febr", "márc", "ápr", "máj", "jún", "júl", "aug", "szept", "okt", "nov", "dec" };
            string hónap = "";
            bool helyes = false;
            do
            {
                Console.Write("Adj meg egy hónapot: ");
                hónap = Console.ReadLine();
                for (int i = 0; i < hónapok.Length; i++)
                {
                    if (hónapok[i] == hónap)
                    {
                        helyes = true;
                    }
                }
            } while (!helyes);
            Console.WriteLine(hónap);

            int n = 5;
            int[] számok = new int[n];
            for (int i = 0; i < számok.Length; i++)
            {
                Console.Write("Add meg a(z) " + (i+1) + ". számot: ");
                számok[i] = int.Parse(Console.ReadLine());
            }

            int e1 = 0, e2db = 0, e3 = 0;
            double e2 = 0.0;
            for (int i = 0; i < számok.Length; i++)
            {
                if (számok[i] < 0)
                {
                    e1 += számok[i];
                } else
                if (számok[i] == 0)
                {
                    e3++;
                } else
                {
                    e2db++;
                    e2 += számok[i];
                }
            }
            e2 /= e2db;
            Console.WriteLine("Negatívok összege: " + e1);
            Console.WriteLine("Pozitívok átlaga: " + e2);
            Console.WriteLine("Zérusok darabszáma: " + e3);
            int j = 0;
            int[] nemnegatív = new int[e3 + (int)e2db];
            for (int i = 0; i < számok.Length; i++)
            {
                  if (számok[i] >= 0)
                  {
                    nemnegatív[j] = számok[i];
                    j++;
                  }
            }
            Console.Write("A nemnegatív számok: ");
            for (int i = 0; i < nemnegatív.Length; i++)
            {
                Console.Write(nemnegatív[i] + " ");
            }
            Console.Write('\n');

            Kiírás("Hello!");
            Üdvözlet();
            bool igaz = MindigIgaz();
            int összeg = Összead(10, 20);
            double összeg2 = Összead(15.3, 10);

           Console.ReadKey();

        }
        // Metódusok:
        static void Kiírás(string üzenet)
        {
            Console.WriteLine(üzenet);
        }
        static void Üdvözlet()
        {
            Kiírás("Hello World!");
        }
        static bool MindigIgaz()
        {
            return true;
        }
        static int Összead(int a, int b)
        {
            return a + b;
        }
        static int Összead(int a, int b, int c) // overload
        {
            return a + b + c;
        }
        static double Összead(double a, double b)
        {
            return a + b;
        }
    }
}

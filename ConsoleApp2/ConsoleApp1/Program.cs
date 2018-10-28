using System;
/* using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; */

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3, m = 3;

            double négyzete = Math.Pow(n, m);
            Console.WriteLine("Négyzete: " + négyzete);

            double gyöke = Math.Pow(n, 0.5);
            Console.WriteLine("Gyöke: " + gyöke);

            double pi = Math.PI;

            n = 5;
            if (n > 10) ;  // empty statement, rossz lesz így
            {
                Console.WriteLine("A szám nagyobb, mint 10!");
            }

            switch(n)
            {
                case var expression when n < 7:
                    Console.WriteLine("Kisebb, mint 7");
                    break;
                case var _ when n > 7:
                    Console.WriteLine("Nagyobb, mint 7");
                    break;
                default:
                    Console.WriteLine("Egyenlő 7-tel");
                    break;
            }

            string országkód = "de";
            switch(országkód)
            {
                case "at":
                case "de":
                    Console.WriteLine("Német");
                    break;
                default:
                    break;
            }

            int i = 10, j = 0;
            if (j != 0 && i/j == 9)
            {
                Console.WriteLine("Hiba!"); // (i/j == 9) ki se lesz értékelve, úgyhogy nem lesz hiba
            } else
            {
                Console.WriteLine("Le se fut!");
            }

            i = 0;
            while(i++ < 10)
            {
                Console.WriteLine(i); // 1..10
            }

            i = 0;
            do
            {
                Console.WriteLine(++i); // 1..10
            } while (i < 10);

            for (int k = 1; k <= 10; k++)
            {
                Console.WriteLine(k);
            }

            string[] collection = { "egy", "kettő", "három" };
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            Console.Write("Kérek egy számot: ");
            int szám = int.Parse(Console.ReadLine());
            Console.Write("Hatvány: ");
            int hatvány = int.Parse(Console.ReadLine());
            int eredmény = 1;
            while (hatvány > 0)
            {
                eredmény *= szám;
                hatvány--;
            }
            Console.WriteLine("Az eredmény: " + eredmény);
            eredmény = 1;
            while (szám>1)
            {
                eredmény *= szám;
                szám--;
            }
            Console.WriteLine("Faktoriális: " + eredmény);

            Console.Write("Fibonacci-sor hányadik eleme? ");
            n = int.Parse(Console.ReadLine());
            ulong a0 = 1, a1 = 1;
            if (n == 0)
            {
                Console.WriteLine(a0);
            } else if (n == 1)
            {
                Console.WriteLine(a1);
            } else if (n >= 2)
            {
                int index = 2;
                ulong következő = 0;
                while (index <= n)
                {
                    következő = a0 + a1;
                    a0 = a1;
                    a1 = következő;
                   
                    index++;
                }
                Console.WriteLine("A(z) " + --index + ". sorszámú elem: " + következő);

            } else
            {
                Console.WriteLine("Hiba.");
            }

            Random rnd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            int a = rnd.Next(); //0..int.MaxValue
            int b = rnd.Next(100); // 0..99
            int c = rnd.Next(10, 100); // 10..99
            double nemEgész = rnd.NextDouble(); // 0.0..1.0
            Console.WriteLine("Random számok: " + a + " " + b + " " + " " + c + " " + nemEgész);

            for (int rr = 0; rr < 10; rr++)
            {
                Random r = new Random(); // Rossz!
                Console.WriteLine(r.Next());
            }

            Console.WriteLine("Gondoltam egy számra. 10 000-nél kisebb.");
            int tipp = 0, igazi = rnd.Next(0,10000), próbálkozások = 0;
            while (tipp != igazi)
            {
                Console.Write("Tipp? ");
                tipp = int.Parse(Console.ReadLine());
                próbálkozások++;
                if (tipp < igazi)
                {
                    Console.WriteLine("Nagyobb.");
                } else if (tipp > igazi)
                {
                    Console.WriteLine("Kisebb.");
                }
            }
            Console.WriteLine("Igen, erre gondoltam. " + próbálkozások + " számú tipped volt jó.");
            // do-while kellett volna inkább

            Console.ReadKey();
        }
    }
}

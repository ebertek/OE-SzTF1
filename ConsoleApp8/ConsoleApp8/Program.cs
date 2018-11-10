using System;
/* using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; */

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            Hallgato Béla = new Hallgato();
            Hallgato Gizi = new Hallgato("Gizi", "DEF456", 2000);
            Béla.Neptunkód = "ABC123";
            Console.WriteLine("Béla neve: " + Béla.Név + ", Gizi neve: " + Gizi.Név);

            Console.WriteLine();
            Béla.Tanul();
            Eredmény eredmény = Béla.Vizsgázik("SzTF1");
            Eredmény eredmény2 = Gizi.Vizsgázik("SzTF1"); // ugyanaz lesz most, de ha berakunk egy breakpointot felé, akkor nem ;D
            Console.WriteLine(eredmény); // a `public override string ToString()` fog lefutni
            Console.WriteLine(eredmény2);

            Console.WriteLine();
            Haromszog haromszog = new Haromszog(3, 4, 5);
            Console.WriteLine("Kerület: " + haromszog.Kerület());
            Console.WriteLine("Terület: " + haromszog.Terület());

            Console.WriteLine();
            Haromszog haromszog2 = new Haromszog();
            Console.WriteLine("Kerület: " + haromszog2.Kerület());
            Console.WriteLine("Terület: " + haromszog2.Terület());

            Console.WriteLine();
            Haromszog haromszog3 = new Haromszog();
            Console.WriteLine(haromszog3.A);
            haromszog3.A = 0; // nem fogja átírni, mert nem lesz szerkeszthető a háromszög
            Console.WriteLine(haromszog3.A);

            Console.ReadKey();
        }
    }
}

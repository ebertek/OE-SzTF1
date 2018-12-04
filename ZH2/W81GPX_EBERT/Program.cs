using System;
/* using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; */

namespace W81GPX_EBERT
{
    class Program
    {
        static void Betölt()
        {
            System.IO.StreamReader sr = new System.IO.StreamReader("INPUT.TXT");
            ÜzenetFeldolgozó.Üzenet = sr.ReadLine().Split('@'); // csak 1 sor van
            sr.Close();
        }
        static void Kiír(Tankör tankör)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("OUTPUT.TXT");
            sw.WriteLine(tankör.LegjobbEredmény());
            sw.WriteLine(tankör.LegjobbÁtlag());
            sw.WriteLine(tankör.LegtöbbVizsgaNap());
            sw.Close();
        }
        static void Main(string[] args)
        {
            Betölt();
            Tankör tankör = new Tankör("L1");
            while (ÜzenetFeldolgozó.VanÜzenet())
            {
                tankör.ÚjHallgató(ÜzenetFeldolgozó.Feldolgoz());
            }
            Kiír(tankör);
        }
    }
}

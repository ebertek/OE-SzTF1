using System;
/* using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; */

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            /* https://elearning.uni-obuda.hu/main/pluginfile.php/153564/mod_resource/content/0/ZH1%20Example%20Temperature.pdf */
            Console.WriteLine("1) Felhasználói adatbekérés.");
            Console.WriteLine("2) Adatsorgenerálás.");
            Console.WriteLine("nbr) Kilépés.");
            Console.Write("> ");
            int[] temps;
            int /*choise*/
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    temps = TemperatureFromUser();
                    break;
                case 2:
                    temps = TemperatureFromGenerator();
                    break;
                default:
                    Environment.Exit(0);
                    temps = new int[0];
                    break;
            }
            Print(temps);
            Console.WriteLine("A 0-hoz legközelebbi nem-0 elem: " + FindClosestToZero(temps));
            Console.WriteLine("A mérések középhőmérséklete: " + CalcAverage(temps));
            Console.WriteLine("A mérések ezekben az évszakokban történtek: " + GetSeason(temps));
            SortRevere(temps);
            Print(temps);
            Print(NegativeSelection(temps));

            Console.ReadKey();
        }
        static int[] TemperatureFromUser()
        {
            int n;
            do
            {
                Console.Write("Hány mérést szeretne megadni (min. 5)? ");
                n = int.Parse(Console.ReadLine());
            } while (n < 5);
            int[] temps = new int[n];

            Console.WriteLine("Adja meg az értékeket!");
            for (int i = 0; i < temps.Length; i++)
            {
                Console.Write(i + 1 + ". érték: ");
                temps[i] = int.Parse(Console.ReadLine());
            }
            return temps;
        }
        static int[] TemperatureFromGenerator()
        {
            int n;
            do
            {
                Console.Write("Hány mérést szeretne legeneráltatni (min. 10)? ");
                n = int.Parse(Console.ReadLine());
            } while (n < 10);
            int[] temps = new int[n];

            Random rnd = new Random();
            for (int i = 0; i < temps.Length; i++)
            {
                temps[i] = rnd.Next(-50, 51);
            }
            return temps;
        }
        static void Print(int[] T)
        {
            /* for (int i = 0; i < T.Length; i++)
            {
                Console.Write(T[i].ToString() + '\t');
            } */
            Console.WriteLine(string.Join("\t", T));
        }
        static int FindClosestToZero(int[] T)
        {
            int closest = int.MaxValue;
            for (int i = 0; i < T.Length; i++) //0-tól megyünk, mert (closest == 0) nem jó (feladatkiírás)
            {
                if (Math.Abs(T[i]) < Math.Abs(closest) && T[i] != 0) {
                    closest = T[i];
                } else
                if (Math.Abs(T[i]) == Math.Abs(closest) && T[i] > closest)
                {
                    closest = T[i];
                }
            }
            return closest;
        }
        static double CalcAverage(int[] T)
        {
            // legkisebb és legnagyobb értéket nem vesszük figyelembe
            int min = T[0];
            int max = T[0];
            double sum = T[0];
            for (int i = 1; i < T.Length; i++)
            {
                sum += T[i];
                if (T[i] > max)
                {
                    max = T[i];
                }
                if (T[i] < min)
                {
                    min = T[i];
                }
            }
            return (sum - max - min) / (T.Length - 2);
        }
        static string GetSeason(int[] T)
        {
            int negativ=0, nyar=0, pozitiv=0, nulla=0;
            for (int i = 0; i < T.Length; i++)
            {
                if (T[i] < 0) negativ++;
                else
                if (T[i] == 0) nulla++;
                else
                if (T[i] > 0)
                {
                    pozitiv++;
                    if (T[i] > 27.5)
                        nyar++;
                }               
            }
            string évszak = "", separator = "";
            if (negativ > T.Length / 2) { évszak += "TÉL"; separator = ", "; }
            if (negativ == pozitiv) { évszak += separator + "TAVASZ"; separator = ", "; };
            if (nyar > T.Length * 0.42) { évszak += separator + "NYÁR"; separator = ", "; };
            if (nulla > Math.Sqrt(T.Length)) { évszak += separator + "ŐSZ"; }
            if (évszak == "") évszak = "NEM TUDNI";

            return évszak;
        }
        static int[] NegativeSelection(int[] T)
        {
            int[] /* selected */ filtered = new int[T.Length];
            int j = 0;
            for (int i = 0; i < T.Length; i++)
            {
                if (T[i]<0)
                {
                    filtered[j] = T[i];
                    j++;
                }
            }

            Console.Write("Kérem a 'k' értékét: ");
            int k = int.Parse(Console.ReadLine());

            int[] k_adikak = new int[j / k];
            j = 0;
            for (int i = k-1; i < filtered.Length; i += k)
            {
                if (filtered[i] != 0)
                {
                    k_adikak[j] = filtered[i];
                    j++;
                }
            }

            return k_adikak; ;
        }
        static void SortRevere(int[] T)
        {
            // JavítottBeillesztésesRendezés
            for (int i = 1; i < T.Length; i++) // pszeudokódban i=2-től, mert az 1-től indexel
            {
                int j = i - 1;
                int segéd = T[i];
                while (j >= 0 && T[j] < segéd) // itt >=0 van, nem >, mint pszeudokódban; <: csökkenő sorrend, >: növekvő
                {
                    T[j + 1] = T[j];
                    j--;
                }
                T[j + 1] = segéd;
            }
            /* Array.Sort(T); Array.Reverse(T); */
        }
        static int CalcPositiveModulo(int[] T)
        {
            return 0;
        }
    }
}

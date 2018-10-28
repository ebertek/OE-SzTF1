using System;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3 };
            int[] b = a;
            int   c = 1;
            b[0] = 70; // a[0] is 70 lesz
            Console.Write("Az 'a' tömb elemei: "); ;
            foreach (int elem in a) Console.Write(elem + " ");
            Console.Write('\n');
            Console.Write("A 'b' tömb elemei: "); ;
            foreach (int elem in b) Console.Write(elem + " ");
            Console.Write('\n');
            Console.Write("A 'c' értéke: " + c);
            Console.Write('\n');

            Console.Write('\n');
            Módosít(b, c); // b[c] = 50; a[c]=50; c = 1; az érték lemásolódik a változóba, a tömb nem
            Console.Write("Az 'a' tömb elemei: "); ;
            foreach (int elem in a) Console.Write(elem + " ");
            Console.Write('\n');
            Console.Write("A 'b' tömb elemei: "); ;
            foreach (int elem in b) Console.Write(elem + " ");
            Console.Write('\n');
            Console.Write("A 'c' értéke: " + c);
            Console.Write('\n');

            Console.Write('\n');
            MódosítRef(b, ref c); // c is módosul
            Console.Write("Az 'a' tömb elemei: "); ;
            foreach (int elem in a) Console.Write(elem + " ");
            Console.Write('\n');
            Console.Write("A 'b' tömb elemei: "); ;
            foreach (int elem in b) Console.Write(elem + " ");
            Console.Write('\n');
            Console.Write("A 'c' értéke: " + c);
            Console.Write('\n');

            Console.Write('\n');
            MódosítÚj(b);
            Console.Write("Az 'a' tömb elemei: "); ;
            foreach (int elem in a) Console.Write(elem + " ");
            Console.Write('\n');
            Console.Write("A 'b' tömb elemei: "); ;
            foreach (int elem in b) Console.Write(elem + " ");
            Console.Write('\n');
            Console.Write("A 'c' értéke: " + c);
            Console.Write('\n');

            Console.Write('\n');
            MódosítÚjRef(ref b);
            Console.Write("Az 'a' tömb elemei: "); ;
            foreach (int elem in a) Console.Write(elem + " ");
            Console.Write('\n');
            Console.Write("A 'b' tömb elemei: "); ;
            foreach (int elem in b) Console.Write(elem + " ");
            Console.Write('\n');
            Console.Write("A 'c' értéke: " + c);
            Console.Write('\n');

            Console.Write('\n');
            Console.WriteLine("Programozási tételek");
            Console.WriteLine("====================");
            int[] T = new int[1000];
            Console.WriteLine("Feltöltöm a tömböt, jól. Várj egy picit. ;)");
            Feltöltés(T);
            // Kiír(T);
            Console.WriteLine("A tömb elemeinek összege: " + Sorozatszámítás(T));
            bool ÖttelOsztható = Eldöntés(T, 5);
            if (ÖttelOsztható) {
                Console.Write("Van 5-tel osztható elem. ");
                int idx = EldöntésIndex(T, 5);
                Console.Write("Az első indexe: " + idx + ", értéke: " + T[idx] + "\n");
                Console.WriteLine("Összesen " + Megszámlálás(T, 5) + " 5-tel osztható elem van.");
            } else
            { Console.WriteLine("Nincs 5-tel osztható elem."); }
            Console.WriteLine("A legkisebb elem: " + Legkisebb(T));

            Console.Write('\n');
            Console.WriteLine("Stringek");
            Console.WriteLine("========");
            string s = "Karaktersorozat";
            // értékadás nélkül _null lesz az értéke, nem ""
            s = new string('c', 12);
            Console.WriteLine(s.Substring(0,5));
            // String.Formattal lehet formázni, $ megoldás is van
            Console.WriteLine("Random Neptun-kódok: " + ÚjNeptun() + ", " + ÚjNeptun() + ", " + ÚjNeptun());
            Random rnd = new Random();
            Console.WriteLine("Randomabb Neptun-kódok: " + ÚjNeptunJó(rnd) + ", " + ÚjNeptunJó(rnd) + ", " + ÚjNeptunJó(rnd));

            int[] betűk = betűkSzáma("Lorem ipsum dolor sit amet...");
            Console.WriteLine("Az 'm' betűk száma: " + betűk['m']);
            Console.WriteLine("Magánhangzók száma: " + magánhangzókSzáma("Lorem ipsum dolor sit amet..."));
            Console.WriteLine("Hello Világ".Replace(" ", "")); // üres string lehet, de üres char nem

            Console.ReadKey();
        }

        static void Módosít(int[] tömb, int index)
        {
            tömb[index] = 50;
            index = 40;
        }

        static void MódosítRef(int[] tömb, ref int index)
        {
            tömb[index] = int.MinValue;
            index = int.MaxValue;
        }

        static void MódosítÚj(int[] tömb)
        {
            tömb = new int[] { 9, 8, 7, 6 }; // ilyenkor új helyre mutat, és ennek a végén így meg is szűnik az egész
        }

        static void MódosítÚjRef(ref int[] tömb)
        {
            tömb = new int[] { 9, 8, 7, 6 }; // így jó
        }

        static void Feltöltés(int[] tömb)
        {
            Random rand = new Random();
            for (int i = 0; i < tömb.Length; i++)
            {
                tömb[i] = rand.Next(0, 101);
                
            }
            // mivel tömb, nem kell visszaadnunk a metódusból, átíródik jól
        }

        static void Kiír(int[] tömb)
        {
            foreach (int érték in tömb)
            {
                Console.Write(érték + " ");
            }
        }

        static int Sorozatszámítás(int[] tömb)
        {
            // Elemek összege
            // https://users.nik.uni-obuda.hu/sergyan/Programozas1Jegyzet.pdf
            int összeg = 0;
            for (int i = 0; i < tömb.Length; i++)
            {
                összeg += tömb[i];
            }
            return összeg;
        }

        static bool Eldöntés(int[] tömb, int osztó)
        {
            // Létezik-e 'osztó'-val osztható elem
            int i = 0;
            while (i<tömb.Length && tömb[i] % osztó != 0)
            {
                i++;
            }
            return i < tömb.Length;
        }

        static int EldöntésIndex(int[] tömb, int osztó)
        {
            int i = 0;
            while (i < tömb.Length && tömb[i] % osztó != 0)
            {
                i++;
            }
            if (i < tömb.Length) return i;
            return -1;
        }

        static int Megszámlálás(int[] tömb, int osztó)
        {
            int db = 0;
            for (int i = 0; i < tömb.Length; i++)
            {
                if(tömb[i] % osztó == 0)
                {
                    db++;
                }
            }
            return db;
        }

        static int Legkisebb(int[] tömb)
        {
            int min = 0; // index
            for (int i = 1; i < tömb.Length; i++)
            {
                if (tömb[i] < tömb[min]) /* ha < helyett <=, akkor az első legkisebb elem helyett az utolsót adja vissza */ {
                    min = i;
                }
            }
            return min;
        }

        static string ÚjNeptun()
        {
            string kód = "";
            Random rand = new Random();
            for (int i = 0; i < 6; i++)
            {
                if (rand.Next(0, 101) < 30)
                {
                    kód += rand.Next(0, 10);
                }
                else
                {
                    kód += (char)rand.Next('A', 'Z' + 1); // 65 és 90 ASCII-ban az A és Z
                }
            }
            return kód;
        }

        static string ÚjNeptunJó(Random rand)
        {
            string kód = "";
            for (int i = 0; i < 6; i++)
            {
                if (rand.Next(0, 101) < 30)
                {
                    kód += rand.Next(0, 10);
                }
                else
                {
                    kód += (char)rand.Next('A', 'Z' + 1); // 65 és 90 ASCII-ban az A és Z
                }
            }
            return kód;
        }

        static int[] betűkSzáma(string szöveg)
        {
            int[] betűk = new int[128]; // ASCII
            for (int i = 0; i < szöveg.Length; i++)
            {
                betűk[(int)szöveg[i]]++;
            }
            return betűk;
        }

        static int magánhangzókSzáma(string szöveg)
        {
            int db = 0;
            foreach (char c in szöveg)
            {
                //if ("aáeéiíoóöőuúüű".Contains(char.ToLower(c))
                    if ("aáeéiíoóöőuúüű".Contains(c.ToString().ToLower()))
                    db++;
            }
            return db;
        }

    }
}

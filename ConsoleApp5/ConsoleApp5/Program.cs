using System;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; */

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Többdimenziós tömbök
            int[] vektor = new int[10];
            int[,] mátrix = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 0, 1, 2 } }; // dimenziószám-1 db vessző
            int[,] tömb2D = new int[2, 5]; // 2 sor, 5 oszlop
            Feltöltés(tömb2D);
            // int[,] tömb2D = LétrehozÉsFeltölt(2, 5);
            Console.WriteLine($"Összes elem tömb2D-ben: {tömb2D.Length}"); // 10
            Console.WriteLine($"Dimenziók száma: {tömb2D.Rank}"); // 2
            Console.WriteLine($"Sorok száma: {tömb2D.GetLength(0)}"); // 2
            Console.WriteLine($"Oszlopok száma: {tömb2D.GetLength(1)}"); // 5
            Console.WriteLine("Első elem: " + tömb2D[0,0]);
            Console.WriteLine("Utolsó elem: " +
                tömb2D[tömb2D.GetLength(0) - 1, tömb2D.GetLength(1) - 1]);
            Console.WriteLine();
            Console.WriteLine("A teljes tömb: ");
            Kiír(tömb2D);
            Console.WriteLine();
            Console.Write("0. sor: ");
            KiírSor(tömb2D, 0);
            Console.WriteLine();
            Console.WriteLine("0. oszlop: ");
            KiírOszlop(tömb2D, 0);
            Console.WriteLine();
            Console.WriteLine("A mátrix transzponáltja: ");
            KiírTranszponált(tömb2D);
            Console.WriteLine();
            Console.WriteLine("=========");
            Console.WriteLine("| LOTTÓ |");
            Console.WriteLine("=========");
            Random rand = new Random();
            int[] kihúzott = GenerateDraw(rand);
            Console.WriteLine(OutDraw(kihúzott));
            int[,] beküldött = GenerateLotto(rand);
            Console.WriteLine(OutLotto(beküldött, kihúzott));

            Console.ReadKey();
        }
        static void Feltöltés(int[,] tömb)
        {
            Random rand = new Random();
            for (int i = 0; i < tömb.GetLength(0); i++)
            {
                for (int j = 0; j < tömb.GetLength(1); j++)
                {
                    tömb[i, j] = rand.Next(1, 101);
                }
            }
        }
        static int[,] LétrehozÉsFeltölt(int sor, int oszlop)
        {
            Random rnd = new Random();
            int[,] tömb = new int[sor, oszlop];
            for (int i = 0; i < tömb.GetLength(0); i++)
            {
                for (int j = 0; j < tömb.GetLength(1); j++)
                {
                    tömb[i, j] = rnd.Next(1, 10);
                }
            }
            return tömb;
        }
        static void Kiír(int[,] tömb)
        {
            for (int i = 0; i < tömb.GetLength(0); i++)
            {
                for (int j = 0; j < tömb.GetLength(1); j++)
                {
                    Console.Write(tömb[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void KiírSor(int[,] tömb2D, int sor)
        {
            for (int j = 0; j < tömb2D.GetLength(1); j++)
            {
                Console.Write(tömb2D[sor, j] + " ");
            }
            Console.WriteLine();
        }
        static void KiírOszlop(int[,] tömb2D, int oszlop)
        {
            for (int i = 0; i < tömb2D.GetLength(0); i++)
            {
                Console.WriteLine(tömb2D[i, oszlop]);
            }
        }
        static void KiírTranszponált(int[,] mátrix)
        {
            for (int j = 0; j < mátrix.GetLength(1); j++)
            {
                for (int i = 0; i < mátrix.GetLength(0); i++)
                {
                    Console.Write(mátrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        // LOTTÓ
        static int[] GenerateDraw(Random rnd)
        {
            // kihúzott számok generálása
            int[] tömb = new int[5];
            for (int i = 0; i < tömb.Length; i++)
            {
                int következő = rnd.Next(1, 91);
                int k = 0;
                while (k < i && tömb[k] != következő)
                {
                    k++;
                }
                if (k==i) { tömb[i] = következő; } else { i--; } // végtelen ciklus lesz, ha 5<91-1. Más megoldás is jó arra, hogy ne legyenek ismétlődő számok.
            }
            return tömb;
        }
        static string OutDraw(int[] t)
        {
            // kihúzott számok megjelenítése
            /*string sep = "";
            string s = "";
            for (int i = 0; i < t.Length; i++)
            {
                s += sep + t[i];
                sep = ", ";
            }
            return s;*/
            return string.Join(", ", t);
        }
        static int[,] GenerateLotto(Random rnd)
        {
            // szelvények generálása
            int[,] szelvények = new int[20, 5]; // 20x ötöslottószelvény
            for (int i = 0; i < szelvények.GetLength(0); i++)
            {
                int[] szelvény = GenerateDraw(rnd);
                // szelvények[i] = szelvény; // ilyet nem lehet csinálni :\
                for (int k = 0; k < szelvény.Length; k++)
                {
                    szelvények[i, k] = szelvény[k];
                }
            }
            return szelvények;
        }
        static string OutLotto(int[,] t, int[] u)
        {
            // kitöltött szelvények és találatok számának megjelenítéses
            string s = "";
            for (int i = 0; i < t.GetLength(0); i++)
            {
                int találat = 0;
                s += "Szelvény #" + (i + 1) + ":\t";
                for (int j = 0; j < t.GetLength(1); j++)
                {
                    s += t[i, j] + " ";
                    if (Inside(u, t[i,j]))
                    {
                        találat++;
                    }
                }
                s += "\tTalálatok száma: " + találat + "\n";
            }
            return s;
        }
        static bool Inside(int[] t, int value)
        {
            // adott szám szerepel-e egy adott szelvényen
            int i = 0;
            while (i < t.Length && t[i] != value)
            {
                i++;
            }
            return i < t.Length;
        }
    }
}

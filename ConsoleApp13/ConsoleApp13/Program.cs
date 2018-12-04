using System;

namespace ConsoleApp13
{
    class Program
    {
        static int[] Pénzkifizetés (int x, int[] c) // mohó (greedy) algoritmus
        {
            int n = c.Length;
            int[] db = new int[n];
            for (int i = 0; i < n; i++)
            {
                db[i] = 0;
            }
            int j = n - 1;
            while (x > 0)
            {
                while (c[j] > x)
                {
                    j--;
                }
                db[j]++;
                x -= c[j];
            }
            return db;
        }
        static void Main(string[] args)
        {
            Console.Write("Hány forintot kell kifizetni? ");
            int x = int.Parse(Console.ReadLine());
            int[] c = { 5, 10, 20, 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000 }; // rendezett tömbnek kell lennie (növekvő)
            x = (int)(Math.Round(x / 5.0) * 5); // 5 Ft-ra kerekítés
            int[] db = Pénzkifizetés(x, c);
            for (int i = c.Length - 1; i >= 0; i--)
            {
                if (db[i] > 0)
                {
                    Console.WriteLine($"{c[i]} Ft: {db[i]} db");
                }
            }
            Console.ReadKey();
        }
    }
}

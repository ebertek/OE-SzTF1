using System;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            BullHunter bh = new BullHunter();
            LogHandler.LogInfo("Game started...");
            do
            {
                Console.Clear();
                bh.DrawMap();

                Console.WriteLine($"Nbr of live bulls: {bh.NbrOfLiveBulls}");
                Console.WriteLine($"Nbr of dead bulls: {bh.NbrOfDeadBulls}");
                bh.ClosestBullFromGoal();
                LogHandler.LogDebug($"Last shoot hit: {bh.LastShootHit}");
                Console.WriteLine($"Last shoot hit: {bh.LastShootHit}");

                Console.WriteLine();
                Console.Write("Shoot X coordinate: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Shoot Y coordinate: ");
                int y = int.Parse(Console.ReadLine());
                bh.Shoot(new Coordinate(x, y));

                bh.Move();
            } while (bh.GetGameState == GameState.OnGoing);

            LogHandler.LogInfo("End game!");

            Console.Clear();
            bh.DrawMap();

            if (bh.GetGameState == GameState.BullsWon)
            {
                Console.WriteLine("Bulls won the game!");
            } else if (bh.GetGameState == GameState.PlayerWon)
            {
                Console.WriteLine("You won the game!");
            }

            LogHandler.WriteToFile();
            Console.ReadKey();
        }
    }
}

using System;
using System.IO;

namespace ConsoleApp10
{
    class BullHunter
    {
        private Bull[] bulls;

        public GameState GetGameState
        {
            get
            {
                GameState state = GameState.PlayerWon;
                for (int i = 0; i < bulls.Length; i++)
                {
                    if (bulls[i].Alive && bulls[i].Crd.Equals(Map.EndCrd))
                    {
                        return GameState.BullsWon; // ki is lépünk a ciklusból
                    } else if (bulls[i].Alive)
                    {
                        state = GameState.OnGoing;
                    }
                }
                return state;
            }
        }
        public int LastShootHit { get; private set; }
        public int NbrOfDeadBulls { get; private set; }
        public int NbrOfLiveBulls { get { return bulls.Length - NbrOfDeadBulls; } }

        public BullHunter() : this("bullhunter.init") { }
        public BullHunter(string filename)
        {
            StreamReader sr = new StreamReader(filename);

            bulls = new Bull[int.Parse(sr.ReadLine())]; // 1. sorban van a bölények száma
            
            /* string[] crd = sr.ReadLine().Split(); // 2. sorban van a pálya mérete
            Map.SetSize(int.Parse(crd[0]), int.Parse(crd[1])); */
            Map.SetSize(Array.ConvertAll(sr.ReadLine().Split(), int.Parse));

            if (sr.ReadLine() == "RND")
            {
                for (int i = 0; i < bulls.Length; i++)
                {
                    bulls[i] = new Bull();
                }
            } else
            {
                for (int i = 0; i < bulls.Length; i++)
                {
                    string line = sr.ReadLine().Replace("{", "").Replace("}", "");
                    string[] crd = line.Split(new char[] { ',' });
                    bulls[i] = new Bull(new Coordinate(int.Parse(crd[0]), int.Parse(crd[1])));
                }
            }
            sr.Close();
        }
        public void ClosestBullFromGoal()
        {
            double distance = int.MaxValue;
            for (int i = 0; i < bulls.Length; i++)
            {
                double actDistance = bulls[i].Distance(Map.EndCrd);
                if (bulls[i].Alive && actDistance < distance)
                {
                    distance = actDistance;
                }
            }
            Console.WriteLine($"Closest bull from the goal ({Map.EndCrd}): {distance}");
        }
        public void DrawMap()
        {
            string map = "  ";

            for (int i = 0; i < Map.Width; i++)
            {
                map += i.ToString().PadLeft(2); // Oszlopok:  0 1 2 3 ...
            }
            map += Environment.NewLine;

            for (int y = 0; y < Map.Width; y++)
            {
                map += y.ToString().PadLeft(2);
                for (int x = 0; x < Map.Height; x++)
                {
                    char cell = '-';
                    // string cell = "-";
                    for (int i = 0; i < bulls.Length; i++)
                    {
                        if (bulls[i].Distance(new Coordinate(x, y)) == 0)
                        {
                            if (!bulls[i].Alive)
                            {
                                cell = '+'; // halott bölény
                                // cell = "💀";
                            } else if (GetGameState != GameState.OnGoing)
                            {
                                cell = 'o'; // élő bölény (csak akkor látszanak, ha már vége a játéknak)
                                // cell = "🐮";
                            }
                        }
                    }
                    map += cell.ToString().PadLeft(2);
                }
                map += Environment.NewLine;
            }
            Console.WriteLine(map);
        }
        public void Move()
        {
            for (int i = 0; i < bulls.Length; i++)
            {
                if (bulls[i].Alive)
                {
                    bulls[i].Move();
                }
            }
        }
        public void Shoot(Coordinate shoot)
        {
            if (shoot.X < 0 || shoot.Y < 0 || shoot.X >= Map.Width || shoot.Y >= Map.Height) // a Map statikus osztály, bárhonnan elérhetjük példányosítás nélkül
            {
                return; // ki is lépünk a metódusból
            }

            LastShootHit = 0;
            for (int i = 0; i < bulls.Length; i++)
            {
                if (bulls[i].Alive && bulls[i].Distance(shoot) == 0)
                {
                    LastShootHit++;
                    bulls[i].Alive = false;
                }
            }

            NbrOfDeadBulls += LastShootHit;
        }
    }
}

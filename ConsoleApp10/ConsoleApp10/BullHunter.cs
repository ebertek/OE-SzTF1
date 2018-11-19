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
        }
        public void DrawMap()
        {
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
        }
    }
}

using System;

namespace ConsoleApp10
{
    class Bull
    {
        private static Random rnd = new Random();
        public bool Alive { get; set; } = true; // ugyanaz, mintha a konstruktorokban tennénk igazzá
        public Coordinate Crd { get; private set; }

        public Bull()
        {
            Crd = new Coordinate(rnd.Next(Map.Width), rnd.Next(Map.Height)); // mert a Map classban ezek static propertyk
        }
        public Bull(Coordinate crd)
        {
            Crd = crd;
        }
        public double Distance(Coordinate crd)
        {
            return Math.Sqrt(Math.Pow(Crd.X - crd.X, 2) + Math.Pow(Crd.Y - crd.Y, 2));
        }
        public void Move()
        {
            int x = Crd.X;
            int y = Crd.Y;

            do
            {
                Crd.X = rnd.Next(x, x + 2);
            } while (Crd.X >= Map.Width);
            do
            {
                Crd.Y = rnd.Next(y, y + 2);
            } while (Crd.Y >= Map.Height);
        }
        public override string ToString()
        {
            return $"{Crd} - {Alive}";
        }
    }
}

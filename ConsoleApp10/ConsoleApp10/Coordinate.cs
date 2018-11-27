using System;

namespace ConsoleApp10
{
    class Coordinate
    {
        #region Tulajdonságok
        public int X { get; set; }
        public int Y { get; set; }
        #endregion

        #region Konstruktor
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Coordinate(int[] crd)
        {
            X = crd[0] - 1;
            Y = crd[1] - 1;
        }
        #endregion

        #region Metódusok
        public override bool Equals(object crd)
        {
            return X == ((Coordinate)crd).X && Y == ((Coordinate)crd).Y;
        }
        public override int GetHashCode()
        {
            return X ^ Y;
        }
        public override string ToString()
        {
            return $"{{{X},{Y}}}";
        }
        #endregion
    }
}

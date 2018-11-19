using System;

namespace ConsoleApp10
{
    class Map
    {
        public static Coordinate EndCrd
        {
            get;
            private set;
        }
        public static int Width
        {
            get;
            private set;
        }
        public static int Height
        {
            get;
            private set;
        }

        public static void SetSize(int width, int height)
        {
            Width = width;
            Height = height;
            EndCrd = new Coordinate(Width - 1, Height - 1);
        }
        public static void SetSize(int[] size)
        {
            Width = size[0];
            Height = size[1];
            EndCrd = new Coordinate(size);
        }
    }
}

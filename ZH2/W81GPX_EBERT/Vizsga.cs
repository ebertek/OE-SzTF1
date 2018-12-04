using System;

namespace W81GPX_EBERT
{
    class Vizsga
    {
        /* string tantárgynév;
        string nap;
        int eredmény; */
        static Random rnd = new Random();
        public string Tantárgynév { get; private set; }
        public string Nap { get; private set; }
        public int Eredmény { get; private set; }

        void Feldolgoz(string s)
        {
            string[] vizsgaAdatok = new string[3];
            char[] elválasztók = { '!', ':' };
            vizsgaAdatok = s.Split(elválasztók);
            Tantárgynév = vizsgaAdatok[0];
            Nap = vizsgaAdatok[1];
            int eredmény = 0;
            if (vizsgaAdatok.Length == 3)
            {
                Eredmény = int.Parse(vizsgaAdatok[2]);
            } else
            {
                Eredmény = rnd.Next(6);
            }
        }

        public Vizsga(string s) {
            Feldolgoz(s);
        }
    }
}

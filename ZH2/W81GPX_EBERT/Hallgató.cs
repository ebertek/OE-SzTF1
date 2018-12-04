namespace W81GPX_EBERT
{
    class Hallgató
    {
        Vizsga[] vizsgák = new Vizsga[0];
        public string Név { get; private set; }
        public Hallgató(string név)
        {
            Név = név;
        }
        public void ÚjVizsga(Vizsga vizsga)
        {
            Vizsga[] vizsgákÚj = new Vizsga[vizsgák.Length + 1];
            for (int i = 0; i < vizsgák.Length; i++)
            {
                vizsgákÚj[i] = vizsgák[i];
            }
            vizsgákÚj[vizsgák.Length] = vizsga;
            vizsgák = vizsgákÚj;
        }
        public double HetiÁtlagEredmény()
        {
            double átlag = 0;
            for (int i = 0; i < vizsgák.Length; i++)
            {
                átlag += vizsgák[i].Eredmény;
            }
            átlag /= vizsgák.Length;
            return átlag;
        }
        public int HetiMaxEredmény()
        {
            int max = vizsgák[0].Eredmény;
            for (int i = 1; i < vizsgák.Length; i++)
            {
                if (vizsgák[i].Eredmény > max)
                {
                    max = vizsgák[i].Eredmény;
                }
            }
            return max;
        }
        public string HetiMaxVizsga()
        {
            int[] vizsgaNapok = new int[7];
            for (int i = 0; i < vizsgák.Length; i++)
            {
                if (vizsgák[i].Nap == "Hétfő")
                    vizsgaNapok[0]++;
                if (vizsgák[i].Nap == "Kedd")
                    vizsgaNapok[1]++;
                if (vizsgák[i].Nap == "Szerda")
                    vizsgaNapok[2]++;
                if (vizsgák[i].Nap == "Csütörtök")
                    vizsgaNapok[3]++;
                if (vizsgák[i].Nap == "Péntek")
                    vizsgaNapok[4]++;
                if (vizsgák[i].Nap == "Szombat")
                    vizsgaNapok[5]++;
                if (vizsgák[i].Nap == "Vasárnap")
                    vizsgaNapok[6]++;
            }
            int max = vizsgaNapok[0];
            int maxIdx = 0;
            for (int i = 1; i < vizsgaNapok.Length; i++)
            {
                if (vizsgaNapok[i] > max)
                {
                    max = vizsgaNapok[i];
                    maxIdx = i;
                }
            }
            string nap = "Hétfő";
            if (maxIdx == 1)
                nap = "Kedd";
            if (maxIdx == 2)
                nap = "Szerda";
            if (maxIdx == 3)
                nap = "Csütörtök";
            if (maxIdx == 4)
                nap = "Péntek";
            if (maxIdx == 5)
                nap = "Szombat";
            if (maxIdx == 6)
                nap = "Vasárnap";
            return $"{nap} ({max})";
        }
    }
}

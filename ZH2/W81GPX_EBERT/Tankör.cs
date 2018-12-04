namespace W81GPX_EBERT
{
    class Tankör
    {
        Hallgató[] hallgatók = new Hallgató[0];
        public string Név { get; private set; }
        public Tankör(string név)
        {
            Név = név;
        }
        bool VanHallgató(string név)
        {
            for (int i = 0; i < hallgatók.Length; i++)
            {
                if (hallgatók[i].Név == név)
                {
                    return true;
                }
            }
            return false;
        }
        int HallgatóIndex(string név)
        {
            int idx;
            for (idx = 0; idx < hallgatók.Length; idx++)
            {
                if (hallgatók[idx].Név == név)
                {
                    break;
                }
            }
            if (idx < hallgatók.Length)
            {
                return idx;
            }
            return -1; // ha nincs
        }
        public void ÚjHallgató(string s)
        {
            string név = s.Split('#')[0];
            if (!VanHallgató(név))
            {
                Hallgató[] hallgatókÚj = new Hallgató[hallgatók.Length + 1];
                for (int i = 0; i < hallgatók.Length; i++)
                {
                    hallgatókÚj[i] = hallgatók[i];
                }
                hallgatókÚj[hallgatók.Length] = new Hallgató(név);
                hallgatók = hallgatókÚj;
            }
            hallgatók[HallgatóIndex(név)].ÚjVizsga(new Vizsga(s.Split('#')[1]));
        }
        public string LegjobbEredmény()
        {
            int max = hallgatók[0].HetiMaxEredmény();
            int maxIdx = 0;
            for (int i = 1; i < hallgatók.Length; i++)
            {
                if (hallgatók[i].HetiMaxEredmény() > max)
                {
                    max = hallgatók[i].HetiMaxEredmény();
                    maxIdx = i;
                }
            }
            return $"Legjobb eredményű hallgató [érdemjegy: {max}]:\t{hallgatók[maxIdx].Név}";
        }
        public string LegjobbÁtlag()
        {
            double max = hallgatók[0].HetiÁtlagEredmény();
            int maxIdx = 0;
            for (int i = 1; i < hallgatók.Length; i++)
            {
                if (hallgatók[i].HetiÁtlagEredmény() > max)
                {
                    max = hallgatók[i].HetiÁtlagEredmény();
                    maxIdx = i;
                }
            }
            return $"Legjobb átlagú hallgató [átlag: {max}]:\t{hallgatók[maxIdx].Név}";
        }
        public string LegtöbbVizsgaNap()
        {
            return $"A legtöbb vizsga a köveketző napon történt:\t{hallgatók[0].HetiMaxVizsga()}"; // ez nem jó, csak az 1. hallgatót nézi
        }
    }
}

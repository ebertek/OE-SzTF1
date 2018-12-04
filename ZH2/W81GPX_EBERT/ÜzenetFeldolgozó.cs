namespace W81GPX_EBERT
{
    static class ÜzenetFeldolgozó
    {
        static string[] üzenet;
        public static string[] Üzenet { set => üzenet = value; }

        public static bool VanÜzenet()
        {
            for (int i = 0; i < üzenet.Length; i++)
            {
                if (üzenet[i] != "")
                {
                    return true;
                }
            }
            return false;
        }
        public static string Feldolgoz()
        {
            string s;
            s = üzenet[0];
            string[] üzenetÚj = new string[üzenet.Length - 1];
            for (int i = 0; i < üzenetÚj.Length; i++)
            {
                üzenetÚj[i] = üzenet[i + 1];
            }
            üzenet = üzenetÚj;
            return s;
        }
    }
}

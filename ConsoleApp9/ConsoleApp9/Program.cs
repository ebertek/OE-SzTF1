using System;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace ConsoleApp9
{
    enum Hónapok // felsorolás
    {
        január, február, március, április, május, június, július, augusztus, szeptember, október, november, december
    }
    class Program
    {
        enum Napok
        {
            hétfő, kedd, szerda = 30, csütörtök /* 31 */, péntek, szombat, vasárnap
        }
        static void Main(string[] args)
        {
            Napok nap = Napok.hétfő; // hétfő
            int hétfő = (int)Napok.hétfő; // 0
            int csütörtök = (int)Napok.csütörtök; // 31
            Console.WriteLine("nap: " + nap + "; hétfő: " + hétfő + "; csütörtök: " + csütörtök);           
            if (nap == Napok.hétfő)
                Console.WriteLine("Hétfő!");

            /* Szöveges fájlok kezelése */
            System.IO.StreamReader sr = new System.IO.StreamReader("lorem.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                Console.WriteLine(line);
            }
            // string teljesFajl = sr.ReadToEnd();
            sr.Close();

            /* felülírás:
             * System.IO.StreamWriter sw = new System.IO.StreamWriter("new_lorem.txt");
             * */
            // hozzáfűzés:
            System.IO.StreamWriter sw = new System.IO.StreamWriter("new_lorem.txt", true);
            // karakterkódolást is meg lehet adni paraméternek; Encoding.Default a rendszer alapértelmezett kódolása, nem feltétlen UTF-8
            sw.Write("sortörés nélkül ");
            sw.WriteLine("sortöréssel");
            sw.Close();

            // másik megoldás: File osztály
            string[] lines = System.IO.File.ReadAllLines("lorem.txt");
            string text = System.IO.File.ReadAllText("lorem.txt");
            // System.IO.File.WriteAllText("new_lorem.txt", "write all text!\n");
            System.IO.File.AppendAllText("new_lorem.txt", "append...\r\n");

            /* Gyakorló feladatok */
            ReadAndPrintAllLines("new_lorem.txt");
            AppendNoOfLinesAndLetters("new_lorem.txt");
            KeepOnlyLettersAndNumbers("new_lorem.txt");
            AlignCenter("lorem.txt");

            Console.Clear();
            /* Objektumtömbök */
            ZH[] zhk = new ZH[20];
            // Console.WriteLine(zhk[0].Neptun); // hiba
            for (int i = 0; i < zhk.Length; i++)
            {
                zhk[i] = new ZH();
                Console.WriteLine(zhk[i].Neptun);
            }
            Console.WriteLine("Átmentek: ");
            for (int i = 0; i < zhk.Length; i++)
            {
                if (zhk[i].Pontszám > 50)
                    Console.WriteLine(zhk[i]);
            }
            Console.WriteLine("Legjobbak:");
            int max = 0;
            for (int i = 1; i < zhk.Length; i++)
            {
                if (zhk[max].Pontszám < zhk[i].Pontszám)
                    max = i;
            }
            for (int i = max; i < zhk.Length; i++) // mivel az előzőben < van, az elsőt dobja vissza
            {
                if (zhk[i].Pontszám == zhk[max].Pontszám)
                    Console.WriteLine(zhk[i]);
            }

            Console.ReadKey();
        }
        static void ReadAndPrintAllLines(string path)
        {
            // Console.WriteLine(System.IO.File.ReadAllText(path));

            System.IO.StreamReader sr = new System.IO.StreamReader(path);
            while (!sr.EndOfStream)
               Console.WriteLine(sr.ReadLine()); // ReadLine nem teszi ki a végére az \n-t
            sr.Close();
        }
        static void AppendNoOfLinesAndLetters(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            int letters = 0;
            foreach (string line in lines)
                foreach (char c in line)
                {
                    if (char.IsLetter(c))
                        letters++;
                }
            System.IO.File.AppendAllText(path, $"Sorok száma: {lines.Length}\r\n");
            System.IO.File.AppendAllText(path, $"Betűk száma: {letters}\r\n");
        }
        static void KeepOnlyLettersAndNumbers(string path)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(path);
            string lettersAndNumbers = "";
            while (!sr.EndOfStream)
            {
                foreach (char c in sr.ReadLine())
                {
                    if (char.IsLetterOrDigit(c))
                        lettersAndNumbers += c;
                }
            }
            sr.Close();

            System.IO.StreamWriter sw = new System.IO.StreamWriter(path);
            sw.Write(lettersAndNumbers);
            sw.Close();
        }
        static void AlignCenter(string path)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(path);
            int longest = 80;
            string lines = "";
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                lines += line + Environment.NewLine;
                if (longest < line.Length)
                    longest = line.Length;
            }
            sr.Close();

            System.IO.StreamWriter sw = new System.IO.StreamWriter(path);
            string[] linesArray = lines.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in linesArray)
            {
                int n = (longest - line.Length) / 2;
                sw.WriteLine(new string(' ', n) + line);
            }
            sw.Close();
        }
    }
    class ZH
    {
        static Random rnd = new Random(); // kell a static, hogy minden Neptun egyedi legyen
        static int[] ponthatárok = new int[] { 51, 63, 75, 87, 101 };
        public string Neptun
        {
            get;
            private set;
        }
        public int Pontszám
        {
            get;
            private set;
        }
        public int Jegy
        {
            get
            {
                for (int i = 0; i < ponthatárok.Length; i++)
                {
                    if (Pontszám < ponthatárok[i])
                        return i + 1;
                }
                return 5;
            }
        }
        public ZH()
        {
            for (int i = 0; i < 6; i++)
            {
                if (rnd.Next(100) < 40)
                    Neptun += rnd.Next(10).ToString();
                else
                    Neptun += (char)rnd.Next('A', 'Z' + 1);
            }
            Pontszám = rnd.Next(101);
        }
        public ZH(string neptun, int pontszám)
        {
            Neptun = neptun;
            Pontszám = pontszám;
        }
        public override string ToString()
        {
            return $"{Neptun} - pontszám: {Pontszám}, jegy: {Jegy}";
        }
    }
}

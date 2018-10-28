using System;
/* using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; */

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Az üzenet:\t\t\t");
            string üzenet = Console.ReadLine();
            string ascii = String.Join("", StringToAsciiDec(üzenet));
            string binary = String.Join(" ", ByteToBinary(StringToAsciiDec(üzenet)));
            Console.Write("Az üzenet ASCII értéke:\t\t" + ascii + '\n');
            Console.Write("Az üzenet bináris értéke:\t" + binary + '\n');
            Console.ReadKey();
        }
        static byte[] StringToAsciiDec(string text)
        {
            byte[] b = new byte[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                b[i] = (byte)text[i];
            }
            return b;
        }
        static string[] ByteToBinary(byte[] ascii)
        {
            string[] bináris = new string[ascii.Length];
            for (int i = 0; i < ascii.Length; i++)
            {
                bináris[i] = ByteToBinary(ascii[i]);
            }
            return bináris;
        }
        static string ByteToBinary(byte value)
        {
            byte[] s = new byte[7];
            int i = s.Length - 1; // utolsó elemre mutat
            while (value > 0)
            {
                s[i]  = (byte)(value % 2);
                value = (byte)(value / 2);
                i--;
            }
            return string.Join("", s);
            // return Convert.ToString(value, 2).PadLeft(7, '0');
        }
        static string ConvertToUnary(string[] binaries)
        {
            // 67 -> 1 0000 11 -> 1 1, 11 1111, 1 11, l. állapotátmeneti ábra
            // "" -> 0: 11_
            // "" -> 1: 1_
            //  0 -> 1: _1_   (nem 1_1)
            //  1 -> 0: _11_1 (nem 11_1)
            //  0 -> 0: 1
            //  1 -> 1: 1
            string unary = "";
            char state = ' ';
            for (int i = 0; i < binaries.Length; i++)
            {
                for (int j = 0; j < binaries[i].Length; j++)
                {
                    if (state == ' ' && binaries[i][j] == '0') { state = '0'; unary += "11 "; }
                    if (state == ' ' && binaries[i][j] == '1') { state = '1'; unary += "1 "; }
                    if (state == '0' && binaries[i][j] == '0') { unary += "1"; }
                    if (state == '0' && binaries[i][j] == '1') { state = '1'; unary += " 1 "; }
                    if (state == '1' && binaries[i][j] == '0') { unary += " 11 1"; }
                    if (state == '1' && binaries[i][j] == '1') { unary += "1"; }
                }
            }
            return unary;
        }
        static int Count(string unary, int k)
        {
            // hány db k hosszúságú rész van
            string[] s = unary.Split(new char[] { ' ' }); // nem kell előre létrehozni a karaktertömböt; az új tömbben csak 1-esek lesznek
            int db = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Length == k)
                {
                    db++;
                }
            }
            return db;
        }
        static int Find(string unary, string value)
        {
            return unary.IndexOf(value); // első karakter indexét vagy -1-et ad vissza
            /* for (int i = 0; i < unary.Length; i++)
            {
                if (unary[i] == value[0])
                {
                    int j = 0, k = i;
                    while (j < value.Length && k < unary.Length && unary[k] == value[j])
                    {
                        j++;
                        k++;
                    }
                    if ( j>= value.Length)
                    {
                        return i;
                    }
                }
            }
            return -1; */
        }
        static string Sort(string unary)
        {
            string[] s = unary.Split(new char[] { ' ' });
            // Array.Sort(s);
            return string.Join(" ", s);
        }
    }
}

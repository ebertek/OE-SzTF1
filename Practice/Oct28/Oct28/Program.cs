using System;

namespace Oct28
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tomb = new int[10];
            Feltoltes(tomb);
            Console.WriteLine("A tomb elemei:");
            Kiiras(tomb);
            SelectionSort(tomb);
            //InsertionSort(tomb);
            Console.WriteLine('\n' + "A tomb elemei rendezes utan:");
            Kiiras(tomb);
        }
        static void Feltoltes(int[] tomb)
        {
            Random rnd = new Random();
            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = rnd.Next(101);
            }
        }
        static void Kiiras(int[] tomb) {
            for (int i = 0; i < tomb.Length; i++)
            {
                Console.WriteLine(tomb[i]);
            }
        }
        static void SelectionSort(int[] tomb) {
            int min, temp;
            for (int i = 0; i < tomb.Length-1; i++)
            {
                min = i;
                for (int j = i+1; j < tomb.Length; j++)
                {
                    if (tomb[min] > tomb[j]) {
                        min = j;
                    }
                }
                temp = tomb[i];
                tomb[i] = tomb[min];
                tomb[min] = temp;
            }
        }
        static void InsertionSort(int[] tomb) {
            int j, temp;
            for (int i = 1; i < tomb.Length; i++)
            {
                j = i - 1;
                temp = tomb[i];
                while (j >= 0 && tomb[j] > temp) {
                    tomb[j + 1] = tomb[j--];
                    //j--;
                }
                tomb[j + 1] = temp;
            }
        }
    }
}

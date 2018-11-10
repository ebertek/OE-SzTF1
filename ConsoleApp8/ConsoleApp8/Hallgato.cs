using System;
/* using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; */

namespace ConsoleApp8
{
    class Hallgato
    {
        string[] keresztnév = { }, vezetéknév = { };
        string neptunkód;
        int születésiIdő;

        public string Név {
            get
            {
                return string.Join(" ", vezetéknév) + " " + string.Join(" ", keresztnév);
            }
            private set
            {
                // ...
            }
        }

        public string Neptunkód
        {
            get
            {
                return neptunkód;
            }
            set
            {
                if (neptunkód == "")
                {
                    neptunkód = value;
                } else
                {
                    Console.WriteLine("Már van neptunkódja!");
                }
            }
        }

        public Hallgato() { }
        public Hallgato(string név, string neptunkód, int születésiIdő)
        {
            Név = név;
            Neptunkód = neptunkód;
            this.születésiIdő = születésiIdő;
        }

        public void Tanul()
        {
            int i = 0;
            while (i < 10)
            {
                i++;
                System.Threading.Thread.Sleep(250);
                Console.WriteLine($"{i}. óra!");
            }
        }

        /*private */bool Puskázik() // alapból private
        {
            return new Random().Next(2) == 0 ? true : false; // sikerül-e, 50%
        }

        public Eredmény Vizsgázik(string tantárgy)
        {
            int százalék = new Random().Next(101);
            if (Puskázik())
            {
                return new Eredmény(tantárgy, százalék, százalék / 2); // ettől lehet >100% is :D
            }
            else
            {
                return new Eredmény(tantárgy, 0, 0); // megbukik
            }
        }
    }

    class Eredmény
    {
        public string Tárgynév { get; }
        public int Százalék { get; }
        public int Pontszám { get; }

        public Eredmény(string tárgynév, int százalék, int pontszám)
        {
            Tárgynév = tárgynév; // konstruktorban lehet csak írni, mert nincs settere a propertynek
            Százalék = százalék;
            Pontszám = pontszám;
        }
        public override string ToString()
        {
            return $"Tárgy: {Tárgynév}, Pontszám: {Pontszám}, Százalék: {Százalék}%";
        }
    }
}

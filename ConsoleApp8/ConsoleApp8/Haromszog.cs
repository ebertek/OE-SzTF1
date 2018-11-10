using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Haromszog
    {
        double a, b, c;
        public double A { get { return a; }
            set {
                double regi = a;
                a = value;
                if (!SzerkeszthetőE())
                {
                    a = regi;
                }
            }
        }
        public double B { get { return b; }
            set
            {
                double regi = b;
                b = value;
                if (!SzerkeszthetőE())
                {
                    b = regi;
                }
            }
        }
        public double C { get { return c; }
            set
            {
                double regi = c;
                c = value;
                if (!SzerkeszthetőE())
                {
                    c = regi;
                }
            }
        }
        public Haromszog()
        {
            Random rnd = new Random();
            do
            {
                a = rnd.Next(101);
                b = rnd.Next(101);
                c = rnd.Next(101);
            } while (!SzerkeszthetőE());
        }
        public Haromszog(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public double Kerület()
        {
            return a + b + c;
        }
        public double Terület()
        {
            // Hérón-képlet
            double p = Kerület()/2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        private bool SzerkeszthetőE()
        {
            return (a + b) > c && (a + c) > b && (b + c) > a;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using cs_lab3_Pudelko.Enums;

namespace cs_lab3_Pudelko
{
    class Pudelko : IFormattable, IEquatable<Pudelko>, IEnumerable<double>
    {
        public Pudelko(double a_size, double b_sise, double c_size, UnitOfMeasure type)
        {
            if (a_size < 0 || b_sise < 0 || c_size < 0)
                throw new ArgumentOutOfRangeException(); 

            a = a_size;
            b = b_sise;
            c = c_size;

            this.Type = type;
        }
        public Pudelko()
        {
            a = 10;
            b = 10;
            c = 10;
            Type = UnitOfMeasure.Centimeter;
        }
        public Pudelko(double a_size, double b_sise, double c_size) : this(a_size, b_sise, c_size, UnitOfMeasure.Meter) { }
        public Pudelko(double a_size, double b_sise) : this(a_size, b_sise, 10 , UnitOfMeasure.Meter) { }
        public Pudelko(double a_size) : this(a_size,10 ,10 , UnitOfMeasure.Meter) { }

        public double A
        {
            get => Math.Round(a, 3);
            set => a = value;
        }
        public double B
        {
            get => Math.Round(b, 3);
            set => b = value;
        }
        public double C
        {
            get => Math.Round(c, 3);
            set => c = value;
        }

        private double a;
        private double b;
        private double c;
        public UnitOfMeasure Type { get; set; } = UnitOfMeasure.Meter;

        public double Volume
        {
            get
            {
                double V = a * b * c;
                return Math.Round(V, 9);
            }
        }

        public double Area
        {
            get
            {
                double TSA = (2 * (a + b + c));
                return Math.Round(TSA, 6);
            }
        }

        public double this[int index] 
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.A;
                    case 1:
                        return this.B;
                    case 2:
                        return this.C;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public void ShowPudelko(Pudelko pudelko)
        {
            Console.WriteLine(pudelko.a + ", " + pudelko.b + ", " + pudelko.c + ", " + pudelko.Type);
        }

        public string ToString(string format)
        {
            switch (format)
            {
                case "mm":
                    return a + " mm \u00D7 " + b + " mm \u00D7 " + c + " mm";
                case "cm":
                    return a + " cm \u00D7 " + b + " cm \u00D7 " + c + " cm";
                case "m":
                    return a + " m \u00D7 " + b + " m \u00D7 " + c + " m";
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
                return ToString("m");

            return null;
        }

        public override string ToString() => this.ToString("m");

        public static Pudelko Parse(string str) //tothink
        {

            var numbers = Regex.Split(str, @"\D+").ToArray();
            //Console.WriteLine("{0},{1},{2}", numbers[0], numbers[1], numbers[2]);
            return new Pudelko(double.Parse(numbers[0]), double.Parse(numbers[1]), double.Parse(numbers[2]));
        }

        public bool Equals(Pudelko other)
        {
            return a == other.a && b == other.b && c == other.c && Type == other.Type;
        }

        public override bool Equals(object obj) => obj is Pudelko equatable && Equals(equatable);
        public override int GetHashCode() => (int)A ^ (int)B ^ (int)C;
        public static bool operator ==(Pudelko a, Pudelko b) => a.Equals(b);
        public static bool operator !=(Pudelko a, Pudelko b) => !a.Equals(b);

        public static Pudelko operator +(Pudelko p1, Pudelko p2)
        {
            double p3_a = (p1.a > p2.a) ? p1.a : p2.a;

            double p3_b = (p1.b > p2.b) ? p1.b : p2.b;

            double p3_c = (p1.c > p2.c) ? p1.c : p2.c;

            Pudelko temp = new Pudelko(p3_a, p3_b, p3_c);

            return temp;
        }

        public static explicit operator double[] (Pudelko p1)
        {
            double[] array = new double[3];
            array[0] = p1.a;
            array[1] = p1.b;
            array[2] = p1.c;

            return array;
        }

        public static implicit operator Pudelko(ValueTuple <int, int, int> t1) => new Pudelko(t1.Item1, t1.Item2, t1.Item3);

        public IEnumerator<double> GetEnumerator()
        {
            return new EnumeratorPudelka(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class EnumeratorPudelka : IEnumerator<double>
        {
            private readonly Pudelko pudelko;

            private int index = 0;
            public EnumeratorPudelka(Pudelko p)
            {
                this.pudelko = p;
            }

            public object Current => pudelko[index++];
            double IEnumerator<double>.Current => pudelko[index++];
            public bool MoveNext() => index <= 1;
            public void Reset() => index = 0;
            public void Dispose() { }
        }
    }
}

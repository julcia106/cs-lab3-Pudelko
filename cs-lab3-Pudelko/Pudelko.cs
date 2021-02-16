using cs_lab3_Pudelko.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace cs_lab3_Pudelko
{
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>, IEnumerable<double>
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;
        public UnitOfMeasure Unit { get; set; }

        public double A => Math.Round(a, 3);
        public double B => Math.Round(b, 3);
        public double C => Math.Round(c, 3);

        public Pudelko(double a, double b, double c, UnitOfMeasure unit)
        {
            if (a < 0 || b < 0 || c < 0)
                throw new ArgumentOutOfRangeException();

            this.a = a;
            this.b = b;
            this.c = c;

            Unit = unit;
        }
        public Pudelko()
        {
            a = 10.0;
            b = 10.0;
            c = 10.0;
            Unit = UnitOfMeasure.centimeter;
        }
        public Pudelko(double a, double b, double c) : this(a, b, c, UnitOfMeasure.centimeter) { }
        public Pudelko(double a, double b) : this(a, b, 0.100) { }
        public Pudelko(double a) : this(a, 0.100, 0.100) { }

        public Pudelko(double a, double b, UnitOfMeasure unit) : this(a, b) {

            if (unit == UnitOfMeasure.centimeter)
                c = 10.0;
            else if (unit == UnitOfMeasure.meter)
                c = 0.1;
            else if (unit == UnitOfMeasure.milimeter)
                c = 100.00;

            Unit = unit;
        }
        public Pudelko(double a, UnitOfMeasure unit) : this(a) {

            if (unit == UnitOfMeasure.centimeter)
            { c = 10.0; b = 10.0; }
            else if (unit == UnitOfMeasure.meter)
            { c = 0.1; b = 0.1; }
            else if (unit == UnitOfMeasure.milimeter)
            { c = 100.00; b = 100.0; }

            Unit = unit;
        }

        public double Volume
        {
            get {
                double V = (A * B * C);
                return Math.Round(V, 9);
            }
        }

        public double Area
        {
            get {
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
                        return a;
                    case 1:
                        return b;
                    case 2:
                        return c;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public void ShowPudelko(Pudelko pudelko)
        {
            Console.WriteLine(pudelko.a + ", " + pudelko.b + ", " + pudelko.c + ", " + pudelko.Unit);
        }

        public string ToString(string format)
        {
            switch (format)
            {
                case "mm":
                    if (Unit == UnitOfMeasure.centimeter)
                        return Math.Round(a * 10) + " mm \u00D7 " + Math.Round(b * 10) + " mm \u00D7 " + Math.Round(c* 10) + " mm";

                    if (Unit == UnitOfMeasure.meter)
                        return Math.Round(a * 1000) + " mm \u00D7 " + Math.Round(b * 1000) + " mm \u00D7 " + Math.Round(c * 1000) + " mm";

                    return Math.Round(a) + " mm \u00D7 " + Math.Round(b) + " mm \u00D7 " + Math.Round(c) + " mm";

                case "cm":
                    if(Unit == UnitOfMeasure.milimeter)
                        return Math.Round(a*0.1, 1) + " cm \u00D7 " + Math.Round(b * 0.1, 1) + " cm \u00D7 " + Math.Round(c * 0.1, 1) + " cm";

                    else if(Unit == UnitOfMeasure.meter)
                        return Math.Round(a* 100, 1) + " cm \u00D7 " + Math.Round(b* 100, 1) + " cm \u00D7 " + Math.Round(c* 100, 1) + " cm";

                    return Math.Round(a,1) + " cm \u00D7 " + Math.Round(b,1) + " cm \u00D7 " + Math.Round(c,1) + " cm";

                case "m":
                    if (Unit == UnitOfMeasure.milimeter)
                        return Math.Round(a * 0.001, 3) + " m \u00D7 " + Math.Round(b * 0.001, 3) + " m \u00D7 " + Math.Round(c * 0.001, 3) + " m";

                    else if (Unit == UnitOfMeasure.centimeter)
                        return Math.Round(a * 0.01, 3) + " m \u00D7 " + Math.Round(b*0.01, 3) + " m \u00D7 " + Math.Round(c*0.01, 3) + " m";

                    return Math.Round(a,3) + " m \u00D7 " + Math.Round(b,3) + " m \u00D7 " + Math.Round(c,3) + " m";

                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
        public override string ToString()
        {
            if(Unit == UnitOfMeasure.centimeter)
            {
                return Math.Round(a*0.01, 3) + " m \u00D7 " + Math.Round(b*0.01, 3) + " m \u00D7 " + Math.Round(c*0.01, 3) + " m";
            }
            else if(Unit == UnitOfMeasure.milimeter)
            {
                return Math.Round(a * 0.001, 3) + " m \u00D7 " + Math.Round(b * 0.001, 3) + " m \u00D7 " + Math.Round(c * 0.001, 3) + " m";
            }
            else
                return Math.Round(a,3) + " m \u00D7 " + Math.Round(b,3) + " m \u00D7 " + Math.Round(c,3) + " m";
        }

        public static Pudelko Parse(string str) //tothink
        {

            var numbers = Regex.Split(str, @"\D+").ToArray();
            //Console.WriteLine("{0},{1},{2}", numbers[0], numbers[1], numbers[2]);
            return new Pudelko(double.Parse(numbers[0]), double.Parse(numbers[1]), double.Parse(numbers[2]));
        }

        public bool Equals(Pudelko other)
        {
            return a == other.a && b == other.b && c == other.c && Unit == other.Unit;
        }

        public override bool Equals(object obj) => obj is Pudelko equatable && Equals(equatable);
        public override int GetHashCode() => (int)a ^ (int)b ^ (int)c;
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

        public static explicit operator double[](Pudelko p1)
        {
            double[] array = new double[3];
            array[0] = p1.a;
            array[1] = p1.b;
            array[2] = p1.c;

            return array;
        }

        public static implicit operator Pudelko(ValueTuple<int, int, int> t1) => new Pudelko(t1.Item1, t1.Item2, t1.Item3);

        public IEnumerator<double> GetEnumerator()
        {
            return new EnumeratorPudelka(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return this.ToString();
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
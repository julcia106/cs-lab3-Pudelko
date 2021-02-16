using cs_lab3_Pudelko.Enums;
using System;

namespace cs_lab3_Pudelko
{
    class Program
    {
        static void Main(string[] args)
        {

            Pudelko p = new Pudelko(1.123,2.333,3);
            Pudelko p1 = new Pudelko(2, 8, UnitOfMeasure.centimeter); 
            Pudelko p2 = new Pudelko(1, UnitOfMeasure.meter); 
            Pudelko p3 = new Pudelko(1,2);
            Pudelko p4 = new Pudelko(34, UnitOfMeasure.milimeter); 
            Pudelko p5 = new Pudelko(1, 2, 34, UnitOfMeasure.milimeter); 
            Pudelko p6 = new Pudelko(); 
            Pudelko p7 = new Pudelko(8.1234);

            Console.WriteLine("Constructors and ToString(): ");
            Console.WriteLine(p.ToString("mm"));
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p1.ToString("m"));
            Console.WriteLine(p1.ToString("mm"));
            Console.WriteLine(p2.ToString());
            Console.WriteLine(p2.ToString("mm"));
            Console.WriteLine(p2.ToString("cm"));
            Console.WriteLine(p3.ToString());
            Console.WriteLine(p4.ToString());
            Console.WriteLine(p4.ToString("cm"));
            Console.WriteLine(p4.ToString("m"));
            Console.WriteLine(p5.ToString());
            Console.WriteLine(p6.ToString());
            Console.WriteLine(p7.ToString());

            Console.WriteLine("Testing operator+ : ");
            Pudelko pA = new Pudelko(1, 2, 3, UnitOfMeasure.centimeter);
            Pudelko pB = new Pudelko(4, 5, 6, UnitOfMeasure.centimeter);
            Console.WriteLine(pA + pB);

            Console.WriteLine("Method show(): ");
            pA.ShowPudelko(pA);

            Console.WriteLine("Volume and Area: ");
            Console.WriteLine(pA.Volume);
            Console.WriteLine(pA.Area);

            Console.WriteLine("Equals false: ");
            Console.WriteLine(pA.Equals(pB));


            Console.WriteLine("Equals true: ");
            Pudelko pC = new Pudelko(1, 2, 3, UnitOfMeasure.centimeter);
            Console.WriteLine(pA.Equals(pC));

            Console.WriteLine("Tuple: ");
            var tuple = (12, 4, 76);
            Pudelko p11 = tuple;

            Console.WriteLine("Testing implicit operator for the tuple types: " + p11);
        }
    }
}
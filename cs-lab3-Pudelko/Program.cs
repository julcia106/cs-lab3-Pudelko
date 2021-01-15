using System;
using cs_lab3_Pudelko.Enums;

namespace cs_lab3_Pudelko
{
    class Program
    {
        static void Main(string[] args)
        {

            Pudelko pudelko = new Pudelko(9.5543,3.7,2.1123);
            Pudelko pudelko1 = new Pudelko(1,2,3);
            Pudelko pudelko2 = new Pudelko(211,2,3);
          
            Console.WriteLine(pudelko + pudelko1);

            Console.WriteLine(pudelko.ToString());
            pudelko.ShowPudelko(pudelko);

            Console.WriteLine(pudelko1.Volume);
            Console.WriteLine(pudelko1.Area);

            Console.WriteLine(pudelko1.Equals(pudelko2));

            var tuple = (12, 4, 76);
            Pudelko p1 = tuple;

            Console.WriteLine("Testing implicit operator for the tuple types: " + p1);

            Pudelko p2 = new Pudelko(12.2, 23, 12);
            Console.WriteLine(p2.ToString());
        }
    }
}

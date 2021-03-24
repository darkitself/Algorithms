using System;

namespace Lab3
{
    class Program
    {
         void Main(string[] args)
        {
            Console.WriteLine(new RationalNumber(-4, 9) - new RationalNumber(3, 9));
            Console.WriteLine(new RationalNumber(14, 19).GetPeriodicFraction());
            Console.WriteLine(RationalNumber.ParsePeriodicFraction("0,324(124)"));
        }
    }
}
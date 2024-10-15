using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {

        List<Fraction> fractions = [new Fraction(), new Fraction(5), new Fraction(3, 4)];

        foreach (Fraction f in fractions) {

            Console.WriteLine(f.GetFractionString());
            Console.WriteLine(f.GetDecimalValue());

        }


        
    }
}
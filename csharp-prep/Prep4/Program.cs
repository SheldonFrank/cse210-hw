using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter an integer to add to the list. To end, input 0");

        int n = -1;

        while (n != 0)
        {
            Console.Write("Enter number: ");
            n = int.Parse(Console.ReadLine());
            numbers.Add(n);

        };

        int sum = numbers.Sum();
        double average = numbers.Average();
        int max = numbers.Max();


         Console.WriteLine();

         Console.WriteLine($"The sum is: {sum}");

         Console.WriteLine($"The average is: {average}");

         Console.WriteLine($"The largest number is: {max}");

         Console.WriteLine();

        
    }
}
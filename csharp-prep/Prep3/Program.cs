using System;

class Program
{
    static void Main(string[] args)
    {

        Random rnd = new Random();
        int magic_number = rnd.Next(1, 100);
        int guess = -1;
        int count = 0;

        while (guess != magic_number)
    {
        Console.WriteLine("Guess an integer between 1 and 100");
        Console.Write("What is your guess? ");
        guess = int.Parse(Console.ReadLine());

        if (guess < magic_number)
        {
            Console.WriteLine("Higher");
        }

        else if (guess > magic_number)
        {
            Console.WriteLine("Lower");
        }

        count++;

        
    }

            Console.WriteLine($"You guessed it with {count} tries");
}}

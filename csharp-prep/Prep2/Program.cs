using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);
        string letter = "";

        if (grade >= 90)
        {
            
            letter = "A";

        }

        else if (grade >= 80)
        {
            
            letter = "B";

        }

        else if (grade >= 70)
        {
            
            letter = "C";

        }

        else if (grade >= 60)
        {
            
            letter = "D";

        }

        else
        {
            
            letter = "F";


        }

        Console.WriteLine(letter);

        if (grade >= 70)
        {
            
            Console.WriteLine("Congrats, you've passed the course!");

        }

        else
        {

            Console.WriteLine("You've failed the course. Better luck next time.");

        }


        

    }
}
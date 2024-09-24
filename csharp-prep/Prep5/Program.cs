using System;

class Program
{
    static void Main(string[] args)
    {

        DisplayWelcome();

        string user_name = PromptUserName();

        int number = PromptUserNumber();

        int number_squared = SquareNumber(number);

        DisplayResult(number_squared, user_name);



        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
            Console.WriteLine();
        }

        static string PromptUserName()
        {
            Console.Write("What is your name? ");

            string user_name = Console.ReadLine();

            return user_name;
        }

        static int PromptUserNumber()
        {
            Console.Write("What is your favorite number? ");
            int fav_number = int.Parse(Console.ReadLine());

            return fav_number;
        }

        static int SquareNumber(int number)
        {
            int squared = number*number;

            return squared;
        }

        static void DisplayResult(int number, string user_name)
        {
            Console.WriteLine($"{user_name}, the square of your number is {number}");
            Console.WriteLine();
        }

        
    }
}
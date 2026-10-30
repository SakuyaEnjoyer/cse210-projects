using System;
using System.Globalization;
using System.Net;

class Program
{
    static void Main(string[] args)
    {

        Random randomNumber = new Random();
        string continueOn = "y";
        int guessInt = 900;
        int attempts = 0;
        do
        {
            int number = randomNumber.Next(1,101);
            Console.WriteLine("What is the magic number?");
            guessInt = 900;
            while (guessInt != number)
            {
                string guess = Console.ReadLine();
                guessInt = int.Parse(guess);
                if (guessInt > number)
                {
                    Console.WriteLine("Wrong, lower.");
                }
                else if (guessInt < number)
                {
                    Console.WriteLine("Wrong, higher.");
                }
                attempts ++;
                Console.WriteLine($"Guess {attempts}");
            }
            attempts = 0;
            Console.WriteLine("Correct!");
            Console.WriteLine("Enter Y to continue");
            continueOn = Console.ReadLine();
        } while (continueOn == "y");
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        int favNumber;
        DisplayWelcome();
        Thread.Sleep(100);
        string userName = PromptUserName();
        Thread.Sleep(100);
        Console.WriteLine("What is your favorite number?");
        string input = Console.ReadLine();
        if(int.TryParse(input, out int number))
        {
            favNumber = number;
        }
        else
        {
            favNumber = 0;
        }
        int square = SquareNumber(favNumber);
        Thread.Sleep(100);
        int birthYear = PromptUserBirthYear();
        Thread.Sleep(100);
        Console.WriteLine($"{userName}, the square of your number is {square}.");
        int currentYear = DateTime.Now.Year;
        int age = currentYear - birthYear;
        Console.WriteLine($"{userName}, you will turn {age} this year.");
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.WriteLine("What is your name?");
        string userName = Console.ReadLine();
        return userName;
    }
    static int PromptUserBirthYear()
    {
        Console.WriteLine("What year were you born?");
        string input = Console.ReadLine();
        if(int.TryParse(input, out int number))
        {
            return number;
        }
        else
        {
            return 0;
        }
    }
    static int SquareNumber(int x)
    {
        return x * x;
    }
}
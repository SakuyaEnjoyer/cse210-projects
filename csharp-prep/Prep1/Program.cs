using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your first name?");
        string firstName = Console.ReadLine();
        Console.WriteLine("What is your last name?");
        string lastName = Console.ReadLine();
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
        Thread.Sleep(500);
        Console.Write("I");
        for(int i = 0; i < 3; i++)
        {
            Thread.Sleep(500);
            Console.Write(".");
        }
        Thread.Sleep(500);
        Console.Write("am STEVE.");
    }
}
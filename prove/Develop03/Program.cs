using System;

class Program
{
    
    static void Main(string[] args)
    {
        string userIn = "";

        Scripture scrip = new Scripture();
        scrip.GetRandomScripture();

        while (userIn != "quit")
        {
            Console.Clear();
            Console.WriteLine($"{scrip.GetReference()}\n{scrip.GetText()}");
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            scrip.HideWords();
            userIn = Console.ReadLine();
        }
    }
}
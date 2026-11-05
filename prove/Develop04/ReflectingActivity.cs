using System;
using System.Diagnostics;


public class ReflectingActivity : Activity
{

    private List<string> _questions = new List<string>();
    public ReflectingActivity(int seconds, string name, int loadTime, string description) : base(name, loadTime, description, seconds)
    {
        _questions.Add("How did you feel when you completed this task?");
        _questions.Add("What did you learn from this experience?");
        _questions.Add("How might you do better a second time?");
    }

    public void DoActivity()
    {
        Console.Clear();
        Console.WriteLine(GetName());
        Console.WriteLine(GetDescription());
        Console.Write("\n");
        Spinner(GetLoadTime());
        Console.WriteLine("How long, in seconds, would you like your session?");
        int s = 0;
        while (s == 0)
        {
            string input = Console.ReadLine();
            int.TryParse(input, out s);
            if(s == 0)
            {
                Console.SetCursorPosition(1,5);
                Console.WriteLine("Invalid entry.");
            }
        }
        SetSeconds(s);
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Console.Clear();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine("Think of a time when you did something really difficult.");
        Console.WriteLine("When you have something in mind, press a key to continue.");
        Console.ReadKey();
        Console.Clear();
        foreach(string q in _questions)
        {
            Console.Write(q);
            Spinner(s / _questions.Count);
            Console.Write("\n\n");
        }
        Console.Clear();
        Console.WriteLine($"Congratulations! You pondered an additional {s} seconds!");
    }
}
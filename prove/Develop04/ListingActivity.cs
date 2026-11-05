using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;


public class ListingActivity : Activity
{
    private List<string> _responses = new List<string>();
    public ListingActivity(int seconds, string name, int loadTime, string description) : base(name, loadTime, description, seconds)
    {
    }

    public void DoActivity()
    {
        Console.Clear();
        Console.WriteLine(GetName());
        Console.WriteLine(GetDescription());
        Console.Write("\n");
        Spinner(GetLoadTime());
        Console.Clear();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine("When have you felt the Holy Ghost this month?");
        Console.WriteLine("To exit, type and enter the word 'escape'");
        Console.CursorVisible = true;
        string response = "";
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        while(response != "escape")
        {
            response = Console.ReadLine();
            _responses.Add(response);
        }
        Console.WriteLine($"You listed {_responses.Count} items!");
        Console.WriteLine($"You spent {stopwatch.Elapsed} seconds on this activity.");
        stopwatch.Stop();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
        Spinner(GetLoadTime());
    }
}
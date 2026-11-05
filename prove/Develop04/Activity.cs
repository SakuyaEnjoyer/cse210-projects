using System;
using System.Diagnostics;

public class Activity
{
    private string _name;
    private int _loadTime;
    private string _description;
    private int _seconds;


    public Activity(string name, int loadTime, string description, int seconds)
    {
        _name = name;
        _loadTime = loadTime;
        _description = description;
        _seconds = seconds;
    }
    public void LoadScreen()
    {
        
    }
    public void Spinner(int s)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while(stopwatch.Elapsed < TimeSpan.FromSeconds(s))
        {
            Console.Write("|");
            Thread.Sleep(100);
            Console.Write("\b");
            Console.Write("/");
            Thread.Sleep(100);
            Console.Write("\b");
            Console.Write("-");
            Thread.Sleep(100);
            Console.Write("\b");
            Console.Write("\\");
            Thread.Sleep(100);
            Console.Write("\b");
        }
        stopwatch.Stop();
    }
    public void SetSeconds(int s)
    {
        _seconds = s;
    }
    public string GetName()
    {
        return _name;
    }
    public string GetDescription()
    {
        return _description;
    }
    public int GetLoadTime()
    {
        return _loadTime;
    }
    public int GetSeconds()
    {
        return _seconds;
    }
}
using System;
using System.Diagnostics;


public class BreathingActivity : Activity
{
    private float _breatheIn;
    private float _breatheOut;

    public BreathingActivity(float breatheIn, float breatheOut, string name, int loadTime, string description, int seconds) : base (name, loadTime, description, seconds)
    {
        _breatheIn = breatheIn;
        _breatheOut = breatheOut;
    }

    public void DoActivity()
    {
        Console.Clear();
        Console.WriteLine(GetName());
        Console.WriteLine(GetDescription());
        Console.Write("\n");
        Spinner(GetLoadTime());
        Console.Clear();
        Console.WriteLine("Press a key when you are ready to begin.");
        Console.ReadKey();
        while(!Console.KeyAvailable)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(1,2);
            Console.Write("Breathe In...");
            Console.SetCursorPosition(1,4);
            Console.Write("Press hold down a key when you are finished.");
            Console.SetCursorPosition(1,1);
            //Breathe In
            for(int i = 0; i < 30; i++)
            {
                Console.Write("|");
                for(int y = 0; y < i; y++)
                {
                    Console.Write("█");
                }
                for(int z = 30; z > i; z--)
                {
                    Console.Write("░");
                }
                Console.Write("|");
                Console.SetCursorPosition(1,1);
                Thread.Sleep((int)(_breatheIn * 1000f / 30f));
            }
            Console.Clear();
            Console.SetCursorPosition(1,2);
            Console.Write("Breathe Out...");
            Console.SetCursorPosition(1,4);
            Console.Write("Press hold down a key when you are finished.");
            Console.SetCursorPosition(1,1);
            //Breathe Out
            for(int i = 0; i < 30; i++)
            {
                Console.Write("|");
                for(int y = 30; y > i; y--)
                {
                    Console.Write("█");
                }
                for(int z = 0; z < i; z++)
                {
                    Console.Write("░");
                }
                Console.Write("|");
                Console.SetCursorPosition(1,1);
                Thread.Sleep((int)(_breatheOut * 1000 / 30));
            }
        }
        Spinner(GetLoadTime());
    }
}
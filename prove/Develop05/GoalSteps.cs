using System;


class GoalSteps : Goal
{
    private List<Step> _steps = new List<Step>(); 


    public GoalSteps (string name, string task, bool isComplete, int expValue) : base (name, task, isComplete, expValue)
    {
        //filling steps list through other function
    }


    public override void PrintGoalInfo()
    {
        Console.WriteLine(GetName()+" | "+GetTask()+" | Steps remaining: "+GetRemainingStepCount());
    }

    public override void PrintGoalAspects()
    {
        Console.WriteLine("| 1 Name | 2 Task  | 3 Experience Value  | 4 Steps  |");
    }

    public void AddStep(Step s)
    {
        _steps.Add(s);
    }
    public List<Step> GetSteps()
    {
        return _steps;
    }
    public void PrintSteps()
    {
        foreach(Step s in _steps)
        {
            if (!s.GetStatus())
            {
                Console.WriteLine("*"+s.GetStep()+"*");
            }
            else if (s.GetStatus())
            {
                Console.WriteLine(s.GetStep());
            }
            else
            {
                Console.WriteLine("Error reading step, possibly corrupt data.");
            }
        }
        Console.WriteLine("A step is marked as complete if it is NOT surrounded by *.");
    }
    public int GetRemainingStepCount()
    {
        int remainingCount = 0;
        foreach (Step s in _steps)
        {
            if (s.GetStatus())
            {
                remainingCount += 1;
            }
        }
        return remainingCount;
    }
    public void RequestSteps()//can be used for creating the goal and when editing it.
    {
        Console.Clear();
        Console.WriteLine("Input your desired steps one at a time, hitting the enter key after each step.");
        Console.WriteLine("To exit, simply press enter with nothing in the field.");

        string input = "a";

        while (input != "")
        {
            input = Console.ReadLine();
            if (input != "")
            {
                try
                {
                    AddStep(new Step(input, false));
                }
                catch
                {
                    Console.WriteLine("There was a problem with the input, try again.");
                }
            }
        }

        Console.WriteLine("Excellent, here are the current steps for the task:");
        foreach(Step s in _steps)
        {
            Console.Write(s.GetStep()+" | ");
        }
    }

    public void SetStep(string s, int index)
    {
        _steps[index].SetName(s);
    }

    public void SetAllSteps(List<Step> steps)
    {
        _steps = steps;
    }
}
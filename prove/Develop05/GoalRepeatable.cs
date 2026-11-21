using System;


class GoalRepeatable : Goal
{
    private int _repeatCount;
    private string _repeatInterval;


    public GoalRepeatable(string name, string task, bool isComplete, int expValue, int repeatCount, string repeatInterval) : base (name, task, isComplete, expValue)
    {
        _repeatCount = repeatCount;
        _repeatInterval = repeatInterval;
    }

    public override void PrintGoalInfo()
    {
        if (_repeatCount == 0 & _repeatInterval == "")
        {
            Console.WriteLine(GetName()+" | "+GetTask()+" | Repeat until further notice");//no count, no interval
        }
        else if (_repeatCount != 0 & _repeatInterval == "")
        {
            Console.WriteLine(GetName()+" | "+GetTask()+" | Number of times left to complete: "+_repeatCount);//count, no interval
        }
        else if (_repeatCount == 0 & _repeatInterval != "")
        {
            Console.WriteLine(GetName()+" | "+GetTask()+" | Repeat until further notice on the following days "+_repeatInterval);//no count, interval
        }
        else if (_repeatCount != 0 & _repeatInterval != "")
        {
            Console.WriteLine(GetName()+" | "+GetTask()+" | Number of times left to complete: "+_repeatCount+" on the following days "+_repeatInterval);//count, interval
        }
        else
        {
            Console.WriteLine("Error printing repeatable goal, possible corrupt data.");
        }
    }

    public override void PrintGoalAspects()
    {
        Console.WriteLine("| 1 Name  | 2 Task  | 3 Experience Value  | 4 Repeat Count  | 5 Repeat Interval |");
    }

    public int GetRepeatCount()
    {
        return _repeatCount;
    }
    public void SetRepeatCount(int r)
    {
        _repeatCount = r;
    }
    public string GetRepeatInterval()
    {
        return _repeatInterval;
    }
    public void SetRepeatInterval(string r)
    {
        _repeatInterval = r;
    }
    public void CompleteSome(int c)
    {
        _repeatCount -= c;
    }
}
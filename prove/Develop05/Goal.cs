using System;


class Goal
{
    
    private string _name;
    private string _task;
    private bool _isComplete;
    private int _expValue;

    public Goal(string name, string task, bool isComplete, int expValue)
    {
        _name = name;
        _task = task;
        _isComplete = isComplete;
        _expValue = expValue;
    }

    public virtual void PrintGoalInfo()
    {
        Console.WriteLine(_name+" | "+_task+" | worth "+_expValue+" experience points");
    }

    public virtual void PrintGoalAspects()
    {
        Console.WriteLine("|1  Name | 2  Task | 3  Experience Value");
    }

    //getters and setters
    public string GetName()
    {
        return _name;
    }
    public void SetName(string n)
    {
        _name = n;
    }
    public string GetTask()
    {
        return _task;
    }
    public void SetTask(string t)
    {
        _task = t;
    }
    public bool GetComplete()
    {
        return _isComplete;
    }
    public void SetComplete(bool c)
    {
        _isComplete = c;
    }
    public int GetExperience()
    {
        return _expValue;
    }
    public void SetExperience(int e)
    {
        _expValue = e;
    }
}
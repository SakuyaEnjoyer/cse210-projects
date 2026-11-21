using System;
using System.Reflection.Metadata.Ecma335;


class Player
{
    string _name;
    int _exp;
    int _level;

    public Player(string name, int exp, int level)
    {
        _name = name;
        _exp = exp;
        _level = level;
    }

    public void AddExp(int e)
    {
        _exp += e;
        while (CheckLevel())
        {
            //nothing to do here...
            //this just loops the level check until it's done.
        }
    }

    public void Save()
    {
        File.WriteAllText("PlayerData.txt",_name+":"+_exp+":"+_level);
    }

    public void Initialize()
    {
        string data = File.ReadAllText("PlayerData.txt");
        string[] datas = data.Split(':', StringSplitOptions.RemoveEmptyEntries);
        _name = datas[0];
        _exp = int.Parse(datas[1]);
        _level = int.Parse(datas[2]);
    }

    public void PrintPlayerInfo()
    {
        Console.SetCursorPosition(100, 3);
        Console.Write(_name);
        Console.SetCursorPosition(100, 4);
        Console.Write("Level: "+_level);
        Console.SetCursorPosition(100, 5);
        Console.Write("Experience: "+_exp+" with "+ExpRemaining()+" remaining until level up");
        Console.SetCursorPosition(0, 6);
    }

    public bool CheckLevel()
    {
        //find required exp to level up. use exponential function to find required exp from level value.
        double requiredExp = 10*Math.Pow(_level, 1.5); 
        if (requiredExp < _exp)
        {
            _level += 1;
            _exp -= (int)requiredExp;
            Console.WriteLine(_name+" is now level "+_level+"!");
            return true;
        }
        else 
        {
            return false;
        }
    }

    public int ExpRemaining()
    {
        double requiredExp = 10*Math.Pow(_level, 1.5); 
        return (int)requiredExp - _exp;
    }

    //now for the glorious getters and setters

    public string getName()
    {
        return _name;
    }
    public void SetName(string n)
    {
        _name = n;
    }
}
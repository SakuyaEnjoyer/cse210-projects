using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        goals = InitializeGoals();
        Player player = new Player("name", 1, 1);
        try
        {
            player.Initialize();
        }
        catch
        {
            Console.WriteLine("There is no player data saved, please enter your name.");
            string name = Console.ReadLine();
            player.SetName(name);
            player.Save();
        }
        string choice = "";
        Console.Clear();
        Console.WriteLine("Welcome "+player.getName()+", to the super cool goal tracker!");
        Spinner(3);
        while(choice != "4")
        {
            Console.Clear();
            Console.WriteLine("What do you wish to do?");
            Thread.Sleep(20);
            Console.WriteLine("1 | Add a new goal");
            Thread.Sleep(20);
            Console.WriteLine("2 | Edit an existing goal");
            Thread.Sleep(20);
            Console.WriteLine("3 | Mark goal as complete");
            Thread.Sleep(20);
            Console.WriteLine("4 | Quit");
            Thread.Sleep(20);
            Console.WriteLine("Select an option by typing the number assigned to it.");
            PrintReimu();
            player.PrintPlayerInfo();
            choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.Clear();
                Spinner(3);
                Console.WriteLine("What type of goal do you want to add?");
                Thread.Sleep(20);
                Console.WriteLine("1 | One time goal");
                Thread.Sleep(20);
                Console.WriteLine("2 | Repeatable goal");
                Thread.Sleep(20);
                Console.WriteLine("3 | Complex goal with steps");
                Thread.Sleep(20);
                Console.WriteLine("4 | Cancel");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("What is the name of this goal?");
                    string name = Console.ReadLine();
                    Console.WriteLine("What would you like to accomplish?");
                    string task = Console.ReadLine();
                    Console.WriteLine("And lastly, how much experience should this goal be worth?");
                    int expValue = 0;
                    string exp = Console.ReadLine();
                    expValue = TryParseStringInt(exp);
                    while (expValue == 0)
                    {
                        Console.WriteLine("Invalid input, try again. Please put a number.");
                        exp = Console.ReadLine();
                        expValue = TryParseStringInt(exp);
                    }
                    try
                    {
                        Goal goal = new Goal(name, task, false, expValue);
                        goals.Add(goal);
                        SaveGoals(goals);
                        Console.WriteLine("Goal added!");
                        Thread.Sleep(2000);
                    }
                    catch
                    {
                        Console.WriteLine("Failed to add goal to list of goals.");
                        Thread.Sleep(2000);
                    }
                    Console.Clear();
                    Spinner(3);
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    Console.WriteLine("What is the name of this goal?");
                    string name = Console.ReadLine();
                    Console.WriteLine("What would you like to accomplish?");
                    string task = Console.ReadLine();
                    Console.WriteLine("How many times must this task be repeated? If you want it to be infinite, input 0.");
                    int repeat = 999;//well now I cant have 0 be the failsafe. 999 should be outside the reasonable goal repeat count.
                    string rep = Console.ReadLine();
                    repeat = TryParseStringInt(rep);
                    while (repeat == 999)
                    {
                        Console.WriteLine("Invalid input, try again. Please put a number.");
                        rep = Console.ReadLine();
                        repeat = TryParseStringInt(rep);
                    }
                    Console.WriteLine("On what days does this task need to be done? If the time doesn't matter, just press enter.");
                    string days = Console.ReadLine();
                    Console.WriteLine("And lastly, how much experience should this goal be worth?");
                    int expValue = 0;
                    string exp = Console.ReadLine();
                    expValue = TryParseStringInt(exp);
                    while (expValue == 0)
                    {
                        Console.WriteLine("Invalid input, try again. Please put a number.");
                        exp = Console.ReadLine();
                        expValue = TryParseStringInt(exp);
                    }
                    try
                    {
                        GoalRepeatable goal = new GoalRepeatable(name, task, false, expValue, repeat, days);
                        goals.Add(goal);
                        SaveGoals(goals);
                        Console.WriteLine("Goal added!");
                        Thread.Sleep(2000);
                    }
                    catch
                    {
                        Console.WriteLine("Failed to add goal to list of goals.");
                        Thread.Sleep(2000);
                    }
                    Console.Clear();
                    Spinner(3);
                }
                else if (choice == "3")
                {
                    Console.Clear();
                    Console.WriteLine("What is the name of this goal?");
                    string name = Console.ReadLine();
                    Console.WriteLine("What would you like to accomplish?");
                    string task = Console.ReadLine();
                    Console.WriteLine("How much experience should this goal be worth?");
                    int expValue = 0;
                    string exp = Console.ReadLine();
                    expValue = TryParseStringInt(exp);
                    while (expValue == 0)
                    {
                        Console.WriteLine("Invalid input, cannot be 0.");
                        exp = Console.ReadLine();
                        expValue = TryParseStringInt(exp);
                    }
                    try
                    {
                        GoalSteps goal = new GoalSteps(name, task, false, expValue);
                        goal.RequestSteps();
                        goals.Add(goal);
                        SaveGoals(goals);
                        Console.WriteLine("Goal added!");
                        Thread.Sleep(2000);
                    }
                    catch
                    {
                        Console.WriteLine("Failed to add goal to list of goals.");
                        Thread.Sleep(2000);
                    }
                    Console.Clear();
                    Spinner(3);
                }
                else
                {
                    choice = "1";//either exit or invalid, either way just make it not 4 so the while loop doesnt end.
                }
            }
            else if (choice == "2")//edit
            {
                if (goals.Count == 0)
                {
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    int i = 0;
                    foreach(Goal goal in goals)
                    {
                        Console.Write(i+" | ");
                        goal.PrintGoalInfo();
                        i ++;
                    }
                    Console.WriteLine("Select the goal you would like to edit.");
                    string goalchoice = Console.ReadLine();
                    int goalindex = TryParseStringInt(goalchoice, goals.Count);
                    Console.Clear();
                    goals[goalindex].PrintGoalInfo();
                    goals[goalindex].PrintGoalAspects();
                    Console.WriteLine("Which attribute would you like to change?");
                    string attchoice = Console.ReadLine();
                    int att = 0;
                    if (goals[goalindex] is GoalRepeatable)
                    {
                        att = TryParseStringInt(attchoice, 6);
                    }
                    else if (goals[goalindex] is GoalSteps)
                    {
                        att = TryParseStringInt(attchoice, 5);
                    }
                    else if (goals[goalindex] is Goal)
                    {
                        att = TryParseStringInt(attchoice, 4);
                    }
                    else
                    {
                        //uh oh
                    }
                    if (att == 1)
                    {
                        Console.Clear();
                        Console.WriteLine(goals[goalindex].GetName());
                        Console.WriteLine("What would you like to change the name to?");
                        string newname = Console.ReadLine();
                        goals[goalindex].SetName(newname);
                        Console.WriteLine("The change has been made."); 
                        Thread.Sleep(2000);
                    }
                    else if (att == 2)
                    {
                        Console.Clear();
                        Console.WriteLine(goals[goalindex].GetTask());
                        Console.WriteLine("What would you like to change the task to?");
                        string newtask = Console.ReadLine();
                        goals[goalindex].SetName(newtask);
                        Console.WriteLine("The change has been made."); 
                        Thread.Sleep(2000);
                    }
                    else if (att == 3)
                    {
                        Console.Clear();
                        Console.WriteLine(goals[goalindex].GetExperience());
                        Console.WriteLine("What would you like to change the experience value to?");
                        string newexp = Console.ReadLine();
                        int exp = TryParseStringInt(newexp);
                        goals[goalindex].SetExperience(exp);
                        Console.WriteLine("The change has been made."); 
                        Thread.Sleep(2000);
                    }
                    else if (att == 4 && goals[goalindex] is GoalRepeatable)
                    {
                        Console.Clear();
                        GoalRepeatable goalRepeatable = (GoalRepeatable)goals[goalindex];//have to specify it is goal repeatable here.
                        Console.WriteLine(goalRepeatable.GetRepeatCount());
                        Console.WriteLine("What would you like to change the repeat count to?");
                        string newrep = Console.ReadLine();
                        int rep = TryParseStringInt(newrep);
                        goalRepeatable.SetRepeatCount(rep);
                        Console.WriteLine("The change has been made."); 
                        Thread.Sleep(2000);                        
                    }
                    else if (att == 4 && goals[goalindex] is GoalSteps)
                    {
                        Console.Clear();
                        GoalSteps goalSteps = (GoalSteps)goals[goalindex];
                        goalSteps.PrintSteps();
                        Console.WriteLine("Which step would you like to change? If you want to add a new step, type 'NEW'.");
                        string stepchoice = Console.ReadLine();
                        if (stepchoice == "NEW")
                        {
                            string stepin = "wow";
                            Console.WriteLine("You may now add as many steps as you would like. To finish, press enter with nothing in the line.");
                            while (stepin != "")
                            {
                                stepin = Console.ReadLine();
                                Step step = new Step(stepin, false);
                                goalSteps.AddStep(step);
                            }
                            Console.WriteLine("The change has been made.");
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            int stepindex = TryParseStringInt(stepchoice, goalSteps.GetSteps().Count) - 1;//-1 cuz index start at 0
                            Console.Clear();
                            Console.WriteLine(goalSteps.GetSteps()[stepindex]);
                            Console.WriteLine("What would you like to change the step to?");
                            string newStep = Console.ReadLine();
                            goalSteps.SetStep(newStep, stepindex);
                            Console.WriteLine("The change has been made.");
                            Thread.Sleep(2000);
                        }
                    }
                    else if (att == 5)
                    {
                        Console.Clear();
                        GoalRepeatable goalRepeatable = (GoalRepeatable)goals[goalindex];
                        Console.WriteLine(goalRepeatable.GetRepeatInterval());
                        Console.WriteLine("What would you like to change the interval to?");
                        string newinterval = Console.ReadLine();
                        goalRepeatable.SetRepeatInterval(newinterval);
                        Console.WriteLine("The change has been made."); 
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        //uh oh
                    }
                    SaveGoals(goals);
                }
            }
            else if (choice == "3")//mark complete
            {
                if (goals.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("You have no goals to mark as complete. Make sure you added some before.");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.Clear();
                    int i = 0;
                    foreach (Goal goal in goals)
                    {
                        Console.Write(i+" | ");
                        goal.PrintGoalInfo();
                        i ++;
                    }
                    Console.WriteLine("Select the goal you would like to mark complete.");
                    string goalchoice = Console.ReadLine();
                    int goalindex = TryParseStringInt(goalchoice, goals.Count);
                    goals[goalindex].SetComplete(true);
                    Console.Clear();
                    Console.WriteLine("Congratulations on completing your goal!");//TODO now give exp
                    player.AddExp(goals[goalindex].GetExperience());
                    player.CheckLevel();
                    player.Save();
                    Thread.Sleep(2000);
                    Spinner(3);
                }
                SaveGoals(goals);
            }
            else if (choice == "4")
            {
                //the loop will handle em
            }
            else if (choice == "")
            {
                Console.WriteLine("Really? You don't want any of these options? Why are you here?");
            }
            else
            {
                Console.WriteLine("Invalid input, make sure you only input the number associated with the desired option.");
            }
        }
    }

    public static void Spinner(int s)
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

    public static void PrintReimu()
    {
        Console.SetCursorPosition(60, 1);
        Console.Write(" ▃▄▆▆▄▄▃▃  ▃▃▄▄▆▆▄▃ ");
        Console.SetCursorPosition(60, 2);
        Console.Write("█ ||   ▄▄██▄▄   || █");
        Console.SetCursorPosition(60, 3);
        Console.Write("▐ ||▄▀▀      ▀▀▄|| ▌");
        Console.SetCursorPosition(60, 4);
        Console.Write(" █▄▀            ▀▄█ ");
        Console.SetCursorPosition(60, 5);
        Console.Write("▐ █   ▄▄    ▄▄   █ ▌");
        Console.SetCursorPosition(60, 6);
        Console.Write(" ██▄▄▀--▀▄ -▌-▀▄▄██ ");
        Console.SetCursorPosition(60, 7);
        Console.Write("█ ▀█ █▓▓  ▀▌█▓▓ █▀ █");
        Console.SetCursorPosition(60, 8);
        Console.Write(" █ ▄▀▄▃  __  ▃▄▀▄ █ ");
        Console.SetCursorPosition(60, 9);
        Console.Write("  ▀    ▀▀▀▀▀▀    ▀  ");
        Console.SetCursorPosition(0,6);
    }

    public static int TryParseStringInt(string input)
    {
        int output;
        try 
        {
            output = int.Parse(input);
            return output;
        }
        catch
        {
            Console.WriteLine("Invalid input, please try again.");
            input = Console.ReadLine();
            TryParseStringInt(input);
            //return should be inaccessible.
            return 1;
        }
    }

    public static int TryParseStringInt(string input, int max)
    {
        int output;
        try 
        {
            output = int.Parse(input);
            if (output >= max | output < 0)
            {
                Console.WriteLine("Input out of bounds, try again.");
                input = Console.ReadLine();
                TryParseStringInt(input, max);
                return output;//again, inacessible
            }
            else
            {
                return output;
            }
        }
        catch
        {
            Console.WriteLine("Invalid input, please try again.");
            input = Console.ReadLine();
            TryParseStringInt(input);
            //return should be inaccessible.
            return 1;
        }
    }

    public static void SaveGoals(List<Goal> goals)
    {
        File.WriteAllText("Goals.txt", string.Empty);
        foreach (Goal goal in goals)
        {
            if (goal is GoalRepeatable)
            {
                GoalRepeatable gr = (GoalRepeatable)goal;
                string name = goal.GetName();
                string task = goal.GetTask();
                bool isComplete = goal.GetComplete();
                int experienceValue = goal.GetExperience();
                int repeatCount = gr.GetRepeatCount();
                string repeatInterval = gr.GetRepeatInterval();
                File.AppendAllText("Goals.txt", "GR:"+name+":"+task+":"+isComplete+":"+experienceValue+":"+repeatCount+":"+repeatInterval+Environment.NewLine);
            }
            else if (goal is GoalSteps)
            {
                GoalSteps gs = (GoalSteps)goal;
                string name = goal.GetName();
                string task = goal.GetTask();
                bool isComplete = goal.GetComplete();
                int experienceValue = goal.GetExperience();
                List<Step> steps = gs.GetSteps();
                File.AppendAllText("Goals.txt", "GS:"+name+":"+task+":"+isComplete+":"+experienceValue+Environment.NewLine);
                File.AppendAllText("Goals.txt","STEPS:");
                foreach(Step step in steps)
                {
                    File.AppendAllText("Goals.txt",step.GetStep()+"|"+step.GetStatus()+":");
                }
                File.AppendAllText("Goals.txt", Environment.NewLine);
            }
            else if (goal is Goal)
            {
                string name = goal.GetName();
                string task = goal.GetTask();
                bool isComplete = goal.GetComplete();
                int experienceValue = goal.GetExperience();
                File.AppendAllText("Goals.txt", "G:"+name+":"+task+":"+isComplete+":"+experienceValue+Environment.NewLine);
            }
            else
            {
                //shouldn't happen.
            }
        }
    }
    public static List<Goal> InitializeGoals()
    {
        int index = -1;
        List<Goal> newgoals = new List<Goal>();
        string[] goals = File.ReadAllLines("Goals.txt");
        foreach (string goal in goals)
        {
            string[] goalatts = goal.Split(":");
            if (goalatts[0] == "GR")
            {
                newgoals.Add(new GoalRepeatable(goalatts[1], goalatts[2], bool.Parse(goalatts[3]), int.Parse(goalatts[4]) , int.Parse(goalatts[5]), goalatts[6]));
                index++;
            }
            else if (goalatts[0] == "GS")
            {
                GoalSteps gs = new GoalSteps(goalatts[1], goalatts[2], bool.Parse(goalatts[3]), int.Parse(goalatts[4]));
                //need to add steps still
                newgoals.Add(gs);
                index++;
            }
            else if (goalatts[0] == "G")
            {
                newgoals.Add(new Goal(goalatts[1], goalatts[2], bool.Parse(goalatts[3]), int.Parse(goalatts[4])));
                index++;
            }
            else if (goalatts[0] == "STEPS")//entry is list of steps. previous must be GoalSteps.
            {
                GoalSteps gs = (GoalSteps)newgoals[index];
                foreach(string step in goalatts)
                {
                    string[] steps = step.Split("|", StringSplitOptions.RemoveEmptyEntries);
                    if(steps.Count() < 2)
                    {
                        //this will be the STEPS header, ignore.
                    }
                    else
                    {
                        gs.AddStep(new Step(steps[0], bool.Parse(steps[1])));
                    }
                }
            }
            else
            {
                //uh oh
            }
        }
        return newgoals;
    }
}
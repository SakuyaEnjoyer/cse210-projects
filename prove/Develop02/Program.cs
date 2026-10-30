using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    //variables
    static bool continueOn = true;

    static void Main(string[] args)
    {
        while (continueOn)
        {
            Console.WriteLine("Welcome to your journal, dear user.");
            Thread.Sleep(500);
            Console.WriteLine("What would you like me to do for you?");
            Thread.Sleep(500);
            Console.WriteLine("[1]New Entry");
            Thread.Sleep(200);
            Console.WriteLine("[2]Read Journal");
            Thread.Sleep(200);
            Console.WriteLine("[3]Quit");
            string decision = Console.ReadLine();
            if (decision == "1")
            {
                //New Entry was selected
                JournalData tempEntry = EntryInput();
                Logger.LogWrite(tempEntry);
            }
            else if (decision == "2")
            {
                //Read Journal was selected
                List<JournalData> readList = new List<JournalData>();
                readList = Logger.LogRead();
                foreach (JournalData data in readList)
                {
                    Console.WriteLine(data.Date);
                    Thread.Sleep(100);
                    Console.WriteLine(data.Title);
                    Thread.Sleep(100);
                    Console.WriteLine(data.Contents);
                    Thread.Sleep(100);
                }
                Console.WriteLine("Would you like an entry from a specific date? y or n");
                string decision2 = Console.ReadLine();
                if (decision2 == "y")
                {
                    Console.WriteLine("What date are you looking for? Write in the following format: Day/Month/Year");
                    DateTime dateInProper = DateTime.Now;
                    string dateIn = Console.ReadLine();
                    int entriesFound = 0;
                    try
                    {
                        dateInProper = DateTime.Parse(dateIn);
                    }
                    catch
                    {
                        Console.WriteLine("Failed to read date");
                    }
                    foreach (JournalData data in readList)
                    {
                        if (data.Date.DayOfYear == dateInProper.DayOfYear)
                        {
                            Console.WriteLine(data.Date);
                            Thread.Sleep(100);
                            Console.WriteLine(data.Title);
                            Thread.Sleep(100);
                            Console.WriteLine(data.Contents);
                            Thread.Sleep(100);
                            entriesFound ++;
                        }
                    }
                    if (entriesFound == 0)
                    {
                        Console.WriteLine("No entries found with that date.");
                        Thread.Sleep(500);
                    }
                    else
                    {
                        Console.WriteLine($"Entries found: {entriesFound}");
                        Thread.Sleep(500);
                    }
                }
                else if (decision2 != "n")
                {
                    Console.WriteLine("That wasn't the letter y or n, but whatever.");
                }
            }
            else if (decision == "3")
            {
                continueOn = false;
            }
            else
            {
                //Incorrect option
                Console.WriteLine("Hmm... it seems that was not a correct input. You should type in the number associated with your choice and nothing else. Try again.");
            }
        }
    }

    static JournalData EntryInput()
    {
        Console.WriteLine("Please enter the title for this entry.");
        string title = Console.ReadLine();
        Console.WriteLine("Now you may write out your entry.");
        string contents = Console.ReadLine();
        JournalData newentry = new JournalData{ Date = DateTime.Now, Title = title, Contents = contents};
        return newentry;
    }
}

public class JournalData
{
    public DateTime Date { get; set; }
    public string Title { get; set; }
    public string Contents { get; set; }
}

public class Logger
{
    public static void LogWrite(JournalData data)
    {
        File.AppendAllText("Journallog.txt", $"{data.Date},{data.Title},{data.Contents}" + Environment.NewLine);   
    }
    public static List<JournalData> LogRead()
    {
        var lines = File.ReadAllLines("Journallog.txt");
        List<JournalData> restoredEntries = new List<JournalData>();

        foreach (var line in lines)
        {
            var parts = line.Split(",");
            if (parts.Length >= 3)
            {
                try
                {
                    restoredEntries.Add(new JournalData{Date = DateTime.Parse(parts[0]), Title = parts[1], Contents = parts[2]});
                }
                catch
                {
                    Console.WriteLine("Failed to read journal entry");
                }
            }            
        }
        return restoredEntries;
    }
}
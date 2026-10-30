using System;

class Program
{
    static void Main(string[] args)
    {
        //variables
        string letterGrade = "";
        string plusOrMinus = "";
        //

        Console.WriteLine("Enter Percentage");
        string percentString = Console.ReadLine();
        float percent = float.Parse(percentString); //should allow for decimal points in grade

        //match percentage to letter grade

        if (percent >= 90)
        {
            letterGrade = "A";
        }
        else if (percent >= 80)
        {
            letterGrade = "B";
        }
        else if (percent >= 70)
        {
            letterGrade = "C";
        }
        else if (percent >= 60)
        {
            letterGrade = "D";
        }
        else if (percent < 60)
        {
            letterGrade = "F";
        };

        //now I gotta get that + or -
        //grab the digit in the ones place

        int onesPlace = (int)percent %10;
        Console.WriteLine(onesPlace);//test
        if (onesPlace <= 3 && percent != 100 && percent > 60)
        {
            plusOrMinus = "-";
        }
        else if (percent < 90 && onesPlace >= 7 && percent > 60)
        {
            plusOrMinus = "+";
        };

        //did they pass?

        if (percent >= 70)
        {
            Console.WriteLine($"Your grade is {letterGrade}{plusOrMinus}, you passed!");
        }
        else
        {
            Console.WriteLine($"Your grade is {letterGrade}{plusOrMinus}, uh oh.");
        };

        ConsoleKeyInfo waitTillEnter = Console.ReadKey();
    }
}
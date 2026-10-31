using System;
using System.Linq.Expressions;

class Program
{
    static void Main(string[] args)
    {
        Assignment student1 = new Assignment("Ronald McDonald", "Superposition 101");
        Console.WriteLine(student1.GetSummary());
        MathAssignment student2 = new MathAssignment("CirnoMath 101", "25-58", "Mike Schmidt", "Algebra");
        Console.WriteLine(student2.GetSummary());
        Console.WriteLine(student2.GetHomeworkList());
        WritingAssignment student3 = new WritingAssignment("The Grimoiore of Marisa", "Marisa Kirisame", "Danmaku Mastery 301");
        Console.WriteLine(student3.GetSummary());
        Console.WriteLine(student3.GetWritingInformation());
    }
}
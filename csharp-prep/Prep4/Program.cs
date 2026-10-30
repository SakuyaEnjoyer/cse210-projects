using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        bool continueOn = true;
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, then type x when finished.");
        do
        {
            Console.Write("Enter Number:");
            string inputString = Console.ReadLine();
            if (int.TryParse(inputString, out int number))
            {
                //process input
                numbers.Add(number);
            }
            else
            {
                //print list, user is done
                int sum = numbers.Sum();
                double ave = numbers.Average();
                int big = numbers.Max();
                Console.WriteLine($"The sum is: {sum}");
                Console.WriteLine($"The average is: {ave}");
                Console.WriteLine($"The largest number is: {big}");
                continueOn = false;
            }
        } while (continueOn);
    }
}
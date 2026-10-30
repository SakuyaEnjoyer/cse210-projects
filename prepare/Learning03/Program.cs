using System;

class Program
{
    
    static void Main(string[] args)
    {
        Fraction fraction0 = new Fraction();
        Console.WriteLine(fraction0.GetFractionString());
        Console.WriteLine(fraction0.GetDecimalValue());
        Fraction fraction1 = new Fraction(5);
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());
        Fraction fraction2 = new Fraction(6,7);
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        Fraction iteraFraction = new Fraction();
        Random random = new Random();

        for(int i = 0; i < 20; i++)
        {
            iteraFraction.SetTop(random.Next(25));
            iteraFraction.SetBottom(random.Next(25));
            Console.WriteLine($"Fraction {i}: string: {iteraFraction.GetFractionString()} Number: {iteraFraction.GetDecimalValue()}");
        }
    }
}
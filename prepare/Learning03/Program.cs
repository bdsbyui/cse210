using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction first = new();
        Console.WriteLine(first.GetFractionString());
        Console.WriteLine(first.GetDecimalValue());
        
        Fraction second = new(5);
        Console.WriteLine(second.GetFractionString());
        Console.WriteLine(second.GetDecimalValue());
        
        Fraction third = new(3, 4);
        Console.WriteLine(third.GetFractionString());
        Console.WriteLine(third.GetDecimalValue());

        Fraction fourth = new(1, 3);
        Console.WriteLine(fourth.GetFractionString());
        Console.WriteLine(fourth.GetDecimalValue());
    }
}
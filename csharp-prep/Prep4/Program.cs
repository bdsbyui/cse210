using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        string numberInput;
        int number;
        List<int> numbers = new List<int>();
        do
        {
            Console.Write("Enter number: ");
            numberInput = Console.ReadLine();
            number = int.Parse(numberInput);
            numbers.Add(number);
        } while (number != 0);

        // Core Requirement 1
        int sum = 0;
        foreach (int addend in numbers)
        {
            sum += addend;
        }
        Console.WriteLine($"The sume is: {sum}");

        // Core Requirement 2
        int average = sum / numbers.Count;
        Console.WriteLine($"The avearge is: {average}");

        // Core Requirement 3
        int largest = -2000000000;
        foreach (int addend in numbers)
        {
            if (addend > largest)
            {
                largest = addend;
            }
        }
        Console.WriteLine($"The largest number is: {largest}");

        // Stretch Challenge 1
        int smallest = 2000000000;
        foreach (int addend in numbers)
        {
            if (addend > 0 && addend < smallest)
            {
                smallest = addend;
            }
        }
        Console.WriteLine($"The smallest positive number is: {smallest}");
        
        // Stretch Challenge 2
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int addend in numbers)
        {
            Console.WriteLine($"{addend}");
        }
    }
}
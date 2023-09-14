using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirement 1
        Console.Write("Enter grade percentage: ");
        string percentageInput = Console.ReadLine();
        int gradePercentage = int.Parse(percentageInput);
        if (gradePercentage >= 90)
        {
            Console.WriteLine
            (
                $"Core 1: The letter grade for {percentageInput}% is A."
            );
        }
        else if (gradePercentage >= 80)
        {
            Console.WriteLine
            (
                $"Core 1: The letter grade for {percentageInput}% is B."
            );
        }
        else if (gradePercentage >= 70)
        {
            Console.WriteLine
            (
                $"Core 1: The letter grade for {percentageInput}% is C."
            );
        }
        else if (gradePercentage >= 60)
        {
            Console.WriteLine
            (
                $"Core 1: The letter grade for {percentageInput}% is D."
            );
        }
        else
        {
            Console.WriteLine
            (
                $"Core 1: The letter grade for {percentageInput}% is F."
            );
        }

        // Core Requirement 2
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Core 2: Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("Core 2: Sorry, please try again.");
        }

        // Core Requirement 3
        string letter;
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine
        (
            $"Core 3: The letter grade for {percentageInput}% is {letter}."
        );

        // Stretch Challenge 1
        string sign;
        int lastDigit = gradePercentage % 10;
        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }
        Console.WriteLine
        (
            $"Stretch 1: The letter grade for {percentageInput}% is {letter}{sign}."
        );

        // Stretch Challenge 2
        if (gradePercentage < 93)
        {
            Console.WriteLine
            (
                $"Stretch 2: The letter grade for {percentageInput}% is {letter}{sign}."
            );
        }
        else
        {
            Console.WriteLine
            (
                $"Stretch 2: The letter grade for {percentageInput}% is {letter}."
            );
        }

        // Stretch Challenge 3
        if (gradePercentage < 93 && gradePercentage >= 60)
        {
            Console.WriteLine
            (
                $"Stretch 3: The letter grade for {percentageInput}% is {letter}{sign}."
            );
        }
        else
        {
            Console.WriteLine
            (
                $"Stretch 3: The letter grade for {percentageInput}% is {letter}."
            );
        }
    }
}
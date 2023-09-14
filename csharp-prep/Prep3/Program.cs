using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirement 1
        Console.WriteLine("Core 1:");
        Console.Write("What is the magic number? ");
        string numberInput1 = Console.ReadLine();
        int number1 = int.Parse(numberInput1);
        Console.Write("What is your guess? ");
        string guessInput1 = Console.ReadLine();
        int guess1 = int.Parse(guessInput1);
        if (guess1 != number1)
        {
            if (guess1 < number1)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Lower");
            }
        }
        else
        {
            Console.WriteLine("You guessed it!");
        }

        // Core Requirement 2
        Console.WriteLine("Core 2:");
        Console.Write("What is the magic number? ");
        string numberInput2 = Console.ReadLine();
        int number2 = int.Parse(numberInput2);
        string guessInput2;
        int guess2;
        do
        {
            Console.Write("What is your guess? ");
            guessInput2 = Console.ReadLine();
            guess2 = int.Parse(guessInput2);
            if (guess2 < number2)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Lower");
            }
        } while (guess2 != number2);
        Console.WriteLine("You guessed it!");

        // Core Requirement 3
        Console.WriteLine("Core 3:");
        Random randomGenerator = new Random();
        int number3 = randomGenerator.Next(1, 100);
        string guessInput3;
        int guess3;
        do
        {
            Console.Write("What is your guess? ");
            guessInput3 = Console.ReadLine();
            guess3 = int.Parse(guessInput3);
            if (guess3 < number3)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Lower");
            }
        } while (guess3 != number3);
        Console.WriteLine("You guessed it!");

        // Stretch Challenge 1
        Console.WriteLine("Stretch 1:");
        int number4 = randomGenerator.Next(1, 100);
        string guessInput4;
        int guess4;
        int count1 = 0;
        do
        {
            count1++;
            Console.Write("What is your guess? ");
            guessInput4 = Console.ReadLine();
            guess4 = int.Parse(guessInput4);
            if (guess4 < number4)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Lower");
            }
        } while (guess4 != number4);
        string countOutput1 = count1.ToString();
        string trys;
        if (count1 == 1)
        {
            trys = "try";
        }
        else
        {
            trys = "tries";
        }
        Console.WriteLine($"You guessed it in {countOutput1} {trys}!");

        // Stretch Challenge 2
        Console.WriteLine("Stretch 2:");
        string again;
        do
        {
            int number5 = randomGenerator.Next(1, 100);
            string guessInput5;
            int guess5;
            int count2 = 0;
            do
            {
                count2++;
                Console.Write("What is your guess? ");
                guessInput5 = Console.ReadLine();
                guess5 = int.Parse(guessInput5);
                if (guess5 < number5)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("Lower");
                }
            } while (guess5 != number5);
            string countOutput2 = count2.ToString();
            if (count2 == 1)
            {
                trys = "try";
            }
            else
            {
                trys = "tries";
            }
            Console.WriteLine($"You guessed it in {countOutput2} {trys}!");
            Console.Write("Play again? ");
            again = Console.ReadLine();
        } while (again == "yes");
    }
}
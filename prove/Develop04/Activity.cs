using System;

public class Activity
{
    /*
     ***************************  ATTRIBUTES  ***************************
     */
     private int _displayWidth;
     private int _duration;
     private string _description;
     private string _name;
     private string _prompt;
     private Menu _menu;

     /*
     **************************  CONSTRUCTOR  ***************************
     */
    public Activity(Menu menu)
    {
        _menu = menu;
        _displayWidth = menu.GetDisplayWidth();
        _prompt = menu.GetPrompt();
    }

    /*
     ****************************  METHODS  *****************************
     */

    //  Getters ---------------------------------------------------------
    protected int GetDisplayWidth()
    {
        return _displayWidth;
    }
    protected int GetDuration()
    {
        return _duration;
    }
    protected string GetPrompt()
    {
        return _prompt;
    }

    //  Setters ---------------------------------------------------------
    protected void SetDescription(string description)
    {
        _description = description;
    }
    protected void SetName(string name)
    {
        _name = name;
    }

    //  Other Protected Methods -----------------------------------------
    protected void ClearLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }
    protected void DisplayEndingMessage()
    {
        Console.WriteLine("");
        Console.Write("Well done!!");
        ShowSpinner();
        Console.WriteLine("\n");
        Console.Write
            (
                $"You have completed another {_duration} seconds of the {_name}."
            );
        ShowSpinner();
    }
    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine("");
        foreach (string line in _menu.Wrap(_description))
        {
            Console.WriteLine(line);
        }
        Console.WriteLine("");
        bool validDuration = default;
        do
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            validDuration = int.TryParse(Console.ReadLine(), out _duration);
        } while (!validDuration);
        Console.WriteLine("");
        Console.Write("Get ready . . . ");
        ShowCountDown(5);
    }
    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine("\n");
    }
    protected void ShowSpinner()
    {
        string[] spinnerSequence = {"|", "/", "-", "\\"};
        for (int i = 10; i > 0; i--)
        {
            foreach (string spin in spinnerSequence)
            {
                Console.Write(spin);
                Thread.Sleep(100);
                Console.Write("\b \b");
            }
        }
    }
}

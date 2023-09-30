using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialization
        Data scripturesFile = new("lds-scriptures.txt");
        Scriptures scriptures = new(scripturesFile.LoadText());
        Menu mainMenu = new();
        mainMenu.SetWelcome("Welcome to the Scripture Memorizer program. This program was developed by Bryant Smith for CSE 210 at BYU-I.");
        mainMenu.SetTitle("MAIN MENU");
        string[] mainMenuOptions = 
        {
            "Memorize new scripture.",
            "Retrieve saved scripture.",
            "Quit program."
        };
        mainMenu.SetWidth(38);
        mainMenu.SetInstructions("You may select a new scripture to memorize, or retrieve a saved scripture to practice.");
        mainMenu.SetOptions(mainMenuOptions);

        // Main Menu
        do
        {
            mainMenu.Display();
            do
            {
                if (mainMenu.ResponseInvalid())
                {
                    mainMenu.ErrorMessage();
                }
                mainMenu.Prompt();
            } while (mainMenu.ResponseInvalid());
            switch (mainMenu.EvaluateResponse())
            {
                case 0:
                    mainMenu.Kill();
                    break;
                case 1:
                    Menu scriptureMenu = new();
                    scriptureMenu.SubtractTitle();
                    scriptureMenu.SetInstructions("User selection of a scripture is pending.");
                    scriptureMenu.Display();
                    Console.Write("Continue");
                    Console.ReadLine();
                    Reference reference = new("Articles of Faith", 1, 13);
                    Scripture scripture = new(reference);
                    scripture.Memorize();
                    goto case 3;
                case 2:
                    Console.WriteLine("Function pending.");
                    goto case 3;
                case 3:
                    mainMenu.Quit();
                    break;
            }
        } while (mainMenu.Run());
    }
}
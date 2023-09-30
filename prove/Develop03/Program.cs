using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialization
        Data scripturesFile = new("lds-scriptures.txt");
        Scriptures scriptures = new(scripturesFile.Load());
        Menu mainMenu = new();
        mainMenu.SetWelcome("Welcome to the Scripture Memorizer program. This program was developed by Bryant Smith for CSE 210 at BYU-I.");
        mainMenu.SetTitle("MAIN MENU");
        string[] mainMenuOptions = {
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
                    Console.Write($"{mainMenu.GetError()}");
                }
                mainMenu.Prompt();
            } while (mainMenu.ResponseInvalid());
            switch (mainMenu.EvaluateResponse())
            {
                case 0:
                    mainMenu.Kill();
                    break;
                case 1:
                case 2:
                case 3:
                    break;
            }
        } while (false);
    }
}
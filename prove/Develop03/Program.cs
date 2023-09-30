using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialization
        // Data scripturesFile = new("lds-scriptures.txt");
        // Scriptures scriptures = new(scripturesFile.Load());
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
                    scriptureMenu.SetTitle("SCRIPTURE SELECTOR");
                    string[] standardWorks = 
                    {
                        "Old Testament",
                        "New Testament",
                        "Book of Mormon",
                        "Doctrine & Covenants",
                        "Pearl of Great Price"
                    };
                    scriptureMenu.SetOptions(standardWorks);
                    scriptureMenu.AddQuitOption();
                    do
                    {
                        scriptureMenu.Display();
                        do
                        {
                            if (scriptureMenu.ResponseInvalid())
                            {
                                scriptureMenu.ErrorMessage();
                            }
                            scriptureMenu.Prompt();
                        } while (scriptureMenu.ResponseInvalid);
                        string filename = standardWorks[scriptureMenu.EvaluateResponse() - 1];
                        filename = filename.Replace(" ", "-");
                        filename = $"{filename.ToLower()}.json";
                        Data scriptureFile = new(filename);
                        Scriptures testament = new(scriptureFile.Load());
                    } while (scriptureMenu.Run());
                    break;
                case 2:
                    Console.WriteLine("Retrieve");
                    break;
                case 3:
                    mainMenu.Quit();
                    break;
            }
        } while (mainMenu.Run());
    }
}
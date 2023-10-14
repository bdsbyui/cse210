using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goals = new();

        string[] mainOptions = 
            {
                "New goal",
                "List goals",
                "Save goals",
                "Upload goals",
                "Record event"
            };
        string[] newOptions = {"Simple", "Eternal", "Checklist"};

        Menu mainMenu = new("MAIN MENU");
        mainMenu.SetOptions(mainOptions);
        mainMenu.AppendQuitOption();

        do
        {
            mainMenu.SetWelcomeMessage(goals.DisplayPlayerInfo());
            mainMenu.Display();
            
            switch (mainMenu.PromptValidatedSelection())
            {
                case 0:
                    mainMenu.Kill();
                    break;

                case 1:
                    Menu newMenu = new("NEW MENU");
                    newMenu.SetOptions(newOptions);

                    do
                    {
                        newMenu.Display();
                        int selection = newMenu.PromptValidatedSelection();
                        switch (selection)
                        {
                            case 0:
                                newMenu.Kill();
                                break;
                            
                            default:
                                goals.CreateGoal(selection);
                                newMenu.Quit();
                                break;
                        }
                    } while (newMenu.Running());
                    break;

                case 2:
                    Menu listMenu = new("GOALS LIST");
                    listMenu.Display();
                    goals.ListGoalDetails();
                    Console.WriteLine("");
                    Console.WriteLine("Type ENTER to continue...");
                    Console.ReadLine();
                    break;

                case 3:
                    goals.SaveGoals();
                    break;

                case 4:
                    goals.LoadGoals();
                    break;

                case 5:
                    Menu recordMenu = new("RECORD GOALS");
                    recordMenu.SetOptions(goals.ListGoalNames());

                    do
                    {
                        recordMenu.Display();
                        int selection = recordMenu.PromptValidatedSelection();
                        switch (selection)
                        {
                            case 0:
                                recordMenu.Kill();
                                break;
                            
                            default:
                                goals.RecordEvent(selection);
                                recordMenu.Quit();
                                break;
                        }
                    } while (recordMenu.Running());
                    break;

                case 6:
                    mainMenu.Quit();
                    break;
            }
        } while (mainMenu.Running());
    }
}
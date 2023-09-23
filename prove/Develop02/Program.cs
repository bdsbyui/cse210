using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialization
        Data data = new()
        {
            _filename = "journal.txt"
        };
        Journal journal = new();
        Menu menu = new()
        {
            _heading = "\n------------\n**  MENU  **\n------------",
            _options = {"Write", "Display", "Load", "Save", "Quit"},
            _prompt = "Selection? "
        };
        Prompt prompt = new();
        string response = default;
        bool valid = true;
        bool fileLoaded = default;
        bool loadFile;
        bool overwriteFile = default;
        bool fileFound;
        bool fileSaved = default;
        bool saveFile = true;
        bool loop = true;
        Console.WriteLine("\nWelcome to the Journal Program!");

        // Program Loop
        do
        {
            // Menu
            menu.Display();
            do
            {
                if (!valid)
                {
                    Console.Write($"\"{response}\" is invalid. ");
                }
                response = menu.Prompt();
                valid = menu.Validate(response);
            } while (!valid);

            // Action
            switch (menu.Evaluate(response))
            {
                case 0:
                    Console.Write("\nUnexpected error in validating response.");
                    goto case 5;
                case 1:
                    if (data.CheckFile() && !fileLoaded && !overwriteFile)
                    {
                        string message = 
                            $"\nDo you need to first load \"{data._filename}\"? ";
                        loadFile = menu.TrueFalse(message);
                        if (loadFile)
                        {
                            goto case 3;
                        }
                        else
                        {
                            Console.WriteLine
                            (
                                $"\nAny entries saved during this session will overwrite \"{data._filename}\"."
                            );
                            string warning = "Do you wish to overwrite? ";
                            overwriteFile = menu.TrueFalse(warning);
                            if (overwriteFile)
                            {
                                goto case 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        DateTime now = DateTime.Now;
                        string promptText = prompt.Generate();
                        Console.Write($"{promptText}\n> ");
                        string entryText = Console.ReadLine();
                        Entry entry = new()
                        {
                            _date = now.ToShortDateString(),
                            _prompt = promptText,
                            _entry = entryText
                        };
                        journal.Add(entry);
                        fileSaved = false;
                        break;
                    }
                case 2:
                    journal.Display();
                    break;
                case 3:
                    fileFound = journal.Parse(data.Load());
                    if (fileFound)
                    {
                        Console.WriteLine
                        (
                            $"\nJournal loaded from \"{data._filename}\" file."
                        );
                        fileLoaded = true;
                    }
                    else
                    {
                        Console.WriteLine
                        (
                            $"\nFile \"{data._filename}\" does not exist."
                        );
                    }
                    break;
                case 4:
                    data.Save(journal.Unparse());
                    fileSaved = true;
                    Console.WriteLine
                    (
                        $"\nJournal saved to \"{data._filename}\" file."
                    );
                    break;
                case 5:
                    if (!fileSaved && !saveFile)
                    {
                        string message = "Save unsaved entries? ";
                        saveFile = menu.TrueFalse(message);
                        if (saveFile)
                        {
                            goto case 4;
                        }
                        else
                        {
                            saveFile = false;
                            goto case 5;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nGoodbye!\n");
                        loop = false;
                        break;
                    }                    
            }
        } while (loop);
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        string[] activities = 
            {
                "Breathing activity",
                "Reflecting activity",
                "Listing activity"
            };
        
        Menu menu = new();
        menu.SetOptions(activities);
        menu.AppendQuitOption();

        do
        {
            menu.Display();
            menu.GetResponse();
            switch (menu.InterpretResponse())
            {
                case 0:
                    menu.Kill();
                    break;
                case 1:
                    BreathingActivity breathe = new(menu);
                    breathe.Run();
                    break;
                case 2:
                    ReflectingActivity reflect = new(menu);
                    reflect.Run();
                    break;
                case 3:
                    ListingActivity list = new(menu);
                    list.Run();
                    break;
                case 4:
                    menu.Quit();
                    break;
            }

        } while (menu.Run());
    }
}

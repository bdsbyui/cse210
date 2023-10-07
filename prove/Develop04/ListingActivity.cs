using System;

public class ListingActivity : Activity
{
    /*
     ***************************  ATTRIBUTES  ***************************
     */
     private int _count;
     private List<string> _prompts;

     /*
     **************************  CONSTRUCTOR  ***************************
     */
    public ListingActivity(Menu menu) : base(menu) {}

    /*
     ****************************  METHODS  *****************************
     */
    public void Run()
    {
        SetName("Listing Activity");
        SetDescription
            (
                "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
            );
        DisplayStartingMessage();
        MakeLists(GetDuration());
        DisplayEndingMessage();
    }

    //  Private Methods -------------------------------------------------
    private void GetRandomPrompt()
    {
        Random random = new();
        Console.WriteLine(_prompts[random.Next(_prompts.Count())]);
        Console.Write("Get ready . . . ");
        ShowCountDown(5);
        ClearLine();
    }
    private void MakeLists(int seconds)
    {
        DateTime timeStart = DateTime.Now;
        DateTime timeEnd = timeStart.AddSeconds(seconds);
        _prompts = new()
            {
                "Who are people you appreicate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };
        GetRandomPrompt();
        do
        {
            Console.Write($"{GetPrompt()} ");
            Console.ReadLine();
            Console.WriteLine("");
            _count++;
        } while (DateTime.Now < timeEnd);
        Console.WriteLine($"You listed {_count} items!");
    }
}

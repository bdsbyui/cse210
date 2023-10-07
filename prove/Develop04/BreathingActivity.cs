using System;

public class BreathingActivity : Activity
{
    /*
     ***************************  ATTRIBUTES  ***************************
     */
     private int _inhale = 4000;
     private int _hold = 7000;
     private int _exhale = 8000;

     /*
     **************************  CONSTRUCTOR  ***************************
     */
    public BreathingActivity(Menu menu) : base(menu) {}

    /*
     ****************************  METHODS  *****************************
     */
    public void Run()
    {
        SetName("Breathing Activity");
        SetDescription
            (
                "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
            );
        DisplayStartingMessage();
        Breathe(GetDuration());
        DisplayEndingMessage();
    }

    //  Private Methods -------------------------------------------------
    private void Animate(string message, string left, string right, int fill, int interval)
    {
        string leftLung = string.Concat(Enumerable.Repeat(left, fill));
        string rightLung = string.Concat(Enumerable.Repeat(right, fill));
        Console.Write($"{leftLung}{message}{rightLung}");
        Thread.Sleep(interval);
        ClearLine();
    }
    private void Breathe(int seconds)
    {
        const int IN = 0;
        const int OUT = 2;
        int loopStart;
        int loopStep;
        int loopStop;
        int interval;
        string leftSide;
        string rightSide;
        string[] cycle = {"BREATHE IN", "HOLD BREATH", "BREATH OUT"};
        DateTime timeStart = DateTime.Now;
        DateTime timeEnd = timeStart.AddSeconds(seconds);
        do
        {
            for (int breath = IN; breath < cycle.Length; breath++)
            {
                string instruction = cycle[breath];
                int capacity = (GetDisplayWidth() - instruction.Length) / 2;
                if (breath == IN)
                {
                    loopStart = 0;
                    loopStep = 1;
                    loopStop = capacity;
                    leftSide = "<";
                    rightSide = ">";
                    interval = _inhale / capacity;
                    for (int fill = loopStart; fill < loopStop; fill += loopStep)
                    {
                        Animate(instruction, leftSide, rightSide, fill, interval);
                    }
                }
                else if (breath == OUT)
                {
                    loopStart = capacity;
                    loopStep = -1;
                    loopStop = 0;
                    leftSide = ">";
                    rightSide = "<";
                    interval = _exhale / capacity;
                    for (int fill = loopStart; fill > loopStop; fill += loopStep)
                    {
                        Animate(instruction, leftSide, rightSide, fill, interval);
                    }
                }
                else
                {
                    leftSide = "~";
                    rightSide = "~";
                    int fill = capacity;
                    interval = _hold;
                    Animate(instruction, leftSide, rightSide, fill, interval);
                }
            }
        } while (DateTime.Now < timeEnd);
    }
}

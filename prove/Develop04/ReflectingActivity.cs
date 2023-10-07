using System;

public class ReflectingActivity : Activity
{
    /*
     ***************************  ATTRIBUTES  ***************************
     */
     private List<string> _prompts;
     private List<string> _questions;

     /*
     **************************  CONSTRUCTOR  ***************************
     */
    public ReflectingActivity(Menu menu) : base(menu) {}

    /*
     ****************************  METHODS  *****************************
     */
    public void Run()
    {
        SetName("Reflecting Activity");
        SetDescription
            (
                "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use in in other aspects of your life."
            );
        DisplayStartingMessage();
        Reflect(GetDuration());
        DisplayEndingMessage();
    }

    //  Private Methods -------------------------------------------------
    private void DisplayPrompt(string prompt)
    {
        Console.Write(prompt);
        ShowSpinner();
        Console.WriteLine("");
    }
    private void DisplayQuestion(string question)
    {
        Console.Write($"\t{question}");
        ShowSpinner();
        Console.WriteLine("");
    }
    private string GetRandomPrompt(List<string> prompts)
    {
        Random random = new();
        int index = random.Next(prompts.Count());
        string prompt = prompts[index];
        prompts.RemoveAt(index);
        return prompt;
    }
    private string GetRandomQuestion(List<string> questions)
    {
        Random random = new();
        int index = random.Next(questions.Count());
        string question = questions[index];
        questions.RemoveAt(index);
        return question;
    }
    private void Reflect(int seconds)
    {
        string[] prompts = 
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };
        string[] questions =
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };
        DateTime timeStart = DateTime.Now;
        DateTime timeEnd = timeStart.AddSeconds(seconds);
        do
        {
            _prompts = new();
            foreach (string prompt in prompts)
            {
                _prompts.Add(prompt);
            }
            do
            {
                DisplayPrompt(GetRandomPrompt(_prompts));
                _questions = new();
                foreach (string question in questions)
                {
                    _questions.Add(question);
                }            
                do
                {
                    DisplayQuestion(GetRandomQuestion(_questions));
                } while (DateTime.Now < timeEnd && _questions.Count() > 0);
            } while (DateTime.Now < timeEnd && _prompts.Count() > 0);
        } while (DateTime.Now < timeEnd);
    }
}

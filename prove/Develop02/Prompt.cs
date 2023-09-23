using System;

public class Prompt
{
    public string[] _prompts = 
    {
        "How did I see the hand of the Lord in my life today?",
        "If I had one thing I could do over today, what would it be?",
        "What was the best part of my day?",
        "What was the strongest emotion I felt today?",
        "Who was the most interesting person with whom I interacted today?"
    };

    public Prompt() {}

    public string Generate()
    {
        Random randomIndex = new();
        int index = randomIndex.Next(0, _prompts.Length);
        return _prompts[index];
    }
}
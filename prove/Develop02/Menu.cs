using System;

public class Menu
{
    public string _heading;
    public List<string> _options = new();
    public string _prompt;

    public Menu() {}

    public void Display()
    {
        Console.WriteLine(_heading);
        for (int i = 0; i < _options.Count(); i++)
        {
            Console.WriteLine($"{i + 1, 2}. {_options[i]} ");
        }
    }
    public string Prompt()
    {
        Console.Write(_prompt);
        return Console.ReadLine();
    }
    private List<string> Accept(int optionNumber, string option)
    {
        List<string> acceptableResponses = new()
        {
            $"{optionNumber.ToString()}",
            $"{option[0].ToString().ToLower()}"
        };
        return acceptableResponses;
    }
    public bool Validate(string response)
    {
        List<string> validResponses = new();
        for (int i = 1; i <= _options.Count(); i++)
        {
            List<string> acceptableResponses = Accept(i, _options[i - 1]);
            validResponses.AddRange(acceptableResponses);
        }
        return validResponses.Contains(response.ToLower());
    }
    public int Evaluate(string response)
    {
        for (int i = 1; i <= _options.Count(); i++)
        {
            List<string> acceptableResponses = Accept(i, _options[i - 1]);
            if (acceptableResponses.Contains(response.ToLower()))
            {
                return i;
            }
        }
        return 0;
    }
    public bool TrueFalse(string query)
    {
        string[] affirmative = {"1", "y", "t"};
        Console.Write(query);
        string response = Console.ReadLine();
        return affirmative.Contains(response[0].ToString().ToLower());
    }
}

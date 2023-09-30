using System;
using System.Text.RegularExpressions;

public class Menu
{
    // Attributes
    private string _error;
    private string _instructions;
    private int _margin;
    private List<string> _options;
    private string _prompt;
    private bool _quit;
    private string _response;
    private string _title;
    private bool _valid;
    private string _welcome;
    private int _width;

    // Constructor
    public Menu()
    {
        _error = $"\"{_response}\" is invalid. ";
        _prompt = "> ";
        _quit = false;
        _title = "MENU";
        _valid = true;
        _width = 72;
    }

    // Setters
    public void SetInstructions(string instructions)
    {
        _instructions = instructions;
    }
    public void SetOptions(string[] options)
    {
        _options = new();
        foreach (string option in options)
        {
            _options.Add(option);
        }
    }
    public void SetPrompt(string prompt)
    {
        _prompt = prompt;
    }
    public void SetTitle(string title)
    {
        _title = title;
    }
    public void SetWelcome(string welcome)
    {
        _welcome = welcome;
    }
    public void SetWidth(int width)
    {
        _width = width;
    }

    // Getter
    public string GetResponse()
    {
        return _response;
    }

    // Methods
    private List<string> Accept(int optionNumber, string option)
    // Called by Validate() to create list of acceptable responses.
    {
        List<string> acceptableResponses = new()
        {
            $"{optionNumber.ToString()}",
            $"{option[0].ToString().ToLower()}"
        };
        return acceptableResponses;
    }
    public void AddQuitOption()
    {
        _options.Add("Quit");
    }
    private string Border(string symbol, int width)
    // Adapted from https://stackoverflow.com/questions/411752/best-way-to-repeat-a-character-in-c-sharp
    {
        return string.Concat(Enumerable.Repeat(symbol, width));
    }
    public void Display()
    // Called by Program.cs to display menu.
    {
        Console.Clear();
        if (_welcome != null)
        {
            foreach (string line in Wrap(_welcome, _width))
            {
                Console.WriteLine(line);
            }
        }
        Console.WriteLine($"\n{Border("*", _width)}");
        if (_title != null)
        {
            _margin = (_width - _title.Length) / 2;
            Console.Write($"{Border(" ", _margin)}");
            Console.Write(_title);
            Console.Write($"{Border(" ", _margin)}\n");
        }
        if (_title != null && _instructions != null)
        {
            Console.Write($"{Border(" ", _margin)}");
            Console.Write($"{Border("-", _title.Length)}");
            Console.Write($"{Border(" ", _margin)}\n");
        }
        if (_instructions != null)
        {
            foreach (string line in Wrap(_instructions, _width))
            {
                Console.WriteLine(line);
            }
        }
        Console.WriteLine($"{Border("*", _width)}\n");
        if (_options != null)
        {
            for (int i = 0; i < _options.Count(); i++)
            {
                Console.WriteLine($"{i + 1, 2}. {_options[i]} ");
            }
        }
        Console.WriteLine("");
    }
    public void ErrorMessage()
    // Called by Program.cs to display validation error.
    {
        Console.Write(_error);
    }

    public int EvaluateResponse()
    // Called by Program.cs to return user selection as case integer.
    {
        for (int i = 1; i <= _options.Count(); i++)
        {
            List<string> acceptableResponses = Accept(i, _options[i - 1]);
            if (acceptableResponses.Contains(_response.ToLower()))
            {
                return i;
            }
        }
        return 0;
    }
    public void Kill()
    {
        Console.Write("\nUnexpected error in validating response.");
        _quit = true;
    }

    public void Prompt(bool validate=true)
    // Called by Program.cs to prompt and read user response.
    {
        Console.Write($"\n{_prompt}");
        _response = Console.ReadLine();
        Console.WriteLine("");
        if (validate)
        {
            Validate(_response);
        }
    }
    public void Quit()
    {
        _quit = true;
    }
    public bool ResponseInvalid()
    {
        return !_valid;
    }
    public bool Run()
    {
        return !_quit;
    }
    public void SubtractTitle()
    {
        _title = null;
    }
    public bool TrueFalse(string query)
    // Called by Program.cs to prompt and read response to a binary question.
    {
        string[] negative = {"0", "n", "f"};
        Console.Write(query);
        string response = Console.ReadLine();
        return !negative.Contains(response[0].ToString().ToLower());
    }
    public void Validate(string response)
    // Called by Program.cs to validate user response.
    {
        List<string> validResponses = new();
        for (int i = 1; i <= _options.Count(); i++)
        {
            List<string> acceptableResponses = Accept(i, _options[i - 1]);
            validResponses.AddRange(acceptableResponses);
        }
        _valid = validResponses.Contains(response.ToLower());
    }
    private List<string> Wrap(string text, int margin)
    // Adapted from https://mike-ward.net/2009/07/19/word-wrap-in-a-console-app-c/.
    {
        int start = 0, end;
        List<string> lines = new();
        text = Regex.Replace(text, @"\s", " ").Trim();
        while ((end = start + margin) < text.Length)
        {
            while (text[end] != ' ' && end > start)
            {
                end -= 1;
            }
            if (end == start)
            {
                end = start + margin;
            }
            lines.Add(text.Substring(start, end - start));
            start = end + 1;
        }
        if (start < text.Length)
        {
            lines.Add(text.Substring(start));
        }
        return lines;
    }
}

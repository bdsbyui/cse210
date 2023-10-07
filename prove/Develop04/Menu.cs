using System;
using System.Text.RegularExpressions;

public class Menu
{
    /*
     ***************************  ATTRIBUTES  ***************************
     */
    private bool _quit;
    private bool _valid;
    private int _width;
    private string _error;
    private string _instructions;
    private string _prompt;
    private string _response;
    private string _title;
    private string _welcome;
    private List<string> _options;
    
    /*
     **************************  CONSTRUCTOR  ***************************
     */
    public Menu()
    {
        _error = $"\"{_response}\" is invalid.";
        _prompt = " >>";
        _quit = false;
        _title = "MENU";
        _valid = true;
        _width = 72;
    }

    /*
     ****************************  METHODS  *****************************
     */

    //  Getters ---------------------------------------------------------
    public int GetDisplayWidth()
    {
        return _width;
    }
    public string GetPrompt()
    {
        return _prompt;
    }

    //  Setters ---------------------------------------------------------
    public void SetErrorMessage(string message)
    {
        _error = message;
    }
    public void SetDisplayWidth(int width)
    {
        _width = width;
    }
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
    public void SetWelcomeMessage(string welcome)
    {
        _welcome = welcome;
    }
    public void Quit()
    {
        _quit = true;
    }
    public void RemoveDefaultTitle()
    {
        _title = null;
    }
    public bool Run()
    {
        return !_quit;
    }

    //  Other Public Methods --------------------------------------------
    public void AppendQuitOption()
    {
        _options.Add("Quit");
    }
    public bool BooleanQuery(string query, bool affirmativeBias=true)
    {
        Console.Write($"{query} ");
        string response = Console.ReadLine();
        if (affirmativeBias)
        {
            string[] negative = {"0", "n", "f"};
            return !negative.Contains(response[0].ToString().ToLower());
        }
        else
        {
            string[] positive = {"1", "y", "t"};
            return positive.Contains(response[0].ToString().ToLower());
        }        
    }
    public void Display()
    {
        Console.Clear();
        if (_welcome != null)
        {
            foreach (string line in Wrap(_welcome))
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("");
        }
        Console.WriteLine(DrawBorder("*", _width));
        if (_title != null)
        {
            Console.WriteLine(CenterJustify(_title));
        }
        if (_title != null && _instructions != null)
        {
            Console.WriteLine(CenterJustify(DrawBorder("-", _title.Length)));
        }
        if (_instructions != null)
        {
            foreach (string line in Wrap(_instructions))
            {
                Console.WriteLine(line);
            }
        }
        Console.WriteLine(DrawBorder("*", _width));
        Console.WriteLine("");
        if (_options != null)
        {
            for (int i = 0; i < _options.Count(); i++)
            {
                Console.WriteLine($"{i + 1, 2}. {_options[i]} ");
            }
        }
        Console.WriteLine("");
    }
    public void GetResponse()
    {
        do
        {
            if (!_valid)
            {
                Console.Write($"{_error} ");
            }
            Prompt();
        } while (!_valid);
    }
    public int InterpretResponse()
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
        Console.Write("An unexpected error occured. Quitting menu.");
        Quit();
    }
    public void Prompt(bool validate=true)
    {
        Console.Write($"{_prompt} ");
        _response = Console.ReadLine();
        Console.WriteLine("");
        if (validate)
        {
            Validate();
        }
    }
    public List<string> Wrap(string text)
    // From https://mike-ward.net/2009/07/19/word-wrap-in-a-console-app-c/.
    {
        int start = 0, end;
        List<string> lines = new();
        text = Regex.Replace(text, @"\s", " ").Trim();
        while ((end = start + _width) < text.Length)
        {
            while (text[end] != ' ' && end > start)
            {
                end -= 1;
            }
            if (end == start)
            {
                end = start + _width;
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

    //  Private Methods -------------------------------------------------
    private List<string> Accept(int optionNumber, string option)
    {
        List<string> acceptableResponses = new()
        {
            $"{optionNumber.ToString()}",
            $"{option[0].ToString().ToLower()}"
        };
        return acceptableResponses;
    }
    private string CenterJustify(string text)
    {
        string margin = string.Concat(Enumerable.Repeat
        (
            " ", (_width - text.Length) / 2
        ));
        return $"{margin}{text}{margin}";
    }
    private string DrawBorder(string symbol, int length)
    {
        return string.Concat(Enumerable.Repeat(symbol, length));
    }
    private void Validate()
    {
        List<string> validResponses = new();
        for (int i = 1; i <= _options.Count(); i++)
        {
            List<string> acceptableResponses = Accept(i, _options[i - 1]);
            validResponses.AddRange(acceptableResponses);
        }
        _valid = validResponses.Contains(_response.ToLower());
    }
}

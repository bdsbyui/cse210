using System;
using System.Text.RegularExpressions;

public class Menu
{
    /*
     ***************************  ATTRIBUTES  ***************************
     */
    private bool _quit;
    // private bool _valid;
    private int _width;
    private string _error;
    private string _context;
    private string _response;
    private string _title;
    private string _welcome;
    private List<string> _options;
    

    /*
     **************************  CONSTRUCTOR  ***************************
     */
    public Menu(string title="MENU")
    {
        _error = $"\"{_response}\" is invalid.";
        _quit = false;
        _title = title.ToUpper();
        // _valid = true;
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

    //  Setters ---------------------------------------------------------
    public void SetErrorMessage(string message)
    {
        _error = message;
    }

    public void SetDisplayWidth(int width)
    {
        _width = width;
    }

    public void SetContext(string context)
    {
        _context = context;
    }

    public void SetOptions(List<string> options)
    {
        _options = options;
    }

    public void SetWelcomeMessage(string welcome)
    {
        _welcome = welcome;
    }

    public void Quit()
    {
        _quit = true;
    }

    public void RemoveTitle()
    {
        _title = null;
    }

    public bool Running()
    {
        return !_quit;
    }


    //  Other Public Methods --------------------------------------------
    public void AppendQuitOption()
    {
        _options.Add("Quit");
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
        if (_title != null && _context != null)
        {
            Console.WriteLine(CenterJustify(DrawBorder("-", _title.Length)));
        }
        if (_context != null)
        {
            foreach (string line in Wrap(_context))
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

    public void Kill()
    {
        Console.Write("An unexpected error occured. Quitting menu.");
        Quit();
    }
    
    public bool PromptBooleanResponse(string query, bool affirmativeBias=true)
    {
        string response = PromptUnvalidatedResponse(query);
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

    public string PromptUnvalidatedResponse(string query)
    {
        Console.Write($"{query} ");
        _response = Console.ReadLine();
        return _response;
    }

    public int PromptValidatedSelection(string query=" >>")
    {
        // _valid = default;
        List<(string, string)> whitelist = new();
        for (int i = 1; i <= _options.Count(); i++)
        {
            string number = i.ToString();
            string character = _options[i - 1][0].ToString().ToLower();
            whitelist.Add((number, character));
        }
        string response = PromptUnvalidatedResponse(query);
        foreach ((string number, string character) in whitelist)
        {
            if (number == response[0].ToString() 
                || character == response[0].ToString())
            {
                // _valid = true;
                return int.Parse(number);
            }
        }
        // _valid = false;
        return 0;
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


    //  Static Method ---------------------------------------------------
    public static (string, string) GetSubjectVerb(int count)
    {
        if (count != 1)
        {
            return ("are", "s");
        }
        return ("is", "");
    }
}

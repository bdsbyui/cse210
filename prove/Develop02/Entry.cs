using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _entry;

    public Entry() {}

    public void Display()
    {
        Console.WriteLine($"\nDate: {_date} - Prompt: {_prompt}\n\t{_entry}");
    }
    public string Unparse()
    {
        return $"{_date}|{_prompt}|{_entry}\n";
    }
}
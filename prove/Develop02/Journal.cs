using System;

public class Journal
{
    readonly List<Entry> _entries = new();

    public Journal() {}

    public void Add(Entry entry)
    {
        _entries.Add(entry);
    }
    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
    public bool Parse(string[] input)
    {
        if (input != null)
        {
            foreach (string line in input)
            {
                string[] segments = line.Split("|");
                Entry entry = new()
                {
                    _date  = segments[0],
                    _prompt = segments[1],
                    _entry = segments[2]
                };
                _entries.Add(entry);
            }
        }
        return input != null;
    }
    public string Unparse()
    {
        string output = default;
        foreach (Entry entry in _entries)
        {
            output += entry.Unparse();
        }
        return output;
    }
}
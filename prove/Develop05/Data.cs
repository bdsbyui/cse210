using System;
using System.IO;

public class Data
{
    public string _filename;

    public Data(string filename)
    {
        _filename = filename;
    }

    public bool IsExtant()
    {
        return File.Exists(_filename);
    }
    
    public string[] Load()
    {
        string[] input;
        if (IsExtant())
        {
            input = File.ReadAllLines(_filename);
        }
        else
        {
            input = default;    
        }
        return input;
    }

    public void Save(List<string> output)
    {
        using StreamWriter outputFile = new(_filename);
        foreach (string line in output)
        {
            outputFile.WriteLine(line);
        }
    }
}
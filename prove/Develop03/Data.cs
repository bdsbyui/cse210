using System;
using System.IO;
using System.Text.Json;

public class Data
{
    // Attribute
    private string _filename;

    // Constructor
    public Data(string filename)
    {
        _filename = filename;
    }

    // Methods
    private bool CheckFile()
    {
        return File.Exists(_filename);
    }
    public string LoadJson()
    {
        string input;
        if (CheckFile())
        {
            input = File.ReadAllText(_filename);
        }
        else
        {
            input = default;    
        }
        return input;
    }
    public string[] LoadText()
    {
        string[] input;
        if (CheckFile())
        {
            input = File.ReadAllLines(_filename);
        }
        else
        {
            input = default;    
        }
        return input;
    }
    public void Save(string output)
    {
        using StreamWriter outputFile = new(_filename);
        outputFile.Write(output);
    }
}
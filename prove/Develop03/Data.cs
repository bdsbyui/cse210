using System;
using System.IO;

public class Data
{
    private string _filename;

    public Data(string filename)
    {
        _filename = filename;
    }

    private bool CheckFile()
    {
        return File.Exists(_filename);
    }
    public string[] Load()
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
using System;
using System.IO;

public class Data
{
    public string _filename;

    public Data() {}

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
    public bool CheckFile()
    {
        return File.Exists(_filename);
    }
}
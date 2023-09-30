using System;

public class Verse
{
    // Attributes
    private Reference _reference;
    private string _text;

    // Constructor
    public Verse(Reference reference, string text)
    {
        _reference = reference;
        _text = text;
    }

    // Getters
    public Reference GetReference()
    {
        return _reference;
    }
    public string GetText()
    {
        return _text;
    }
    public void Display()
    {
        Console.WriteLine($"{_reference.GetVerse()}  {_text}");
    }
}
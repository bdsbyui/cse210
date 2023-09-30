using System;

public class Verse
{
    private string _book;
    private int _chapter;
    private int _verse;
    private string _text;

    public Verse(string book, int chapter, int verse, string text)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _text = text;
    }
    public void Display()
    {
        Console.WriteLine($"{_book} {_chapter}:{_verse}");
    }
}
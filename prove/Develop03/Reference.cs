using System;
using System.Text;

public class Reference
{
    // Attributes
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;

    // Constructor
    public Reference(string reference)
    {
        string[] splitReference = reference.Split(" ");
        StringBuilder bookObject = new();
        for (int i = 0; i < splitReference.Length - 1; i++)
        {
            if (i != 0)
            {
                bookObject.Append(" ");
            }
            bookObject.Append(splitReference[i]);
        }
        _book = bookObject.ToString();
        int chapterVerseIndex = splitReference.GetUpperBound(0);
        string chapterVerseString = splitReference[chapterVerseIndex];
        string[] referenceNumbers = chapterVerseString.Split(":");
        _chapter = int.Parse(referenceNumbers[0]);
        string verseNumbers = referenceNumbers[1];
        string[] verses = verseNumbers.Split("-");
        _verseStart = int.Parse(verses[0]);
        if (verses.Length == 2)
        {
            _verseEnd = int.Parse(verses[1]);
        }
    }
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verse;
    }

    // Getters
    public string GetBook()
    {
        return _book;
    }
    public int GetChapter()
    {
        return _chapter;
    }
    public int GetVerse()
    {
        return _verseStart;
    }
    public int GetVerseEnd()
    {
        if (_verseEnd == 0)
        {
            return _verseStart;
        }
        return _verseEnd;
    }

    // Method
    public string GetReference()
    {
        string reference = $"{_book} {_chapter}:{_verseStart}";
        if (_verseEnd != 0)
        {
            reference = $"{reference}-{_verseEnd}";
        }
        return reference;
    }
}
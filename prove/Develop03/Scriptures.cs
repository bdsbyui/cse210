using System;
using System.Text;

public class Scriptures
{
    private List<Verse> _verses = new();

    public Scriptures(string[] textFile)
    {
        foreach (string verseString in textFile)
        {
            string[] referenceAndText = verseString.Split("     ");
            string referenceString = referenceAndText[0];
            Reference reference = new(referenceString);
            string verseText = referenceAndText[1];
            Verse verse = new(reference , verseText);
            _verses.Add(verse);
        }
    }

    // Methods
    public void Display()
    {
        foreach(Verse verse in _verses)
        {
            verse.Display();
        }
    }
    private (string book, int chapter, int verse) Parse(string reference)
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
        string bookString = bookObject.ToString();
        int chapterVerseIndex = splitReference.GetUpperBound(0);
        string chapterVerseString = splitReference[chapterVerseIndex];
        string[] referenceNumbers = chapterVerseString.Split(":");
        int chapterNumber = int.Parse(referenceNumbers[0]);
        int verseNumber = int.Parse(referenceNumbers[1]);
        return (bookString, chapterNumber, verseNumber);
    }
    public Verse Search(Reference reference)
    {
        Verse result = default;
        foreach (Verse verse in _verses)
        {
            if (verse.GetReference().GetBook() == reference.GetBook())
            {
                result = verse;
            }
        }
        return result;
    }
}
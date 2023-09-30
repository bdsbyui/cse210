using System;
using System.Text;

public class Scriptures
{
    private List<Verse> _verses = new();

    public Scriptures(string[] verseStrings)
    {
        foreach (string verseString in verseStrings)
        {
            string[] referenceAndText = verseString.Split("     ");
            string referenceString = referenceAndText[0];
            (string, int, int) reference = Parse(referenceString);
            string bookName = reference.Item1;
            int chapterNumber = reference.Item2;
            int verseNumber = reference.Item3;
            string verseText = referenceAndText[1];
            Verse verse = new(bookName, chapterNumber, verseNumber, verseText);
            _verses.Add(verse);
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
    public void Display()
    {
        foreach(Verse verse in _verses)
        {
            verse.Display();
        }
    }
}
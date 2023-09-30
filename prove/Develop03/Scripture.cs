using System;

public class Scripture
{
    // Attributes
    private bool _continue = true;
    private Reference _reference;
    private string _manualText = "We believe in being honest, true, chaste, benevolent, virtuous, and in doing good to all men; indeed, we may say that we follow the admonition of Paul--We believe all things, we hope all things, we have endured many things, and hope to be able to endure all things. If there is anything virtuous, lovely, or of good report or praiseworthy, we seek after these things.";
    private List<Word> _words = new();

    // Constructor
    public Scripture(Reference reference)
    {
        _reference = reference;
    }

    // Method
    private void Display()
    {
        Console.Clear();
        Console.Write(_reference);
        foreach (Word word in _words)
        {
            Console.Write($"{word.Display()} ");
        }
    }
    private void HideWords()
    {
        List<int> remaingIndexes = new();
        for (int i = 0; i < _words.Count(); i++)
        {
            if (_words[i].NotHidden())
            {
                remaingIndexes.Add(i);
            }
        }
        Random random = new();
        int hideIndex = random.Next(0, remaingIndexes.Count());
        _words[remaingIndexes[hideIndex]].Hide();
    }
    private bool IsHidden()
    {
        foreach (Word word in _words)
        {
            if (word.NotHidden())
            {
                return false;
            }
        }
        return true;
    }
    public void Memorize()
    {
        string[] verse = _manualText.Split(" ");
        foreach (string word in verse)
        {
            Word text = new(word);
            _words.Add(text);
        }
        while (_continue)
        {
            Display();
            Console.Write("\n\nContinue? ");
            string play = Console.ReadLine();
            if (play.ToLower() == "quit" || IsHidden())
            {
                _continue = false;
            }
            else
            {
                HideWords();
            }
        }
    }
}
using System;

public class Word
{
    // Attributes
    private string _text;
    private bool _isHidden;

    // Constructor
    public Word(string word)
    {
        _text = word;
        _isHidden = false;
    }
    
    // Methods
    public void Hide()
    {
        _isHidden = true;
    }
    public bool NotHidden()
    {
        return !_isHidden;
    }
    public string Display()
    {
        if (_isHidden)
        {
            return string.Concat(Enumerable.Repeat("_", _text.Length));
        }
        else
        {
            return _text;
        }
    }
}
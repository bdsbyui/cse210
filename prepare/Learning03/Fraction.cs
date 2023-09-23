using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }
    public Fraction(int wholeNumber)
    {
        _numerator = wholeNumber;
        _denominator = 1;
    }
    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    public void SetNumerator(int numerator)
    {
        _numerator = numerator;
    }
    public void SetDenominator(int denominator)
    {
        _denominator = denominator;
    }
    public int GetNumerator()
    {
        return _numerator;
    }
    public int GetDenominator()
    {
        return _denominator;
    }
    public string GetFractionString()
    {
        return $"{_numerator.ToString()}/{_denominator.ToString()}";
    }
    public double GetDecimalValue()
    {
        return (double)_numerator / (double)_denominator;
    }
}
using System;

public abstract class Goal
{
    protected string _description;
    protected string _points;
    protected string _shortName;
    

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }


    public virtual string GetDetailsString()
    {
        return $"{_shortName} ({_description})";
    }

    public string GetName()
    {
        return _shortName;
    }

    public abstract string GetStringRepresentation();

    public abstract bool IsComplete();

    public abstract int RecordEvent();
}
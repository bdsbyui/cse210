using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) 
        : base(name, description, points) {}


    public override string GetStringRepresentation()
    {
        return $"{GetType().Name}~{base._shortName}|{base._description}|{base.
            _points}";
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override int RecordEvent()
    {
        return int.Parse(base._points);
    }
}
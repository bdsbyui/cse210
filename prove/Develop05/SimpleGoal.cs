using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;
    

    public SimpleGoal(string name, string description, string points) 
        : base(name, description, points) 
        {
            _isComplete = false;
        }


    public override string GetStringRepresentation()
    {
        return $"{GetType().Name}~{base._shortName}|{base._description}|{base.
            _points}|{_isComplete}";
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return int.Parse(base._points);
    }

    public void SetCompletion(bool status)
    {
        _isComplete = status;
    }
}
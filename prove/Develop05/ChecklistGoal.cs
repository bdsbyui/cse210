using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _bonus;
    private int _target;
    private bool _isComplete;
    

    public ChecklistGoal
        (
            string name, string description, string points,
            int target, int bonus
        ) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _isComplete = false;
    }


    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString(
            )} -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"{GetType().Name}~{base._shortName}|{base._description}|{base.
            _points}|{_target}|{_bonus}|{_amountCompleted}";
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted < _target)
        {
            return int.Parse(base._points);    
        }
        else
        {
            Console.Write("BONUS!! ");
            _isComplete = true;
            return int.Parse(base._points) + _bonus;
        }
    }

    public void SetCompletion(int status)
    {
        _amountCompleted = status;
        if (_amountCompleted >= _target)
        {
            _isComplete = true;
        }

    }
}
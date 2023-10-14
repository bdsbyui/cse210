using System;
using System.Text;

public class GoalManager
{
    private int _score;
    private List<Goal> _goals = new();
    

    public GoalManager(){}


    public void CreateGoal(int menuSelection)
    {
        
        Console.Write("Name goal: ");
        string name = Console.ReadLine();
        Console.Write("Describe goal: ");
        string description = Console.ReadLine();
        Console.Write("Assign points: ");
        string points = Console.ReadLine();

        switch (menuSelection)
        {
            case 1:
                SimpleGoal simpleGoal = new(name, description, points);
                _goals.Add(simpleGoal);
                break;
            case 2:
                EternalGoal eternalGoal = new(name, description, points);
                _goals.Add(eternalGoal);
                break;
            case 3:
                int target = default;
                bool targetValid = default;
                while (!targetValid)
                {
                    Console.Write("Target completions for goal: ");
                    string response = Console.ReadLine();
                    targetValid = int.TryParse(response, out target);
                    if (!targetValid)
                    {
                        Console.Write("Must be a number. ");
                    }
                }

                int bonus = default;
                bool bonusValid = default;
                while (!bonusValid)
                {
                    Console.Write("Assign bonus for reaching target: ");
                    string response = Console.ReadLine();
                    bonusValid = int.TryParse(response, out bonus);
                    if (!bonusValid)
                    {
                        Console.Write("Must be a number. ");
                    }
                }                
                
                ChecklistGoal checklistGoal 
                    = new (name, description, points, target, bonus);
                _goals.Add(checklistGoal);
                break;
        }
    }

    public string DisplayPlayerInfo()
    {
        return $"You have {_score} points.";
    }
    
    public void ListGoalDetails()
    {
        for (int i = 0; i < _goals.Count(); i++)
        {
            char x = default;
            if (_goals[i].IsComplete())
            {
                x = 'X';
            }
            else
            {
                x = ' ';
            }
            Console.WriteLine($"{i + 1, 2}. [{x}] {_goals[i].GetDetailsString()}");
        }
    }

    public string[] ListGoalNames()
    {
        StringBuilder builder = new();
        for (int i = 0; i < _goals.Count(); i++)
        {
            string name = _goals[i].GetName();
            builder.Append(name).Append("|");
        }
        return builder.ToString().Remove(builder.Length - 1, 1).Split("|");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        Data inputFile = new(filename);
        string[] input = inputFile.Load();

        for (int i = 0; i < input.Length; i++)
        {
            if (i > 0)
            {
                string[] classParse = input[i].Split("~");
                string className = classParse[0];
                string classAttributes = classParse[1];
                string[] attributesParse = classAttributes.Split("|");
                switch (className)
                {
                    case "SimpleGoal":
                        SimpleGoal simpleGoal = new
                            (
                                attributesParse[0],
                                attributesParse[1],
                                attributesParse[2]
                            );
                        simpleGoal.SetCompletion(Convert.ToBoolean(
                            attributesParse[3]));
                        _goals.Add(simpleGoal);
                        break;
                    
                    case "EternalGoal":
                        EternalGoal eternalGoal = new
                            (
                                attributesParse[0],
                                attributesParse[1],
                                attributesParse[2]
                            );
                        _goals.Add(eternalGoal);
                        break;
                    
                    case "ChecklistGoal":
                        ChecklistGoal checklistGoal = new
                            (
                                attributesParse[0],
                                attributesParse[1],
                                attributesParse[2],
                                int.Parse(attributesParse[3]),
                                int.Parse(attributesParse[4])
                            );
                        checklistGoal.SetCompletion(int.Parse(
                            attributesParse[5]));
                        _goals.Add(checklistGoal);
                        break;
                }
            }
            else
            {
                _score = int.Parse(input[0]);
            }
        }
    }

    public void RecordEvent(int selection)
    {
        Goal goal = _goals.ElementAt(selection - 1);
        int points = goal.RecordEvent();
        _score += points;
        Console.WriteLine(
            $"Congratulations! You have earned {points} points!");
        
    }

    public void SaveGoals()
    {
        List<string> output = new()
        {
            _score.ToString()
        };
        foreach (Goal goal in _goals)
        {
            output.Add(goal.GetStringRepresentation());
        }
        
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        Data outputFile = new(filename);
        outputFile.Save(output);
    }
}
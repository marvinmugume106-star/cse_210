using System;

abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;

    public abstract bool IsComplete();
    public abstract int RecordEvent();
    public abstract string GetDisplayText();
    public abstract string GetStringRepresentation();

    public static Goal CreateGoalFromString(string serialized)
    {
        string[] parts = serialized.Split("|");
        if (parts.Length < 5)
        {
            throw new FormatException("Goal data is malformed.");
        }

        string goalType = parts[0];
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);

        switch (goalType)
        {
            case "SimpleGoal":
                bool isComplete = bool.Parse(parts[4]);
                return new SimpleGoal(name, description, points, isComplete);

            case "EternalGoal":
                int timesRecorded = int.Parse(parts[4]);
                return new EternalGoal(name, description, points, timesRecorded);

            case "ChecklistGoal":
                if (parts.Length != 7)
                {
                    throw new FormatException("Checklist goal data is malformed.");
                }

                int requiredTimes = int.Parse(parts[4]);
                int bonusPoints = int.Parse(parts[5]);
                int currentTimes = int.Parse(parts[6]);
                return new ChecklistGoal(name, description, points, requiredTimes, bonusPoints, currentTimes);

            default:
                throw new FormatException($"Unknown goal type: {goalType}");
        }
    }
}

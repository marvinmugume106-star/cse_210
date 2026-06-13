using System;

class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _requiredTimes;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int requiredTimes, int bonusPoints, int timesCompleted = 0)
        : base(name, description, points)
    {
        _requiredTimes = requiredTimes;
        _bonusPoints = bonusPoints;
        _timesCompleted = timesCompleted;
    }

    public override bool IsComplete()
    {
        return _timesCompleted >= _requiredTimes;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _timesCompleted++;
        int reward = Points;

        if (IsComplete())
        {
            reward += _bonusPoints;
        }

        return reward;
    }

    public override string GetDisplayText()
    {
        return $"{(IsComplete() ? "[X]" : "[ ]")} {Name} ({Description}) -- Completed {_timesCompleted}/{_requiredTimes} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{_requiredTimes}|{_bonusPoints}|{_timesCompleted}";
    }
}

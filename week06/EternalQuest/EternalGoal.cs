using System;

class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string name, string description, int points, int timesRecorded = 0)
        : base(name, description, points)
    {
        _timesRecorded = timesRecorded;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override int RecordEvent()
    {
        _timesRecorded++;
        return Points;
    }

    public override string GetDisplayText()
    {
        string timesText = _timesRecorded == 1 ? "time" : "times";
        return $"[ ] {Name} ({Description}) -- Completed {_timesRecorded} {timesText}";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{Name}|{Description}|{Points}|{_timesRecorded}";
    }
}

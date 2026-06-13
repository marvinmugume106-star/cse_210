using System;

abstract class Activity
{
    private DateTime _date;
    private int _lengthMinutes;

    public Activity(DateTime date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    public DateTime Date => _date;
    public int LengthMinutes => _lengthMinutes;

    public string GetDateString()
    {
        return _date.ToString("dd MMM yyyy");
    }

    public abstract string GetActivityType();
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public abstract string GetDistanceUnit();
    public abstract string GetSpeedUnit();
    public abstract string GetPaceUnit();

    public virtual string GetSummary()
    {
        return $"{GetDateString()} {GetActivityType()} ({LengthMinutes} min) - Distance {GetDistance():0.0} {GetDistanceUnit()}, Speed {GetSpeed():0.0} {GetSpeedUnit()}, Pace: {GetPace():0.00} {GetPaceUnit()}";
    }
}

using System;

class RunningActivity : Activity
{
    private double _distanceMiles;

    public RunningActivity(DateTime date, int lengthMinutes, double distanceMiles)
        : base(date, lengthMinutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override string GetActivityType()
    {
        return "Running";
    }

    public override double GetDistance()
    {
        return _distanceMiles;
    }

    public override double GetSpeed()
    {
        return (_distanceMiles / LengthMinutes) * 60.0;
    }

    public override double GetPace()
    {
        return LengthMinutes / GetDistance();
    }

    public override string GetDistanceUnit()
    {
        return "miles";
    }

    public override string GetSpeedUnit()
    {
        return "mph";
    }

    public override string GetPaceUnit()
    {
        return "min per mile";
    }
}

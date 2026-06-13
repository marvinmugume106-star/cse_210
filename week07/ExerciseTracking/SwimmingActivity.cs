using System;

class SwimmingActivity : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50.0;
    private const double MetersPerKilometer = 1000.0;

    public SwimmingActivity(DateTime date, int lengthMinutes, int laps)
        : base(date, lengthMinutes)
    {
        _laps = laps;
    }

    public override string GetActivityType()
    {
        return "Swimming";
    }

    public override double GetDistance()
    {
        return (_laps * LapLengthMeters) / MetersPerKilometer;
    }

    public override double GetSpeed()
    {
        return GetDistance() > 0 ? (GetDistance() / LengthMinutes) * 60.0 : 0.0;
    }

    public override double GetPace()
    {
        return GetDistance() > 0 ? LengthMinutes / GetDistance() : 0.0;
    }

    public override string GetDistanceUnit()
    {
        return "km";
    }

    public override string GetSpeedUnit()
    {
        return "kph";
    }

    public override string GetPaceUnit()
    {
        return "min per km";
    }
}

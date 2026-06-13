using System;

class CyclingActivity : Activity
{
    private double _speedKph;

    public CyclingActivity(DateTime date, int lengthMinutes, double speedKph)
        : base(date, lengthMinutes)
    {
        _speedKph = speedKph;
    }

    public override string GetActivityType()
    {
        return "Cycling";
    }

    public override double GetDistance()
    {
        return (_speedKph * LengthMinutes) / 60.0;
    }

    public override double GetSpeed()
    {
        return _speedKph;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        return distance > 0 ? LengthMinutes / distance : 0.0;
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

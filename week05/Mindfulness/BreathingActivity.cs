using System;

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        bool breatheIn = true;

        while (DateTime.Now < endTime)
        {
            int remaining = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            if (remaining <= 0)
            {
                break;
            }

            if (breatheIn)
            {
                Console.WriteLine();
                Console.Write("Breathe in...");
                ShowCountDown(Math.Min(4, remaining));
            }
            else
            {
                remaining = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
                if (remaining <= 0)
                {
                    break;
                }

                Console.WriteLine();
                Console.Write("Breathe out...");
                ShowCountDown(Math.Min(6, remaining));
            }

            breatheIn = !breatheIn;
        }

        DisplayEndingMessage();
    }
}

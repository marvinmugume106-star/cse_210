using System;
using System.IO;
using System.Threading;

class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(input, out int duration) && duration > 0)
            {
                _duration = duration;
                break;
            }

            Console.WriteLine("Please enter a positive number.");
        }

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
        SaveToLog();
    }

    protected void SaveToLog()
    {
        string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {_name} ({_duration}s)";
        File.AppendAllText("mindfulness_log.txt", entry + Environment.NewLine);
    }

    public void ShowSpinner(int seconds)
    {
        char[] spinner = { '|', '/', '-', '\\' };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[(int)(DateTime.Now.Ticks / 5000000) % 4]);
            Thread.Sleep(100);
            Console.Write("\b \b");
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}

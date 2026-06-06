using System;
using System.IO;

/*
 * Exceeding requirements:
 * - Tracks how many times each activity is performed during the session.
 * - Saves a log entry to mindfulness_log.txt after each activity.
 * - Shows a session summary when the user exits.
 */
class Program
{
    private static int _breathingCount;
    private static int _reflectingCount;
    private static int _listingCount;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Enter a choice: ");

            string choice = Console.ReadLine() ?? string.Empty;
            Console.WriteLine();

            if (choice == "1")
            {
                new BreathingActivity().Run();
                _breathingCount++;
            }
            else if (choice == "2")
            {
                new ReflectingActivity().Run();
                _reflectingCount++;
            }
            else if (choice == "3")
            {
                new ListingActivity().Run();
                _listingCount++;
            }
            else if (choice == "4")
            {
                DisplaySessionSummary();
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

            Console.WriteLine();
        }
    }

    static void DisplaySessionSummary()
    {
        Console.WriteLine("Session Summary:");
        Console.WriteLine($"Breathing activities: {_breathingCount}");
        Console.WriteLine($"Reflecting activities: {_reflectingCount}");
        Console.WriteLine($"Listing activities: {_listingCount}");

        if (File.Exists("mindfulness_log.txt"))
        {
            Console.WriteLine();
            Console.WriteLine("Activity log saved to mindfulness_log.txt");
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

// Creativity note: This Eternal Quest program includes an adventure-level system
// that rewards players with thematic titles as their score increases. This adds
// extra gamification beyond the required goal tracking and point system.
class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int totalScore = 0;

        Console.WriteLine("Welcome to Eternal Quest!");
        Console.WriteLine("Track your goals, earn points, and advance your adventure.");
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("Eternal Quest Menu:");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record an event");
            Console.WriteLine("6. Show score and level");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                CreateGoal(goals);
            }
            else if (choice == "2")
            {
                DisplayGoals(goals);
            }
            else if (choice == "3")
            {
                SaveGoals(goals, totalScore);
            }
            else if (choice == "4")
            {
                LoadGoals(ref goals, ref totalScore);
            }
            else if (choice == "5")
            {
                totalScore += RecordGoalEvent(goals);
            }
            else if (choice == "6")
            {
                ShowScore(totalScore);
            }
            else if (choice == "7")
            {
                Console.WriteLine("Goodbye, brave quester!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number from 1 to 7.");
            }

            Console.WriteLine();
        }
    }

    static void CreateGoal(List<Goal> goals)
    {
        Console.WriteLine("Choose a goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Goal type: ");
        string goalType = Console.ReadLine();

        Console.Write("Goal name: ");
        string name = Console.ReadLine();
        Console.Write("Goal description: ");
        string description = Console.ReadLine();
        int points = GetPositiveNumber("Enter points awarded (whole number): ");

        if (goalType == "1")
        {
            goals.Add(new SimpleGoal(name, description, points));
            Console.WriteLine("Simple goal created.");
        }
        else if (goalType == "2")
        {
            goals.Add(new EternalGoal(name, description, points));
            Console.WriteLine("Eternal goal created.");
        }
        else if (goalType == "3")
        {
            int requiredTimes = GetPositiveNumber("How many times must this goal be completed? ");
            int bonusPoints = GetPositiveNumber("Enter bonus points when goal is finished (whole number): ");
            goals.Add(new ChecklistGoal(name, description, points, requiredTimes, bonusPoints));
            Console.WriteLine("Checklist goal created.");
        }
        else
        {
            Console.WriteLine("Invalid goal type. The goal was not created.");
        }
    }

    static void DisplayGoals(List<Goal> goals)
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("Your Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDisplayText()}");
        }
    }

    static int RecordGoalEvent(List<Goal> goals)
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("You have no goals to record.");
            return 0;
        }

        DisplayGoals(goals);
        int choice = GetPositiveNumber("Enter the number of the goal you completed: ");

        if (choice < 1 || choice > goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return 0;
        }

        Goal selectedGoal = goals[choice - 1];
        int earnedPoints = selectedGoal.RecordEvent();

        if (earnedPoints == 0)
        {
            Console.WriteLine("This goal is already completed and does not award additional points.");
        }
        else
        {
            Console.WriteLine($"You earned {earnedPoints} points!");
        }

        return earnedPoints;
    }

    static void SaveGoals(List<Goal> goals, int totalScore)
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine($"Score|{totalScore}");
                foreach (Goal goal in goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine($"Goals saved to '{filename}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to save goals: {ex.Message}");
        }
    }

    static void LoadGoals(ref List<Goal> goals, ref int totalScore)
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        if (!File.Exists(filename))
        {
            Console.WriteLine($"File not found: {filename}");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            List<Goal> loadedGoals = new List<Goal>();
            int score = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split("|");
                if (parts.Length == 2 && parts[0] == "Score")
                {
                    score = int.Parse(parts[1]);
                }
                else
                {
                    Goal goal = Goal.CreateGoalFromString(line);
                    loadedGoals.Add(goal);
                }
            }

            goals = loadedGoals;
            totalScore = score;
            Console.WriteLine($"Goals loaded from '{filename}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to load goals: {ex.Message}");
        }
    }

    static int GetPositiveNumber(string prompt)
    {
        Console.Write(prompt);
        while (true)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int value) && value >= 0)
            {
                return value;
            }

            Console.WriteLine("Invalid entry. Please enter a whole number greater than or equal to 0.");
            Console.Write(prompt);
        }
    }

    static void ShowScore(int totalScore)
    {
        Console.WriteLine($"Current score: {totalScore}");
        Console.WriteLine($"Adventure level: {GetAdventureLevel(totalScore)}");
    }

    static string GetAdventureLevel(int totalScore)
    {
        if (totalScore >= 3000)
        {
            return "Paladin of Progress";
        }

        if (totalScore >= 1500)
        {
            return "Guardian of Growth";
        }

        if (totalScore >= 500)
        {
            return "Knight of Commitment";
        }

        return "Squire of the Quest";
    }
}

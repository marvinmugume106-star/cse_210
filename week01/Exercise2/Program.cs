using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your grade percentage.");
        string gradeInput = Console.ReadLine();
        double grade = double.Parse(gradeInput);

        string letterGrade;
        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else
        {
            letterGrade = "C";
        }

        Console.WriteLine($"Your letter grade is: {letterGrade}");
    }
}
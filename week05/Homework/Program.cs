using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "Section 7.3", "Problems 8-9");
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II by Mary Waters");

        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine($"{mathAssignment.GetSummary()}\n{mathAssignment.GetHomeworkList()}");
        Console.WriteLine($"{writingAssignment.GetSummary()}\n{writingAssignment.GetWritingInformation()}");
    }
}
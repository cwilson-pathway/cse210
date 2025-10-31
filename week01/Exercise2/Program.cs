using System;

class Program
{
    static void Main(string[] args)
    {
        /*
            Author: Christian Wilson

            Purpose: To turn percentage grades into letter grades, given that there's no A+, F-, or F+. 
        */

        // Declaring variables.
        bool hasPassed = false;
        string letterGrade = "";
        
        // Prompting user for their grade percentage and confirming the input.
        Console.Write("Please enter your grade percentage: ");
        int gradePercent = int.Parse(Console.ReadLine());
        Console.WriteLine($"\nYou input {gradePercent}");

        // Assigning a letter grade and decoration through the PlusOrMinus function.
        if (gradePercent >= 90)
        {
            hasPassed = true;
            letterGrade = $"A{PlusOrMinus(gradePercent)}";
            if (letterGrade == "A+")
            {
                letterGrade = "A";
            }
        }
        else if (gradePercent >= 80)
        {
            hasPassed = true;
            letterGrade = $"B{PlusOrMinus(gradePercent)}";
        }
        else if (gradePercent >= 70)
        {
            hasPassed = true;
            letterGrade = $"C{PlusOrMinus(gradePercent)}";
        }
        else if (gradePercent >= 60)
        {
            letterGrade = $"D{PlusOrMinus(gradePercent)}";
        }
        else
        {
            letterGrade = "F";
        }

        // Write the result in console.
        Console.Write($"You've earned a(n) {letterGrade}");

        // The following statements have the punctuation of the previous sentence. That way, the text has more personality.
        if (hasPassed)
        {
            Console.WriteLine("! Congratulations! You've passed the class!");
        }
        else
        {
            Console.WriteLine(". You have not passed. Please try again!");
        }
    }

    static string PlusOrMinus(int gradePercent)
    {
        /*
            Author: Christian Wilson

            Purpose: To take a letter grade input and apply the +/- decoration. The exception for A occurs in the Main function.
        */

        // Declaring variables.
        string decoration = "";
        int remainder = gradePercent % 10;

        // If remainder is greater than or equal to seven, set decoration to +. Else if remainder is less than 3, set decoration to -.
        if (remainder >= 7)
        {
            decoration = "+";
        }
        else if (remainder < 3)
        {
            decoration = "-";
        }

        // Return the decoration.
        return decoration;
    }
}
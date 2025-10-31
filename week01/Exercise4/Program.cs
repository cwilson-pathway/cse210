using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        /*
            Author: Christian Wilson

            Purpose: To create a user-defined list of numbers. On the encouragement to find other C# libraries for the sorting of the numbers, I decided to check if
            there were any that could find the max and minimum of the list as well. There were.
        */

        // Declaring variables.
        List<int> userNumbers = new List<int>();
        List<int> positiveNumbers = new List<int>();
        int userInput = 0;
        int totalOfList = 0;
        int largestOfList = 0;
        int smallestOfList = 0;

        // Startup message:
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Do while true: Add numbers to userList one at a time. The program will terminate if the user inputs 0.
        do
        {
            Console.Write("Enter number: ");
            userInput = int.Parse(Console.ReadLine());

            if (userInput == 0)
            {
                break;
            }
            else
            {
                if (userInput > 0)
                {
                    positiveNumbers.Add(userInput);
                }
                userNumbers.Add(userInput);
            }
        } while (true);

        // Sum the list numbers and find the largest number.
        foreach (int number in userNumbers)
        {
            totalOfList += number;
        }
        Console.WriteLine($"The sum is: {totalOfList}");

        // Average the numbers.
        float avg = ((float)totalOfList) / userNumbers.Count;
        Console.WriteLine($"The average is: {avg}");

        // Find the largest number.
        largestOfList = userNumbers.Max();
        Console.WriteLine($"The largest number is: {largestOfList}");

        // Find the smallest natural number.
        smallestOfList = positiveNumbers.Min();
        Console.WriteLine($"The smallest positive number is: {smallestOfList}");

        // Sort the numbers from least to greatest.
        userNumbers.Sort();
        Console.WriteLine("The sorted list is: ");
        foreach (int number in userNumbers)
        {
            Console.WriteLine(number);
        }
    }
}
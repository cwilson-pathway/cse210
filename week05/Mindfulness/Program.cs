/*
    Author: Christian Wilson
    Purpose: To display an understanding of Inheritance by having 3 child activity classes under a parent activity class. This is a
    Mindfulness program that includes 3 activities: Breathing exercises (using the box method), reflections, and listing. Exceeded Expectations
    by adding the box breathing functionality to the breathing activity and using a unique and meaningful animation to represent the process.
    I also created a class for the throbber so multiple of them can be used at different points, instead of setting the universal one's duration
    each time it needs to change.
*/
using System;

class Program
{
    static void Main(string[] args)
    {
        // Main Menu
        while (true)
        {
            Console.Write("Welcome to the Mindfulness Program! Please choose from the options below: " + 
            "\n1) Start Breathing Activity" +
            "\n2) Start Reflecting Activity" +
            "\n3) Start Listing Activity" +
            "\n4) Quit" +
            "\n> ");

            int userInput = int.Parse(Console.ReadLine());
            if (userInput == 1)
            {
                // Setup Breathing Activity
                Console.Clear();
                Console.WriteLine("Before we begin, let's set up your inhale and exhale duration, and any holds between them, in seconds:");
                int inhale = CheckNegative("How long are you inhaling for? ");
                int inhaleHold = CheckNegative("How long are you holding on your inhale for? ");
                int exhale = CheckNegative("How long are you exhaling for? ");
                int exhaleHold = CheckNegative("How long are you holding on your exhale for? ");
                int reps = CheckNegative("How many reps do you want to do? ");
                BreathingActivity breathingActivity = new BreathingActivity("Breathing Activity", "This activity will guide you through breathing exercises you defined just now!", inhale, inhaleHold, exhale, exhaleHold, reps);
                Console.Clear();
                breathingActivity.Run();
                Console.Clear();
            }
            else if (userInput == 2)
            {
                // Setup Reflection Activity
                Console.Clear();
                int activitySecs = CheckNegative("Before we begin, how much time, in seconds, would you like to spend on this activity? ");
                ReflectionActivity reflectionActivity = new ReflectionActivity("Reflection Activity", "This activity will ask you a main prompt and then ask you to ponder questions about it until the time runs out or the questions run out. Please don't type anything during this activity.", activitySecs);
                Console.Clear();
                reflectionActivity.Run();
                Console.Clear();
            }
            else if (userInput == 3)
            {
                // Setup Listing Activity
                Console.Clear();
                int activitySecs = CheckNegative("Before we begin, how much time, in seconds, would you like to spend on this activity? ");
                ListActivity listActivity = new ListActivity("List Activity", "In this activity, you'll list things according to a given prompt until the time runs out. You may type in this activity.", activitySecs);
                Console.Clear();
                listActivity.Run();
                Console.Clear();
            }
            else if (userInput == 4)
            {
                // Close program
                Console.Write("\nClosing Program");
                for (int seconds = 0; seconds < 3; seconds++)
                {
                    Thread.Sleep(1000);
                    Console.Write(".");
                }
                Thread.Sleep(1000);
                Console.Clear();
                break;
            }
            else
            {
                // Check for valid inputs.
                Console.Clear();
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        }

    }

    public static int CheckNegative(string message)
    {
        // Checks for a negative number and only returns userInput if the number is positive.
        bool isNegative = true;
        int userInput = 0;
        while (isNegative)
        {
            Console.Write(message);
            userInput = int.Parse(Console.ReadLine());

            if (userInput > -1)
            {
                isNegative = false;
            }
            else
            {
                Console.WriteLine("You cannot input a negative number. Please try again.\n");
            }
        }
        

        return userInput;
    }
}
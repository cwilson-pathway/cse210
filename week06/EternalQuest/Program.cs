/*
    Author: Christian Wilson

    Purpose: To create a goal-tracking program and gamifying it. Nothing extra was done due to time constraints due to the holidays.
*/
using System;

class Program
{
    static void Main(string[] args)
    {
        // Let's start the program...
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}
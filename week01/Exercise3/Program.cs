using System;

class Program
{
    static void Main(string[] args)
    {
        /*
            Author: Christian Wilson

            Purpose: To make a number guessing game similar to CSE 110, but in C# this time.
        */

        // Declare variables.
        Random randomNumber = new Random();
        int magicNumber = randomNumber.Next(1, 100);
        int userNumber = 0;
        bool isRunning = true;

        // Do while the guess isn't correct: Prompt user for the "magic number".
        do
        {
            Console.Write("What is your guess? ");
            userNumber = int.Parse(Console.ReadLine());

            // Display results.
            if (userNumber == magicNumber)
            {
                Console.WriteLine("You guessed it!");

                // Prompt user to play again.
                do
                {
                    Console.Write("\nWould you like to play again (Y/N)? ");
                    string userInput = Console.ReadLine();
                    if (userInput == "N")
                    {
                        isRunning = false;
                        break;
                    }
                    else if (userInput == "Y")
                    {
                        magicNumber = randomNumber.Next(1, 100);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please only enter Y or N.");
                    }
                } while (true);

            }
            else if (userNumber < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Lower");
            }
        } while (isRunning);

        // Closing message.
        Console.WriteLine("Closing program...");
    }
}
/*
    Author: Christian Wilson

    Purpose: To provide a journal program that uses prompts to encourage the user to write in it. Exceeded requirements by
    using .csv as the file format for the saves.
*/


using System;
using System.Reflection.Metadata;

class Program
{
    static List<List<string>> runtimeEntries = new List<List<string>>();
    static List<List<string>> loadedEntries = new List<List<string>>();
    static void Main(string[] args)
    {
        do
        {
            // Display a main menu and call different functions from it. Add a quit function.
            Console.WriteLine("Welcome to your journal! Please choose from below: " +
                            "\n1) Write Entry" +
                            "\n2) Display Entries" +
                            "\n3) Load Entries from File" +
                            "\n4) Save Entries to File" +
                            "\n5) Quit Program");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                // Write Entry
                WriteEntry entry = new WriteEntry();
                string prompt = entry._currentPrompt;
                Console.WriteLine(prompt);
                entry._textEntry = Console.ReadLine();
                runtimeEntries.Add(new List<string> { entry._entryTime.ToString(), prompt, entry._textEntry });
            }
            else if (userInput == "2")
            {
                // Display Entries
                DisplayEntries displayEntries = new DisplayEntries();
                displayEntries._entries.AddRange(runtimeEntries);
                displayEntries._loadedEntries.AddRange(loadedEntries);
                displayEntries.Display();
            }
            else if (userInput == "3")
            {
                // Load Entries from File
                if (runtimeEntries.Count > 0)
                {
                    SaveReminder();
                    Load();
                }
                else
                {
                    Load();
                }
            }
            else if (userInput == "4")
            {
                // Save Entries to File
                if (runtimeEntries.Count() > 0)
                {
                    Save();
                }
                else
                {
                    Console.WriteLine("No changes have been made.");
                }
            }
            else if (userInput == "5")
            {
                // Quit
                if (runtimeEntries.Count > 0)
                {
                    SaveReminder();
                    break;
                }
                else
                {
                    Console.WriteLine("Closing program...");
                    break;
                }
            }
            else
            {
                // Invalid entry
                Console.WriteLine("Invalid input. Please try again.");
            }

            // For white space between iterations
            Console.WriteLine();
        
        } while (true);        
    }

    static void SaveReminder()
    {
        // Gives the user the option to save before performing actions that would otherwise lose changes.
        bool unconfirmed = true;
        while (unconfirmed)
        {
            Console.Write("You have unsaved changes. Would you like to save before continuing? (Y/N) ");
            string confirmation = Console.ReadLine();
            if (confirmation.ToLower() == "y")
            {
                // Yes
                Save();
                unconfirmed = false;
            }
            else if (confirmation.ToLower() == "n")
            {
                // No
                unconfirmed = false;
            }
            else
            {
                // Invalid input
                Console.WriteLine("Invalid input. Please try again. \n");
            }
        }
    }

    static void Save()
    {
        // Saves data to a CSV.
        SaveEntries saveEntries = new SaveEntries();
        saveEntries._entries.AddRange(runtimeEntries);
        saveEntries.SaveToCSV();
    }

    static void Load()
    {
        // Clears runtimeEntries and loadedEntries and loads a new file into loadedEntries.
        loadedEntries.Clear();
        runtimeEntries.Clear();
        LoadEntries loadEntries = new LoadEntries();
        loadEntries.Load();
        loadedEntries.AddRange(loadEntries._entries);
    }
}
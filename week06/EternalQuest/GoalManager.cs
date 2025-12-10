using System.Reflection.Metadata;
using System.IO;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager(){}

    public void Start()
    {
        // Display quick welcome message.
        Console.WriteLine("Welcome to EternalQuest!");
        Thread.Sleep(3000);
        Console.Clear();

        // Generate main menu.
        do
        {
            Console.WriteLine($"You have {_score} points.\n");

            Console.Write("Menu options:" +
            "\n   1. Create New Goal" +
            "\n   2. List Goals" +
            "\n   3. Save Goals" +
            "\n   4. Load Goals" +
            "\n   5. Record Event" +
            "\n   6. Quit" +
            "\nSelect a choice from the menu. ");

            int userInput = int.Parse(Console.ReadLine());

            if (userInput == 1) // Create Goal
            {
                CreateGoal();
            }
            else if (userInput == 2) // List goals
            {
                Console.WriteLine("The goals are: ");
                ListGoalDetails();
            }
            else if (userInput == 3) // Save goals
            {
                SaveGoals();
            }
            else if (userInput == 4) // Load goals
            {
                LoadGoals();
            }
            else if (userInput == 5) // Record event to complete goals
            {
                RecordEvent();
            }
            else if (userInput == 6) // Exit the program.
            {
                Console.Write("Closing Program");
                for (int dot = 0; dot < 3; dot++)
                {
                    Thread.Sleep(1000);
                    Console.Write(".");
                }
                break;
            }
            else // Boot them to the top if the input falls out of range.
            {
                Console.WriteLine("That was an invalid input. Please only use numbers 1-6.");
            }

        } while (true);
    }

    private void ListGoalNames()
    {
        // Write the goals in a numbered list.
        const int goalNameIndex = 1;
        int listNumber = 1;

        foreach (Goal goal in _goals)
        {
            string rep = goal.GetStringRepresentation();
            string[] repArray = rep.Split(",");
            Console.WriteLine($"{listNumber}. {repArray[goalNameIndex]}");
            listNumber++;
        }
    }

    private void ListGoalDetails()
    {
        // Write the goals in a numbered list with their completion criteria.
        int listNumber = 1;
        foreach(Goal goal in _goals)
        {
            Console.WriteLine($"{listNumber}. {goal.GetDetailsString()}");
            listNumber++;
        }
    }

    private void CreateGoal()
    {
        // Select what goal to make. Simple = 1 time completion, Eternal = infinite completion, checklist = finite completion > 1.
        Console.WriteLine("The types of goals are: " +
        "\n1. Simple Goal" +
        "\n2. Eternal Goal" +
        "\n3. Checklist Goal");
        do
        {
            Console.Write("Which type of goal would you like to create? ");
            int userInput = int.Parse(Console.ReadLine());

            if (userInput == 1) // Create simple goal
            {
                List<string> goalSpecs = GoalBuilder();
                SimpleGoal simpleGoal = new SimpleGoal(goalSpecs[0], goalSpecs[1], goalSpecs[2]);
                _goals.Add(simpleGoal);
                break;
            }
            else if (userInput == 2) // Create eternal goal
            {
                List<string> goalSpecs = GoalBuilder();
                EternalGoal eternalGoal = new EternalGoal(goalSpecs[0], goalSpecs[1], goalSpecs[2]);
                _goals.Add(eternalGoal);
                break;
            }
            else if (userInput == 3) // Create checklist goal
            {
                List<string> goalSpecs = GoalBuilder();
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                string bonus = Console.ReadLine();
                Console.Write("What is the bonus for accomplishing it that many times? ");
                string target = Console.ReadLine();

                goalSpecs.AddRange([bonus, target]);
                ChecklistGoal checklistGoal = new ChecklistGoal(goalSpecs[0], goalSpecs[1], goalSpecs[2], int.Parse(goalSpecs[3]), int.Parse(goalSpecs[4]));
                _goals.Add(checklistGoal);
                break;
            }
            else // Boot them to the top if the input falls out of range.
            {
                Console.WriteLine("That was an invalid input. Please only use numbers 1-3.");
            }
        } while (true);
        
    }

    private List<string> GoalBuilder()
    {
        // Helper function to fill out the first three criteria in the parent Goal class.
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();

        return [name, desc, points];
    }

    private void RecordEvent()
    {
        // Records goal completion and awards points.
        Console.WriteLine("The goals are: ");

        // Display goals
        ListGoalNames();

        do {
            Console.Write("What goal did you accomplish? ");
            int userInt = int.Parse(Console.ReadLine());

            if (userInt <= 0 || userInt > _goals.Count) // Boot them to the top if the input falls out of range.
            {
                Console.WriteLine($"That was an invalid input. Please only use numbers 1-{_goals.Count}.");
            }
            else // Actually records the event.
            {
                Goal chosenGoal = _goals[userInt - 1];
                int accruedPoints = chosenGoal.RecordEvent();
                if (accruedPoints != 0)
                {
                    Console.WriteLine($"Congratulations! You have earned {accruedPoints} points!");
                }
                _score += accruedPoints;
                Console.WriteLine($"You now have {_score} points.\n");
                break;
            }
        } while (true);
    }

    private void SaveGoals()
    {
        // Saves the goals and points into a .csv file.
        Console.Write("What is the name of the file? (Don't use extensions, it'll save as a .csv) ");
        string filename = Console.ReadLine();
        filename += ".csv";

        using (StreamWriter file = new StreamWriter(filename))
        {
            file.WriteLine(_score);
            foreach(Goal goal in _goals)
            {
                file.WriteLine(goal.GetStringRepresentation());
            }
        }

        // Little animation for the user to let them know the file is saving.
        Console.Write("Saving");
        for (int dot = 0; dot < 3; dot++)
        {
            Thread.Sleep(1000);
            Console.Write(".");
        }

        Console.WriteLine("\nSave Complete!");
        Thread.Sleep(1000);
    }

    private void LoadGoals()
    {
        // Clears current _goals list and populates with the .csv data.
        _goals.Clear();

        // Making some index integers for better readability.
        const int objectIndex = 0;
        const int nameIndex = 1;
        const int descIndex = 2;
        const int pointsIndex = 3;
        const int bonusIndex = 4;
        const int completedIndex = 4;
        const int targetIndex = 5;
        const int amountCompletedIndex = 6;
        Console.Write("What is the filename for the goal file? (Don't use extensions) ");
        string filename = Console.ReadLine();
        filename += ".csv";

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]); // Grabs score from the top of the .csv.

        foreach (string line in lines)
        {
            string[] specs = line.Split(",");
            if (specs[objectIndex] == "SimpleGoal")
            {
                SimpleGoal simpleGoal = new SimpleGoal(specs[nameIndex], specs[descIndex], specs[pointsIndex], bool.Parse(specs[completedIndex]));
                _goals.Add(simpleGoal);
            }
            else if (specs[objectIndex] == "EternalGoal")
            {
                EternalGoal eternalGoal = new EternalGoal(specs[nameIndex], specs[descIndex], specs[pointsIndex]);
                _goals.Add(eternalGoal);
            }
            else if (specs[objectIndex] == "ChecklistGoal")
            {
                ChecklistGoal checklistGoal = new ChecklistGoal(specs[nameIndex], specs[descIndex], specs[pointsIndex], int.Parse(specs[bonusIndex]), int.Parse(specs[targetIndex]), int.Parse(specs[amountCompletedIndex]));
                _goals.Add(checklistGoal);
            }
        }
    }
}
using System;
class Program
{
    static GoalManager goalManager = new GoalManager();

    static void Main(string[] args)
    {
        Console.WriteLine("You have 0 points");

        while (true)
        {
            Console.WriteLine("\nMenu options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List of Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("\nSelect a choice from the menu: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateNewGoal();
                        break;
                    case 2:
                        goalManager.ListGoalDetails();
                        break;
                    case 3:
                        SaveGoals();
                        break;
                    case 4:
                        LoadGoals();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    static void CreateNewGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Progress Goal"); // 1. Ability to create progress goals where users can make progress towards a large goal (e.g., running a marathon).
        Console.WriteLine("5. Negative Goal"); // // 2. Introduction of negative goals where users lose points for bad habits.

        Console.Write("Which type of goal would you like to create?: ");
        if (int.TryParse(Console.ReadLine(), out int goalTypeChoice))
        {
            Goal goal = null;
            string goalType = "";

            switch (goalTypeChoice)
            {
                case 1:
                    goal = CreateSimpleGoal();
                    goalType = "Simple Goal";
                    break;
                case 2:
                    goal = CreateEternalGoal();
                    goalType = "Eternal Goal";
                    break;
                case 3:
                    goal = CreateChecklistGoal();
                    goalType = "Checklist Goal";
                    break;
                case 4:
                    goal = CreateProgressGoal();
                    goalType = "Progress Goal";
                    break;
                case 5:
                    goal = CreateNegativeGoal();
                    goalType = "Negative Goal";
                    break;
                default:
                    Console.WriteLine("Invalid choice. Goal not created.");
                    return;
            }

            goalManager.CreateGoal(goal);
            Console.WriteLine($"{goalType} '{goal.ShortName}' created!");
        }
        else
        {
            Console.WriteLine("Invalid number. Please enter a valid number.");
        }
    }

    static Goal CreateSimpleGoal()
    {
        Console.Write("Enter the name of your simple goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter a short description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points for completing the goal: ");
        if (int.TryParse(Console.ReadLine(), out int points))
        {
            return new SimpleGoal(name, description, points);
        }
        else
        {
            Console.WriteLine("Invalid points value. Goal not created.");
            return null;
        }
    }

    static Goal CreateEternalGoal()
    {
        Console.Write("Enter the name of your eternal goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter a short description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points for the eternal goal: ");
        if (int.TryParse(Console.ReadLine(), out int points))
        {
            return new EternalGoal(name, description, points);
        }
        else
        {
            Console.WriteLine("Invalid points value. Goal not created.");
            return null;
        }
    }

    static Goal CreateChecklistGoal()
    {
        Console.Write("Enter the name of your checklist goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter a short description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points for completing the goal: ");
        if (int.TryParse(Console.ReadLine(), out int points))
        {
            Console.Write("Enter the target for the checklist goal: ");
            if (int.TryParse(Console.ReadLine(), out int target))
            {
                Console.Write("Enter the bonus points for the checklist goal: ");
                if (int.TryParse(Console.ReadLine(), out int bonus))
                {
                    return new ChecklistGoal(name, description, points, target, bonus);
                }
                else
                {
                    Console.WriteLine("Ineligible bonus points value. Goal not created.");
                }
            }
            else
            {
                Console.WriteLine("Ineligible target value. Goal not created.");
            }
        }
        else
        {
            Console.WriteLine("Invalid points value. Goal not created.");
        }

        return null;
    }

    static Goal CreateProgressGoal()
    {
        Console.Write("Enter the name of your progress goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter a short description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points for reaching a milestone: ");
        if (int.TryParse(Console.ReadLine(), out int points))
        {
            Console.Write("Enter the target for the progress goal: ");
            if (int.TryParse(Console.ReadLine(), out int target))
            {
                return new ProgressGoal(name, description, points, target);
            }
            else
            {
                Console.WriteLine("Invalid target value. Goal not created.");
            }
        }
        else
        {
            Console.WriteLine("Invalid points value. Goal not created.");
        }

        return null;
    }

    static Goal CreateNegativeGoal()
    {
        Console.Write("Enter the name of your negative goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter a short description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the penalty points for violating this goal: ");
        if (int.TryParse(Console.ReadLine(), out int penalty))
        {
            return new NegativeGoal(name, description, penalty, goalManager);
        }
        else
        {
            Console.WriteLine("Invalid penalty points value. Goal not created.");
            return null;
        }
    }

    static void ListGoals()
    {
        goalManager.ListGoalDetails();
    }

    static void SaveGoals()
    {
        Console.Write("Enter the filename to save goals: ");
        string fileName = Console.ReadLine();
        goalManager.SaveGoals(fileName);
        Console.WriteLine($"Goals saved to {fileName}");
    }

    static void LoadGoals()
    {
        Console.Write("Enter the filename to load goals: ");
        string fileName = Console.ReadLine();
        goalManager.LoadGoals(fileName);
        Console.WriteLine($"Goals loaded from {fileName}");
    }

    static void RecordEvent()
    {
        Console.Write("Enter the short name of the goal you completed: ");
        string goalShortName = Console.ReadLine();
        goalManager.RecordEvent(goalShortName);
    }
}

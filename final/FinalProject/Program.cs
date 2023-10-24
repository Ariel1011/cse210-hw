using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Math Odyssey!");
        Console.WriteLine("Explore the unknown, solve math, and begin your adventure!");

        Player player = new Player("Adventurer");

        while (true)
        {
            int choice = DisplayMainMenu();

            GameWorld world = CreateGameWorld(choice);
            if (world == null)
            {
                Console.WriteLine("Invalid choice. Please select a valid difficulty level.");
                continue;
            }

            world.Initialize();

            while (true)
            {
                Location currentLocation = world.GetCurrentLocation();
                Console.WriteLine(currentLocation.GetDescription());

                if (currentLocation.HasChallenge)
                {
                    Console.WriteLine("Prepare to face a formidable test:");
                    Challenge challenge = currentLocation.GetChallenge();
                    {
                        Console.WriteLine(challenge.GetStatement());
                        Console.Write("Your answer: ");
                        int userAnswer = int.Parse(Console.ReadLine());

                        if (challenge.CheckAnswer(userAnswer))
                        {
                            Console.WriteLine("Congratulations! You solved the challenge.");
                            player.UpdateAttributes(1);
                            player.UpdateScore(10);
                            Console.WriteLine($"Your current score: {player.GetScore()}%");
                        }
                        else
                        {
                            Console.WriteLine("Wrong answer. Please try again.");
                        }
                    }
                }

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Move to a new location");
                Console.WriteLine("2. Exit the game!");

                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    world.MoveToNextLocation();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Thank you for playing Math Odyssey!");
                    break;
                }

                Console.WriteLine("You have completed the current level!");
                Console.WriteLine("Storyline: " + currentLocation.GetStoryline()); // Added storyline display.
                Console.WriteLine("What would you like to do next?");
                Console.WriteLine("1. Proceed to the next level");
                Console.WriteLine("2. Exit the game!");

                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    if (world is EasyGameWorld)
                    {
                        world = new HardGameWorld();
                    }
                    else if (world is HardGameWorld)
                    {
                        world = new AdvancedGameWorld();
                    }
                    else if (world is AdvancedGameWorld)
                    {
                        Console.WriteLine("Congratulations! You have completed all levels of Math Odyssey!");
                        Console.WriteLine("Thank you for playing!");
                        break;
                    }

                    world.Initialize();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Thank you for playing Math Odyssey!");
                    break;
                }
            }
        }
    }

    static int DisplayMainMenu()
    {
        Console.WriteLine("Select a difficulty level:");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Hard");
        Console.WriteLine("3. Advanced");

        int choice = int.Parse(Console.ReadLine());
        return choice;
    }

    static GameWorld CreateGameWorld(int choice)
    {
        switch (choice)
        {
            case 1:
                return new EasyGameWorld();
            case 2:
                return new HardGameWorld();
            case 3:
                return new AdvancedGameWorld();
            default:
                return null;
        }
    }
}

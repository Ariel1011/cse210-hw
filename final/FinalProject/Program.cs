class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Math Odyssey!");
        Console.WriteLine("Explore the unknown, solve math, and begin your adventure!");

        Player player = new Player("Adventurer");
        GameWorld world = new GameWorld();
        world.Initialize();

        while (true)
        {
            Location currentLocation = world.GetCurrentLocation();
            Console.WriteLine(currentLocation.GetDescription());

            if (currentLocation.HasChallenge)
            {
                Console.WriteLine("Prepare to face a formidable test:");
                MathProblem problem = currentLocation.GetChallenge();
                Console.WriteLine(problem.GetStatement());
                Console.Write("Your answer: ");
                int userAnswer = int.Parse(Console.ReadLine());

                if (problem.CheckAnswer(userAnswer))
                {
                    Console.WriteLine("Congratulations! You solved the challenge.");
                    player.UpdateAttributes(1);
                }
                else
                {
                    Console.WriteLine("Wrong answer. Please try again.");
                }
            }

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Move to a new location");
            Console.WriteLine("2. Exit the game and remain within the dream!");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                world.MoveToNextLocation();
            }
            else if (choice == 2)
            {
                Console.WriteLine("Thank you for playing Math Odyssey!");
                break;
            }
        }
    }
}
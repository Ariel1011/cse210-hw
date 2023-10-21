public class GameWorld
{
    private List<Location> locations;
    private int currentLocationIndex;

    public void Initialize()
    {
        locations = new List<Location>
        {
            new Location("Mist of Darkness", "You find yourself surrounded by an eerie shroud of darkness, making it nearly impossible to see your surroundings. As you stand in this mystic mist, you wonder how you will conquer the forthcoming challenge.."),
            new Location("Filthy River", "You've reached the Filthy River, and an unpleasant stench fills the air. Can you navigate past this noxious waterway and face the daunting mathematical puzzle that awaits? Unravel its secrets to progress further."),
            new Location("Great and Spacious Building", "Ahead, you spot the imposing Great and Spacious Building. Will you venture inside, where the sound of people crying echoes, or will you choose to move on to the next challenge? The choice is yours."),
            new Location("Bridge of Life", "You arrive at the Bridge of Life's edge, facing a significant challenge that blocks your path. Are you ready to overcome this hurdle and continue your journey to the other side?."),
        };

        locations[1].SetChallenge(new MathProblem("Solve: 10 + 7 =", 17));
        locations[2].SetChallenge(new MathProblem("Solve: 13 - 5 =", 8));
        locations[3].SetChallenge(new MathProblem("Solve: 9 * 9 =", 81));

        currentLocationIndex = 0;
    }

    public Location GetCurrentLocation()
    {
        return locations[currentLocationIndex];
    }

    public void MoveToNextLocation()
    {
        if (currentLocationIndex < locations.Count - 1)
        {
            currentLocationIndex++;
        }
        else
        {
            Console.WriteLine("You have explored all locations. Congratulations!");
            Environment.Exit(0);
        }
    }
}

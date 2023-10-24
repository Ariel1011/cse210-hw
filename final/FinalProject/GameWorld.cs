public class GameWorld
{
    protected List<Location> locations;
    protected int currentLocationIndex;

    public virtual void Initialize()
    {
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


    public virtual bool HasCompletedGame()
    {
        return currentLocationIndex == locations.Count - 1;
    }
}

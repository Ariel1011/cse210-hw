public class EasyGameWorld : GameWorld
{
    public override void Initialize()
    {
        locations = new List<Location>
        {
            new Location("Mist of Darkness", "Description 1", "You find yourself surrounded by an eerie shroud of darkness, making it nearly impossible to see your surroundings. As you stand in this mystic mist, you wonder how you will conquer the forthcoming challenge.."),
            new Location("Filthy River", "Description 2", "You've reached the Filthy River, and an unpleasant stench fills the air. Can you navigate past this noxious waterway and face the daunting mathematical puzzle that awaits? Unravel its secrets to progress further."),
        };

        locations[0].SetChallenge(new AdditionChallenge("Solve: 5 + 3 =", 8));
        locations[1].SetChallenge(new SubtractionChallenge("Solve: 10 - 4 =", 6));
    }
}

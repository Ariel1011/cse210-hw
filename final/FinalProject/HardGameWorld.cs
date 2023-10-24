public class HardGameWorld : GameWorld
{
    public override void Initialize()
    {
        locations = new List<Location>
        {
            new Location("Great and Spacious Building", "Description 1", "Ahead, you spot the imposing Great and Spacious Building. Will you venture inside, where the sound of people crying echoes, or will you choose to move on to the next challenge? The choice is yours."),
            new Location("Bridge", "Description 2", "You arrive at the Bridge of Life's edge, facing a significant challenge that blocks your path. Are you ready to overcome this hurdle and continue your journey to the other side?"),
            new Location("Abandoned Mine", "Description 3", "You've discovered an old abandoned mine, complete with rusty tracks. The mine holds the secrets of a long-forgotten era"),
        };

        locations[0].SetChallenge(new MultiplicationChallenge("Solve: 4 * 7 =", 28));
        locations[1].SetChallenge(new SubtractionChallenge("Solve: 12 - 5 =", 7));
        locations[2].SetChallenge(new AdditionChallenge("Solve: 8 + 6 =", 14));
    }
}

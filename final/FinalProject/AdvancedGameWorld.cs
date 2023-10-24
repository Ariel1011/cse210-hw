public class AdvancedGameWorld : GameWorld
{
    public override void Initialize()
    {
        locations = new List<Location>
        {
            new Location("Underwater Ruins", "Description 1", "You explore the ruins of an ancient underwater city. The city's secrets are waiting to be unveiled."),
            new Location("Lava Caverns", "Description 2", "You navigate through treacherous lava caverns, surrounded by the red glow of molten rock. Can you escape these fiery depths with your knowledge?"),
            new Location("Sky Castle", "Description 3", "You arrive at a floating castle among the clouds, a realm of mysteries and enchantment. The castle's ancient library holds the key to your journey."),
            new Location("Lost Temple", "Description 4", "You've reached a hidden temple in the jungle, its overgrown ruins concealing age-old riddles. Solve the temple's puzzles to unlock its forgotten wisdom."),
        };

        locations[0].SetChallenge(new AdditionChallenge("Solve: 5 + 3 =", 8));
        locations[1].SetChallenge(new SubtractionChallenge("Solve: 10 - 4 =", 6));
        locations[2].SetChallenge(new MultiplicationChallenge("Solve: 7 * 9 =", 63));
        locations[3].SetChallenge(new AdditionChallenge("Solve: 8 + 12 =", 20));
    }
}

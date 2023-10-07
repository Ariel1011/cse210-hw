public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing")
    {
    }

    protected override void PerformActivity()
    {
        for (int i = 0; i < _duration; i += 6)
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(3);
            Thread.Sleep(2000);
            Console.WriteLine("Breathe out...");
            ShowSpinner(3);
            Thread.Sleep(2000);
        }
    }
}

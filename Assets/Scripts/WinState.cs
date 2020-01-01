public class WinState : IHackerState
{
    public void Enter()
    {
        Terminal.WriteLine("You win!");
    }

    public void Execute(string input)
    {
        // Anytime the user enters data after having already won, tell them they've won.
        Terminal.WriteLine("You have already completed the game! Type 'menu' to restart.");
    }

    public void Exit()
    {
        Terminal.ClearScreen();
    }
}

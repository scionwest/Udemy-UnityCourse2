using System.Collections.Generic;

public class WinState : IHackerState
{
    private int selectedLevel;

    public WinState(int selectedLevel)
    {
        this.selectedLevel = selectedLevel;
    }

    public void Enter()
    {
        switch(selectedLevel)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /______//
(______(/
                ");
                break;
            case 2:
                Terminal.WriteLine("You got a key!");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '
                ");
                break;
            case 3:
                Terminal.WriteLine("Welcome to NASA's internal systems.");
                break;
        }

        Terminal.WriteLine("Type 'menu' to restart the game.");
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

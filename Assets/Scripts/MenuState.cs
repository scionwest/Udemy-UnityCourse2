public class MenuState : IHackerState
{
    private string startupMessage;
    private int selectedLevel;
    private HackerStateMachine stateMachine;

    public MenuState(HackerStateMachine stateMachine, string startupMessage)
    {
        this.startupMessage = startupMessage;
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        // Setup the menu for the user to consume
        Terminal.WriteLine(this.startupMessage);

        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");

        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("");

        Terminal.WriteLine("Enter your selection:");
    }

    public void Execute(string input)
    {
        // Attempt the parse their input into a level integer
        if (!int.TryParse(input, out selectedLevel))
        {
            // Not an integer, fail.
            Terminal.WriteLine("Invalid level - must be a number");
            return;
        }

        // We only support 3 levels.
        // TODO: How do we look up the number of levels consistently across states? Potentially move level dictionary from PasswordCheck to HackerStateMachine.
        if (selectedLevel > 3)
        {
            Terminal.WriteLine("Invalid level - must be less than 3.");
            return;
        }

        // We have a valid level number, change to password check state.
        this.stateMachine.ChangeState(new PasswordCheckState(this.stateMachine, this.selectedLevel));
    }

    public void Exit()
    {
        Terminal.ClearScreen();
    }
}

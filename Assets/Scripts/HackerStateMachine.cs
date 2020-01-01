using System.Collections.Generic;

public class HackerStateMachine
{
    private IHackerState currentState;
    private Dictionary<int, string[]> levelPasswords;

    public HackerStateMachine()
    {
        this.levelPasswords = new Dictionary<int, string[]>
        {
            { 1, new[] { "MyPass", "EzPz" } },
            { 2, new[] { "FooBar", "FibBam" } },
            { 3, new[] { "Hello", "World" } },
        };
    }

    // Change the State of the machine with what is provided.
    public void ChangeState(IHackerState newState)
    {
        // Exit the current state
        this.currentState?.Exit();

        // Assign and enter the new state
        currentState = newState;
        currentState?.Enter();
    }

    public bool IsInState<TState>() where TState : class, IHackerState
        => typeof(TState) == this.currentState.GetType();

    public IHackerState GetCurrentState()
        => currentState;

    public void Update(string input)
        => currentState?.Execute(input);

    public Dictionary<int, string[]> GetLevelPasswords()
        => levelPasswords;
}
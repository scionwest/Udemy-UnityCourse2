using System;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    public string startupMessage = "Hello there";
    private HackerStateMachine stateMachine = new HackerStateMachine();

    // Start is called before the first frame update
    void Start()
    {
        // Start the state machine out with the menu state.
        var menuState = new MenuState(stateMachine, startupMessage);
        stateMachine.ChangeState(menuState);
    }

    void OnUserInput(string input)
    {
        // If the input is 'menu' or '007' then restart state machine
        // with the appropriate menu state.
        if (input.Equals("menu", StringComparison.OrdinalIgnoreCase))
        {
            stateMachine.ChangeState(new MenuState(stateMachine, startupMessage));
            return;
        }
        else if (input.Equals("007"))
        {
            stateMachine.ChangeState(new MenuState(stateMachine, "Welcome Mr. Bond."));
            return;
        }

        // Update the state machine with the provided input.
        // State machine will change based on what the input contains.
        stateMachine.Update(input);
    }
}

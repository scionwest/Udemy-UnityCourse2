using System.Collections.Generic;
using UnityEngine;

public class PasswordCheckState : IHackerState
{
    private int selectedLevel;
    private string requiredPassword;
    private HackerStateMachine stateMachine;

    public PasswordCheckState(HackerStateMachine stateMachine, int level)
    {
        this.selectedLevel = level;
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        // Create the levels allowed and their available passwords
        SetRequiredPassword(selectedLevel);

        Terminal.WriteLine("Please enter your password, hint: " + requiredPassword.Anagram());
    }

    public void Execute(string input)
    {
        // Check our password for this level against what the user entered.
        if (requiredPassword.Equals(input))
        {
            // If the password matches, the user wins.
            this.stateMachine.ChangeState(new WinState(selectedLevel));
        }
        else
        {
            Terminal.WriteLine("Invalid password, try again");
        }
    }

    public void Exit()
    {
        Terminal.ClearScreen();
    }

    private void SetRequiredPassword(int level)
    {
        // Pull out the array of passwords for the level choosen by the user
        Dictionary<int, string[]> levelPasswords = stateMachine.GetLevelPasswords();

        if (!levelPasswords.TryGetValue(level, out string[] passwords))
        {
            Debug.LogError("Level that was provided does not exist in the Dictionary of allowed levels. Level given was '" + selectedLevel + "'");
            Terminal.WriteLine("Invalid level.");

            // If we can't find the level, tell the user and go back to the menu.
            this.stateMachine.ChangeState(new MenuState(this.stateMachine, "Try again"));
            return;
        }

        // Randomly pull a password out of the array for this level.
        // We grab and store it during Enter and not Execute so the password
        // doesn't change inbetween attempts by the user.
        // A harder difficulty setting in the future could have this moved to Execute
        // where it changes with each User attempt.
        int index = UnityEngine.Random.Range(0, passwords.Length);
        requiredPassword = passwords[index];
    }
}

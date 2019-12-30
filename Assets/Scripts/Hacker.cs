using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    public string startupMessage = "Hello there";

    private Screen currentScreen;
    private int selectedLevel;

    private Dictionary<int, string[]> levelPasswords = new Dictionary<int, string[]>();

    // Start is called before the first frame update
    void Start()
    {
        levelPasswords.Add(1, new[] { "MyPass", "EzPz" });
        levelPasswords.Add(2, new [] { "FooBar", "FibBam" });
        levelPasswords.Add(3, new[] { "Hello", "World" });

        ShowMainMenu(startupMessage);
    }

    void OnUserInput(string input)
    {
        if (input.Equals("menu"))
        {
            ShowMainMenu(startupMessage);
        }
        else if (input.Equals("007"))
        {
            Terminal.WriteLine("Please select a level Mr. Bond!");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            if (int.TryParse(input, out selectedLevel))
            {
                StartGame();
            }
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
            return;
        }
        else
        {
            Terminal.WriteLine("Invalid input provided.");
        }
    }

    void ShowMainMenu(string greeting)
    {
        this.currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();

        Terminal.WriteLine(greeting);

        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");

        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("");

        Terminal.WriteLine("Enter your selection:");
    }

    private void StartGame()
    {
        if (selectedLevel > 3)
        {
            Terminal.WriteLine("Invalid level.");
            return;
        }

        Terminal.ClearScreen();
        this.currentScreen = Screen.Password;
        Terminal.WriteLine("Please enter your password:");
    }

    private void CheckPassword(string input)
    {
        if (!this.levelPasswords.TryGetValue(this.selectedLevel, out string[] passwords))
        {
            Terminal.WriteLine("Invalid level");
            return;
        }

        int index = UnityEngine.Random.Range(0, passwords.Length);
        string password = passwords[index];
        print(index);

        if (password.Equals(input, StringComparison.OrdinalIgnoreCase))
        {
            Terminal.WriteLine("Success");
            this.currentScreen = Screen.Win;
            return;
        }
        else
        {
            Terminal.WriteLine("Invalid password");
            return;
        }
    }
}

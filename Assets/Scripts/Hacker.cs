using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    public string startupMessage = "Hello there";

    private Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu(startupMessage);
    }

    void OnUserInput(string input)
    {
        if (input.Equals("menu"))
        {
            ShowMainMenu(startupMessage);
        }
        else if (currentScreen == Screen.MainMenu)
        {
            if (int.TryParse(input, out int result))
            {
                SelectLevel(result);
                return;
            }
        }
        else if (input.Equals("007"))
        {
            Terminal.WriteLine("Please select a level Mr. Bond!");
        }

        Terminal.WriteLine("Invalid input provided.");
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

    void SelectLevel(int level)
    {
        if (level > 3)
        {
            Terminal.WriteLine("Invalid level.");
            return;
        }

        StartGame(level);
    }

    private void StartGame(int level)
    {
        this.currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password:");
    }
}

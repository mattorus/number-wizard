using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class NumberWizard : MonoBehaviour
{   
    private static int DefaultMin = 1;
    private static int DefaultMax = 1000;
    private static int DefaultGuess = DefaultMax / 2;
    private TreeNode tree;
    private System.Random rand;
    // Game 
    private int Min;
    private int Max;
    private int Guess;
    private bool IsGameOver;
    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !IsGameOver)
        {
            Min = Guess + 1;
            UpdateGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !IsGameOver)
        {
            Max = Guess;
            UpdateGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && !IsGameOver)
        {   
            Victory();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Resetting...");
            ResetGame();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Farewell, friend!");
            QuitGame();
        }
    }

    private void UpdateGuess()
    {
        //Guess = (Min + Max) / 2;
        Guess = rand.Next(Min, Max);
        tree.Add(Guess);
        Debug.Log($"Is your number {Guess}?");
        ShowControls();
    }

    private void ResetGame()
    {   
        Min = NumberWizard.DefaultMin;
        Max = NumberWizard.DefaultMax;
        //Guess = NumberWizard.DefaultGuess;
        IsGameOver = false;
        rand = new System.Random();
        Guess = rand.Next(Min, Max + 1);
        tree = new TreeNode(Guess);

        Debug.Log("Greetings, friend! Welcome to Number Wizard!");
        Debug.Log("Pick a number...keep it secret, keep it safe!");
        Debug.Log($"It can be as low as {Min}, or as high as {Max++}");
        Debug.Log($"Use your keyboard to tell me if your number is higher or lower than {Guess}.");
        ShowControls();
    }

    private void Victory()
    {
        Debug.Log($"Victory!");
        Debug.Log($"Here are all my guesses:\n\t");
        int guessCount = 0;
        while (tree != null)
        {
            guessCount++;
            Debug.Log($"{tree.Val}\n\t");
            if (tree.Right != null)
            {
                tree = tree.Right;
            }
            else
            {
                tree = tree.Left;
            }
        }
        Debug.Log($"\nIt only took me {guessCount} tries! :D\n\n");
        Debug.Log($"Play Again?\n\tS = Start Over, Q = Quit");
        IsGameOver = true;
    }

    private void ShowControls()
    {
        Debug.Log("Up Arrow = Higher, Down Arrow = Lower, Enter = Correct, S = Start Over, Q = Quit");
    }

    private void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else        
            Application.Quit();
        #endif
    }
}

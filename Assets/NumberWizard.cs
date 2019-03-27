using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    private KeyCode PlayerInput; 
    // Start is called before the first frame update
    void Start()
    {
        int min = 1;
        int max = 200;

        Debug.Log("Welcome to Number Wizard!");
        Debug.Log("Pick a number...keep it secret, keep it safe!");
        Debug.Log($"It can be as low as {min}, or as high as {max}");

        Debug.Log("Use your keyboard to tell me if your number is higher or lower than 500.");
        Debug.Log("Up Arrow = Higher, Down Arrow = Lower, Enter = Correct");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up Arrow key was pressed.");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down Arrow key was pressed.");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter key was pressed.");
        }
    }
}

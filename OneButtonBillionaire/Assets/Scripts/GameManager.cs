using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
        }
    }

    private bool _inputValid = false;
    private int _score = 0;

    private HashSet<string> used = new System.Collections.Generic.HashSet<string>();
    private string entryA = "";
    private string entryB = "";
    private string entryC = "";

    private void setEntries()
    {
        used.Clear();
        entryA = MorseAlphabet.GetRandomMorseLetter();
        used.Add(entryA);

        do {
            entryB = MorseAlphabet.GetRandomMorseLetter();
        } while (used.Contains(entryB));
        used.Add(entryB);

        do {
            entryC = MorseAlphabet.GetRandomMorseLetter();
        } while (used.Contains(entryC));
        used.Add(entryC);
    }

    private void clearEntries()
    {
        used.Clear();
        entryA = "";
        entryB = "";
        entryC = "";
    }

    private void Start()
    {
        setEntries();
        Debug.Log($"GameManager started: correct={entryA}, B={entryB}, C={entryC}");
    }

    private float timer = 0f;
    private float interval = 5f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            // Place your timed logic here
            if(_inputValid)
            {
                _score += 100;
                //displayResults(true);
                // Execute your logic for valid input
            }
            else
            {
                _score -= 100;
                //displayResults(false);
                // Execute your logic for invalid input
            }

            setEntries();
            timer = 0f;

            Debug.Log("5 seconds have passed!");
        }
    }
}
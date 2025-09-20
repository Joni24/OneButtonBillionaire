using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public InputManager inputManager;
    public TextMeshProUGUI objectiveLabel;

    public AnswerUI[] answerUis;
    
    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
        }
    }

    private bool _inputValid = false;
    private int _score = 0;

    private HashSet<(Letter, string)> used = new System.Collections.Generic.HashSet<(Letter, string)>();
    private List<(Letter, string)> entries = new List<(Letter, string)>();
    private Letter correctLetter;
    private string[] answer;
    
    private List<((Letter, string), string)> answers = new List<((Letter, string), string)>();

    private void setEntries()
    {
        entries.Clear();
        used.Clear();
        var entry = MorseAlphabet.GetRandomMorseLetter();
        entries.Add(entry);
        used.Add(entry);

        do
        {
            entry = MorseAlphabet.GetRandomMorseLetter();
        } while (used.Contains(entry));

        entries.Add(entry);
        used.Add(entry);

        do
        {
            entry = MorseAlphabet.GetRandomMorseLetter();
        } while (used.Contains(entry));

        entries.Add(entry);
        used.Add(entry);

        correctLetter = entries.ElementAt(Random.Range(0, entries.Count - 1)).Item1;
        Debug.Log(correctLetter);
    }

    private void SetUpQuestion()
    {
        answers.Clear();
        answer = Answers.GetRandomAnswer();
        objectiveLabel.text = answer[0];
        SetUpAnswers();
    }

    private void SetUpAnswers()
    {
        for (int i = 0; i < entries.Count; i++)
        {
            answers.Add((entries.ElementAt(i), answer[i + 1]));
        }
  
        // Shuffle the list using LINQ and OrderBy
        var rnd = new System.Random();
        var randomized = answers.OrderBy(item => rnd.Next());
        
        for (int i = 0; i < randomized.Count(); i++)
        {
            var currentAnswer = answers.ElementAt(i);
            answerUis[i].optionText.text = currentAnswer.Item2;
            answerUis[i].letterText.text = currentAnswer.Item1.Item1.ToString();
            answerUis[i].morseCodeText.text = currentAnswer.Item1.Item2;
        }
    }

    private void clearEntries()
    {
        used.Clear();
        entries.Clear();
    }

    private void Start()
    {
        Answers.ResetUsedAnswers();
        NewQuestion();
       // Debug.Log($"GameManager started: correct={entryA}, B={entryB}, C={entryC}");
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

            NewQuestion();
            Debug.Log("5 seconds have passed!");
        }
    }
    
    private void NewQuestion()
    {
        inputManager.StartInputSequence();
        setEntries();
        SetUpQuestion();
        timer = 0f;
    }
}
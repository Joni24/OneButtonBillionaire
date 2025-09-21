using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public InputManager inputManager;
    public AudioManager audioManager;
    public BillionaireState billionaire;
    public TextMeshProUGUI objectiveLabel;
    public TextMeshProUGUI resultLabel;
    public Image timerBar;

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
    private string correctMorseCode = "";
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
    }

    private void SetUpQuestion()
    {
        if (Answers.IsOutOfAnswers())
        {
            EndGame();
            return;
        }
        
        answers.Clear();
        answer = Answers.GetRandomAnswer();
        objectiveLabel.text = answer[0];
        SetUpAnswers();
    }

    private void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    private void SetUpAnswers()
    {
        for (int i = 0; i < entries.Count; i++)
        {
            answers.Add((entries.ElementAt(i), answer[i + 1]));
        }
        
        correctMorseCode = answers.ElementAt(0).Item1.Item2;
        Debug.Log(correctMorseCode);
        
        var randomAnswers = ShuffleList(answers);
        
        for (int i = 0; i < answerUis.Length; i++)
        {
            var currentAnswer = randomAnswers.ElementAt(i);

            answerUis[i].optionText.text = currentAnswer.Item2;
            answerUis[i].letterText.text = currentAnswer.Item1.Item1.ToString();
            answerUis[i].morseCodeText.text = currentAnswer.Item1.Item2;
        }
    }

    private List<((Letter, string), string)> ShuffleList(List<((Letter, string), string)> listToShuffle)
    {
        System.Random rand = new System.Random();
        for (int i = listToShuffle.Count - 1; i > 0; i--)
        {
            int k = rand.Next(i + 1);
            // Swap
            (listToShuffle[k], listToShuffle[i]) = (listToShuffle[i], listToShuffle[k]);
        }

        return listToShuffle;
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
        audioManager.PlayMusic();
       // Debug.Log($"GameManager started: correct={entryA}, B={entryB}, C={entryC}");
    }

    private float timer = 0f;
    private float interval = 5f;

    private void Update()
    {
        timer += Time.deltaTime;
        UpdateTimerBar();
        
        if (timer >= interval)
        {
            EvaluateAnswer();
            NewQuestion();
            
            Debug.Log("5 seconds have passed!");
        }
    }

    private void UpdateTimerBar()
    {
        if (timer > 0)
        {
            var scale = timerBar.rectTransform.localScale;
            scale.x = (interval - timer) / interval;
            timerBar.transform.localScale = scale;
        }
    }
    
    private void NewQuestion()
    {
        inputManager.StartInputSequence();
        setEntries();
        SetUpQuestion();
        timer = 0f;
    }

    private void EvaluateAnswer()
    {
        var isCorrect = inputManager.InputIsCorrect(correctMorseCode);
        _score = isCorrect ? _score + 100 : _score - 100;
        if (isCorrect)
        {
            audioManager.PlayHappySound();
        }
        else
        {
            audioManager.PlayMadSound();
        }
        
        
        var correctText = isCorrect ? "CORRECT" : "WRONG";
        resultLabel.text = $"Score: {_score}";

        billionaire.SetState(isCorrect ? BillionaireMood.HAPPY : BillionaireMood.MAD);
    }
}
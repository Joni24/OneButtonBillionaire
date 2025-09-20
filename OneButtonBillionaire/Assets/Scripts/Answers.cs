using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Answers
{
    private static List<string[]> usedAnswers = new List<string[]>();

    public static List<string[]> answers = new List<string[]>()
    {
        new[] { "Cheese", "$77.49", "$2.99", "$3.49" },
        new[] { "Ham", "$63.99", "$2.79", "$3.19" },
        new[] { "Chicken", "$111.89", "$6.99", "$7.49" },
        new[] { "Beef", "$185.99", "$12.99", "$13.49" },
        new[] { "Salmon", "$97.50", "$6.49", "$6.99" },
        new[] { "Tuna", "$42.49", "$1.49", "$1.89" },
        new[] { "Oil", "$123.99", "$6.99", "$7.49" },
        new[] { "Vinegar", "$45.99", "$1.79", "$2.19" },
        new[] { "Mustard", "$38.50", "$1.29", "$1.59" },
        new[] { "Ketchup", "$59.95", "$2.29", "$2.79" }
    };

    public static string[] GetRandomAnswer()
    {
        string[] answer;
        do
        {
            answer = answers.ElementAt(Random.Range(0, answers.Count));
        } while (usedAnswers.Contains(answer));

        usedAnswers.Add(answer);

        return answer;
    }

    public static void ResetUsedAnswers()
    {
        usedAnswers.Clear();
    }
}
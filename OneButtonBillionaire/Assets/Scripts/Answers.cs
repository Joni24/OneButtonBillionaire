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
        new[] { "Ketchup", "$59.95", "$2.29", "$2.79" },
        
        new[] { "Mayonnaise", "$55.99", "$1.99", "$2.49" },
        new[] { "Honey", "$99.99", "$5.99", "$6.49" },
        new[] { "Jam", "$71.49", "$2.99", "$3.49" },
        new[] { "Peanut Butter", "$83.50", "$3.49", "$3.99" },
        new[] { "Chocolate Spread", "$95.75", "$3.79", "$4.19" },
        new[] { "Baking Paper", "$47.99", "$1.79", "$1.99" },
        new[] { "Foil", "$66.95", "$2.49", "$2.79" },
        new[] { "Cling Film", "$58.25", "$1.99", "$2.29" },
        new[] { "Freezer Bags", "$69.49", "$2.49", "$2.79" },
        new[] { "Dish Soap", "$51.99", "$1.49", "$1.79" },

        new[] { "Sponges", "$43.75", "$1.29", "$1.59" },
        new[] { "Trash Bags", "$74.99", "$2.49", "$2.99" },
        new[] { "Toilet Paper", "$83.90", "$3.99", "$4.49" },
        new[] { "Paper Towels", "$64.95", "$1.99", "$2.29" },
        new[] { "Tissues", "$52.49", "$1.79", "$2.19" },
        new[] { "Hairspray", "$78.25", "$2.99", "$3.49" },
        new[] { "Shaving Foam", "$69.99", "$2.49", "$2.99" },
        new[] { "Deodorant", "$61.99", "$1.99", "$2.49" },
        new[] { "Cotton Swabs", "$39.50", "$0.99", "$1.29" },
        new[] { "Cotton Pads", "$44.99", "$1.29", "$1.59" },
    };

    public static bool IsOutOfAnswers()
    {
        return usedAnswers.Count == answers.Count;
    }
    
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
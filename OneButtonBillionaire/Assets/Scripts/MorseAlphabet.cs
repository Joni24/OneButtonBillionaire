using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class MorseAlphabet
{
    public static Dictionary<Letter, string> letters = new Dictionary<Letter, string>()
    {
        { Letter.A, ".-" },
        { Letter.B, "-..." },
        { Letter.C, "-.-." },
        { Letter.D, "-.." },
        { Letter.E, "." },
        { Letter.F, "..-." },
    };

    public static (Letter, string) GetRandomMorseLetter()
    {
        var randomElement = letters.ElementAt(Random.Range(0, letters.Count));
        return (randomElement.Key, randomElement.Value);
    }
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class MorseAlphabet
{
    public static Dictionary<Letter, string> letters = new Dictionary<Letter, string>()
    {
        { Letter.A, ".-" },
        { Letter.B, "-..." },
        { Letter.C, "-.-." }
    };

    public static string GetRandomEntry()
    {
        return letters.ElementAt(Random.Range(0, letters.Count)).Value;
    }
}
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

    private void Start()
    {
        var entry = MorseAlphabet.GetRandomEntry();
        
        Debug.Log(entry);
    }
}
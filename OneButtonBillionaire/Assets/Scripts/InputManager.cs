using System;
using TMPro;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public TextMeshProUGUI inputLabel;
    public AudioManager audioManager;
 
    public float shortInputMax = 0.1f;

    private bool _hasStartedInput = false;
    private DateTime _inputTime = DateTime.MaxValue;
    private string _inputString = "";

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _inputTime = DateTime.Now;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            UpdateMorseCode();
        }
    }

    private void UpdateMorseCode()
    {
        var duration = (DateTime.Now - _inputTime).TotalSeconds;
        bool isShortMorse = duration <= shortInputMax;
        UpdateInput(isShortMorse ? "." : "-");
        // audioManager.PlayMorseSound(isShortMorse);
    }

    public bool InputIsCorrect(string expectedMorseCode)
    {
        return _inputString.Equals(expectedMorseCode);
    }

    private void UpdateInput(string input)
    {
        _inputString += input;
        inputLabel.text = _inputString;
    }

    public void StartInputSequence()
    {
        inputLabel.text = "";
        _inputString = "";
        _hasStartedInput = true;
        inputLabel.text = _inputString;
    }
}
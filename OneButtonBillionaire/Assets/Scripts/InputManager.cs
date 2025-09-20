using System;
using TMPro;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public TextMeshProUGUI inputLabel;

    private const float MorseTime = 5f;
    private const float ShortInputMax = 0.1f;

    private bool _hasStartedInput = false;
    private DateTime _inputTime = DateTime.MaxValue;
    private string _inputString = "";

    private string A = ".-";
    private string B = "-...";

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _inputTime = DateTime.Now;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            CheckMorse();
        }
    }

    private void CheckMorse()
    {
        var duration = (DateTime.Now - _inputTime).TotalSeconds;
        Debug.Log($"Duration {duration}");

        if (duration <= ShortInputMax)
        {
            UpdateInput(".");
        }
        else
        {
            UpdateInput("-");
        }
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
    }
}
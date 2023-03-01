using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float MinutesTimer = 5;
    [SerializeField]
    TMP_Text TimerText,PlayerText;

    float currentTime;
    int currentPlayer = 1;
    private bool TimeEnded = false;

    private void Start()
    {
        currentTime = MinutesTimer * 60;
        ShowCurrentPlayer();
    }

    private void Update()
    {
        if(TimeEnded && Input.GetMouseButtonDown(0))
        {
            // Wait for user to press the button
        }
        else
        {
            currentTime -= Time.deltaTime;
            CalculateAndShowTimer();
            if (currentTime <= 0)
            {
                TimeEnded = true;
            }
        }
        
        
    }
   
    void UpdatePlayerAndResetTime()
    {
        currentTime = MinutesTimer * 60;
        currentPlayer = (currentPlayer % PlayerHandler.MaxPlayers) + 1;
        ShowCurrentPlayer();
    }

    void ShowCurrentPlayer()
    {
        PlayerText.text = $"Current Player: {currentPlayer}";
    }

    void CalculateAndShowTimer()
    {
        int seconds = (int) currentTime % 60;
        int minutes = (int) currentTime / 60;

        string timeAsString = "";

        if (minutes < 10)
            timeAsString += "0";
        timeAsString += minutes.ToString();
        timeAsString += ":";
        if (seconds < 10)
            timeAsString += "0";
        timeAsString += seconds.ToString();

        TimerText.text = timeAsString;
    }
    public void StartNextPlayerTurn()
    {
        if (TimeEnded)
        {
            UpdatePlayerAndResetTime();
            TimeEnded = false;
        }
        else
        {
            // Timer hasn't ended yet, so do nothing
        }
    }
}

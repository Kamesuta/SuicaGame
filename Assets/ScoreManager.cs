using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int currentScore;
    public TextMeshProUGUI scoreText;

    public void AddScore(int score)
    {
        currentScore += score;
        scoreText.text = $"�c��:��{currentScore}";
        
        // ���M
        GetComponent<MyScript>().room?.Send("updateScore", currentScore);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score;

  
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }

    public void addPoints()
    {
        score += 20;
        scoreText.text = "Score: " + score.ToString();
    }

    public void subtractPoints()
    {
        score -= 10;
        scoreText.text = "Score: " + score.ToString();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score;

    public GameObject apple;
    public GameObject tomato;
    public GameObject banana;
    public GameObject carrot;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (CompareTag("Apple"))
        {
            Debug.Log("20 points!");
            addPoints();
        }
        else if (CompareTag("Tomato"))
        {
            Debug.Log("Minus 10 points!");
            subtractPoints();
        }
        else if (CompareTag("Banana"))
        {
            Debug.Log("Minus 10 points!");
            subtractPoints();
        }
        else if (CompareTag("Carrot"))
        {
            Debug.Log("20 points!");
            addPoints();
        }
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    [Header("Minigame Info")]
    public string title;
    [TextAreaAttribute]
    public string instructions;

    [Header("Scoring / Game States")]
    public bool finished = false;
    public float score = 0f;

    public static Minigame instance;


    //Defining as singleton
        //Call like this:
        //Minigame.instance
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start() {
        MinigameFramework.instance.SetTitleText(title);
        MinigameFramework.instance.SetInstructionText(instructions);
    }

    public void SetScore(float newScore) {
        score = newScore;
    }

    public void Finish() {
        //if already done return
        if (finished) {
            Debug.LogError("Minigame Already Finished: Cannot call Minigame.Finish()");
            return;
        }

        //send score to minigame base scene to record
        MinigameFramework.instance.Scores.Add(score);
        finished = true;
    }
}

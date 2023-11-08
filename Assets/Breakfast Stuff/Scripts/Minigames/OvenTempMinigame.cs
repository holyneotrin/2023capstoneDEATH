using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class OvenTempMinigame : MonoBehaviour
{
    [Header("References")]
    public Slider OvenTempSlider;
    public Slider TargetSlider;
    public Slider ChangeTempSlider;

    [Header("Coefficients")]
    [Range(0,1)]
    public float TempROC = 1f;

    [Header("Sounds")]
    public AudioClip DoneSound;

    private bool isDone = false;


    void Start() {
        //Randomize target value
        TargetSlider.value = UnityEngine.Random.Range(0.7f,0.9f);
    }

    void Update() {
        //Only execute if slider is over 0
        if (ChangeTempSlider.value > 0 && !isDone) {
            //Account for time and coef and add to temp
            float addedVal = TempROC * ChangeTempSlider.value * Time.deltaTime;
            OvenTempSlider.value += addedVal;
        }
    }

    public void EndGame() {
        isDone = true;
        ReactionProfile.instance.QueueReaction(new ReactionCommand(ReactionProfile.instance.successSprite));
        AudioManager.instance.PlaySound(DoneSound, 100f);
        Debug.Log("TargetTemp: " + TargetSlider.value + " | OvenTemp: " + OvenTempSlider.value);
    }
}

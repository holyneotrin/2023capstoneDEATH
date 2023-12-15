using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.UI;

public class RollingMinigame : MonoBehaviour
{
    [Header("References")]
    public GameObject[] Croissants; 
    private int croissantIndex = 0;

    [Header("UI References")]
    public Slider TargetSlider;
    public Slider RollingProgressSlider;
    public GameObject StartButton;

    [Header("Rolling Values")]
    public float minRollingRate;
    public float maxRollingRate;
    private float rollingRate = .01f;
    private float rollingTargetVal;
    private float[] rollingResults;

    [Header("Sounds")]
    public AudioClip goodReact;
    public AudioClip badReact;

    [Header("Other shit I guess")]
    public bool Started = false;


    void Start() {
        rollingResults = new float[Croissants.Length];
        rollingTargetVal = TargetSlider.value;
        changeRollingRate();
    }

    void Update() {
        if (Started && (croissantIndex <= Croissants.Length)) {

            if (RollingProgressSlider.value >= 1f) {
                fuckUp();
                //stopRolling();
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                doGood();
                stopRolling();
            }

            Croissants[croissantIndex].GetComponent<CroissantRollingAnimation>().Animate(RollingProgressSlider.value);
            updateProgressSlider();
        }
    }

    public void StartMinigame() {
        StartButton.SetActive(false);
        Started = true;
    }

    public void HideStartButton() {
        StartButton.SetActive(false);
    }

    private void updateProgressSlider() {
        RollingProgressSlider.value += rollingRate;
    }

    private void changeRollingRate() {
        rollingRate = UnityEngine.Random.Range(minRollingRate, maxRollingRate);
    }

    private void fuckUp() {
        Debug.Log("Fucked up");
        ReactionProfile.instance.QueueReaction(new ReactionCommand(ReactionProfile.instance.angrySprite));
        // AudioManager.instance.PlaySound(badReact, 100f);
        MinigameFramework.instance.PlayFailSound();
        rollingResults[croissantIndex] = 0f;
        Croissants[croissantIndex].GetComponent<CroissantRollingAnimation>().FailCroissant();
        stopRolling();
    }

    private void doGood() {
        Debug.Log("Did good");
        ReactionProfile.instance.QueueReaction(new ReactionCommand(ReactionProfile.instance.successSprite));
        // AudioManager.instance.PlaySound(goodReact, 100f);
        MinigameFramework.instance.PlaySuccessSound();
        rollingResults[croissantIndex] = RollingProgressSlider.value;
    }

    private void stopRolling() {
        Debug.Log("Stopping Rolling");
        RollingProgressSlider.value = 0f;
        changeRollingRate();

        croissantIndex++;
        if (croissantIndex > 5) {
            //TODO: Record score
            Debug.Log("GAME OVER FUCKIGN STOP");
            ReactionProfile.instance.QueueReaction(new ReactionCommand(ReactionProfile.instance.loveSprite));
            MinigameFramework.instance.PlayLoveSound();
            Minigame.instance.Finish();
            //Destroy(this);
            Started = false;
        }
    }
}

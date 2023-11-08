using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinigameFramework : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI TitleText;
    public GameObject InstructionsPanel;
    public TextMeshProUGUI InstructionTitleText;
    public TextMeshProUGUI InstructionInstructionText;

    [Header("Scoring")]
    public List<float> Scores = new List<float>();

    [Space(25)]
    public static MinigameFramework instance;



    //Defining as singleton
        //Call like this:
        //MinigameFramework.instance
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start() {
        ShowInstructions();
    }

    public void SetTitleText(string newText) {
        TitleText.text = newText;
        InstructionTitleText.text = newText;
    }

    public void SetInstructionText(string newText) {
        InstructionInstructionText.text = newText;
    }

    public void ShowInstructions() {
        InstructionsPanel.SetActive(true);
    }

    public void HideInstructions() {
        InstructionsPanel.SetActive(false);
    }
}

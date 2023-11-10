using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MinigameFramework : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI TitleText;
    public GameObject InstructionsPanel;
    public TextMeshProUGUI InstructionTitleText;
    public TextMeshProUGUI InstructionInstructionText;

    [Header("Scenes")]
    public string[] SceneNames;
    private int sceneIndex;

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
        LoadMinigame(0);
        ShowInstructions();
    }

    // Function to load a scene by index
    void LoadMinigame(int index) {
        // Check if the index is within the bounds of the array
        if (index >= 0 && index < SceneNames.Length) {
            // Load the scene by name
            SceneManager.LoadScene(SceneNames[index], LoadSceneMode.Additive);
        }
        else {
            Debug.LogError("Invalid scene index");
        }
    }

    [ContextMenu("LoadNextMinigameScene")]
    public void LoadNextMinigame() {
        SceneManager.UnloadSceneAsync(SceneNames[sceneIndex]);
        sceneIndex++;
        LoadMinigame(sceneIndex);
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

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
    public GameObject EndGamePanel;
    public TextMeshProUGUI InstructionTitleText;
    public TextMeshProUGUI InstructionInstructionText;

    [Header("Scenes")]
    public string[] SceneNames;
    private int sceneIndex;

    [Header("Minigame Sounds")]
    public AudioClip SuccessSound;
    public AudioClip FailSound;
    public AudioClip LoveSound;
    public AudioClip ButtonSound;

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

    public void PlayFailSound() {
        AudioManager.instance.PlaySound(FailSound, 100f);
    }
    public void PlaySuccessSound() {
        AudioManager.instance.PlaySound(SuccessSound, 100f);
    }
    public void PlayLoveSound() {
        AudioManager.instance.PlaySound(LoveSound, 100f);
    }
    public void PlayButtonSound() {
        AudioManager.instance.PlaySound(ButtonSound, 100f);
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
        EndGamePanel.SetActive(false);
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

    public void FinishMinigame() {
        EndGamePanel.SetActive(true);
    }
}

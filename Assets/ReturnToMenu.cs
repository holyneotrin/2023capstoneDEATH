using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public void LoadMenu() {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}

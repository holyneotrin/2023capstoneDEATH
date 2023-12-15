using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class LoadEndLandingPage : MonoBehaviour
{
    public void LoadEndScreen() {
        Debug.Log("Loading End Screen");
        SceneManager.LoadScene("EndGameLandingPage", LoadSceneMode.Single);
    }

}

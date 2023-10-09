using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        else if (CompareTag("Tomato"))
        {
            Debug.Log("Minus 10 points!");
        }
        else if (CompareTag("Banana"))
        {
            Debug.Log("Minus 10 points!");
        }
        else if (CompareTag("Carrot"))
        {
            Debug.Log("20 points!");
        }
    }
}

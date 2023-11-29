using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CroissantRollingAnimation : MonoBehaviour
{
    [SerializeField]
    private Sprite[] croissantRollingSprites;

    private Image croissantImage;


    void Start() {
        croissantImage = GetComponent<Image>();
        Animate(-1f);
    }

    public void Animate(float percentage) {
        croissantImage.color = Color.white;

        if (percentage > .8f) {
            croissantImage.sprite = croissantRollingSprites[4];
        } else if (percentage > .6f) {
            croissantImage.sprite = croissantRollingSprites[3];
        } else if (percentage > .4f) {
            croissantImage.sprite = croissantRollingSprites[2];
        } else if (percentage > .2f) {
            croissantImage.sprite = croissantRollingSprites[1];
        } else if (percentage > 0f) {
            croissantImage.sprite = croissantRollingSprites[0];
        } else {
            croissantImage.sprite = null;
            croissantImage.color = new Color(0,0,0,0);
        }
    }

    public void FailCroissant() {
        croissantImage.color = Color.red;
    }
}

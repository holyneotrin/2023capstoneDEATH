using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MinigameFramework.instance.PlayLoveSound();
        InvokeRepeating("Yippee", 0f, 2f);
    }

    void Yippee() {
        ReactionProfile.instance.QueueReaction(new ReactionCommand(ReactionProfile.instance.loveSprite, 10f));   
    }
}

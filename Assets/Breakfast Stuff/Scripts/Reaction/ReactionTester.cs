using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionTester : MonoBehaviour
{
    [Header("Reaction GameObject to Test")]
    public GameObject reactionGameObject;

    private ReactionProfile reactionProfile;


    void Start() {
        reactionProfile = reactionGameObject.GetComponent<ReactionProfile>();
    }

    void Update() {
        // Check for key presses to trigger reactions
        if (Input.GetKeyDown(KeyCode.C)) {
            // Queue the "sad" reaction for 3 seconds
            ReactionCommand reactionCommand = new ReactionCommand(reactionProfile.happySprite, 1f);
            reactionProfile.QueueReaction(reactionCommand);
        } 
        if (Input.GetKeyDown(KeyCode.X)) {
            // Queue the "happy" reaction for 3 seconds
            ReactionCommand reactionCommand = new ReactionCommand(reactionProfile.sadSprite, 2f);
            reactionProfile.QueueReaction(reactionCommand);
        }
    }
}

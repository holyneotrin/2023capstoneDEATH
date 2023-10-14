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
        if (Input.GetKeyDown(KeyCode.V)) {
            // Queue the "happy" reaction for 1 seconds
            ReactionCommand reactionCommand = new ReactionCommand(reactionProfile.loveSprite, 1f);
            reactionProfile.QueueReaction(reactionCommand);
            Debug.Log("Queueing 'Love' for 1 Second");
        } 
        if (Input.GetKeyDown(KeyCode.X)) {
            // Queue the "sad" reaction for 3 seconds
            ReactionCommand reactionCommand = new ReactionCommand(reactionProfile.angrySprite, 1f);
            reactionProfile.QueueReaction(reactionCommand);
            Debug.Log("Queueing 'Angry' for 3 Seconds");
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            // Queue the "sad" reaction for 3 seconds
            ReactionCommand reactionCommand = new ReactionCommand(reactionProfile.successSprite, 1f);
            reactionProfile.QueueReaction(reactionCommand);
            Debug.Log("Queueing 'Success' for 3 Seconds");
        }
        if (Input.GetKeyDown(KeyCode.Z)) {
            // Queue the "sad" reaction for 3 seconds
            ReactionCommand reactionCommand = new ReactionCommand(reactionProfile.failSprite, 1f);
            reactionProfile.QueueReaction(reactionCommand);
            Debug.Log("Queueing 'Fail' for 3 Seconds");
        }
    }
}

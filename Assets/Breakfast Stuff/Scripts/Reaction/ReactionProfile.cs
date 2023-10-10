using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionProfile : MonoBehaviour
{
    [Header("Sprite References")]
    public Sprite defaultSprite;
    public Sprite happySprite;
    public Sprite sadSprite;

    private List<ReactionCommand> reactionCommandList = new List<ReactionCommand>();
    private Image reactionImage; //This is the actual image of the npc
    private SpriteSquish spriteSquish;

    //-------------------------------------------------------------------------------

    void Start() { 
        //Setup the reactionImage component
        reactionImage = GetComponent<Image>();
        reactionImage.sprite = defaultSprite;
        
        //Setup sprite squishing
        spriteSquish = GetComponent<SpriteSquish>();
    }

    void Update() {
        // Check if there are commands in the list.
        if (reactionCommandList.Count > 0) {
            ReactionCommand currentCommand = reactionCommandList[0]; // Get the first command in the list.

            // Show the reaction + countdown the duration.
            currentCommand.Duration -= Time.deltaTime;
            ShowReaction(currentCommand.ReactionSprite);

            // If the duration <= 0, remove the command from the list.
            if (currentCommand.Duration <= 0f) {
                reactionCommandList.RemoveAt(0); //Remove the first command.

                //For testing do a bounce
                StartCoroutine(spriteSquish.Bounce());
            }
        } else {
            // Otherwise, show default.
            ShowReaction(defaultSprite);
        }
    }

    //-------------------------------------------------------------------------------

    public void QueueReaction(ReactionCommand reactionCommand) { 
        //Add the reaction command to the list.
        reactionCommandList.Add(reactionCommand); 
    }

    private void ShowReaction(Sprite reactionSprite) { 
        if (reactionImage != null && reactionSprite != null) { 
            //Set the reaction image sprite. 
            reactionImage.sprite = reactionSprite;
        } 
    }
}
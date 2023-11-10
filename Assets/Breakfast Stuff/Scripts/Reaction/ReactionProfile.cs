using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionProfile : MonoBehaviour
{
    [Header("Sprite References")]
    public Sprite defaultSprite;
    public Sprite failSprite;
    public Sprite angrySprite;
    public Sprite loveSprite;
    public Sprite successSprite;
    public static ReactionProfile instance;

    private List<ReactionCommand> reactionCommandList = new List<ReactionCommand>();
    private Image reactionImage; //This is the actual image of the npc
    private SpriteSquish spriteSquish;

    //-------------------------------------------------------------------------------

    //Defining as singleton
        //Call like this:
        //ReactionProfile.instance.QueueReactions();
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

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

                //if not empty then bounce
                if (reactionCommandList.Count != 0) {
                    StartCoroutine(spriteSquish.Bounce());
                }       
            }
        } else {
            // Otherwise, show default.
            ShowReaction(defaultSprite);
        }
    }

    //-------------------------------------------------------------------------------

    public void QueueReaction(ReactionCommand reactionCommand) { 
        //If command queue is empty sprite bounce
        if (reactionCommandList.Count == 0) {
            StartCoroutine(spriteSquish.Bounce());
        }

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
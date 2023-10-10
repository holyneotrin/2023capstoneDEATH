using UnityEngine;

[System.Serializable]
public class ReactionCommand
{
    public Sprite ReactionSprite { get; }
    public float Duration { get; set; }

    private const float defaultDuration = 2f; 

    public ReactionCommand(Sprite sprite, float duration) {
        ReactionSprite = sprite;
        Duration = duration;
    }

    //Default duration constructor
    public ReactionCommand(Sprite sprite) {
        ReactionSprite = sprite;
        Duration = defaultDuration;
    }
}

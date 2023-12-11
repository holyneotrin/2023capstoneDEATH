using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IngredientsManager : MonoBehaviour
{
    public Text flour;
    public Text sugar;
    public Text yeast;
    public Text salt;
    public Text butter;
    public Text milk;
    
    
    // Start is called before the first frame update
    void Start()
    {
        flour.text = "Flour";
        sugar.text = "Sugar";
        yeast.text = "Yeast";
        salt.text = "Salt";
        butter.text = "Butter";
        milk.text = "Milk";
    }

    // Update is called once per frame
    void Update()
    {
        ReactionProfile.instance.QueueReaction(new ReactionCommand(ReactionProfile.instance.successSprite));
    }

    public void MakeDoneText(Text element)
    {
        element.text = "";
    } 
}

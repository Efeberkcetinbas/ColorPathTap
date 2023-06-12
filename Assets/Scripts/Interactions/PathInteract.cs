using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathInteract : Interactable
{   
    [SerializeField] private int colorIndex;


    public PathInteract()
    {
        canStay=false;
    }

    internal override void DoAction(PlayerTrigger player)
    {
        if(colorIndex==player.playerColorIndex)
        {
            player.transform.parent=this.transform;
            Debug.Log("+1 Score");
        }
        else
        {
            Debug.Log("GAME OVER");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathInteract : Interactable
{   
    [SerializeField] private int colorIndex;

    public PlayerData playerData;
    public PathInteract()
    {
        canStay=false;
    }

    internal override void DoAction(PlayerTrigger player)
    {
        if(colorIndex==player.playerColorIndex)
        {
            player.transform.parent=this.transform;
            EventManager.Broadcast(GameEvent.OnIncreaseScore);
            Debug.Log("+1 Score");
        }
        else
        {
            //playerData.playerCanMove=false;
            Debug.Log("GAME OVER");
        }
    }
}

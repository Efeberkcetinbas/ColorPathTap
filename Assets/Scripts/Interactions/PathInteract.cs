using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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
            player.transform.DOLocalMove(Vector3.zero,0.1f);
            //player.transform.localPosition=Vector3.zero;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : Interactable
{
    public Finish()
    {
        canStay=false;
    }

    internal override void DoAction(PlayerTrigger player)
    {
        EventManager.Broadcast(GameEvent.OnSuccess);
    }
}

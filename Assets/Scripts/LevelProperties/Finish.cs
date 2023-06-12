using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : Interactable
{
    public GameData gameData;
    public Finish()
    {
        canStay=false;
    }

    internal override void DoAction(PlayerTrigger player)
    {
        gameData.isGameEnd=true;
        EventManager.Broadcast(GameEvent.OnSuccess);
    }
}

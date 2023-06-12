using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{

    private Vector3 firstPosition;
    private Vector3 lastPosition;

    public PlayerData playerData;

    private void Update() 
    {   
        if(playerData.playerCanMove)
            CheckMove();        
    }

    private void CheckMove()
    {
        if(Input.touchCount>0)
        {
            Touch touch=Input.GetTouch(0);
            if(touch.phase==TouchPhase.Began)
            {
                firstPosition=touch.position;
                lastPosition=touch.position;
                transform.DOJump(new Vector3(transform.position.x,transform.position.y+1,transform.position.z+1),2,1,0.2f);
                //transform.DOMove(new Vector3(transform.position.x,transform.position.y+1,transform.position.z+1),0.1f);
                //EventManager.Broadcast(GameEvent.OnPlayerTakeStep);
            }

            else if(touch.phase==TouchPhase.Moved)
            {
                lastPosition=touch.position;
            }

            else if(touch.phase==TouchPhase.Ended)
            {
                lastPosition=touch.position;
            }
        }
    }



   

    
}

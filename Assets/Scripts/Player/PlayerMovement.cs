using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{

    private Vector3 firstPosition;
    private Vector3 lastPosition;

    private void Update() 
    {
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
                transform.DOMoveZ(transform.position.z+1,0.1f);
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

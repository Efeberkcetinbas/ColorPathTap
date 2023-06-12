using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMovement : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameData gameData;

    [SerializeField] private int x;
    public float speed = 1.0f;

    [SerializeField] private bool canMove=false;
    private void Update() 
    {
        if(!gameData.isGameEnd && canMove)
            MoveBetweenPoints();
        
    }

    

    private void MoveBetweenPoints()
    {
        for (int i = 0; i < gameManager.PathGameObjects.Count; i++)
        {
            float y=gameManager.PathGameObjects[i].transform.position.y;
            float z=gameManager.PathGameObjects[i].transform.position.z;
            if(i%2==0)
            {
                gameManager.PathGameObjects[i].transform.position = Vector3.Lerp (new Vector3(-x,y,z), new Vector3(x,y,z), (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
            }
            else
            {
                gameManager.PathGameObjects[i].transform.position = Vector3.Lerp (new Vector3(x,y,z), new Vector3(-x,y,z), (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
            }
        }
        
    }
}

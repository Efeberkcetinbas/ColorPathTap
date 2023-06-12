using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public bool onePath,fivePath,tenPath;

    public GameObject onePathGameObject,fivePathGameObject,tenPathGameObject;

    public GameManager gameManager;

    public int x;

    private void OnEnable() 
    {
        if(onePath) CreateOnePath();
        if(fivePath) CreateFivePath();
        if(tenPath) CreateTenPath();
    }

    private void CreateOnePath()
    {
        CreatePath(onePathGameObject);
    }

    private void CreateFivePath()
    {
        CreatePath(fivePathGameObject);
    }

    private void CreateTenPath()
    {
        CreatePath(tenPathGameObject);
    }

    private void CreatePath(GameObject gameObject)
    {
        for (int i = 1; i < x; i++)
        {
            GameObject paths=Instantiate(gameObject,new Vector3(0,i,i),Quaternion.identity);
            gameManager.PathGameObjects.Add(paths);
        }
    }

}

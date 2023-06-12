using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    
    public List<GameObject> levels;


    public GameData gameData;

    private void Start()
    {
        LoadLevel();
    }
    private void LoadLevel()
    {

        if (gameData.LevelIndex == levels.Count) gameData.LevelIndex = 0;

        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].SetActive(false);
        }
        levels[gameData.LevelIndex].SetActive(true);
    }

    public void LoadNextLevel()
    {
        gameData.LevelIndex++;
        gameData.tempLevelIndex++;
        EventManager.Broadcast(GameEvent.OnNextLevel);
        LoadLevel();
    }

    public void RestartLevel()
    {
        LoadLevel();
    }

    
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public PlayerData playerData;
    public PathData pathData;

    [SerializeField] private GameObject FailPanel;
    [SerializeField] private Ease ease;



    private void Awake() 
    {
        ClearData();
    }

    

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnIncreaseScore, OnIncreaseScore);
        EventManager.AddHandler(GameEvent.OnNextLevel,OnNextLevel);
        EventManager.AddHandler(GameEvent.OnPlayerTakeStep,OnPlayerTakeStep);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnIncreaseScore, OnIncreaseScore);
        EventManager.RemoveHandler(GameEvent.OnNextLevel,OnNextLevel);
        EventManager.RemoveHandler(GameEvent.OnPlayerTakeStep,OnPlayerTakeStep);
    }
    
    void OnGameOver()
    {
        FailPanel.SetActive(true);
        FailPanel.transform.DOScale(Vector3.one,1f).SetEase(ease);
        playerData.playerCanMove=false;
        gameData.isGameEnd=true;

    }
    

    void OnIncreaseScore()
    {
        //gameData.score += 50;
        DOTween.To(GetScore,ChangeScore,gameData.score+gameData.increaseScore,0.25f).OnUpdate(UpdateUI);
    }

    private int GetScore()
    {
        return gameData.score;
    }

    private void ChangeScore(int value)
    {
        gameData.score=value;
    }

    private void UpdateUI()
    {
        EventManager.Broadcast(GameEvent.OnScoreUIUpdate);
    }

    
    //Fade olup acilista cagirilacak
    private void OnNextLevel()
    {
        EventManager.Broadcast(GameEvent.OnUIUpdateLevelText);
        EventManager.Broadcast(GameEvent.OnUIUpdateProgressBar);
    }

    private void OnPlayerTakeStep()
    {
        pathData.tempPathNumber++;
        EventManager.Broadcast(GameEvent.OnUIUpdateProgressBar);
    }
    
    void ClearData()
    {
       
    }

    
}

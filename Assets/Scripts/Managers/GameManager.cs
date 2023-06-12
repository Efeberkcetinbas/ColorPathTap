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

    public List<GameObject> PathGameObjects=new List<GameObject>();

    [SerializeField] private Transform player;


    private void Awake() 
    {
        ClearData();
    }
    

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnIncreaseScore, OnIncreaseScore);
        EventManager.AddHandler(GameEvent.OnNextLevel,OnNextLevel);
        EventManager.AddHandler(GameEvent.OnPlayerTakeStep,OnPlayerTakeStep);
        EventManager.AddHandler(GameEvent.OnSuccess,OnSuccess);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnIncreaseScore, OnIncreaseScore);
        EventManager.RemoveHandler(GameEvent.OnNextLevel,OnNextLevel);
        EventManager.RemoveHandler(GameEvent.OnPlayerTakeStep,OnPlayerTakeStep);
        EventManager.RemoveHandler(GameEvent.OnSuccess,OnSuccess);
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
    
    private IEnumerator ClearList()
    {
        player.SetParent(null);
        for (int i = 0; i < PathGameObjects.Count; i++)
        {
            Destroy(PathGameObjects[i]);
        }

        yield return new WaitForSeconds(1);
        PathGameObjects.Clear();
    }

    private void OnSuccess()
    {
        StartCoroutine(ClearList());
    }

    private void ClearData()
    {

    }

    

    
}

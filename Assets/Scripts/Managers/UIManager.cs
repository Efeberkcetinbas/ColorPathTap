using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI score,highscore,endingScore;
    public TextMeshProUGUI fromLevelText,toLevelText;

    public Image progressBar;

    public GameData gameData;
    public PlayerData playerData;
    public PathData pathData;

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnUIUpdate, OnUIUpdate);
        EventManager.AddHandler(GameEvent.OnUIUpdateLevelText,OnUIUpdateLevelText);
        EventManager.AddHandler(GameEvent.OnUIUpdateProgressBar,OnUIUpdateProgressBar);
    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnUIUpdate, OnUIUpdate);
        EventManager.RemoveHandler(GameEvent.OnUIUpdateLevelText,OnUIUpdateLevelText);
        EventManager.RemoveHandler(GameEvent.OnUIUpdateProgressBar,OnUIUpdateProgressBar);
    }

    
    void OnUIUpdate()
    {
        score.SetText(gameData.score.ToString());
        score.transform.DOScale(new Vector3(1.5f,1.5f,1.5f),0.2f).OnComplete(()=>score.transform.DOScale(new Vector3(1,1f,1f),0.2f));
    }

    void OnUIUpdateLevelText()
    {
        fromLevelText.SetText((gameData.tempLevelIndex+1).ToString());
        toLevelText.SetText((gameData.tempLevelIndex+2).ToString());
    }

    void OnUIUpdateProgressBar()
    {
        float amount=(float)pathData.tempPathNumber/(float)(pathData.pathNumber);
        progressBar.DOFillAmount(amount,0.2f);
    }

    
}

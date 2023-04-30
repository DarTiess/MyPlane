using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using GameEvents;
using UnityEngine.UI;


public class CanvasController : MonoBehaviour
{
   
    [SerializeField] private CanvasGroup startGroupe;
    [SerializeField] private CanvasGroup playGroupe;
    [SerializeField] private CanvasGroup failGroupe;
    [SerializeField] private CanvasGroup headerGroupe;
    [SerializeField] private TextMeshProUGUI countLifes;
    [SerializeField] private int lifesOnStart = 12;
    [SerializeField] private Button startButton;

    private List<CanvasGroup> canvasGroupes = new List<CanvasGroup>();
    private IGameEvents gameEvents;
    
    public int _Lifes
    {
        get { return PlayerPrefs.GetInt("Lifes"); }
        set { PlayerPrefs.SetInt("Lifes", value); }
    }

    public void Init(IGameEvents gameEvents)
   {
       this.gameEvents = gameEvents;
        countLifes.text = lifesOnStart.ToString();
        if (_Lifes <= 0)
        {
            _Lifes = lifesOnStart;
        }
        else
        {
            lifesOnStart = _Lifes;
        }
        countLifes.text = lifesOnStart.ToString();
     
        canvasGroupes.Add(startGroupe);
        canvasGroupes.Add(playGroupe);
        canvasGroupes.Add(failGroupe);
       gameEvents.IsStarting += OnStart;
       gameEvents.IsFail += OnFail;
       startButton.onClick.AddListener(OnGame);
      
    }

   private void OnStart()
    {
        headerGroupe.alpha = 1;
        headerGroupe.interactable = true;
        headerGroupe.blocksRaycasts = true;
      
        ActivateUIScreen(startGroupe);
    }
   private void OnGame()
    {
        gameEvents.PlayGame();
        ActivateUIScreen(playGroupe);
    }
    void OnFail()
    {
        ActivateUIScreen(failGroupe);
    }
    public void DisplayDamage()
    {
        if (lifesOnStart <= 0)
        {
            return;
        }
       lifesOnStart-=1;
        _Lifes = lifesOnStart;
        countLifes.text = lifesOnStart.ToString();
        countLifes.transform.DOScale(1.5f, 0.5f)
            .OnComplete(() => {
                countLifes.transform.DOScale(1f, 0.5f);
            });
        if (lifesOnStart <= 0)
        {
          //  gameEvents.FailGame();
        }
    }

    void ActivateUIScreen(CanvasGroup uiScreen)
    {
        foreach (CanvasGroup cGr in canvasGroupes)
        {
            if (cGr != uiScreen)
            {
                cGr.alpha = 0;
                cGr.interactable = false;
                cGr.blocksRaycasts = false;
            }
            else
            {
                cGr.alpha =1;
                cGr.interactable = true;
                cGr.blocksRaycasts =true;
            }
        }
    }
}

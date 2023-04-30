using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using GameEvents;
using UI;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class UIController : MonoBehaviour
{
    [SerializeField] private CanvasGroup startGroupe;
    [SerializeField] private CanvasGroup playGroupe;
    [SerializeField] private CanvasGroup failGroupe;
    [SerializeField] private CanvasGroup headerGroupe;
   
    [SerializeField] private Button startButton;
    [SerializeField] private Button restartButton;

    private readonly List<CanvasGroup> canvasGroupes = new List<CanvasGroup>();
    private IGameState gameState;
    private Health health;

    public void Init(IGameEvents gameEvents, IGameState gameStates)
   {
       gameState = gameStates;
       health = GetComponent<Health>();
        health.SetLifesCount(gameEvents, gameStates);
        CreateCanvasList();
        
       gameEvents.Starting += OnStart;
       gameEvents.Fail += OnFail;
       startButton.onClick.AddListener(OnGame);
       restartButton.onClick.AddListener(OnRestartGame);
   }

    private void OnRestartGame()
    {
        gameState.RestartGame();
    }

    private void CreateCanvasList()
    {
        canvasGroupes.Add(startGroupe);
        canvasGroupes.Add(playGroupe);
        canvasGroupes.Add(failGroupe);
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
        gameState.PlayGame();
        ActivateUIScreen(playGroupe);
    }
    private void OnFail()
    {
        ActivateUIScreen(failGroupe);
    }
    private void ActivateUIScreen(CanvasGroup uiScreen)
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

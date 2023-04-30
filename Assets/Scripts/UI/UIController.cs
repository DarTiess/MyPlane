using System.Collections.Generic;
using Data;
using GameEvents;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Health))]
    public class UIController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup startGroupe;
        [SerializeField] private CanvasGroup playGroupe;
        [SerializeField] private CanvasGroup pauseGroupe;
        [SerializeField] private CanvasGroup failGroupe;
        [SerializeField] private CanvasGroup headerGroupe;
        [SerializeField] private Button startButton;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button continueButton;
        [SerializeField] private Button exitButton;

        private readonly List<CanvasGroup> canvasGroupes = new List<CanvasGroup>();
        private IGameState gameState;
        private Health health;

        public void Init(IGameEvents gameEvents, IGameState gameStates, IDataSaver dataserver)
        {
            gameState = gameStates;
            health = GetComponent<Health>();
            health.Init(gameEvents, gameStates, dataserver);
            CreateCanvasList();
        
            gameEvents.Starting += OnStart;
            gameEvents.Fail += OnFail;
            InitButtons();
        }

        private void InitButtons()
        {
            startButton.onClick.AddListener(OnGame);
            restartButton.onClick.AddListener(OnRestartGame);
            pauseButton.onClick.AddListener(OnPausedGame);
            continueButton.onClick.AddListener(OnGame);
            exitButton.onClick.AddListener(ExitGame);
        }

        private void ExitGame()
        {
            gameState.QuiteGame();
        }

        private void OnPausedGame()
        {
            gameState.PauseGame();
            ActivateUIScreen(pauseGroupe);
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
            canvasGroupes.Add(pauseGroupe);
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
}

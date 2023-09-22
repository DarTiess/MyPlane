using System;
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
        [SerializeField] private CanvasGroup _startGroupe;
        [SerializeField] private CanvasGroup _playGroupe;
        [SerializeField] private CanvasGroup _pauseGroupe;
        [SerializeField] private CanvasGroup _failGroupe;
        [SerializeField] private CanvasGroup _headerGroupe;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _exitButton;

        private readonly List<CanvasGroup> _canvasGroupes = new List<CanvasGroup>();
        private IGameState _gameState;
        private Health _health;
        private IChangeLifes _lifeData;
        private IGameEvents _gameEvents;


        public void Init(IGameEvents gameEvents, IGameState gameStates, IChangeLifes lifeData)
        {
            _lifeData = lifeData;
            _lifeData.ChangeLifes += OnDisplayDamage;
            
            _gameState = gameStates;
            _health = GetComponent<Health>();
            _health.Init(_lifeData.GetLifesCount());
            CreateCanvasList();

            _gameEvents = gameEvents;
            _gameEvents.Starting += OnStart;
            _gameEvents.Fail += OnFail;
            InitButtons();
        }

        private void OnDisable()
        {
            _gameEvents.Starting -= OnStart;
            _gameEvents.Fail -= OnFail;
        }

        private void OnDisplayDamage(int value)
        {
            _health.DisplayDamage(value);
        }

        private void InitButtons()
        {
            _startButton.onClick.AddListener(OnGame);
            _restartButton.onClick.AddListener(OnRestartGame);
            _pauseButton.onClick.AddListener(OnPausedGame);
            _continueButton.onClick.AddListener(OnGame);
            _exitButton.onClick.AddListener(ExitGame);
        }

        private void ExitGame()
        {
            _gameState.OnQuiteGame();
        }

        private void OnPausedGame()
        {
            _gameState.OnPauseGame();
            ActivateUIScreen(_pauseGroupe);
        }

        private void OnRestartGame()
        {
            _gameState.OnRestartGame();
        }
        private void CreateCanvasList()
        {
            _canvasGroupes.Add(_startGroupe);
            _canvasGroupes.Add(_playGroupe);
            _canvasGroupes.Add(_failGroupe);
            _canvasGroupes.Add(_pauseGroupe);
        }
        private void OnStart()
        {
            _headerGroupe.alpha = 1;
            _headerGroupe.interactable = true;
            _headerGroupe.blocksRaycasts = true;
      
            ActivateUIScreen(_startGroupe);
        }
        private void OnGame()
        {
            _gameState.OnPlayGame();
            ActivateUIScreen(_playGroupe);
        }
        private void OnFail()
        {
            ActivateUIScreen(_failGroupe);
        }
        private void ActivateUIScreen(CanvasGroup uiScreen)
        {
            foreach (CanvasGroup cGr in _canvasGroupes)
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

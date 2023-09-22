using System;
using Data;
using Infrastructure;
using UnityEngine;

namespace GameEvents
{
    public class GameStateEvents : IGameEvents, IGameState
    {
        private SceneLoader _sceneLoader;
        private IGameOver _gameOver;

        public event Action Starting;
        public event Action Gaming;
        public event Action Pause;
        public event Action Fail;

        public void Init(SceneLoader loader, IGameOver gameOver)
        {
            _sceneLoader = loader;
            _gameOver = gameOver;
            _gameOver.PlayerDied += OnFailGame;
        }
        public void OnStartGame()
        {
            Starting?.Invoke();
        }
        public void OnPlayGame()
        {
            Gaming?.Invoke();
        }
        private void OnFailGame()
        {
            Fail?.Invoke();
        }
        public void OnPauseGame()
        {
            Pause?.Invoke();
        }
        public void OnRestartGame()
        {
            _sceneLoader.RestartScene();
        }

        public void OnQuiteGame()
        {
            Application.Quit();
        }
    }
    
}

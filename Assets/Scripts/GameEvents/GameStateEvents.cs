using System;
using Infrastructure;
using UnityEngine;

namespace GameEvents
{
    public class GameStateEvents : IGameEvents, IGameState
    {
        public event Action Starting;
        public event Action Gaming;
        public event Action Pause;
        public event Action Fail;
        public event Action TakeDamage;

        private SceneLoader sceneLoader;
        public void Init(SceneLoader loader)
        {
            sceneLoader = loader;
        }
        public void StartGame()
        {
            Starting?.Invoke();
        }
        public void PlayGame()
        {
            Gaming?.Invoke();
        }
        public void FailGame()
        {
            Fail?.Invoke();
        }
        void IGameState.TakeDamage()
        {
            TakeDamage?.Invoke();
        }

        public void PauseGame()
        {
            Pause?.Invoke();
        }
        public void RestartGame()
        {
            sceneLoader.RestartScene();
        }
        public void NextLevel()
        {
             sceneLoader.LoadNextLevel();
        }

        public void QuiteGame()
        {
            Application.Quit();
        }
    }
    
}

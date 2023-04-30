using System;
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
           // Time.timeScale = 0;
            Starting?.Invoke();
        }

        public void PlayGame()
        {
           // Time.timeScale = 1;
            Gaming?.Invoke();
        }
 
        public void FailGame()
        {
            Fail?.Invoke();
           // Time.timeScale = 0;

        }

        void IGameState.TakeDamage()
        {
            TakeDamage?.Invoke();
        }

        public void PauseGame()
        {
            Pause?.Invoke();
            Time.timeScale =0;
        }
        public void RestartGame()
        {
            sceneLoader.RestartScene();

        }
        public void NextLevel()
        {
             sceneLoader.LoadNextLevel();
        }
   
        public void ClearSaves()
        {
            PlayerPrefs.DeleteAll();
        }

        public void QuiteGame()
        {
            Application.Quit();
        }
  

    }
    
}

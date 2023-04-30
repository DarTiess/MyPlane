using System;
using UnityEngine;

namespace GameEvents
{
    public class GameEvents : IGameEvents
    {
        public event Action IsStarting;
        public event Action IsGaming;
        public event Action OnPause;
        public event Action IsFail;
        public event Action IsWin;
  
  
        public void StartGame()
        {
            Time.timeScale = 0;
            IsStarting?.Invoke();
        }

        public void PlayGame()
        {
            Time.timeScale = 1;
            IsGaming?.Invoke();
        }
 
        public void FailGame()
        {
            IsFail?.Invoke();
            Time.timeScale = 0;

        }
        public void WinGame()
        {
            IsWin?.Invoke();
            Time.timeScale = 0;
        }
        public void PauseGame()
        {
            OnPause?.Invoke();
            Time.timeScale =0;
        }
        public void RestartGame()
        {
            //levelsManager.RestartScene();

        }
        public void NextLevel()
        {
            // levelsManager.LoadNextLevel();
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

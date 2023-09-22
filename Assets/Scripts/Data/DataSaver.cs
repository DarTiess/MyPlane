using System;
using Configs;
using Player;
using UnityEngine;

namespace Data
{
    public class DataSaver : IChangeLifes, IChangeScene, IGameOver
    {
        private const string LIFES = "Lifes";
        private const string CURRENTSCENE = "CurrentScene";
        private int _lifes;
        private int _currentScene;

        public event Action<int> ChangeLifes;
        public event  Action PlayerDied;

        public DataSaver(PlayerConfigs playerConfig)
        {
            _lifes = PlayerPrefs.GetInt(LIFES);
            if (_lifes <= 0)
            {
                _lifes = playerConfig.Lifes;
                SetLifesParametr();
            }
            _currentScene=PlayerPrefs.GetInt(CURRENTSCENE);
        }

        private void SetLifesParametr()
        {
            PlayerPrefs.SetInt(LIFES, _lifes);
            ChangeLifes?.Invoke(_lifes);
        }

        public int GetLifesCount()
       {
           return _lifes;
       }

        public void ChangeLifeCount()
        {
            if (_lifes <= 0)
            {
                return;
            }
            _lifes -= 1;
            if (_lifes == 0)
            {
                PlayerDied?.Invoke();
            }
            SetLifesParametr();
        }

        public void ChangeCurrentScene(int value)
        {
            _currentScene =value;
            PlayerPrefs.SetInt(CURRENTSCENE, _currentScene); 
        }

        public int GetCurrentScene()
        {
            return _currentScene;
        }
    }
}
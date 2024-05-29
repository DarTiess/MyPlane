using System;
using Infrastructure.Level.EventsBus;
using Infrastructure.Level.EventsBus.Signals;
using UnityEngine;

namespace Data
{
    public class DataSaver 
    {
        private const string LIFES = "Lifes";
        private const string CURRENTSCENE = "CurrentScene";
        private int _lifes;
        private int _currentScene;
        private readonly IEventBus _event;

        public int Lifes => _lifes;
        public event Action<int> ChangeLifes;
        public event  Action PlayerDied;


        public DataSaver(PlayerSettings playerConfig, IEventBus events)
        {
            _event=events;
            _event.Subscribe<LevelWin>(OnLevelWin);
            _event.Subscribe<PlayerDamage>(OnDamagePlayer);
            _lifes = PlayerPrefs.GetInt(LIFES);
            if (_lifes <= 0)
            {
                _lifes = playerConfig.Lifes;
                SetLifesParametr();
            }
            _currentScene=PlayerPrefs.GetInt(CURRENTSCENE);
        }

        private void OnDamagePlayer(PlayerDamage obj)
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

        private void OnLevelWin(LevelWin obj)
        {
            _currentScene += 1;
            PlayerPrefs.SetInt(CURRENTSCENE, _currentScene); 
        }

        private void SetLifesParametr()
        {
            PlayerPrefs.SetInt(LIFES, _lifes);
            ChangeLifes?.Invoke(_lifes);
        }
    }
}
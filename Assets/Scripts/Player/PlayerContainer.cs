using System;
using Configs;
using Data;
using Enemy;
using GameEvents;
using Input;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerContainer : MonoBehaviour, IPlayerDamageable
    {
        [SerializeField] private ParticleSystem _boomEffect;
       
       
        private IGameEvents _gameEvents;
        private PlayerMovement _movement;
        private IChangeLifes _lifesData;

        public event Action TakeDamage;
        public void Init(IInputService inputService,IGameEvents gameEvents, PlayerConfigs configs, IChangeLifes lifesData)
        {
            _movement = GetComponent<PlayerMovement>();
            _movement.Init(inputService, configs);

            _lifesData = lifesData;
            if (_lifesData.GetLifesCount() <= 0)
            {
                _lifesData.ChangeLifeCount();
            }
            _gameEvents = gameEvents;
            
            _gameEvents.Gaming += OnPlayGame;
            _gameEvents.Pause += OnPausedGame;
        }

        private void OnDisable()
        {
            _gameEvents.Gaming -= OnPlayGame;
            _gameEvents.Pause -= OnPausedGame;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyContainer enemy))
            {
                _boomEffect.Play();
                TakeDamage?.Invoke();
               _lifesData.ChangeLifeCount();
            }
        }

        private void OnPausedGame()
        {
            _movement.OnPausedGame();
        }

        private void OnPlayGame()
        {
            _movement.OnPlayGame();
        }
    }
}
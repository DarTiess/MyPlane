using Configs;
using GameEvents;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyColor))]
    [RequireComponent(typeof(EnemyMovement))]
    public class EnemyContainer : MonoBehaviour
    {
        [SerializeField] private EnemyTrail _enemyTrail;
        
        private EnemyMovement _enemyMovement;
        private EnemyColor _enemyColor;
        private IGameEvents _gameEvents;
        private void OnDisable()
        {
            _gameEvents.Gaming -= PlayGame;
            _gameEvents.Fail -= StopGame;
            _gameEvents.Pause -= StopGame;
        }

        public void Init(IGameEvents gameEvents, Transform player, EnemySetting settings)
        {
            _gameEvents = gameEvents;
           
            _gameEvents.Gaming += PlayGame;
            _gameEvents.Fail += StopGame;
            _gameEvents.Pause += StopGame;
           
            _enemyMovement = GetComponent<EnemyMovement>();
            _enemyMovement.Init(player, settings.Delay);
           
            _enemyColor = GetComponent<EnemyColor>();
            _enemyColor.SetEnemyColor(settings.Color);
         
            _enemyTrail.SetTrailsSettings(settings.Color);
        }

        private void PlayGame()
        {
            _enemyMovement.PlayGame();
        }
        private void StopGame()
        {
            _enemyMovement.StopGame();
        }
    }
}

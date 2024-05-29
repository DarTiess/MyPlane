using Infrastructure.Level.EventsBus;
using Infrastructure.Level.EventsBus.Signals;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private TrailRenderer trailRenderer;
        private SpriteRenderer _renderer;
        private EnemyMovement _enemyMovement;
        private EnemyColor _enemyColor;
        private EnemyTrail _enemyTrail;
        private IEventBus _events;
        private bool _canMove;

        public void Init(IEventBus events, Transform player, ViewSettings settings)
        {
            _events=events;
           
            _events.Subscribe<PlayGame>(OnPlayGame);
           _events.Subscribe<LevelLost>(StopGame);
           _events.Subscribe<PauseGame>(PauseGame);

           _enemyMovement = new EnemyMovement(player, settings.Delay, transform);
            
            _renderer = GetComponent<SpriteRenderer>();
            _enemyColor = new EnemyColor(_renderer, settings.Color);
            
            _enemyTrail = new EnemyTrail(trailRenderer, settings.Color);
        }
        private void FixedUpdate()
        {
            if(_canMove)
                _enemyMovement.Move();
        }

        private void OnDestroy()
        {
            _events.Unsubscribe<PlayGame>(OnPlayGame);
            _events.Unsubscribe<LevelLost>(StopGame);
            _events.Unsubscribe<PauseGame>(PauseGame);
        }

        private void PauseGame(PauseGame obj)
        {
            StopGame();
        }

        private void StopGame(LevelLost obj)
        {
           StopGame();
        }

        private void StopGame()
        {
            _canMove = false;
            _enemyMovement.StopGame();
        }

        private void OnPlayGame(PlayGame obj)
        {
            _canMove = true;
            _enemyMovement.PlayGame();
        }
    }
}

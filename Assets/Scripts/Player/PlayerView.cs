using Enemy;
using Infrastructure.Level.EventsBus;
using Infrastructure.Level.EventsBus.Signals;
using Input;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : MonoBehaviour
    {
        [FormerlySerializedAs("_boomEffect")]
        [SerializeField] private ParticleSystem boomEffect;
        
        private Rigidbody2D _rigidBody;
        private PlayerMovement _movement;
        private IEventBus _events;
        private bool _canMove;

        public void Init(IInputService inputService, IEventBus eventBus,PlayerSettings configs)
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _movement = new PlayerMovement(inputService, configs, _rigidBody);
            
            _events = eventBus;
            _events.Subscribe<PlayGame>(OnPlayGame);
            _events.Subscribe<PauseGame>(OnPausedGame);
        }
        private void FixedUpdate()
        {
            if(_canMove)
                _movement.Move();
        }

        private void OnDestroy()
        {
            _events.Unsubscribe<PlayGame>(OnPlayGame);
            _events.Unsubscribe<PauseGame>(OnPausedGame);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyView enemy))
            {
                boomEffect.Play();
                _events.Invoke(new PlayerDamage());
            }
        }

        private void OnPausedGame(PauseGame obj)
        {
            _canMove = false;
        }

        private void OnPlayGame(PlayGame obj)
        {
            _canMove = true;
        }
    }
}
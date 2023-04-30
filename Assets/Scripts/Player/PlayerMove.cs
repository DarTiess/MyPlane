using GameEvents;
using Input;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float playerSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private ParticleSystem boomEffect;

        private IInputService inputService;
        private IGameState gameStates;
        private Rigidbody2D rigidBody;
        private Vector2 temp;

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate()
        {
            Move();
        }
        public void Init(IInputService _inputService, IGameState _gameStates)
        {
            inputService = _inputService;
            gameStates = _gameStates;
        }
        private void Move()
        {
            temp.x = inputService.GetHorizontal;
            temp.y = inputService.GetVertical;

            rigidBody.MovePosition(rigidBody.position + temp * (playerSpeed * Time.fixedDeltaTime) );
            if (temp != Vector2.zero)
            {
                RotatePlayer();
            }
        }
        private void RotatePlayer()
        {
            float angle = Mathf.Atan2(inputService.GetHorizontal, inputService.GetVertical) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f,-angle), Time.deltaTime * rotationSpeed);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                boomEffect.Play();
                gameStates.TakeDamage();
            }
        }
    }
}
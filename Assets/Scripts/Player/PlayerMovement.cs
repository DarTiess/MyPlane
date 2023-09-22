using Configs;
using Input;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private float _playerSpeed; 
        private float _rotationSpeed;
        private IInputService _inputService;
        private Rigidbody2D _rigidBody;
        private Vector2 _temp;
        private bool _canMove;
        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if(_canMove)
            {
                Move();
            }
        }

        public void Init(IInputService inputService, PlayerConfigs config)
        {
            _inputService = inputService;
            _playerSpeed = config.MoveSpeed;
            _rotationSpeed = config.RotationSpeed;
        }

        private void Move()
        {
            _temp.x = _inputService.GetHorizontal;
            _temp.y = _inputService.GetVertical;

            _rigidBody.MovePosition(_rigidBody.position + _temp * (_playerSpeed * Time.fixedDeltaTime) );
            if (_temp != Vector2.zero)
            {
                RotatePlayer();
            }
        }

        private void RotatePlayer()
        {
            float angle = Mathf.Atan2(_inputService.GetHorizontal, _inputService.GetVertical) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f,-angle), Time.deltaTime * _rotationSpeed);
        }

        public void OnPlayGame()
        {
            _canMove = true;
        }

        public void OnPausedGame()
        {
            _canMove = false;
        }
    }
}
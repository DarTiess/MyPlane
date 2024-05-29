using Input;
using UnityEngine;

namespace Player
{
    
    public class PlayerMovement
    {
        private float _playerSpeed; 
        private float _rotationSpeed;
        private IInputService _inputService;
        
        private Vector2 _temp;
        private Rigidbody2D _rigidBody;
        private readonly Transform _parent;


        public PlayerMovement(IInputService inputService, PlayerSettings config, Rigidbody2D rigidbody)
        {
            _inputService = inputService;
            _playerSpeed = config.MoveSpeed;
            _rotationSpeed = config.RotationSpeed;
            _rigidBody = rigidbody;
            _parent = _rigidBody.transform;
        }

        public void Move()
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
            _parent.rotation = Quaternion.Lerp(_parent.rotation, Quaternion.Euler(0f, 0f,-angle), Time.deltaTime * _rotationSpeed);
        }
    }
}
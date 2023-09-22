using DG.Tweening;
using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        private bool _canMove;
        private Vector3 _targetLastPos;
        private Tweener _tween;
        private Transform _player;
        private float _delay=1f;
        private void FixedUpdate()
        {
            if (_canMove)
            {
                Move();
            } 
        }

        public void Init(Transform player, float delay)
        {
            _delay = delay;
            _player = player;
        }
        private void Move()
        {
            if (_targetLastPos == _player.position) 
                return;

            _delay = Vector3.Distance(transform.position, _player.position);
            _tween.ChangeEndValue(_player.position, true).Restart();
            _targetLastPos = _player.position;
            RotateToPlayer();
        }
        private void RotateToPlayer()
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _player.transform.rotation, Time.fixedDeltaTime * 8f);
        }
        public void PlayGame()
        {
            _canMove = true;
            _tween.Play();
            _tween = transform.DOMove(_player.position,_delay/2).SetUpdate(UpdateType.Fixed).SetAutoKill(false);
       
            _targetLastPos = _player.position;
        }
        public void StopGame()
        {
            _canMove = false;
            _tween.Pause();
        }

    }
}
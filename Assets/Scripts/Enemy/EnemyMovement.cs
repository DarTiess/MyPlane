using DG.Tweening;
using UnityEngine;

namespace Enemy
{
    public class EnemyMovement 
    {
        private bool _canMove;
        private Vector3 _targetLastPos;
        private Tweener _tween;
        private Transform _player;
        private float _delay=1f;
        private Transform _parent;

        public EnemyMovement(Transform player, float delay, Transform parent)
        {
            _delay = delay;
            _player = player;
            _parent = parent;
        }
        public void Move()
        {
            if (_targetLastPos == _player.position) 
                return;

            _delay = Vector3.Distance(_parent.position, _player.position);
            _tween.ChangeEndValue(_player.position, true).Restart();
            _targetLastPos = _player.position;
            RotateToPlayer();
        }
        private void RotateToPlayer()
        {
            _parent.rotation = Quaternion.Lerp(_parent.rotation, _player.transform.rotation, Time.fixedDeltaTime * 8f);
        }
        public void PlayGame()
        {
            _canMove = true;
            _tween.Play();
            _tween = _parent.DOMove(_player.position,_delay/2).SetUpdate(UpdateType.Fixed).SetAutoKill(false);
       
            _targetLastPos = _player.position;
        }
        public void StopGame()
        {
            _canMove = false;
            _tween.Pause();
        }

    }
}
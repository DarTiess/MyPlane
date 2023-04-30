using Data;
using DG.Tweening;
using GameEvents;
using Player;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyColor))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private EnemyTrail enemyTrail;
        private Transform player;
        private float delay=1f;
        private Vector3 startPosition;
        private Vector3 endPosition;
        private bool canMove;
        private Vector3 targetLastPos;
        private Tweener tween;
        private EnemyColor enemyColor;

        private void FixedUpdate()
        {
            if (canMove)
            {
                Move();
            } 
        }

        public void Init(IGameEvents gameEvents, PlayerMove playerMove, EnemySetting settings)
        {
            gameEvents.Gaming += PlayGame;
            gameEvents.Fail += StopGame;
            enemyColor = GetComponent<EnemyColor>();
            
            
            enemyColor.SetEnemyColor(settings.color);
            enemyTrail.SetTrailsSettings(settings.color);

            delay = settings.delay;
            startPosition = transform.position;
            player = playerMove.transform;
        }

        private void Move()
        {
            if (targetLastPos == player.position) 
                return;

            delay = Vector3.Distance(transform.position, player.position);
            tween.ChangeEndValue(player.position, true).Restart();
            targetLastPos = player.position;
            RotateToPlayer();
        }


        private void RotateToPlayer()
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, Time.fixedDeltaTime * 8f);
        }

        private void PlayGame()
        {
            canMove = true;
            tween = transform.DOMove(player.position,delay/2).SetUpdate(UpdateType.Fixed).SetAutoKill(false);
       
            targetLastPos = player.position;
        }

        private void StopGame()
        {
            canMove = false;
        }


        public void RestartEnemy()
        {
            transform.SetPositionAndRotation(startPosition, Quaternion.Euler(Vector3.zero));

        }
  
    }
}

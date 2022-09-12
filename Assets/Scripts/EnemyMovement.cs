using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 startPosition;
    Vector3 endPosition;
    [SerializeField] float delay=1f;
    bool canMove;

  
    Vector3 targetLastPos;
    Tweener tween;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.IsGaming += PlayGame;
        startPosition = transform.position;
        if (player != null)
        {
            endPosition = player.position;
        }
        else
        {
            player = GameObject.Find("Player").transform;
        }
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            if (targetLastPos == player.position) return;

            delay = Vector3.Distance(transform.position, player.position);
            tween.ChangeEndValue(player.position, true).Restart();
            targetLastPos = player.position;
            RotateToPlayer();
        } 
    }

    void PlayGame()
    {
        canMove = true;
        tween = transform.DOMove(player.position,delay/2).SetAutoKill(false);
       
        targetLastPos = player.position;
    }
  
    public void RotateToPlayer()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, Time.fixedDeltaTime * 8f);
    }
   
  
    public void RestartEnemy()
    {
        transform.SetPositionAndRotation(startPosition, Quaternion.Euler(Vector3.zero));

    }
  
}

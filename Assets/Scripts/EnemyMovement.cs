using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 startPosition;
    Vector3 endPosition;
    [SerializeField] float delay=500f;
  
    
    // Start is called before the first frame update
    void Start()
    {
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
    void Update()
    {
        if (GameManager.Instance.statusOfGame == GameManager.GameStatus.isGaming)
        {
            FollowThePlayer();
        }
          
    }

    void FollowThePlayer()
    {
        transform.position = Vector3.Slerp(startPosition, endPosition, Time.time / delay);
        startPosition = transform.position;
        endPosition = player.position;
        RotateToPlayer();
    }
    public void RotateToPlayer()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, Time.deltaTime * 8f);
    }
   
  
    public void RestartEnemy()
    {
        transform.SetPositionAndRotation(startPosition, Quaternion.Euler(Vector3.zero));

    }
  
}

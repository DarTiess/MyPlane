using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rigidbody;
    [SerializeField] float moveSpeed=50f;
    [SerializeField] Transform player;
    Vector3 startPosition;
    Vector3 restartPosition;
    Vector3 endPosition;
    [SerializeField] float delay;
  

    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        restartPosition = transform.position;
        endPosition = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGaming)
        {
            transform.position = Vector3.Slerp(startPosition, endPosition, Time.time / delay);
            startPosition = transform.position;
            endPosition = player.position;
            RotateToPlayer();
        }
          
    }
    public void RotateToPlayer()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, Time.deltaTime * 8f);
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.isGaming)
            rigidbody.AddForce(new Vector2(0f, moveSpeed* Time.deltaTime));

       
    }
  
    public void ResrtartEnemy()
    {
        transform.SetPositionAndRotation(startPosition, Quaternion.Euler(Vector3.zero));

    }
  
}

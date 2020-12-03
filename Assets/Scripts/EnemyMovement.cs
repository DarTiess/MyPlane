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
    Vector3 endPosition;
    [SerializeField] float delay;
  

    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        endPosition = player.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position = Vector3.Slerp(startPosition, endPosition, Time.time/delay);
        startPosition = transform.position;
        endPosition = player.position;
        RotateToPlayer();
    }
    public void RotateToPlayer()
    {
        Vector3 fromDirection = startPosition;
        Vector3 toDirection = endPosition;
        Quaternion.FromToRotation( fromDirection, toDirection);
    }
    private void FixedUpdate()
    {
       
     rigidbody.AddForce(new Vector2(0f, moveSpeed* Time.deltaTime));
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
           // Invoke("GameOver", 2f);
        }
    }
    void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}

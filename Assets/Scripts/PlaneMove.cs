using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
  
   
    private Rigidbody2D rb;
    [SerializeField] private float forceFactor = 50f;
    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private ParticleSystem boomEffect;
    private Vector3 startPosition;
    [SerializeField] private float motionSpeed = 2f;
    [SerializeField] private float rotateSpeed = 8f;
    [SerializeField] private CanvasController canvas;
    bool canMove;
    private void Start()
    {
        GameManager.Instance.IsGaming += PlayGame;
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        
    } 
    private void FixedUpdate()
    {
        if (canMove)
        {
            FlyForward();
        }
    }
    void PlayGame()
    {
        canMove = true;
    }
    public void FlyForward()
    {
         rb.AddForce(new Vector2(0f, forceFactor * Time.fixedDeltaTime));

        if (joystick.Direction.x != 0 || joystick.Direction.y != 0)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        float angle = Mathf.Atan2(joystick.Direction.x, joystick.Direction.y) * Mathf.Rad2Deg;

        rb.AddForce(new Vector2(joystick.Direction.x / Screen.width * 320,
                            joystick.Direction.y / Screen.height * 526) * motionSpeed, ForceMode2D.Impulse);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f,
            -angle), Time.deltaTime * rotateSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           boomEffect.Play();
            canvas.DisplayDamage();
        }
    }

    public void RestartPlane()
    {
        transform.SetPositionAndRotation(startPosition, Quaternion.Euler(Vector2.zero));
    }
}

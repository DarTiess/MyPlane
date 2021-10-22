using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    public static PlaneMove Instance { get; private set; }
    private Rigidbody2D rb;
    [SerializeField] private float forceFactor = 50f;
    public VariableJoystick joystick;
    public ParticleSystem boomEffect;
    private Vector3 startPosition;
    public float motionSpeed = 2f;
    public float rotateSpeed = 8f;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        
    } 
    private void FixedUpdate()
    {
        if (GameManager.Instance.statusOfGame==GameManager.GameStatus.isGaming)
        {
            FlyForward();
        }
       
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
        if (collision.gameObject.tag == "Enemy")
        {
           boomEffect.Play();
            GameManager.Instance.DisplayDamage();
        }
    }

    public void RestartPlane()
    {
        transform.SetPositionAndRotation(startPosition, Quaternion.Euler(Vector2.zero));
    }
}

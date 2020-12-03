using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float forceFactor = 50f;
 
  

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    } 
    private void FixedUpdate()
    {
       rb.AddForce(new Vector2 (0f,forceFactor * Time.fixedDeltaTime));
    }
  
   
}

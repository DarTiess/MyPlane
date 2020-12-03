using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TouchMovement : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private Rigidbody2D Player = null;
    [SerializeField]
    private float forceFactor = 0.05f;
    [SerializeField]
    private float rotateSpeed = 210f;
   Camera cameraMain;
   


    private void Start()
    {
      cameraMain = Camera.main;
    }
    private void Update()
    {
       
    }
    private void LateUpdate()
    {
        cameraMain.transform.position = new Vector3(Player.transform.position.x,
            Player.transform.position.y, cameraMain.transform.position.z);

    }
  
    public void OnDrag(PointerEventData eventData)
    {
        Player.AddForce(new Vector3(eventData.delta.x / Screen.width * 320,
                                  eventData.delta.y / Screen.height * 526,0f) * forceFactor, ForceMode2D.Impulse);

        if (eventData.delta.x > 0)
        {
           RotateRight();

        }
        else if (eventData.delta.x < 0)
        {
            RotateLeft();

        }
    }

    public void RotateRight()
    {
     
        Player.transform.Rotate(Vector3.forward * (-rotateSpeed) * Time.deltaTime);
       
    }
    public void RotateLeft()
    {
      
        Player.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
   
    
}

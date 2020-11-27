using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchMovement : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private Rigidbody2D Player = null;
    [SerializeField]
    private float forceFactor = 0.025f;
    Camera cameraMain;
    public void OnDrag(PointerEventData eventData)
    {
        Player.AddForce(new Vector2(eventData.delta.x / Screen.width * 320,
                                  eventData.delta.y / Screen.height * 526) * forceFactor, ForceMode2D.Impulse);
    }
    private void Start()
    {
       cameraMain = Camera.main;
    }
    private void LateUpdate()
    {
        cameraMain.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, cameraMain.transform.position.z);
    }
}

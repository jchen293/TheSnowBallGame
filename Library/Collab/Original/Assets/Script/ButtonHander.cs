using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ButtonHander : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public int movement_force = 5;

    public GameObject snowBall;
    public Rigidbody2D rb;

    public bool buttonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
        rb.velocity = Vector2.zero;
    }

    public void FixedUpdate()
    {
        if(buttonPressed){
            rb.AddForce(movement_force * Vector2.left, 0);
        }
    }

   

}

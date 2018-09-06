﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class rightButtonEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public int movement_force = 5;

    public GameObject snowBall;
    public Rigidbody2D rb;
    public Transform tf;

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
            if(tf.position.x > 3){
                rb.velocity = Vector2.zero;
            }
            else{
                rb.AddForce(movement_force * Vector2.right, 0);    
            }

        }


    }



}

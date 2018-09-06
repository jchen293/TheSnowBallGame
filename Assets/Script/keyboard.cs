using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard : MonoBehaviour
{
    public int movement_force = 5;

    public GameObject snowBall;
    public Rigidbody2D rb;
    public Transform tf;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("HI");
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(movement_force * Vector2.left, 0);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(movement_force * Vector2.right, 0);

        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        if (tf.position.x > 3 || tf.position.x < -3)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
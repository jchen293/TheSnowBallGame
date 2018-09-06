using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Prefabs : MonoBehaviour {

    public static Prefabs Instance;
    GameManager gameManager;
    public GameObject rock;
    public Rigidbody2D rb;
    public Transform rockPos;
    public Vector2 pos;
    GameObject duplicateRock;
    GameObject duplicateRock2;
    public Button startGame;
    Quaternion downRotation;
    public float xPosition;
    public float xPositionCheck;

    float timer = 0f;
    Queue<GameObject> objectList = new Queue<GameObject>();

    System.Random randomNumber = new System.Random();

    void Awake()
    {
        Instance = this;
    }

    public void Movement(){
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -1);


    }
  
    
    public double XNumber(){
        int randomXNumber = randomNumber.Next(0,6)-3;
        return randomXNumber;
    }

    public void Update()
    {
        Debug.Log(TapController.Instance.gameOver);
        if (!startGame.IsActive()&&!TapController.Instance.gameOver)
        {

            timer += Time.deltaTime;
            if (timer > (randomNumber.NextDouble() + 1))
            {
                GameObject oj = ObjectPooler.Instance.GetPooledObject();
                if (oj != null)
                {
                    xPosition = (float)(randomNumber.NextDouble() * 6.0 - 3.0);
                    if((xPositionCheck-xPosition)<2.5){
                        xPosition = (float)(randomNumber.NextDouble() * 6.0 - 3.0);
                    }
                    oj.transform.position = new Vector2(xPosition, 6);
                    oj.SetActive(true);

                    xPositionCheck = xPosition;
                }


                timer = 0;

            }
        }
    }
}

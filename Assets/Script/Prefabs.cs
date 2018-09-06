using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Prefabs : MonoBehaviour
{

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

    float timer = 0f;
    Queue<GameObject> objectList = new Queue<GameObject>();

    System.Random randomNumber = new System.Random();

    void Awake()
    {
        Instance = this;
    }

    public void Movement()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -1);


    }


    public double XNumber()
    {
        int randomXNumber = randomNumber.Next(0, 6) - 3;
        return randomXNumber;
    }

    bool safeDistance(List<float> list, float x)
    {
        foreach (float x1 in list)
        {
            if (Math.Abs((x - x1)) < 1.2)
            {
                return false;
            }
        }
        return true;
    }

    public void Update()
    {
        if (!startGame.IsActive() && !TapController.Instance.gameOver)
        {

            timer += Time.deltaTime;
            if (timer > (randomNumber.NextDouble() + 1))
            {
                GameObject oj = ObjectPooler.Instance.GetPooledObject();
                if (oj != null)
                {
                    List<float> range = new List<float>();
                    foreach (GameObject obj in ObjectPooler.Instance.pooledObjects)
                    {
                        if (obj.activeInHierarchy && obj.transform.position.y > 5.5)
                        {
                            range.Add(obj.transform.position.x);
                        }
                    }
                    float x = (float)(randomNumber.NextDouble() * 6.0 - 3.0);
                    if (safeDistance(range, x))
                    {
                        oj.transform.position = new Vector2(x, 6);
                        oj.SetActive(true);
                    }
                }
                timer = 0;

            }
        }
    }
}

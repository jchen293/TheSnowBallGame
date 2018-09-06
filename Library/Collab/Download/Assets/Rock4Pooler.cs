using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock4Pooler : MonoBehaviour
{

    public static Rock4Pooler Instance;

    void Awake()
    {
        Instance = this;
    }
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public bool expand = false;
    public Transform leftSnowBall;
    public Transform rightSnowBall;
    public bool gameOver;



    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        if (expand)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            obj.GetComponent<Rigidbody2D>().simulated = true;
            pooledObjects.Add(obj);
            return obj;
        }
        else
        {
            return null;
        }
    }

    public void Start()
    {
        gameOver = false;
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            obj.GetComponent<Rigidbody2D>().simulated = true;
            pooledObjects.Add(obj);
        }
    }

    public void Update()
    {
        foreach (GameObject oj in pooledObjects)
        {
            if (oj.transform.position.y < -6)
            {
                oj.SetActive(false);
            }
            else if(Mathf.Abs(oj.transform.position.x - leftSnowBall.position.x) < 0.01  
                    && Mathf.Abs(oj.transform.position.y - leftSnowBall.position.y) < 0.5
                    || Mathf.Abs(oj.transform.position.x - rightSnowBall.position.x) < 0.01 
                    && Mathf.Abs(oj.transform.position.y - rightSnowBall.position.y) < 0.5){
                gameOver = true;
            }
            else{
                continue;
            }
        }
    }


}
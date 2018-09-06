using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public static ObjectPooler Instance;

    void Awake()
    {
        Instance = this;
    }
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public bool expand = true;
    int grow, expandNum, growSpeed;



    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        if (expand && grow > expandNum)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            obj.GetComponent<Rigidbody2D>().simulated = true;
            pooledObjects.Add(obj);
            expandNum++;
            growSpeed += 5;
            return obj;
        }

            return null;
    }

    public void Start()
    {
        growSpeed = 20;
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
        }
        if (expandNum < 5)
        {
            grow = HighScore.Instance.scores / growSpeed;
        }
    }


}
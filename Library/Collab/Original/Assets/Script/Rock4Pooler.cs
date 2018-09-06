using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public bool reuseObject = false;
    public GameObject gameOverPage;
    public GameObject leftButton, rightButton;
   



    public GameObject GetPooledObject()
    {
        if (GameManageFor4Lines.Instance.startGame)
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
        }

            return null;
    }

    public void Start()
    {
        gameOver = false;
        reuseObject = false;
        pooledObjects = new List<GameObject>();


        if (GameManageFor4Lines.Instance.startGame)
        {
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(objectToPool);

                obj.GetComponent<Rigidbody2D>().simulated = true;


                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
       
    }

    public void Update()

    {

        if (!gameOver)
        {
            foreach (GameObject oj in pooledObjects)
            {
                
                Debug.Log("gravity" + oj.GetComponent<Rigidbody2D>().gravityScale);

                if (((HighScoreFor4Lines.Instance.scores+1) % 5 == 0) && oj.GetComponent<Rigidbody2D>().gravityScale < 1.5f)
                {
                    oj.GetComponent<Rigidbody2D>().gravityScale += 0.05f;

                }
                //Debug.Log(HighScoreFor4Lines.Instance.scores);

                if (oj.transform.position.y < -6)
                {
                    oj.SetActive(false);
                }
                else if (Mathf.Abs(oj.transform.position.x - leftSnowBall.position.x) < 0.01
                        && Mathf.Abs(oj.transform.position.y - leftSnowBall.position.y) < 0.5||
                       Mathf.Abs(oj.transform.position.x - rightSnowBall.position.x) < 0.01
                        && Mathf.Abs(oj.transform.position.y - rightSnowBall.position.y) < 0.5)
                {

                    //foreach (GameObject ojb in pooledObjects)
                    //{

                    //    if (ojb.activeInHierarchy)
                    //    {
                    //        ojb.SetActive(false);
                    //    }
                    //    ojb.GetComponent<Rigidbody2D>().simulated = false;

                    //}
                    //onPlayDied();
                }
                else
                {
                    continue;
                }
            }
        }
    }

    public void onPlayDied(){
        gameOverPage.SetActive(true);
        gameOver = true;
        GameManageFor4Lines.Instance.startGame = false;
        GameManageFor4Lines.Instance.numberDead++;
        leftSnowBall.GetComponent<Rigidbody2D>().simulated = false;
        rightSnowBall.GetComponent<Rigidbody2D>().simulated = false;
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        Rock4rightButton.Instance.gameHasStarted = false;
        Rock4leftButton.Instance.gameHasStarted = false;


    }
}
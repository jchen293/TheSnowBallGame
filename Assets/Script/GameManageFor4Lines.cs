using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManageFor4Lines : MonoBehaviour {

    public static GameManageFor4Lines Instance;

    public GameObject rock;
    public GameObject startPage;
    public GameObject gameoverPage;
    public GameObject scorePage;
    public GameObject leftSnowBall;
    public GameObject rightSnowBall;
    public GameObject line1, line2, line3;
    public Button right, left;

    public bool startGame = false;
    public int numberDead = 0;

    void Awake()
    {
        Instance = this;
    }

    public void StartGame(){
        startGame = true;
        startPage.SetActive(false);
        scorePage.SetActive(true);
        leftSnowBall.SetActive(true);
        rightSnowBall.SetActive(true);
        line1.SetActive(true);
        line2.SetActive(true);
        line3.SetActive(true);
        right.gameObject.SetActive(true);
        left.gameObject.SetActive(true);

        Rock4Pooler.Instance.Start();
        Rock4rightButton.Instance.gameHasStarted = true;
        Rock4leftButton.Instance.gameHasStarted = true;
    }



    public void RestartGame()
    {

        startPage.SetActive(true);
        gameoverPage.SetActive(false);
        foreach (GameObject ojb in Rock4Pooler.Instance.pooledObjects)
        {
            ojb.SetActive(false);
        }
        if(numberDead>=1){
            for (int i = 0; i < Rock4Pooler.Instance.pooledObjects.Count; i++)
            {
                Destroy(Rock4Pooler.Instance.pooledObjects[i]);
            }
        }


        leftSnowBall.transform.position = new Vector2((float)-0.7, (float)-2.5);
        rightSnowBall.transform.position = new Vector2((float)0.7, (float)-2.5);

        leftSnowBall.SetActive(false);
        rightSnowBall.SetActive(false);
        scorePage.SetActive(false);
        HighScoreFor4Lines.Instance.theTime = 0;


    }
}

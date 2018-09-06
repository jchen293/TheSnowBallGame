using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class GameManager : MonoBehaviour {
    
    public static GameManager Instance;
    public Button restartButton;
    public Button playButton;
    public GameObject playButton2;
    public GameObject startPage;
    public GameObject GameOverPage;
    public GameObject scorePage;
    public GameObject snowBall;
    public GameObject rock;
    public Rigidbody2D snowBallMovement;
    public Rigidbody2D rockMovement;
    public Vector3 startPos;
    public Vector3 rockStartPos;
    public GameObject objectPooler;
    public bool PrefabStart = false;
    public int distanceTravelled;


    void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        snowBallMovement.simulated = false;
        rockMovement.simulated = false;

    }

   

    public void startGame(){
        
        snowBallMovement.simulated = true;
        rockMovement.simulated = true;
        playButton2.SetActive(false);
        PrefabStart = true;
        scorePage.SetActive(true);
        objectPooler.SetActive(true);


    }

    public bool PrefabStarts(){
        return PrefabStart;
    }


    public void restartGame()
    {
        GameOverPage.SetActive(false);       
        startPage.SetActive(true);
        playButton2.SetActive(true);
        snowBall.transform.localPosition = startPos;    //move the snowball back to origial 
                                                        //place once user hit restart button
        rock.transform.localPosition = rockStartPos;

        rockMovement.velocity = Vector2.zero;
        TapController.Instance.gameOver = false;



    }

    public int Score(){
        return distanceTravelled;
    }

}

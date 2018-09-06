using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapController : MonoBehaviour {
     
    public static TapController Instance;
    public Rigidbody2D snowBallMovement;
    public Rigidbody2D rockMovement;
    public GameObject snowBall;
    public GameObject startPage;
    public GameObject GameOverPage;

    //public static int highestScore = HighScore.Instance.scores;
    public Text highScoreText;
    public GameObject highScoreTextObject;
    public int savedScore;
    public bool gameOver ;

    public void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        savedScore = PlayerPrefs.GetInt("HighScore");

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "DeadZone") // chekc when the snowball hit the rock
        {
            gameOver = true;
            GameManager.Instance.scorePage.SetActive(false);
            snowBallMovement.simulated = false;
            rockMovement.simulated = false;
            GameOverPage.SetActive(true);           // make gameover page pops up
            highScoreText.text = "Highest Score: " + savedScore;

            if(HighScore.Instance.scores > savedScore){
                highScoreText.text = "New Highest Score: " + HighScore.Instance.scores;
                PlayerPrefs.SetInt("HighScore", HighScore.Instance.scores);
            }
            HighScore.Instance.theTime = 0;

        }

        Debug.Log(HighScore.Instance.scores);
    }

   
}

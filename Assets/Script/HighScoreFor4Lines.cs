using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreFor4Lines : MonoBehaviour {

    public static HighScoreFor4Lines Instance;
    public Text ScoreBoard;
    public float theTime;
    public float speed = 1;
    public int scores;
    public int highestScore;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        //highestScore = PlayerPrefs.GetInt("highScore");
        ScoreBoard = GetComponent<Text>();

    }


    public void Update()
    {
        if (!Rock4Pooler.Instance.gameOver)
        {
            theTime += Time.deltaTime * speed;
            scores = (int)(theTime / 1);
            ScoreBoard.text = scores + " Meters";
        }
    }

}

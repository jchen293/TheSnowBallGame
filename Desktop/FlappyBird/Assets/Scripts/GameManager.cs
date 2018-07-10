using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {



    public static GameManager Instance;

    public delegate void GameDelegate();
    public static event GameDelegate OnGameStarted;
    public static event GameDelegate OnGameOverConfirmed;

    public GameObject startPage;
    public GameObject gameOverPage;
    public GameObject countdownPage;
    public GameObject pausePage;
    public GameObject pauseButton;
    public Text ScoreText;
    public Text NewHighScore;


    public Sprite on;
    public Sprite off;
    public Sprite pause;
    public Sprite resume;
    public Button AudioButton;
    public Text MusicText;

    public Button PauseButton;


     int score = 0;
    bool gameOver = true;
    bool music = true;
    bool music2 = true;
    bool pauseGame = true;

    enum PageState
    {
        None,
        Start,
        GameOver,
        Countdown
    }

    public int Score(){
        return score;
    }

    public bool Gameover(){
        
        return gameOver;
    }

	 void Awake()
	{
        Instance = this;
	}

	 void OnEnable()
	{
        CountDownText.OnCountDownFinished += OnCountDownFinished;
        TapController.OnPlayerDied += OnPlayerDied;
        TapController.OnPlayerScored += OnPlayerScored;

	}

	 void OnDisable()
	{
        CountDownText.OnCountDownFinished -= OnCountDownFinished;
        TapController.OnPlayerDied -= OnPlayerDied;
        TapController.OnPlayerScored -= OnPlayerScored;

	}

   
    void OnPlayerDied(){

        gameOver = true;
        ScoreText.text = "";
        int savedScore = PlayerPrefs.GetInt("HighScore");
        if (score > savedScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            NewHighScore.text = "New High Score: " + score;
        }else{
            NewHighScore.text = "";
        }
        SetPageState(PageState.GameOver);
    }

    void OnPlayerScored(){
        score ++;
        ScoreText.text = score.ToString();

    }
    void OnCountDownFinished(){
        SetPageState(PageState.None);
        OnGameStarted();
        score = 0;
        gameOver = false;
    }

    public bool Pause(){
        return pauseGame;
    }

    public void OnPauseFinished()
    {
        
            Time.timeScale = 0;
            music = false;
            pausePage.SetActive(true);
        pauseButton.SetActive(false);
        pauseGame = false;

    }

    public void resumeGame(){

        Time.timeScale = 1;
        pausePage.SetActive(false);
        music = true;
        pauseButton.SetActive(true);
        pauseGame = true;
    }


    void SetPageState(PageState state)
    {
        switch (state)
        {
            case PageState.None:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                break;
            case PageState.Start:
                startPage.SetActive(true);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                break;
            case PageState.Countdown:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(true);
                break;
            case PageState.GameOver:
                startPage.SetActive(false);
                gameOverPage.SetActive(true);
                countdownPage.SetActive(false);
                break;
        }
    }

    public void Music()
    {

        if(AudioButton.image.sprite==on){
            MusicText.text = "Auido is off";
            AudioButton.image.sprite = off;
                music = false;
                music2 = false;
        }else{
            MusicText.text = "Auido is on";
            AudioButton.image.sprite = on;     
                music = true;
            music2 = true;

        }

    }

    public bool MusicOnAndOff(){
        return music;
    }

    public bool MusciOnAndOff2(){
        return music2;
    }
    public void ConfirmedGameOver(){
        OnGameOverConfirmed();
        ScoreText.text = "0";
        SetPageState(PageState.Start);
    }

    public void StartGame(){
        SetPageState(PageState.Countdown);
    }


}

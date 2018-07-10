using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class TapController : MonoBehaviour {

    public static TapController Instance;

    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerDied;
    public static event PlayerDelegate OnPlayerScored;

    public float tapForce = 10;
    public float tiltSmooth = 5;
    public AudioSource tapAudio;
    public AudioSource dieAudio;
    public AudioSource scoreAudio;
    public GameObject pauseButton2;

    public GameObject bird;
    public Sprite bird2;
    public Sprite wasted;
    public bool dead = true;

    public Vector3 startPos;

    public Rigidbody2D rigidBody;

    Quaternion downRotation;
    Quaternion forwardRotation;
    GameManager game;

	// Use this for initialization


	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);
        game = GameManager.Instance;
        rigidBody.simulated = false;

        pauseButton2.SetActive(false);


	}

    private void OnEnable()
    {
        GameManager.OnGameStarted += OnGameStarted;
        GameManager.OnGameOverConfirmed += OnGameOverConfirmed;

    }

    private void OnDisable()
    {

        GameManager.OnGameStarted -= OnGameStarted;
        GameManager.OnGameOverConfirmed -= OnGameOverConfirmed;

    }

    void OnGameStarted(){
        rigidBody.velocity = Vector3.zero;
        rigidBody.simulated = true;
        pauseButton2.SetActive(true);



    }

    void OnGameOverConfirmed(){
        transform.localPosition = startPos;
        transform.rotation = Quaternion.identity;
        bird.GetComponent<SpriteRenderer>().sprite = bird2;
        transform.localScale = new Vector2(0.12f, 0.12f);


    }

    public bool music(){
        return GameManager.Instance.MusicOnAndOff();
    }
    public bool music2()
    {
        return GameManager.Instance.MusciOnAndOff2();
    }

    public bool Pause(){
        return GameManager.Instance.Pause();
    }


    void Update () {
        if(game.Gameover()){
            return;
        }

            if (Input.GetMouseButtonDown(0))
            {
            if (music() == true &&music2()==true)
            {
                tapAudio.Play();
            }

            if (Pause() == true)
            {
                transform.rotation = forwardRotation;
                rigidBody.velocity = Vector3.zero;

                rigidBody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
            }
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth*Time.deltaTime);
	}

	 void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag=="ScoreZone"){

            OnPlayerScored();
            if (music() == true&& music2() == true)
            {
                scoreAudio.Play();
            }
        }
        if (collision.gameObject.tag == "DeadZone"){
            rigidBody.simulated = false;
            pauseButton2.SetActive(false);

            OnPlayerDied();
            if (music() == true&& music2() == true)
            {
                dieAudio.Play();
            }
            bird.GetComponent<SpriteRenderer>().sprite = wasted;
            transform.localScale = new Vector2(0.2F, 0.2F);

            dead = false;
        }

        if(collision.gameObject.tag =="AboveZone"){
            rigidBody.AddForce(Vector2.down * tapForce, ForceMode2D.Force);

        }
	}
}

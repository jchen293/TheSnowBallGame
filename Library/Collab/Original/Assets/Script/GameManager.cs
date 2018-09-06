using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public GameObject snowBall;
    public Button LeftButton;
    public Button RightButton;

    public void leftButton(){
       

            snowBall.transform.Translate(-1, 0, 0);

    }

    public void rightButton(){
        snowBall.transform.Translate(1, 0, 0);
    }
}

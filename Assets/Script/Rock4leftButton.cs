using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Rock4leftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static Rock4leftButton Instance;
    public GameObject snowBall;
    public Rigidbody2D rb;
    public Transform tf;
    public bool gameHasStarted = false;

    public void Awake()
    {
        Instance = this;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameHasStarted)
        {
            snowBall.transform.position = new Vector2((float)-2.6, (float)-2.5);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        snowBall.transform.position = new Vector2((float)-0.7, (float)-2.5);
    }





}

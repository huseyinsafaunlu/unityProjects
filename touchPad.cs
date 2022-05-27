using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class touchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public bool isStartMoving = false;
    public float sizeX;
    public float sizeY;
    public static touchPad instance;
    private void Awake()
    {
        instance = this;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("down");
        isStartMoving = true;
    }



    public void OnDrag(PointerEventData eventData)
    {
        sizeY = eventData.delta.y/1000;
        playerSize.instance.reSize();


    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("up");
    }


    [SerializeField] GameObject winPannel;
    public void activateWinPannel()
    {
        winPannel.SetActive(true);
    }

    public void reStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

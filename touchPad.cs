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
    float cubeSpeed = 100f;
    float cubeVelocity = 10f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody playerRigidbody;

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
        Debug.Log("drag");
        playerTransform.position += new Vector3(eventData.delta.x / cubeSpeed, 0, 0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("up");
    }

}

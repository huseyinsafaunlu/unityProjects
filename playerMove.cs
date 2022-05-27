using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public bool drag = false;

    private Rigidbody playerRigidbody;
    bool isSlideAsMuch = false;
    float previousTime;
    public static playerMove instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        playerRigidbody = this.gameObject.GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        if (touchPad.instance.isStartMoving)
        {
            playerRigidbody.velocity = new Vector3(0, 0, 10f);

        }

        if (isSlideAsMuch&&(previousTime+(0.1+((float)(generalControl.instance.sphereCount)/10f))<Time.time))
        {
            playerRigidbody.velocity *= 0.7f;
            previousTime = Time.time;
        }

    }


    public void stopMoving()
    {
        touchPad.instance.isStartMoving = false;
        playerRigidbody.velocity = new Vector3(0, 0, 0);
    }

    

    public void slideAsMuch()
    {
        playerRigidbody.AddForce(0, 0, 1000);
        previousTime = Time.time;
        isSlideAsMuch = true;
        //playerRigidbody.AddForce(0, 0, -100);
        //playerRigidbody.AddForce(0,0,1000);
        //playerRigidbody.AddForce(0, 0, -100);
        //playerRigidbody.useGravity = true;
        //playerRigidbody.isKinematic = false;
    }

}

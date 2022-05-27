using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public bool drag = false;

    private Rigidbody playerRigidbody;

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
    }


    public void stopMoving()
    {
        touchPad.instance.isStartMoving = false;
        playerRigidbody.velocity = new Vector3(0, 0, 0);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isAvelibleToJump;

    public static Player instance;
    public Rigidbody rbPlayer;

    private void Awake()
    {
        instance = this;



        rbPlayer = GetComponent<Rigidbody>();
        rbPlayer.mass = 1f;
    }

    public void OnCollisionStay(Collision collision)
    {
        Debug.Log("stay");
        isAvelibleToJump = true;
        //Physics.gravity = new Vector3(0, -9.81f, 0);
        //rbPlayer.mass = 1f;
    }
    public void OnCollisionExit(Collision collision)
    {
        Debug.Log("exit");
        isAvelibleToJump = false;
    }

    private void Update()
    {
        /*
        if (gameObject.transform.position.y>2.5f)
        {

            //Physics.gravity = new Vector3(0, -30, 0);
            rbPlayer.mass = 20000f;
        }
        */

    }


}

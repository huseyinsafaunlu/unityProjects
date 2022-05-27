using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag=="sphere")
        {
            Destroy(other.gameObject);
        }
        else
        {
            generalControl.instance.winPannelActivate();
            playerMove.instance.stopMoving();
            playerMove.instance.slideAsMuch();
            //generalControl.instance.throwPlayer();
            //generalControl.instance.lineUp();
        }

    }
}

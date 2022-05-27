using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        generalControl.instance.winPannelActivate();
        playerMove.instance.stopMoving();
        generalControl.instance.lineUp();
    }
}

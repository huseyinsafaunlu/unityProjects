using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsticle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        touchPad.instance.activateWinPannel();
        touchPad.instance.isStartMoving = false;
    }
}
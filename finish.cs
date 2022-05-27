using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        arrowCounter.instance.activateWinPannel();
        playerBagMove.instance.speed = 0f;

        Debug.Log("Finish Collide");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chainsaw : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        GeneralControl.instance.loseAllCollectibleNumber();
    }
}

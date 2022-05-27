using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lighter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        GeneralControl.instance.decreaseCollectibleNumber();
    }
}

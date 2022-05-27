using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    
    

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        GeneralControl.instance.increaseCollectibleNumber();
    }




}
 
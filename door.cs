using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class door : MonoBehaviour
{
    [SerializeField] private TextMeshPro doorText;
    int sphereCount = 0;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player"&&(generalControl.instance.collectibleCount==0))
        {
            generalControl.instance.losePannelActivate();
            playerMove.instance.stopMoving();
        }
        if (other.tag == "sphere")
        {
            //other.GetComponent<smoothFallower>().currentLeadTransform =;
            generalControl.instance.decreaseSphereCount();
            Destroy(other.gameObject);
            sphereCount++;
            doorText.text = "Count:" + sphereCount.ToString();

        }
    }
}

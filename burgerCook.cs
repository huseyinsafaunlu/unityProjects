using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerCook : MonoBehaviour
{
    //Burger => Kofte, 2 * ekmek, marul, Hotdog => Sosis, ekmek, harda
    bool isCooking = false;
    int breadCount = 0;
    int vegCount = 0;
    int meatCount = 0;

    public GameObject burgerPrefab;

    GameObject[] breadArray = new GameObject[20];
    GameObject[] vegArray = new GameObject[20];
    GameObject[] meatArray = new GameObject[20];

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bread"&&(!isCooking))
        {
            breadArray[breadCount] = other.gameObject;
            breadCount++;
            other.transform.parent = this.gameObject.transform;
            playerCollector.instance.isCarrying=false;
        }
        if (other.tag=="veg" && (!isCooking))
        {
            vegArray[vegCount] = other.gameObject;
            vegCount++;
            other.transform.parent = this.gameObject.transform;
            playerCollector.instance.isCarrying = false;
        }
        if (other.tag == "meat" && (!isCooking))
        {
            meatArray[meatCount] = other.gameObject;
            meatCount++;
            other.transform.parent = this.gameObject.transform;
            playerCollector.instance.isCarrying = false;
        }


        if ((meatCount>0) && (breadCount>1) && (vegCount>0) )
        {
            meatCount--;
            breadCount -= 2;
            vegCount--;
            
            Destroy(meatArray[meatCount]);
            Destroy(vegArray[vegCount]);
            Destroy(breadArray[breadCount]);
            Destroy(breadArray[breadCount + 1]);

            isCooking = true;
           StartCoroutine(startCooking());
        }
        
    }

    IEnumerator startCooking()
    {
        isCooking = true;
        yield return new WaitForSeconds(15);
        Debug.Log("Hamburger Spawn");
        Instantiate(burgerPrefab, this.gameObject.transform.position, Quaternion.identity);
        isCooking = false;
    }
}

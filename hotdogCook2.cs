using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotdogCook2 : MonoBehaviour
{
    //Hotdog => Sosis, ekmek, hardal
    bool isCooking = false;
    int breadCount = 0;
    int sausageCount = 0;
    int mustardCount = 0;

    public GameObject burgerPrefab;

    GameObject[] breadArray = new GameObject[20];
    GameObject[] sausageArray = new GameObject[20];
    GameObject[] mustardArray = new GameObject[20];

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bread" && (!isCooking))
        {
            breadArray[breadCount] = other.gameObject;
            breadCount++;
            other.transform.parent = this.gameObject.transform;
            playerCollector.instance.isCarrying = false;
        }
        if (other.tag == "sausage" && (!isCooking))
        {
            sausageArray[sausageCount] = other.gameObject;
            sausageCount++;
            other.transform.parent = this.gameObject.transform;
            playerCollector.instance.isCarrying = false;
        }
        if (other.tag == "mustard" && (!isCooking))
        {
            mustardArray[mustardCount] = other.gameObject;
            mustardCount++;
            other.transform.parent = this.gameObject.transform;
            playerCollector.instance.isCarrying = false;
        }


        if ((mustardCount > 0) && (breadCount > 0) && (sausageCount > 0) )
        {
            mustardCount--;
            breadCount--;
            sausageCount--;

            Destroy(breadArray[breadCount]);
            Destroy(sausageArray[sausageCount]);
            Destroy(mustardArray[mustardCount]);



            isCooking = true;
            StartCoroutine(startCooking());
        }

    }

    IEnumerator startCooking()
    {
        isCooking = true;
        yield return new WaitForSeconds(12);
        Instantiate(burgerPrefab, this.gameObject.transform.position, Quaternion.identity);
        isCooking = false;
    }
}

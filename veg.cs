using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class veg : MonoBehaviour
{
    // Start is called before the first frame update
    Coroutine lastRoutine = null;
    void Start()
    {
        lastRoutine = StartCoroutine(spoil());
    }
    IEnumerator spoil()
    {
        yield return new WaitForSeconds(20);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            StopCoroutine(lastRoutine);
        }
    }
}

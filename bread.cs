using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bread : MonoBehaviour
{
    // Start is called before the first frame update
    Coroutine lastRoutine = null;
    void Start()
    {
        lastRoutine = StartCoroutine(spoil());
    }
    IEnumerator spoil()
    {
        yield return new WaitForSeconds(30);
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

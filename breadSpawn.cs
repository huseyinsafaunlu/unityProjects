using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breadSpawn : MonoBehaviour
{
    public GameObject breadPrefab;
    int breadDelayTime = 3;
    private void Start()
    {
        StartCoroutine(spawnBread());
    }

    IEnumerator spawnBread()
    {
        while (true)
        {
            yield return new WaitForSeconds(breadDelayTime);
            Vector3 spawnPos = new Vector3(this.gameObject.transform.position.x + Random.Range(-1,2), this.gameObject.transform.position.y + 0.5f, this.gameObject.transform.position.z + Random.Range(-1, 2));
            Instantiate(breadPrefab, spawnPos, Quaternion.identity);
            Debug.Log("3 sec later");
        }
    }
}

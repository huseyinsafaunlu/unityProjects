using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sausageSpawn : MonoBehaviour
{
    public GameObject sausagePrefab;
    int sausageDelayTime = 7;
    private void Start()
    {
        StartCoroutine(spawnSausage());
    }

    IEnumerator spawnSausage()
    {
        while (true)
        {
            yield return new WaitForSeconds(sausageDelayTime);
            Vector3 spawnPos = new Vector3(this.gameObject.transform.position.x + Random.Range(-1, 2), this.gameObject.transform.position.y + 0.5f, this.gameObject.transform.position.z + Random.Range(-1, 2));
            Instantiate(sausagePrefab, spawnPos, Quaternion.identity);
            Debug.Log("3 sec later");
        }
    }

}

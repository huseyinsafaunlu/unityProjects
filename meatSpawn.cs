using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meatSpawn : MonoBehaviour
{
    public GameObject meatPrefab;
    int meatDelayTime = 9;
    private void Start()
    {
        StartCoroutine(spawnMeat());
    }

    IEnumerator spawnMeat()
    {
        while (true)
        {
            yield return new WaitForSeconds(meatDelayTime);
            Vector3 spawnPos = new Vector3(this.gameObject.transform.position.x + Random.Range(-1, 2), this.gameObject.transform.position.y + 0.5f, this.gameObject.transform.position.z + Random.Range(-1, 2));
            Instantiate(meatPrefab, spawnPos, Quaternion.identity);
            Debug.Log("3 sec later");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mustardSpawn : MonoBehaviour
{
    public GameObject mustardPrefab;
    int mustardDelayTime = 6;
    private void Start()
    {
        StartCoroutine(spawnMustard());
    }

    IEnumerator spawnMustard()
    {
        while (true)
        {
            yield return new WaitForSeconds(mustardDelayTime);
            Vector3 spawnPos = new Vector3(this.gameObject.transform.position.x + Random.Range(-1, 2), this.gameObject.transform.position.y + 0.5f, this.gameObject.transform.position.z + Random.Range(-1, 2));
            Instantiate(mustardPrefab, spawnPos, Quaternion.identity);
            Debug.Log("3 sec later");
        }
    }
}

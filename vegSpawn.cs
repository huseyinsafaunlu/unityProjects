using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vegSpawn : MonoBehaviour
{
    public GameObject vegPrefab;
    int vegDelayTime = 2;
    private void Start()
    {
        StartCoroutine(spawnVeg());
    }

    IEnumerator spawnVeg()
    {
        while (true)
        {
            yield return new WaitForSeconds(vegDelayTime);
            Vector3 spawnPos = new Vector3(this.gameObject.transform.position.x + Random.Range(-1, 2), this.gameObject.transform.position.y + 0.5f, this.gameObject.transform.position.z + Random.Range(-1, 2));
            Instantiate(vegPrefab, spawnPos, Quaternion.identity);
            Debug.Log("3 sec later");
        }
    }
}

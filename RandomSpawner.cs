using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    //----------Make It Global---------------
    public static RandomSpawner instance;

    private void Awake()
    {
        instance = this;
    }
    //-------------------------------------



    public GameObject RedSphere;
    public GameObject BlueSphere;
    public GameObject GreenSphere;

    public float Radius = 1;
    int TimeCount=0;
    public int objectCount = 0;


    public void subObjectCount()
    {
        objectCount--;
    }


    void SpawnObjectRandomPos()
    {
        float xObjectPos = Random.Range(-10f, 10f);
        float zObjectPos = Random.Range(-10f, 10f);
        Vector3 randomPos =new Vector3(xObjectPos,1f, zObjectPos);
        int randomColor = Random.Range(1, 4);
        if (randomColor == 1)
        {
            Instantiate(RedSphere,randomPos,Quaternion.identity);
            
        }
        else if (randomColor == 2)
        {
            Instantiate(BlueSphere, randomPos, Quaternion.identity);
            
        }


        else if (randomColor == 3)
        {
            Instantiate(GreenSphere, randomPos, Quaternion.identity);
            
        }


    }

    private void Update()
    {
        if (objectCount<20) {
            objectCount++;
            SpawnObjectRandomPos();
        }

    }




}

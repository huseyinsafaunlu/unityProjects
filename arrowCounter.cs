using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class arrowCounter : MonoBehaviour
{
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] GameObject arrowBag;
    [SerializeField] GameObject winPannel;
    [SerializeField] public int arrowCount = 1;

    public GameObject[] arrowArray = new GameObject[400];
    //public GameObject []arrowArray;

    //----------------------------------------------
    public static arrowCounter instance;

    private void Awake()
    {
        instance = this;
    }
    //----------------------------------------------

    private void Start()
    {
        int spawnCount = 0;
        for (int j = 0; j <= 7; j++)
        {
        for (int i = 1; i <= ((j+1)*10); i++)
        {
            spawnCount++;
            arrowArray[spawnCount] = Instantiate(arrowPrefab, new Vector3(Mathf.Cos((36*(i))/(j+1))*j/5f, Mathf.Sin((36 * (i)) / (j + 1)) * j / 5f + 1.35f, arrowArray[0].transform.position.z), Quaternion.identity, arrowBag.transform); 
        }
        }
    }

    public void activateWinPannel()
    {
        winPannel.SetActive(true);
    }

    public void reStart()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void deleteAllArrows()
    {
        for (int i = 1; i <= 359; i++)
        {
            arrowArray[i].SetActive(false);
        }
    }

    public void updateArrows()
    {


        deleteAllArrows();
        for (int i = 1; i <= arrowCount; i++)
        {
            arrowArray[i].SetActive(true);
        }

    }




}

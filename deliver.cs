using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class deliver : MonoBehaviour
{

    public GameObject[] hotdog = new GameObject[5];
    public GameObject[] hamburger = new GameObject[5];
    int hotdogCount = 0;
    int hamburgerCount = 0;
    public TextMeshPro scoreText;


    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag=="hamburger")&&(hamburgerCount < 5))
        {
            Destroy(other.gameObject);
            playerCollector.instance.isCarrying = false;
            hotdog[hotdogCount].SetActive(true);
            hotdogCount++;
        }
        if ((other.tag == "hotdog")&& (hotdogCount < 5))
        {
            Destroy(other.gameObject);
            playerCollector.instance.isCarrying = false;
            hamburger[hamburgerCount].SetActive(true);
            hamburgerCount++;
        }


        scoreText.text = "hotdog="+ hotdogCount.ToString()+ "           hamburger=" + hamburgerCount.ToString();

        if ((hotdogCount>=4) && (hamburgerCount>=4))
        {
            //End game
        }
    }





}

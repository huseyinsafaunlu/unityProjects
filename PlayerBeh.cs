using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerBeh : MonoBehaviour
{
    public Text scoreText;
    public GameObject WinPannel;
    public GameObject LoosePannel;
    int points = 0;

    Renderer rend;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        scoreText.text = points.ToString() + " Points";
    }

    private void Update()
    {
        if (points > 10)
        {
            WinPannel.SetActive(true);
        }
        /*
        if (points > 1)
        {
            WinPannel.SetActive(true);
        }
        */
    }

    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }



    private void OnCollisionEnter(Collision collision)
    {



        if (collision.gameObject.tag == "RedCoin")
        {

            //+1
            points++;
            RandomSpawner.instance.subObjectCount();
            Destroy(collision.gameObject);
            gameObject.GetComponent<Renderer>().material.color = collision.gameObject.GetComponent<MeshRenderer>().material.color;
        }


        if (collision.gameObject.tag == "BlueCoin")
        {
            //+2
            points+=2;
            RandomSpawner.instance.subObjectCount();
            Destroy(collision.gameObject);
            gameObject.GetComponent<Renderer>().material.color = collision.gameObject.GetComponent<MeshRenderer>().material.color;
        }



        if (collision.gameObject.tag == "GreenCoin")
        {
            //+3
            points+=3;
            RandomSpawner.instance.subObjectCount();
            Destroy(collision.gameObject);
            gameObject.GetComponent<Renderer>().material.color = collision.gameObject.GetComponent<MeshRenderer>().material.color;
        }

        scoreText.text = points.ToString() + " Points";

    }
}

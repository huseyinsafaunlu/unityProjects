using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreMenager : MonoBehaviour
{
    public static ScoreMenager instance;

    public Text scoreText;
  

    int score = 0;


    private void Awake()
    {
        instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " Points";

    }

    public void AddPoint()
    {
        score++;
        scoreText.text = score.ToString() + "Points";
        if(score>9) SceneManager.LoadScene("GameScene");
    }

    public void SubbPoint()
    {
        score--;
        scoreText.text = score.ToString() + "Points";
        if (score < 0) SceneManager.LoadScene("GameScene");
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class generalControl : MonoBehaviour
{
    //----------------------------Var
    
    public int collectibleCount = 0;

    [SerializeField] private GameObject fallowerPrefab;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private GameObject bag;
    [SerializeField] public GameObject winPannel;
    [SerializeField] public GameObject losePannel;
    [SerializeField] public Text capsuleText;
    [SerializeField] public Text sphereText;
    [SerializeField] public Text scoreText;
    [SerializeField] public GameObject playerGameObject;
    [SerializeField] public Rigidbody playerRigidbody;
    [SerializeField] public GameObject cameraGameObject;
    [SerializeField] public GameObject newCameraGameObject;
    [SerializeField] public bool isLineUp = false;
    [SerializeField] Mesh sphere;
    [SerializeField] Mesh capsule;
    //[SerializeField] public int []lineController;

    public List<GameObject> spawnedList;
    public Vector3 offset;
    public int capsuleCount = 0;
    public int sphereCount = 0;
    int scoreCount = 0;
    int newSphereCount;
    int newCapsuleCount;
    private float velocity = 0f;
    private float smoothTime = 0.07f;
    float previousTime = 0;
    private bool isCalculateScoreUpdate = false;
    //----------------------------Var
    public static generalControl instance;
    private void Awake()
    {
        instance = this;
        offset = new Vector3(0,0,1f);
    }
    void Update()
    {
        if (isLineUp)
        {
            spawnedList[0].transform.position = new Vector3(playerGameObject.transform.position.x, Mathf.SmoothDamp(spawnedList[0].transform.position.y, playerGameObject.transform.position.y + 1.5f, ref velocity, smoothTime), playerGameObject.transform.position.z);

            for (int i=1;i<(capsuleCount+sphereCount);i++)
            {
                //if (spawnedList[i].GetComponent<MeshFilter>().sharedMesh == sphere) 
                //{
                spawnedList[i].transform.position = new Vector3(spawnedList[i-1].transform.position.x, Mathf.SmoothDamp(spawnedList[i].transform.position.y, spawnedList[i-1].transform.position.y + (1.1f), ref velocity, smoothTime), spawnedList[i-1].transform.position.z);
                /*}
                if (spawnedList[i].GetComponent<MeshFilter>().sharedMesh == capsule)
                {
                    spawnedList[i].transform.position = new Vector3(spawnedList[i - 1].transform.position.x, Mathf.SmoothDamp(spawnedList[i].transform.position.y, spawnedList[i - 1].transform.position.y + (1.2f), ref velocity, smoothTime), spawnedList[i - 1].transform.position.z);
                }
                */
            }
            cameraGameObject.transform.position = new Vector3(Mathf.SmoothDamp(cameraGameObject.transform.position.x, newCameraGameObject.transform.position.x, ref velocity, smoothTime), Mathf.SmoothDamp(cameraGameObject.transform.position.y, newCameraGameObject.transform.position.y, ref velocity, smoothTime), Mathf.SmoothDamp(cameraGameObject.transform.position.z, newCameraGameObject.transform.position.z, ref velocity, smoothTime));


        }



        if (isCalculateScoreUpdate)
        {
            if ((previousTime + 1) < Time.time)
            {

                if (newSphereCount+newCapsuleCount>0)
                {
                    if (newSphereCount > 0)
                    {
                        newSphereCount--;
                        scoreCount += 5;
                        scoreText.text = "Score:" + scoreCount.ToString();
                        sphereText.text = "Sphere:" + newSphereCount.ToString();
                    }
                    if (newCapsuleCount > 0)
                    {
                        newCapsuleCount--;
                        scoreCount += 10;
                        scoreText.text = "Score:" + scoreCount.ToString();
                        capsuleText.text = "Capsule:" + newCapsuleCount.ToString();
                    }


                }
                previousTime = Time.time;
            }
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "collectible")
        {
            Debug.Log("sdsad");
            increaseSphereCount();
            fallow();
            Destroy(other.gameObject);
        }
        
    }
    GameObject spawnedFallower;
    public GameObject[] spawnedFallowerArray = new GameObject[10];
    public void fallow()
    {
        spawnedFallowerArray[collectibleCount] = Instantiate(fallowerPrefab, spawnTransform.position, Quaternion.identity, bag.transform);
        spawnTransform.position = spawnTransform.position + offset;
        spawnedList.Insert(collectibleCount, spawnedFallowerArray[collectibleCount]);
        //spawnedFallowerArray[collectibleCount] = spawnedFallower;
        if (collectibleCount == 0)
        {
            Debug.Log("smoot");
            spawnedFallowerArray[collectibleCount].GetComponent<smoothFallower>().currentLeadTransform = this.transform;
        }
        else
        {
            spawnedFallowerArray[collectibleCount].GetComponent<smoothFallower>().currentLeadTransform = spawnedList[collectibleCount - 1].transform;
        }
        collectibleCount++;
    }




    //---------------------functions
    private bool isCalculateScore = true;

    public void winPannelActivate()
    {
        winPannel.SetActive(true);
        if (isCalculateScore) { 
            isCalculateScoreUpdate = true;
            newCapsuleCount = capsuleCount;
            newSphereCount = sphereCount;
            previousTime = Time.time;
        }
    }
    public void losePannelActivate()
    {
        touchPad.instance.isStartMoving = false;
        playerRigidbody.velocity = new Vector3(0,0,0);
        losePannel.SetActive(true);
    }


    /*
    public void calculateScore()
    {
        isCalculateScore = false;
        int newSphereCount = sphereCount;
        int newCapsuleCount = capsuleCount;
        Debug.Log("calculateStart");
        while (newSphereCount > 0)
        {
            Debug.Log("sphereCountStart");
            newSphereCount--;
            scoreCount += 5;
            scoreText.text = "Score:" + scoreCount.ToString();
            sphereText.text = "Sphere:" + newSphereCount.ToString();
        }
        while (newCapsuleCount > 0)
        {
            Debug.Log("capsuleCountStart");
            newCapsuleCount--;
            scoreCount += 10;
            scoreText.text = "Score:" + scoreCount.ToString();
            capsuleText.text = "Capsule:" + newCapsuleCount.ToString();
        }
    }
    */
    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void increaseSphereCount()
    {
        sphereCount++;
        sphereText.text = "Sphere:"+sphereCount.ToString();
    }
    public void decreaseSphereCount()
    {
        if(!(sphereCount==0))sphereCount--;
        spawnTransform.position = spawnTransform.position - offset;
        //spawnedList.RemoveAt(collectibleCount);
        collectibleCount--;
        sphereText.text = "Sphere:" + sphereCount.ToString();
    }
    public void increaseCapsuleCount()
    {
        capsuleCount++;
        capsuleText.text = "Capsule:" + capsuleCount.ToString();
    }
    public void decreaseCapsuleCount()
    {
        if (!(capsuleCount == 0)) capsuleCount--; 
        capsuleText.text = "Capsule:" + capsuleCount.ToString();
    }

    public void lineUp()
    {
        isLineUp = true;
    }

    public void throwPlayer()
    {
        playerRigidbody.velocity=new Vector3(0, generalControl.instance.sphereCount * 100, generalControl.instance.sphereCount * 100);
    }
    //------------------------------
}

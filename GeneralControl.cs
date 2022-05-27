using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GeneralControl : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private GameObject playerGameobject;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private GameObject winPannel;
    [SerializeField] private GameObject losePannel;
    [SerializeField] Text loseText;
    [SerializeField] Text winText;

    [SerializeField] private Transform deadDude1Transform;
    [SerializeField] private Transform deadDude2Transform;
    [SerializeField] private Transform deadDude3Transform;
    [SerializeField] private Transform deadDude4Transform;


    [SerializeField] private Rigidbody deadDude1Rigidbody;
    [SerializeField] private Rigidbody deadDude2Rigidbody;
    [SerializeField] private Rigidbody deadDude3Rigidbody;
    [SerializeField] private Rigidbody deadDude34igidbody;



    bool isStartMoving = false;
    float cubeSpeed = 100f;//Side ways
    float cubeVelocity = 15f;//Forward
    float previousTime;
    [SerializeField] public int collectibleNumber = 0;
    

    //----------To make it accesible
    public static GeneralControl instance;
    private void Awake()
    {
        //Physics.gravity = new Vector3(0, -30, 0);
        instance = this;
    }
    //------------------------------
    //------------Player Movement
    public void OnPointerDown(PointerEventData eventData)
    {
        isStartMoving = true;
        previousTime = Time.time;
    }
    public void OnDrag(PointerEventData eventData)
    {
        playerTransform.position += new Vector3(eventData.delta.x / cubeSpeed, 0, 0);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        
        if (Player.instance.isAvelibleToJump) {
            if (previousTime + 0.3f > Time.time)
            {               
                playerRigidbody.AddForce(0, 400f, 0);
            }
        }
        
        
        
    }
    //----------PlayerMovement End



    private void Update()
    {
        if (isStartMoving)
        { 
            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, playerRigidbody.velocity.y, cubeVelocity); 
        }

        makeObjectsFallow();


        //-------------player dont fall
        Vector3 pos = playerGameobject.transform.position;
        pos.x = Mathf.Clamp(pos.x, -4.50f, 4.50f);
        playerGameobject.transform.position = pos;
        //-------------player dont fall

    }

    //----------Functions
    public void gameWin()
    {
        winPannel.SetActive(true);
        stopMoving();
    }
    public void gameLose()
    {
        Handheld.Vibrate();
        losePannel.SetActive(true);
        stopMoving();
    }
    public void stopMoving()
    {
        cubeVelocity = 0f;
        playerRigidbody.velocity=new Vector3(0,0,0);
    }
    public void reStart()
    {
        SceneManager.LoadScene("Level1");
    }

    public void increaseCollectibleNumber()
    {
        collectibleNumber++;
        winText.text = collectibleNumber.ToString() + " Bodies";
    }

    public void decreaseCollectibleNumber()
    {
        Handheld.Vibrate();
        collectibleNumber--;
        loseText.text = collectibleNumber.ToString() + " Bodies";
    }

    public void loseAllCollectibleNumber()
    {
        Handheld.Vibrate();
        if (collectibleNumber>0)
        {
            collectibleNumber = 0;
            loseText.text = collectibleNumber.ToString() + " Bodies";

        }
        else if (collectibleNumber == 0)
        {
            gameLose();
            stopMoving();
        }
    }


    public void makeObjectsFallow()
    {
        if (collectibleNumber < 0)
        {
            collectibleNumber = 0;
            loseText.text = collectibleNumber.ToString() + " Bodies";
            gameLose();
            stopMoving();
        }
        else if (collectibleNumber == 1)
        {
            deadDude1Transform.position = new Vector3(playerTransform.position.x+0.8f, playerTransform.position.y-0.5f, playerTransform.position.z-1.2f);
        }
        else if (collectibleNumber == 2)
        {
            deadDude1Transform.position = new Vector3(playerTransform.position.x + 0.8f, playerTransform.position.y - 0.5f, playerTransform.position.z - 1.2f);
            deadDude2Transform.position = new Vector3(playerTransform.position.x + 0.8f, playerTransform.position.y , playerTransform.position.z - 1.2f);
        }
        else if (collectibleNumber == 3)
        {
            deadDude1Transform.position = new Vector3(playerTransform.position.x + 0.8f, playerTransform.position.y - 0.5f, playerTransform.position.z - 1.2f);
            deadDude2Transform.position = new Vector3(playerTransform.position.x + 0.8f, playerTransform.position.y, playerTransform.position.z - 1.2f);
            deadDude3Transform.position = new Vector3(playerTransform.position.x + 0.8f, playerTransform.position.y+0.5f, playerTransform.position.z - 1.2f);
        }
        else if (collectibleNumber == 4)
        {
            deadDude1Transform.position = new Vector3(playerTransform.position.x + 0.8f, playerTransform.position.y - 0.5f, playerTransform.position.z - 1.2f);
            deadDude2Transform.position = new Vector3(playerTransform.position.x + 0.8f, playerTransform.position.y, playerTransform.position.z - 1.2f);
            deadDude3Transform.position = new Vector3(playerTransform.position.x + 0.8f, playerTransform.position.y + 0.5f, playerTransform.position.z - 1.2f);
            deadDude4Transform.position = new Vector3(playerTransform.position.x + 0.8f, playerTransform.position.y + 1f, playerTransform.position.z - 1.2f);
        }




    }

    //----------Funclitons End

}



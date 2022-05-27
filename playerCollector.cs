using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollector : MonoBehaviour
{
    public bool isCarrying = false;

    public static playerCollector instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {

        if ((other.tag == "mustard") && (!isCarrying))
        {
            isCarrying = true;
            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 1.5f, other.gameObject.transform.position.z);
        }
        if ((other.tag == "veg") && (!isCarrying))
        {
            Debug.Log("hit the bread");
            isCarrying = true;
            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 1.5f, other.gameObject.transform.position.z);
        }
        if ((other.tag == "bread") && (!isCarrying))
        {
            Debug.Log("hit the bread");
            isCarrying = true;
            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 1.5f, other.gameObject.transform.position.z);
        }
        if ((other.tag == "meat") && (!isCarrying))
        {
            Debug.Log("hit the bread");
            isCarrying = true;
            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 1.5f, other.gameObject.transform.position.z);
        }
        if ((other.tag == "sausage") && (!isCarrying))
        {
            Debug.Log("hit the bread");
            isCarrying = true;
            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 1.5f, other.gameObject.transform.position.z);
        }

        if ((other.tag == "hamburger") && (!isCarrying))
        {
            Debug.Log("hit the bread");
            isCarrying = true;
            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 1.5f, other.gameObject.transform.position.z);
        }


        if ((other.tag == "hotdog") && (!isCarrying))
        {
            Debug.Log("hit the bread");
            isCarrying = true;
            other.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 1.5f, other.gameObject.transform.position.z);
        }



    }
}

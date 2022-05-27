using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    private void OnTriggerEnter(Collider other)
    {
        playerRigidbody.AddForce(0,400f,0);
    }
}

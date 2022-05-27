using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveForward : MonoBehaviour
{
    public static playerMoveForward instance;
    public float speed= 0.0001f;
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (touchPad.instance.isStartMoving)
        {
            transform.position += new Vector3(0,0, speed);
        }
    }
}

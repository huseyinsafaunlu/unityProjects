using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBagMove : MonoBehaviour
{

    public static playerBagMove instance;
    public float speed = 0.1f;
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (touchPad.instance.isStartMoving)
        {
            transform.position += new Vector3(0, 0, speed);
        }

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -4.5f, 4.5f);
        transform.position = pos;
    }

    
}

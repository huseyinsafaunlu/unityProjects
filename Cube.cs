using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{


    [SerializeField] float velocity = 200.0f;
    [SerializeField] float force = 20000.0f;
    public Rigidbody rb;
    bool isJumpPressed;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        /*
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Time.deltaTime * velocity);

        
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector3(-velocity * Time.deltaTime, rb.velocity.y, rb.velocity.z);
            }

            else if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector3(velocity * Time.deltaTime, rb.velocity.y, rb.velocity.z);
            }

            else if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * 200f);
            }
        
        */
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -3.75f, 3.75f);
        transform.position = pos;

        //else rb.velocity = new Vector3(0, 0, 0);
    }
}

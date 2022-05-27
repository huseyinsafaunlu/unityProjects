using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{

    [SerializeField] float velocity = 200.0f;
    public float speed;
    public FloatingJoystick variableJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Time.deltaTime * velocity);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -3.75f, 3.75f);
        transform.position = pos;
    }
}
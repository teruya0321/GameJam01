using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsubasaScriptPlayer : MonoBehaviour
{
    Vector3 moving;
    public float speed;
    public Rigidbody rb;
    public Vector3 movingVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moving = new Vector3(x, 0, z);
        moving.Normalize();
        movingVelocity = moving * speed;

        rb.velocity = new Vector3(movingVelocity.x, rb.velocity.y, movingVelocity.z);
    }
}

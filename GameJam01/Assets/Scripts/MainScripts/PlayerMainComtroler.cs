using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainComtroler : MonoBehaviour
{
    Rigidbody myRb;
    Vector3 tol;
    bool fallDown;
    public GameObject point;
    public float speed = 50;
    bool isGround;
    public bool jumptrigger;
    bool jump;
    BoxCollider baranceCollider;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGround && jump)
        {
            
        }
        if (Input.GetKey(KeyCode.W))
        {
            myRb.velocity = transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            myRb.velocity = transform.forward * -speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            myRb.AddTorque(Vector3.up * Mathf.PI * -50, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            myRb.AddTorque(Vector3.up * Mathf.PI * 50, ForceMode.Force);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }
}

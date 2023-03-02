using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLegComtroler : MonoBehaviour
{
    Rigidbody myRb;
    public GameObject main;
    public bool conect;
    FixedJoint joint;
    Rigidbody mainRb;
    public float speed = 20;
    public bool isGround;
    bool moving;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        joint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGround)
        {
            if (conect)
            {
                Left();
            }
            else
            {
                Right();
            }
        }
        if (!moving)
        {
            //myRb.velocity = Vector3.zero;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            mainRb = collision.gameObject.GetComponent<Rigidbody>();
            joint.connectedBody = mainRb;
        }
        if (collision.gameObject.tag == "Ground")
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
    void Left()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            //myRb.velocity = main.transform.forward * speed;
            Debug.Log("‚Å‚«‚Ä‚é‚æ");
            moving = true;
            myRb.AddForce(transform.forward * 30);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //myRb.velocity = main.transform.forward * speed * -1;
            myRb.AddForce(transform.forward * -30);
            moving = true;
        }
        else
        {
            moving = false;
        }
    }
    void Right()
    {
        if (Input.GetKey(KeyCode.E))
        {
            //myRb.velocity = main.transform.forward * speed;
            moving = true;
            myRb.AddForce(transform.forward * 30);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //myRb.velocity = main.transform.forward * speed * -1;
            moving = true;
            myRb.AddForce(transform.forward * -30);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLegComtroler : MonoBehaviour
{
    Rigidbody myRb;
    public GameObject main;
    bool conect;
    FixedJoint joint;
    Rigidbody mainRb;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        joint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myRb.AddForce(main.transform.forward * 10);
        }
        if (Input.GetKey(KeyCode.S))
        {
            myRb.AddForce(main.transform.forward * -10);
        }
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            joint.connectedBody = null;
        }*/
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            mainRb = collision.gameObject.GetComponent<Rigidbody>();
            joint.connectedBody = mainRb;
        }
    }
}

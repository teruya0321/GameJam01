using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainComtroler : MonoBehaviour
{
    Rigidbody myRb;
    Vector3 tol;
    bool fallDown;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fallDown && Input.GetKeyDown(KeyCode.R))
        {
            transform.position += transform.up * 2;
            transform.localEulerAngles = Vector3.zero;
            fallDown = false;
        }
    }
    private void FixedUpdate()
    {
        //tol = Vector3.zero;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            fallDown = true;
        }
    }
}

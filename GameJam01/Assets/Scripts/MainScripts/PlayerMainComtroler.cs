using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainComtroler : MonoBehaviour
{
    Rigidbody myRb;
    Vector3 tol;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -0.1f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0.1f, 0f);
        }
    }
    private void FixedUpdate()
    {
        //tol = Vector3.zero;
    }
}

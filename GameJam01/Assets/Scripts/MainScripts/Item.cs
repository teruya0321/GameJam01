using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Rigidbody mainRb;
    FixedJoint joint;
    Transform pos;
    public Component sclipt;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<FixedJoint>();
        //gameObject.AddComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            joint.connectedBody = null;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pos = collision.gameObject.transform;
            
            mainRb = collision.gameObject.GetComponent<Rigidbody>();
            joint.connectedBody = mainRb;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScript : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            Debug.Log("b");
            Vector3 force = new Vector3(0, 700, 0);    // óÕÇê›íË
            rb.AddForce(force);  // óÕÇâ¡Ç¶ÇÈ
        }
           
    }
}

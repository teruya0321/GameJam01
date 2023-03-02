using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRotation : MonoBehaviour
{
    public GameObject main;
    Vector3 angle;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //mainTrans = main.gameObject.transform;
        angle = main.transform.localEulerAngles;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            main.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
}

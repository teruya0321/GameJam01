using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Rigidbody myRb;
    Rigidbody mainRb;
    public Behaviour script;
    public string posname;
    GameObject main;
    GameObject posobj;
    FixedJoint fix;
    bool conect = false;
    // Start is called before the first frame update

    private void Awake()
    {
        script.enabled = false;
    }
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        //gameObject.AddComponent<HingeJoint>();
        script.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (conect && Input.GetKeyDown(KeyCode.Space))
        {
            int randomX = Random.Range(-5, 6);
            int randomZ = Random.Range(-5, 6);
            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x + randomX, pos.y + 5, pos.z + randomZ);
            posobj = null;
            Destroy(GetComponent<FixedJoint>());
            script.enabled = false;
            conect = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !conect)
        {
            posobj = GameObject.Find(posname);
            mainRb = collision.gameObject.GetComponent<Rigidbody>();
            gameObject.transform.position = posobj.transform.position;
            gameObject.AddComponent<FixedJoint>();
            fix = GetComponent<FixedJoint>();
            fix.connectedBody = mainRb;
            transform.localEulerAngles = posobj.transform.localEulerAngles;
            script.enabled = true;
            conect = true;
        }
    }
}

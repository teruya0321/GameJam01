using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsubasaGun : MonoBehaviour
{
    public Collider gunCol;
    public Collider gunCol2;

    private bool upGun;
    private bool downGun;

    public GameObject enemy;
    public GameObject shotPoint;
    public GameObject gunBullet;

    public float angle;
    public float bulletSpeed;

    Transform myTransform;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ShotBullet();
        }

        WheelAngle();
    }
    private void ShotBullet()
    {
        Vector3 bulletPos = shotPoint.transform.position;

        GameObject newBall = Instantiate(gunBullet, bulletPos, transform.rotation);

        Vector3 direction = newBall.transform.right * -1;

        newBall.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed, ForceMode.Impulse);

        newBall.name = gunBullet.name;

        Destroy(newBall, 0.8f);   

    }
    private void WheelAngle()
    {
        myTransform = this.transform;

        angle = Input.GetAxis("Mouse ScrollWheel");

        if(downGun)
        {
            Debug.Log("-20");
            myTransform.Rotate(0, 0, angle * 0);
        }
        else
        {
            if (upGun)
            {
                Debug.Log("10");
                myTransform.Rotate(0, 0, angle * 0);
            }
            else
            {
                myTransform.Rotate(0, 0, angle * 10);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == gunCol)
        {
            upGun = true;
        }
        else
        {
           if (other == gunCol2)
           {
               downGun = true;
           }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        upGun = false;
        downGun = false;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            Vector3 enemPos = enemy.transform.up;
            enemy.GetComponent<Rigidbody>().AddForce(enemPos * 5, ForceMode.Impulse);
        }
    }

}

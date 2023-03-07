using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsubasaGun : MonoBehaviour
{
    public static GameObject TsubasaNewBall;

    public static GameObject TsubasaEnemy;
    public GameObject shotPoint;
    public GameObject gunBullet;

    public float bulletSpeed;

    void Start()
    {
        TsubasaEnemy = GameObject.Find("Enemy");
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ShotBullet();
        }
    }
    private void ShotBullet()
    {
        Vector3 bulletPos = shotPoint.transform.position;

        TsubasaNewBall = Instantiate(gunBullet, bulletPos, transform.rotation);

        Vector3 direction = TsubasaNewBall.transform.right * -1;

        TsubasaNewBall.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed, ForceMode.Impulse);

        TsubasaNewBall.name = gunBullet.name;

    }
}

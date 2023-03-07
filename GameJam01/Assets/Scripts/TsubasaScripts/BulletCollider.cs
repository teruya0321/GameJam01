using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Destroy(TsubasaGun.TsubasaNewBall,0.1f);
        }

        if (other.CompareTag("Enemy"))
        {
            Destroy(TsubasaGun.TsubasaEnemy, 0.1f);
        }
    }

}

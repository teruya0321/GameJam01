using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TsubasaScriptEnemy : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    public int distance; //ray‹——£
    void Start()
    {

    }
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 1.0f,Color.red);

        if (Physics.SphereCast(transform.position, 1.0f, transform.forward, out hit, 5.0f,LayerMask.GetMask("Player")))
        {
            Debug.Log("Player‚É“–‚½‚Á‚½");
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward * 1.0f, 1.0f);
    }

}

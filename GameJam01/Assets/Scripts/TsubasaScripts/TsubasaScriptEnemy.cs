using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TsubasaScriptEnemy : MonoBehaviour
{
    public GameObject player;

    private NavMeshAgent navMeshAgent;

    Ray ray;
    RaycastHit hit;

    private float chargeTime;
    private float timeCount;

    public float force;
    public float distance;


    private bool moveEnemy;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); //NavMeshAgent‚ð•ÛŽ
        moveEnemy = true;

        chargeTime = 3;
    }
    void Update()
    {
        //rayPos = transform.position + new Vector3(0, 0, -8);  //Ray‚ÌˆÊ’u
        ray = new Ray(transform.position,transform.forward * distance);
        Debug.DrawRay(transform.position, transform.forward * distance,Color.red);

        if (Physics.Raycast(ray,out hit,distance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                moveEnemy = false;
                Debug.Log("“–‚½‚Á‚½");
                navMeshAgent.destination = player.transform.position;
            }
            else
            {
                moveEnemy = true;
            }
        }
        if (moveEnemy)
        {
            Debug.Log("’T‚µ’†");

            timeCount += Time.deltaTime;
            transform.position += transform.forward * Time.deltaTime;

            if (timeCount > chargeTime)
            {
                Vector3 course = new Vector3(0, UnityEngine.Random.Range(0, 360), 0);
                transform.localRotation = Quaternion.Euler(course);

                timeCount = 0;
            }
        }
    }
    public void OnDestectObject(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            navMeshAgent.destination = collider.transform.position;
            Debug.Log("’Ç‚¢‚©‚¯");
        }
        else
        {
            moveEnemy = true;
        }
    }

}

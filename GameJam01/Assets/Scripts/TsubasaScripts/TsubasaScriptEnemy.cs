using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TsubasaScriptEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject collisionDetector;
    public GameObject collisionBool;

    public GameObject tsubasaSword;
    public GameObject tsubasaHammer;
    public GameObject tsubasaCanon;
    public GameObject tsubasaShovel;

    private NavMeshAgent navMeshAgent;

    Ray ray;
    RaycastHit hit;

    private float chargeTime;
    private float timeCount;

    public float distance;

    private bool rayDistance;
    private bool moveEnemy;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); //NavMeshAgent‚ð•ÛŽ

        rayDistance = true;
        moveEnemy = true;

        chargeTime = 3;

        collisionBool.SetActive(true);
        collisionDetector.SetActive(true);

    }
    void Update()
    {
        //rayPos = transform.position + new Vector3(0, 0, -8);  //Ray‚ÌˆÊ’u

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
                Debug.Log("•Ç‚ª‚ ‚é‚æ‚¤‚¾");
                moveEnemy = true;
                rayDistance = false;

            }

        }
        if (moveEnemy)
        {
            Debug.Log("’T‚µ’†");

            timeCount += Time.deltaTime;
            transform.position += transform.forward * Time.deltaTime;

        }
        if (rayDistance)
        {
            collisionDetector.SetActive(true);
            collisionBool.SetActive(false);
            ray = new Ray(transform.position, transform.forward * distance);
        }
        else
        {
            collisionDetector.SetActive(false);
            collisionBool.SetActive(true);
            ray = new Ray(transform.position, transform.forward * 0);
        }

        if (timeCount > chargeTime)
        {
            Vector3 course = new Vector3(0, UnityEngine.Random.Range(0, 360), 0);
            transform.localRotation = Quaternion.Euler(course);

            timeCount = 0;
        }

    }
    public void OnDestectObject(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            moveEnemy = false;
            //rayDistance = true;
            navMeshAgent.destination = collider.transform.position;
            Debug.Log("’Ç‚¢‚©‚¯");
        }
    }
    public void OnBoolObject(Collider collider)
    {
        if (!collider.CompareTag("Player"))
        {
            moveEnemy = true;
            rayDistance = true;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (tsubasaSword.activeSelf)
            {
                tsubasaSword.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                if (tsubasaHammer.activeSelf)
                {
                    tsubasaHammer.SetActive(false);
                    Destroy(gameObject);
                }
                else
                {
                    if (tsubasaShovel.activeSelf)
                    {
                        Destroy(gameObject);
                        tsubasaShovel.SetActive(false);
                    }
                    else
                    {
                        if (tsubasaCanon.activeSelf)
                        {
                            tsubasaCanon.SetActive(false);
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
    }

}

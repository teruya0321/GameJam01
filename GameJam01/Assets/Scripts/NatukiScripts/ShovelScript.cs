using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelScript : MonoBehaviour
{
    public Collider attackCollider;

    public Animator animator;

    public Rigidbody Shovel;


    void Start()
    {
        animator = GetComponent<Animator>();   //アニメーションを取得する
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(2))//中クリックで攻撃モーション
        {
            Debug.Log("Sho");
            animator.SetBool("Idel", false);
            animator.SetBool("Shovel", true);
            Invoke("Idel", 1);
        }

    }

    void Idel()//Idel状態に移行する
    {
        animator.SetBool("Idel", true);
        animator.SetBool("Shovel", false);
    }
}

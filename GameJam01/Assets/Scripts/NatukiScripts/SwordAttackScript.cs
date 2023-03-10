using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackScript : MonoBehaviour
{
    public Collider attackCollider;

    public Animator animator;

    public Rigidbody Sword;


    void Start()
    {
        animator = GetComponent<Animator>();   //アニメーションを取得する
        animator.SetBool("Idel", true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))//左クリックで攻撃モーション
        {
            Debug.Log("S");
            animator.SetBool("Idel", false);
            animator.SetBool("Attack", true);
            Invoke("Idel", 1);
        }

    }

    void Idel()//Idel状態に移行する
    {
        animator.SetBool("Idel", true);
        animator.SetBool("Attack", false);
    }
}

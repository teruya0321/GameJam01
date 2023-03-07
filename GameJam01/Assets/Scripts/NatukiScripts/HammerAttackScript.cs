using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttackScript : MonoBehaviour
{
    public Collider attackCollider;

    public Animator animator;

    public Rigidbody Hammer;


    void Start()
    {
        animator = GetComponent<Animator>();   //アニメーションを取得する
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))//右クリックで攻撃モーション
        {
            Debug.Log("H");
            animator.SetBool("Idel", false);
            animator.SetBool("Hammer", true);
            Invoke("Idel", 1);
        }

    }

    void Idel()//Idel状態に移行する
    {
        animator.SetBool("Idel", true);
        animator.SetBool("Hammer", false);
    }
}

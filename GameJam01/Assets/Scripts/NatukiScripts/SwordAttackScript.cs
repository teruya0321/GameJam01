using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackScript : MonoBehaviour
{
    public Collider attackCollider;

    public Animator animator;

    public Rigidbody pCube3;


    void Start()
    {
        animator = GetComponent<Animator>();   //アニメーションを取得する
        animator.SetBool("Idel", true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("a");
            animator.SetBool("Idel", false);
            animator.SetBool("Attack", true);//マウスクリックで攻撃モーション
            Invoke("Idel", 1);
        }

    }

    void Idel()
    {
        animator.SetBool("Idel", true);
        animator.SetBool("Attack", false);
    }

    //武器の判定を有効or無効切り替える
    public void OffColliderAttack()
    {
        attackCollider.enabled = false;
    }
    public void OnColliderAttack()
    { 
        attackCollider.enabled = true;
        Debug.Log("a");
    }
}

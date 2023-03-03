using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackScript : MonoBehaviour
{
    public Collider attackCollider;

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();   //アニメーションを取得する
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("a");
            animator.SetBool("Attack",true);  //マウスクリックで攻撃モーション
            animator.SetBool("stop", false);
        }

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

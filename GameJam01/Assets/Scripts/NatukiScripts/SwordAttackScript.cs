using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackScript : MonoBehaviour
{
    public Collider attackCollider;

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();   //�A�j���[�V�������擾����
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("a");
            animator.SetBool("Attack",true);  //�}�E�X�N���b�N�ōU�����[�V����
            animator.SetBool("stop", false);
        }

    }

    //����̔����L��or�����؂�ւ���
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

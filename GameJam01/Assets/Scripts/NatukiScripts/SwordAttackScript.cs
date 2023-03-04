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
        animator = GetComponent<Animator>();   //�A�j���[�V�������擾����
        animator.SetBool("Idel", true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("a");
            animator.SetBool("Idel", false);
            animator.SetBool("Attack", true);//�}�E�X�N���b�N�ōU�����[�V����
            Invoke("Idel", 1);
        }

    }

    void Idel()
    {
        animator.SetBool("Idel", true);
        animator.SetBool("Attack", false);
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

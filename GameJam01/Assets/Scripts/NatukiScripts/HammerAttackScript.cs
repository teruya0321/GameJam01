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
        animator = GetComponent<Animator>();   //�A�j���[�V�������擾����
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))//�E�N���b�N�ōU�����[�V����
        {
            Debug.Log("H");
            animator.SetBool("Idel", false);
            animator.SetBool("Hammer", true);
            Invoke("Idel", 1);
        }

    }

    void Idel()//Idel��ԂɈڍs����
    {
        animator.SetBool("Idel", true);
        animator.SetBool("Hammer", false);
    }
}

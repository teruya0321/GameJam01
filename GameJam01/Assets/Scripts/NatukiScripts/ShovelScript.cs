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
        animator = GetComponent<Animator>();   //�A�j���[�V�������擾����
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(2))//���N���b�N�ōU�����[�V����
        {
            Debug.Log("Sho");
            animator.SetBool("Idel", false);
            animator.SetBool("Shovel", true);
            Invoke("Idel", 1);
        }

    }

    void Idel()//Idel��ԂɈڍs����
    {
        animator.SetBool("Idel", true);
        animator.SetBool("Shovel", false);
    }
}

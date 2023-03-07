using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainComtroler : MonoBehaviour
{
    Rigidbody myRb;
    //������Rigidbody
    public float speed = 50;
    //�L�����̃X�s�[�h �L������5����{�X�s�[�h
    public float jumppower = 100;
    bool isGround;
    //�n�ʂ̐ڒn����
    public bool jumptrigger;
    //�W�����v���ł���悤�ɂȂ������̔���
    public bool swordtrigger;
    //�����擾�����Ƃ��̔���
    public bool hammertrigger;
    //�n���}�[���擾�������̔���
    public bool shoveltrigger;
    //�V���x�����擾�������̔���
    BoxCollider baranceCollider;
    //�L�����̓]�|�h�~�p�̃R���C�_�[ �W�����v����Ƃ���false�ɂ���
    public GameObject sword;
    //���̃I�u�W�F�N�g
    public Behaviour swordScript;
    //���̃X�N���v�g
    public GameObject hammer;
    //�n���}�[�̃I�u�W�F�N�g
    public Behaviour hammerScript;
    //�n���}�[�̃X�N���v�g
    public GameObject shovel;
    //�V���x���̃I�u�W�F�N�g
    public Behaviour shovelScript;
    //�V���x���̃X�N���v�g
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        //Rigidbody�̎擾
        sword.SetActive(false);
        hammer.SetActive(false);
        shovel.SetActive(false);
        //�ŏ��͂��ׂẴA�C�e���𖳌�������
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            jumptrigger = true;
        }
        if ((isGround && jumptrigger) && Input.GetKeyDown(KeyCode.Space))
        {
            myRb.AddForce(transform.up * jumppower, ForceMode.Impulse);
            baranceCollider.enabled = false;
        }
        if (Input.GetKey(KeyCode.W))
        {
            myRb.velocity = transform.forward * speed;
            //�O�i
        }
        if (Input.GetKey(KeyCode.S))
        {
            myRb.velocity = transform.forward * -speed;
            //��i
        }
        if (Input.GetKey(KeyCode.A))
        {
            myRb.AddTorque(Vector3.up * Mathf.PI * -50, ForceMode.Force);
            //����]
        }
        if (Input.GetKey(KeyCode.D))
        {
            myRb.AddTorque(Vector3.up * Mathf.PI * 50, ForceMode.Force);
            //�E��]
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
            //�n�ʂɂ�����bool��true��
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
            //�n�ʂ��痣�ꂽ��bool��false��
            baranceCollider.enabled = true;
        }
    }
}

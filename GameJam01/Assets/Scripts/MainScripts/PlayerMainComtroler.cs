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
    public BoxCollider baranceCollider;
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
        swordScript.enabled = false;
        hammer.SetActive(false);
        hammerScript.enabled = false;
        shovel.SetActive(false);
        shovelScript.enabled = false;
        //�ŏ��͂��ׂẴA�C�e���𖳌�������
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            transform.position = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;
            //�|�W�V�������Z�b�g�p �O�u�������Ă���������
        }
        if (Input.GetKey(KeyCode.P))
        {
            jumptrigger = true;
            //�f�o�b�O�p �W�����v�g���K�[
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            swordtrigger = true;
            //�f�o�b�O�p ���̃g���K�[
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            hammertrigger = true;
            //�f�o�b�O�p �n���}�[�̃g���K�[
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            shoveltrigger = true;
            //�f�o�b�O�p �V���x���̃g���K�[
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            jumptrigger = false;
            swordtrigger = false;
            hammertrigger = false;
            shoveltrigger = false;
            //�f�o�b�O�p �S���̃g���K�[���Z�b�g
        }
        if (isGround)
        {
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
            if(jumptrigger && Input.GetKeyDown(KeyCode.Space))
            {
                myRb.AddForce(transform.up * jumppower, ForceMode.Impulse);
                //�W�����v
                baranceCollider.enabled = false;
                //�o�����X�ێ��p�̃R���C�_�[���ꎞ�I�ɖ���������
            }
        }
        if (swordtrigger)
        {
            sword.SetActive(true);
            swordScript.enabled = true;
            //����L���ɂ���
        }
        else
        {
            sword.SetActive(false);
            swordScript.enabled = false;
            //���𖳌�������
        }
        if (hammertrigger)
        {
            hammer.SetActive(true);
            hammerScript.enabled = true;
            //�n���}�[��L���ɂ���
        }
        else
        {
            hammer.SetActive(false);
            hammerScript.enabled = false;
            //�n���}�[�𖳌�������
        }
        if (shoveltrigger)
        {
            shovel.SetActive(true);
            shovelScript.enabled = true;
            //�V���x����L���ɂ���
        }
        else
        {
            shovel.SetActive(false);
            shovelScript.enabled = false;
            //�V���x���𖳌�������
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

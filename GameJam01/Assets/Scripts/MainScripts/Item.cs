using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemNumber; //�A�C�e���̎�ޔ��ʗp�̕ϐ�
    private void Start()
    {
        // �A�C�e���̃^�O���g���Č��m����
        //�A�C�e���̃^�O��Sword�Ȃ�0�AHammer�Ȃ�1�AShovel�Ȃ�2�ƂȂ�
        if(gameObject.tag == "Sword")
        {
            itemNumber = 0;
        }
        if (gameObject.tag == "Hammer")
        {
            itemNumber = 1;
        }
        if (gameObject.tag == "Shovel")
        {
            itemNumber = 2;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //���������I�u�W�F�N�g���v���C���[�Ȃ�A�v���C���[�̃X�N���v�g���擾����
            PlayerMainComtroler playerScript = collision.gameObject.GetComponent<PlayerMainComtroler>();
            //�ŏ��Ɋ��蓖�Ă��i���o�[�ɉ����āA�L���ɂ���A�C�e����I������
            if (itemNumber == 0)
            {
                playerScript.swordtrigger = true;
            }
            if (itemNumber == 1)
            {
                playerScript.hammertrigger = true;
            }
            if (itemNumber == 0)
            {
                playerScript.shoveltrigger = true;
            }
            //�Ō�Ɍ��ƂȂ����A�C�e��������
            Destroy(gameObject);
        }
    }

}

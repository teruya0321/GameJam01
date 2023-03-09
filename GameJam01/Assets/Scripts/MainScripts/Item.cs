using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemNumber; //アイテムの種類判別用の変数
    private void Start()
    {
        // アイテムのタグを使って検知する
        //アイテムのタグがSwordなら0、Hammerなら1、Shovelなら2となる
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
            //当たったオブジェクトがプレイヤーなら、プレイヤーのスクリプトを取得する
            PlayerMainComtroler playerScript = collision.gameObject.GetComponent<PlayerMainComtroler>();
            //最初に割り当てたナンバーに応じて、有効にするアイテムを選択する
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
            //最後に元となったアイテムを消す
            Destroy(gameObject);
        }
    }

}

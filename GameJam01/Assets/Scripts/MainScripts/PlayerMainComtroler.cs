using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainComtroler : MonoBehaviour
{
    Rigidbody myRb;
    //自分のRigidbody
    public float speed = 50;
    //キャラのスピード 記入時は5が基本スピード
    public float jumppower = 100;
    bool isGround;
    //地面の接地判定
    public bool jumptrigger;
    //ジャンプができるようになったかの判定
    public bool swordtrigger;
    //剣を取得したときの判定
    public bool hammertrigger;
    //ハンマーを取得した時の判定
    public bool shoveltrigger;
    //シャベルを取得した時の判定
    public BoxCollider baranceCollider;
    //キャラの転倒防止用のコライダー ジャンプするときにfalseにする
    public GameObject sword;
    //剣のオブジェクト
    public Behaviour swordScript;
    //剣のスクリプト
    public GameObject hammer;
    //ハンマーのオブジェクト
    public Behaviour hammerScript;
    //ハンマーのスクリプト
    public GameObject shovel;
    //シャベルのオブジェクト
    public Behaviour shovelScript;
    //シャベルのスクリプト
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        //Rigidbodyの取得
        sword.SetActive(false);
        swordScript.enabled = false;
        hammer.SetActive(false);
        hammerScript.enabled = false;
        shovel.SetActive(false);
        shovelScript.enabled = false;
        //最初はすべてのアイテムを無効化する
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            transform.position = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;
            //ポジションリセット用 前置きあってもいいかも
        }
        if (Input.GetKey(KeyCode.P))
        {
            jumptrigger = true;
            //デバッグ用 ジャンプトリガー
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            swordtrigger = true;
            //デバッグ用 剣のトリガー
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            hammertrigger = true;
            //デバッグ用 ハンマーのトリガー
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            shoveltrigger = true;
            //デバッグ用 シャベルのトリガー
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            jumptrigger = false;
            swordtrigger = false;
            hammertrigger = false;
            shoveltrigger = false;
            //デバッグ用 全部のトリガーリセット
        }
        if (isGround)
        {
            if (Input.GetKey(KeyCode.W))
            {
                myRb.velocity = transform.forward * speed;
                //前進
            }
            if (Input.GetKey(KeyCode.S))
            {
                myRb.velocity = transform.forward * -speed;
                //後進
            }
            if (Input.GetKey(KeyCode.A))
            {
                myRb.AddTorque(Vector3.up * Mathf.PI * -50, ForceMode.Force);
                //左回転
            }
            if (Input.GetKey(KeyCode.D))
            {
                myRb.AddTorque(Vector3.up * Mathf.PI * 50, ForceMode.Force);
                //右回転
            }
            if(jumptrigger && Input.GetKeyDown(KeyCode.Space))
            {
                myRb.AddForce(transform.up * jumppower, ForceMode.Impulse);
                //ジャンプ
                baranceCollider.enabled = false;
                //バランス維持用のコライダーを一時的に無効化する
            }
        }
        if (swordtrigger)
        {
            sword.SetActive(true);
            swordScript.enabled = true;
            //剣を有効にする
        }
        else
        {
            sword.SetActive(false);
            swordScript.enabled = false;
            //剣を無効化する
        }
        if (hammertrigger)
        {
            hammer.SetActive(true);
            hammerScript.enabled = true;
            //ハンマーを有効にする
        }
        else
        {
            hammer.SetActive(false);
            hammerScript.enabled = false;
            //ハンマーを無効化する
        }
        if (shoveltrigger)
        {
            shovel.SetActive(true);
            shovelScript.enabled = true;
            //シャベルを有効にする
        }
        else
        {
            shovel.SetActive(false);
            shovelScript.enabled = false;
            //シャベルを無効化する
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
            //地面についたらboolをtrueに
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
            //地面から離れたらboolをfalseに
            baranceCollider.enabled = true;
        }
    }
}

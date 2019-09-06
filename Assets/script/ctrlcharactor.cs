using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ctrlcharactor : MonoBehaviour
{
    // アニメーション
    private Animator anim;

    // 移動・カメラ操作
    float speed;
    private float x, z, y;
    private float cameraX, cameraY;

    // クイックブースト
    public GameObject Boost;
    float BoostTimer;

    // HP系
    public float HP;
    public float MaxHP;

    // EN系
    bool ENflag;

    // 移動をリジッドボディにすれば慣性が生まれるだろうかと思い、やってみた。
    Rigidbody rigid;
    Vector3 cameraForward;
    Vector3 moveForward;

    // HPが減ると表示するやつ
    public GameObject warningObj;
    AudioSource audio;
    bool one;

    //カメラY軸反転
    public bool invertY=false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        Boost.SetActive(false);
        speed = 50f;
        BoostTimer = 0f;
        one = false;

    }

    // Update is called once per frame
    void Update()
    {

        if(HP <= (MaxHP * 0.3f)) {
            warningObj.SetActive(true);
            if(!one) {
                one = true;
                audio.PlayOneShot(audio.clip);
            }
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if(Input.GetAxis("LTrigger") > 0) {
            y = -1;
        } else if(Input.GetButton("L1button")) {
            y = 1;
        } else {
            y = 0;
        }


          // Aボタンを押すとクイックブースト
          // わりとスマートに書けたと自負している
          if(Input.GetButtonDown("Abutton")) {
            if(!ENflag) {
                ENflag = true;
                Boost.SetActive(true);
                speed = 500f;
            }
          }
        if(ENflag) {
            BoostTimer += Time.deltaTime;
            if(BoostTimer >= 0.5f) {
                ENflag = false;
                Boost.SetActive(false);
                speed = 50f;
                BoostTimer = 0f;
            }
        }


        // 右スティックの入力
        cameraX = Input.GetAxis("RightHorizontal");
        cameraY = Input.GetAxis("RightVertical")*(float)(Convert.ToInt32(invertY) * (-2) + 1);

        // カメラの正面をキャラクター移動の座標と合わせる計算がここに詰まってやがる
        cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 1, 1)).normalized;
        moveForward = cameraForward * z * -1 + Camera.main.transform.right * x + Camera.main.transform.up * y;


        // アニメーション処理だ。長いが許してくれ
        if(x == 0 && z == 0 && y == 0) {
          moveForward = Vector3.zero;
        }

        if(x == 0 && z == -1) {
          anim.SetBool("isForward", true);
        } else {
          anim.SetBool("isForward", false);
        }

        if(x == 0 && z == 1) {
          anim.SetBool("isBack", true);
        } else {
          anim.SetBool("isBack", false);
        }

        if(x == 1 && z == 0) {
          anim.SetBool("isRight", true);
        } else {
          anim.SetBool("isRight", false);
        }

        if(x == -1 && z == 0) {
          anim.SetBool("isLeft", true);
        } else {
          anim.SetBool("isLeft", false);
        }

        if(0.2 < x && -0.2 > z) {
          anim.SetBool("isForwardRight", true);
        } else {
          anim.SetBool("isForwardRight", false);
        }

        if(0.2 < x && z > -0.8) {
          anim.SetBool("isBackRight", true);
        } else {
          anim.SetBool("isBackRight", false);
        }

        if(-0.2 > x && z < 0.2) {
          anim.SetBool("isForwardLeft", true);
        } else {
          anim.SetBool("isForwardLeft", false);
        }

        if(-0.8 > x && z > 0.2) {
          anim.SetBool("isBackLeft", true);
        } else {
          anim.SetBool("isBackLeft", false);
        }

        rigid.velocity += moveForward * speed * Time.deltaTime;

        // カメラとともに回転します
        rigid.AddTorque(transform.up * cameraX * Time.deltaTime * 150f);
        rigid.AddTorque(transform.right * -cameraY * Time.deltaTime * 200f);

    }
}

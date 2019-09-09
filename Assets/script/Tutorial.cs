using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{

    // チュートリアル用ステージのスクリプト
    public Image load;
    public Text tutorial1;
    public Text tutorial2;
    public Text tutorial3;
    public Text tutorial4;
    public Text tutorial5;
    public Text tutorial6;

    public GameObject Dummy;

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Enemy5;
    public GameObject Enemy6;
    public GameObject Enemy7;
    public GameObject Enemy8;
    public GameObject Enemy9;
    public GameObject Enemy10;
    public GameObject Enemy11;
    public GameObject Enemy12;

    float Timer;
    bool Clear;
    float ClearTimer;
    bool one;

    RemainingEnemy script;
    GameObject EnemyCountObj;

    public Image Back;
    public Image ClearText;
    public Image FadeOut;
    Animator anim1, anim2, anim3;


    // Start is called before the first frame update
    void Start()
    {
        Timer = 0f;
        ClearTimer = 0f;
        load.enabled = true;
        Clear = false;
        one = false;
        EnemyCountObj = GameObject.Find("Camera/Enemys");
        anim1 = Back.GetComponent<Animator>();
        anim2 = ClearText.GetComponent<Animator>();
        anim3 = FadeOut.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer >= 4f) {
            load.enabled = false;
            tutorial1.enabled = true;
        }
        if(Timer >= 19f) {
            tutorial1.enabled = false;
            load.enabled = true;
        }
        if(Timer >= 21f) {
            load.enabled = false;
            tutorial2.enabled = true;
        }
        if(Timer >= 36f) {
            tutorial2.enabled = false;
            load.enabled = true;
        }
        if(Timer >= 38f) {
            load.enabled = false;
            tutorial3.enabled = true;
            tutorial6.enabled = true;
            if(!one) {
                one = true;
                Instantiate(Dummy, Enemy1.transform.position, Quaternion.identity);
                Instantiate(Dummy, Enemy2.transform.position, Quaternion.identity);
                Instantiate(Dummy, Enemy3.transform.position, Quaternion.identity);
                Instantiate(Dummy, Enemy4.transform.position, Quaternion.identity);
                Instantiate(Dummy, Enemy5.transform.position, Quaternion.identity);
                Instantiate(Dummy, Enemy6.transform.position, Quaternion.identity);
                Instantiate(Dummy, Enemy7.transform.position, Quaternion.identity);
                Instantiate(Dummy, Enemy8.transform.position, Quaternion.identity);
                Instantiate(Dummy, Enemy9.transform.position, Quaternion.identity);
                Instantiate(Dummy, Enemy10.transform.position, Quaternion.identity);
                Instantiate(Dummy, Enemy11.transform.position, Quaternion.identity);
                Instantiate(Dummy, Enemy12.transform.position, Quaternion.identity);
            }
        }
        if(Timer >= 50f) {
            tutorial3.enabled = false;
            tutorial6.enabled = false;
            load.enabled = true;

        }
        if(Timer >= 52f) {
            load.enabled = false;
            tutorial4.enabled = true;
            script = EnemyCountObj.GetComponent<RemainingEnemy>();
            if(script.EnemyCount == 0) {
                Clear = true;
            } else {
                Clear = false;
            }
        }
        if(Clear) {
            ClearTimer += Time.deltaTime;
            tutorial4.enabled = false;
            load.enabled = true;
            if(ClearTimer >= 2f) {
                load.enabled = false;
                tutorial5.enabled = true;
            }
            if(ClearTimer >= 4f) {
                anim1.SetTrigger("Start");
            }
            if(ClearTimer >= 6f) {
                anim2.SetTrigger("Start");
            }
            if(ClearTimer >= 9f) {
                anim3.SetTrigger("Start");
            }
            if(ClearTimer >= 11f) {
                SceneManager.LoadScene("Stage2");
            }
        }

    }
}

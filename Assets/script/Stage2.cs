using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage2 : MonoBehaviour
{

    float Timer, EndTimer;
    bool Clear, Failed;

    RemainingEnemy script;
    ctrlcharactor script1;
    GameObject EnemyCountObj;
    GameObject PlayerObj;

    public Text info1, info2, info3;

    public GameObject EnemyGroup1, EnemyGroup2, Boss;
    public GameObject point1, point2, point3;

    public Image Back, ClearText, FadeOut, failedText;
    Animator anim1, anim2, anim3, anim4;

    bool one1, one2;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.Find("player");
        EnemyCountObj = GameObject.Find("Camera/Enemys");
        Timer = 0f;
        EndTimer = 0f;
        one1 = false;
        one2 = false;
        Clear = false;
        Failed = false;
        anim1 = Back.GetComponent<Animator>();
        anim2 = ClearText.GetComponent<Animator>();
        anim3 = FadeOut.GetComponent<Animator>();
        anim4 = failedText.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        script1 = PlayerObj.GetComponent<ctrlcharactor>();
        script = EnemyCountObj.GetComponent<RemainingEnemy>();

        if(script1.HP <= 0) {
            FailedEvent();
        }
        if(Timer >= 30f) {
            if(!one1) {
                one1 = true;
                Wave2();
            }
        }
        if(Timer >= 60f) {
            if(!one2) {
                one2 = true;
                Wave3();
            }
            if(script.EnemyCount == 0) {
                ClearEvent();
            }
        }
    }

    void Wave2()
    {
        info1.enabled = false;
        info2.enabled = true;
        Instantiate(EnemyGroup1, point1.transform.position, Quaternion.identity);
        Instantiate(EnemyGroup2, point2.transform.position, Quaternion.identity);
    }

    void Wave3()
    {
        info2.enabled = false;
        info3.enabled = true;
        Instantiate(Boss, point3.transform.position, Quaternion.identity);
    }

    void ClearEvent()
    {
        EndTimer += Time.deltaTime;
        anim1.SetTrigger("Start");
        if(EndTimer >= 2f) {
            anim2.SetTrigger("Start");
        }
        if(EndTimer >= 5f) {
            anim3.SetTrigger("Start");
        }
        if(EndTimer >= 7f) {
            SceneManager.LoadScene("Stage3");
        }
    }

    void FailedEvent()
    {
        EndTimer += Time.deltaTime;
        anim1.SetTrigger("Start");
        if(EndTimer >= 2f) {
            anim4.SetTrigger("Start");
        }
        if(EndTimer >= 5f) {
            anim3.SetTrigger("Start");
        }
        if(EndTimer >= 7f) {
            SceneManager.LoadScene("StageSelect");
        }
    }

}

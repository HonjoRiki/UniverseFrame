using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage4 : MonoBehaviour
{

    RemainingEnemy script;
    ctrlcharactor script1;
    GameObject EnemyCountObj;
    GameObject PlayerObj;

    bool Clear;
    bool Failed;

    float EndTimer;
    float Timer;

    public Image Back;
    public Image ClearText;
    public Image failedText;
    public Image FadeOut;
    Animator anim1, anim2, anim3, anim4;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.Find("player");
        EnemyCountObj = GameObject.Find("Camera/Enemys");
        anim1 = Back.GetComponent<Animator>();
        anim2 = ClearText.GetComponent<Animator>();
        anim3 = FadeOut.GetComponent<Animator>();
        anim4 = failedText.GetComponent<Animator>();
        Clear = false;
        Failed = false;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        script1 = PlayerObj.GetComponent<ctrlcharactor>();
        script = EnemyCountObj.GetComponent<RemainingEnemy>();

        if(script1.HP <= 0f) {
            Failed = true;
        } else {
            Failed = false;
        }

        if(Timer >= 1f) {
            if(script.EnemyCount == 0) {
                Game.StageClearFrag[3] = true;
                Clear = true;
            } else {
                Clear = false;
            }
        }


        if(Clear) {
            EndTimer += Time.deltaTime;
            anim1.SetTrigger("Start");
            if(EndTimer >= 2f) {
                anim2.SetTrigger("Start");
            }
            if(EndTimer >= 5f) {
                anim3.SetTrigger("Start");
            }
            if(EndTimer >= 7f) {
                SceneManager.LoadScene("EndRoll");
            }
        }

        if(Failed) {
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlLockonTrigger : MonoBehaviour
{

    private float trigger;
    public HashSet<GameObject> EnemyList = new HashSet<GameObject>();

    // 敵のスクリプトを操作するためのやつ
    ctrlEnemy script;
    DummyEnemy script2;


    // レーザー発射用
    public GameObject playerBullet;
    public GameObject playerNormalBullet;
    public GameObject shotPoint;
    public float shotTime;
    public float MaxShotTime;
    private float NormalLazerShotTtime;

    playerBullet script1;
    NormalBullet script3;

    // レーザー効果音
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip ChageComp;
    private AudioSource LaserSound;
    bool LockOnSound;
    bool NormalSound;

    // Start is called before the first frame update
    void Start()
    {
        shotTime = 0f;
        LaserSound = GetComponent<AudioSource>();
        LockOnSound = false;
        NormalSound = false;
    }

    // Update is called once per frame
    void Update()
    {
        shotTime += Time.deltaTime;

        if(Input.GetButtonDown("R1button")) {
            Instantiate(playerNormalBullet, shotPoint.transform.position, Quaternion.identity);
            LaserSound.PlayOneShot(sound1);
        }
        if(Input.GetButton("R1button")) {
            NormalLazerShotTtime += Time.deltaTime;
            if(NormalLazerShotTtime >= 0.3f) {
                Instantiate(playerNormalBullet, shotPoint.transform.position, Quaternion.identity);
                if(!NormalSound) {
                    NormalSound = true;
                    LaserSound.PlayOneShot(sound1);
                }
                NormalLazerShotTtime = 0f;
                NormalSound = false;
            }
        }

        if(EnemyList != null) {
            if(shotTime >= MaxShotTime) {
                if(Input.GetAxis("RTrigger") > 0) {
                    foreach(GameObject go in EnemyList) {
                        if(go != null) {
                            GameObject bullet = Instantiate(playerBullet, shotPoint.transform.position, Quaternion.identity) as GameObject;
                            script1 = bullet.GetComponent<playerBullet>();
                            script1.target = go.transform;
                            if(!LockOnSound) {
                                LockOnSound = true;
                                LaserSound.PlayOneShot(sound2);
                            }
                            shotTime = 0f;
                            }
                        }
                    LockOnSound = false;
                }
            }

        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy") {
            script = other.gameObject.GetComponent<ctrlEnemy>();
            script.IsList = true;
            EnemyList.Add(other.gameObject);
        }

        if(other.tag == "Dummy") {
            script2 = other.gameObject.GetComponent<DummyEnemy>();
            script2.IsList = true;
            EnemyList.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy") {
            script = other.gameObject.GetComponent<ctrlEnemy>();
            script.IsList = false;
        }

        if(other.tag == "Dummy") {

            script2 = other.gameObject.GetComponent<DummyEnemy>();
            script2.IsList = false;
        }
    }
}

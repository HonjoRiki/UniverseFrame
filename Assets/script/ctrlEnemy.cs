﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlEnemy : MonoBehaviour
{

  public bool lockOnfalg = false;
  public bool IsList = false;
  public GameObject lockonCanvas;

  public GameObject Bullet;

  private float shotTime;

  public float HP;
  public GameObject shotPos;

  CtrlLockonTrigger script;
  GameObject listData;

  float ExitTimer;

  public GameObject ExplosionObj;
  bool one;

    // Start is called before the first frame update
    void Start()
    {
        one = false;
        ExitTimer = 0f;
        shotTime = 0f;
        listData = GameObject.Find("Camera/Cube");
    }

    // Update is called once per frame
    void Update()
    {
        script = listData.GetComponent<CtrlLockonTrigger>();
        if(!IsList) {
            ExitTimer += Time.deltaTime;
            if(ExitTimer >= 2f) {
                lockOnfalg = false;
                script.EnemyList.Remove(this.gameObject);
                ExitTimer = 0f;
            }
        } else {
            lockOnfalg = true;
            ExitTimer = 0f;
        }
        shotTime += Time.deltaTime;

        if(shotTime >= Random.Range(1f, 3f)) {
            Instantiate(Bullet, shotPos.transform.position, Quaternion.identity);
            shotTime = 0f;
        }

        if(HP < 0) {
            if(!one) {
                one = true;
                Instantiate(ExplosionObj, transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }

        if(lockOnfalg) {
          lockonCanvas.SetActive(true);
        } else {
          lockonCanvas.SetActive(false);
        }
    }
}
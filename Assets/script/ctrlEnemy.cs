using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlEnemy : MonoBehaviour
{

  public bool LockOnFrag = false;
  public bool IsList = false;
  public GameObject lockonCanvas;

  public GameObject Bullet;

  private float shotTime;

  public float HP;
  public GameObject shotPos;

  CtrlLockonTrigger script;
  GameObject listData;

  float ExitTimer;

  public GameObject ExplosionObj1;
  public GameObject ExplosionObj2;
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
                LockOnFrag = false;
                script.EnemyList.Remove(this.gameObject);
                ExitTimer = 0f;
            }
        } else {
            LockOnFrag = true;
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
                Instantiate(ExplosionObj1, transform.position, Quaternion.identity);
                Instantiate(ExplosionObj2, transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }

        if(LockOnFrag) {
          lockonCanvas.SetActive(true);
        } else {
          lockonCanvas.SetActive(false);
        }
    }
}

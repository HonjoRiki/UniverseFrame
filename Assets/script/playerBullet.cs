using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{

    private float BulletLife;

    Vector3 bulletSpeed;

    public Transform target;

    Rigidbody rigid;
    float period = 1f;

    ctrlEnemy script;
    DummyEnemy script2;
    CtrlLockonTrigger script1;
    GameObject script1Obj;

    MeshRenderer MR;
    TrailRenderer TR;

    bool isDestroying = false;
    float destroyStartTime = 0f;
    const float DESTROY_PERIOD = 1f;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        script1Obj = GameObject.Find("Camera/Cube");
        MR = GetComponent<MeshRenderer>();
        TR = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null) {
            Vector3 acceleration = Vector3.zero;

            var diff = target.position - transform.position;

            acceleration = (diff - bulletSpeed * period) * 2f / (period * period);

            /*
            if(acceleration.magnitude > 100f) {
                acceleration = acceleration.normalized * 100f;
            }
            */



            period -= Time.deltaTime;

            bulletSpeed += acceleration * Time.deltaTime;
        }
        BulletLife += Time.deltaTime;

        if(isDestroying == false && BulletLife >= 2f) {
            StartDestroy();
        }

        if(isDestroying) {
            float transparent = 1f - (BulletLife - destroyStartTime) / DESTROY_PERIOD;
            Color mc = MR.material.color;
            Color tc = TR.material.color;
            MR.material.color = new Color(mc.r, mc.g, mc.b, transparent);
            TR.material.color = new Color(tc.r, tc.g, tc.b, transparent);
            if(BulletLife > destroyStartTime + DESTROY_PERIOD) {
                Destroy(this.gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        rigid.MovePosition(transform.position + bulletSpeed * Time.deltaTime);
    }

    private void StartDestroy()
    {
        isDestroying = true;
        destroyStartTime = BulletLife;
    }

    void OnTriggerEnter(Collider obj)
    {
        if(obj.tag == "Enemy") {
            StartDestroy();
            bulletSpeed = Vector3.zero;
            script1 = script1Obj.gameObject.GetComponent<CtrlLockonTrigger>();
            script1.EnemyList.Remove(obj.gameObject);
            script = obj.gameObject.GetComponent<ctrlEnemy>();
            script.HP -= 10f;
        }
        if(obj.tag == "Dummy") {
            StartDestroy();
            bulletSpeed = Vector3.zero;
            script1 = script1Obj.gameObject.GetComponent<CtrlLockonTrigger>();
            script1.EnemyList.Remove(obj.gameObject);
            script2 = obj.gameObject.GetComponent<DummyEnemy>();
            script2.HP -= 10f;
        }
    }
}

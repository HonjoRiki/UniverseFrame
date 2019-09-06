using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{

    private float BulletLife;
    public float BulletSpeed;

    Rigidbody rigid;

    ctrlEnemy script;
    DummyEnemy script2;

    MeshRenderer MR;
    TrailRenderer TR;

    bool isDestroying = false;
    float destroyStartTime = 0f;
    const float DESTROY_PERIOD = 1f;

    Vector3 Forward;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        MR = GetComponent<MeshRenderer>();
        TR = GetComponent<TrailRenderer>();
        Forward = Camera.main.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        rigid.MovePosition(transform.position + Forward * BulletSpeed * Time.deltaTime);

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

    private void StartDestroy()
    {
        isDestroying = true;
        destroyStartTime = BulletLife;
    }

    void OnTriggerEnter(Collider obj)
    {
        if(obj.tag == "Enemy") {
            StartDestroy();
            BulletSpeed = 0f;
            script = obj.gameObject.GetComponent<ctrlEnemy>();
            script.HP -= 10f;
        }
        if(obj.tag == "Dummy") {
            StartDestroy();
            BulletSpeed = 0f;
            script2 = obj.gameObject.GetComponent<DummyEnemy>();
            script2.HP -= 10f;
        }
    }
}

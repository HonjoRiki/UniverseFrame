using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public GameObject target;

    public float bulletSpeed;
    Vector3 targetVector;

    float BulletLife = 0f;
    ctrlcharactor script;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("player");
        targetVector = (target.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += targetVector * bulletSpeed * Time.deltaTime;

        BulletLife += Time.deltaTime;
        if(BulletLife >= 3f) {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision obj)
    {
        if(obj.gameObject.tag == "Player") {

            script = obj.gameObject.GetComponent<ctrlcharactor>();
            script.HP -= 10f;
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerminus : MonoBehaviour
{
    public float speed=5.0f;//移動スピード
    //public 個体識別番号
    private float[] gpu;

    // Start is called before the first frame update
    void Start()
    {
       gpu= GameObject.Find("ENEMY_DRIVER").GetComponent<OperateCompute>().GPUoutput;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        transform.forward = new Vector3(gpu[0], gpu[1], gpu[2]);
        transform.position = new Vector3(gpu[4], gpu[5], gpu[6]);
       // transform.position += transform.forward * speed;
    }
}

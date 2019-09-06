using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerminal : MonoBehaviour
{
    private int number;
    private float[] gpu;

    // Start is called before the first frame update
    void Start()
    {
        gpu = GameObject.Find("ENEMY_DRIVER").GetComponent<W0P1>().GPUoutput;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.forward = new Vector3(gpu[8*number+0], gpu[8 * number+1], gpu[8 * number+2]);
        transform.position = new Vector3(gpu[8 * number+4], gpu[8 * number+5], gpu[8 * number+6]);
        // transform.position += transform.forward * speed;
    }

    public void setNumber(int num) { this.number = num; }
}

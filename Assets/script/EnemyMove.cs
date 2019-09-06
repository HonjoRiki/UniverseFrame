using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    GameObject playerObj;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("player");
        speed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector3.Distance(playerObj.transform.position, transform.position) >= 100)) {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}

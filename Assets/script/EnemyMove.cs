using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    GameObject playerObj;
    public float MoveSpeed;
    public float DistanceToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector3.Distance(playerObj.transform.position, transform.position) >= DistanceToPlayer)) {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
    }
}

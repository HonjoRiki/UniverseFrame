using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingEnemy : MonoBehaviour
{

    public Text remaining;
    public int EnemyCount;

    GameObject[] tagObjects;
    GameObject[] dummys;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tagObjects = GameObject.FindGameObjectsWithTag("Enemy");
        dummys = GameObject.FindGameObjectsWithTag("Dummy");
        EnemyCount = tagObjects.Length + dummys.Length;
        remaining.text = EnemyCount.ToString();
    }
}

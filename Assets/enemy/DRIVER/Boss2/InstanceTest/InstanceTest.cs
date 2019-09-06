using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceTest : MonoBehaviour
{
    private int number;

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("Instance "+this.GetInstanceID());
        Debug.Log("Instance " + this.number);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setNumber(int num)
    {
        this.number = num;
    }
}

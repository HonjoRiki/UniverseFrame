using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotZ = Quaternion.AngleAxis(10.0f * Time.deltaTime, transform.forward);
        Quaternion newRotation = rotZ * transform.rotation;
        transform.rotation = newRotation;
    }
}

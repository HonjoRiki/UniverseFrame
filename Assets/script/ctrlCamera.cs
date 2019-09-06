using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlCamera : MonoBehaviour
{
  public GameObject playerObj;
  public GameObject prevObj;
  Vector3 prevPlayerPos;

  public float cameraSpeed;

    // Start is called before the first frame update
    void Start()
    {
        prevPlayerPos = prevObj.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp (
            this.transform.position,
            prevPlayerPos,
            cameraSpeed * Time.deltaTime
        );
        Transform target = playerObj.transform;
        transform.localRotation = target.localRotation;

        prevPlayerPos = prevObj.transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlOffset : MonoBehaviour
{
    public GameObject targetObj;
    Vector3 targetPos;
    float cameraX, cameraY;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = targetObj.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
      // 右スティックの入力
      cameraX = Input.GetAxis("RightHorizontal");
      cameraY = Input.GetAxis("RightVertical");

      // カメラ回転処理
      transform.RotateAround(targetPos, Vector3.up, cameraX * Time.deltaTime * 200f);
      transform.RotateAround(targetPos, transform.right, -cameraY * Time.deltaTime * 200f);

      transform.position += targetObj.transform.position - targetPos;

      targetPos = targetObj.transform.position;
    }
}

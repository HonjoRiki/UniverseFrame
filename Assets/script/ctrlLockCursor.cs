using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ctrlLockCursor : MonoBehaviour
{

    public Image LockOn;
    public Text LockOnText;

    float LTrigger;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LTrigger = Input.GetAxis("LTrigger");

        if(LTrigger > 0) {
          LockOn.enabled = true;
          LockOnText.enabled = true;
        } else {
          LockOn.enabled = false;
          LockOnText.enabled = false;
        }
    }
}

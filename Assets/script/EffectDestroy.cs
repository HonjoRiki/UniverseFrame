using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroy : MonoBehaviour
{

    float DeleteTimer;
    bool one;

    // Start is called before the first frame update
    void Start()
    {
        DeleteTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        DeleteTimer += Time.deltaTime;
        if(DeleteTimer >= 3f) {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlExplosion : MonoBehaviour
{

    float DeleteTimer;
    AudioSource audio;
    bool one;
    // Start is called before the first frame update
    void Start()
    {
        DeleteTimer = 0f;
        one = false;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!one) {
            one = true;
            audio.PlayOneShot(audio.clip);
        }
        DeleteTimer += Time.deltaTime;
        if(DeleteTimer >= 2f) {
            Destroy(this.gameObject);
        }
    }
}

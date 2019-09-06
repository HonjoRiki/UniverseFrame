using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndRoll : MonoBehaviour
{

    public Image StaffText;
    Animation anim;
    float Timer;
    bool one;

    AudioSource audio;
    bool skip;
    float SkipTimer;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        anim = StaffText.GetComponent<Animation>();
        Timer = 0;
        one = false;
        skip = false;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer >= 2f) {
            StaffText.enabled = true;
        }
        
        if(Timer >= 4f) {
            if(!one) {
                one = true;
                anim.Play();

            }
        }

        if(Input.GetButtonDown("Abutton")) {
            audio.PlayOneShot(audio.clip);
            skip = true;
        }

        if(skip) {
            SkipTimer += Time.deltaTime;
            if(SkipTimer >= 1f) {
                SceneManager.LoadScene("Title");
            }
        }
    }
}

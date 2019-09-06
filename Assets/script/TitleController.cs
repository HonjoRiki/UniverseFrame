using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{

  public Image img1;
  public Image img2;
  public Image img3;
  public Text text;
  public Image img4;

  Animator anim1;
  Animator anim2;
  Animator anim3;
  Animator anim4;
  Animator anim5;

  AudioSource audio;
  float StartTimer = 0f;
  bool StartFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        anim1 = img1.GetComponent<Animator>();
        anim2 = img2.GetComponent<Animator>();
        anim3 = img3.GetComponent<Animator>();
        anim4 = text.GetComponent<Animator>();
        anim5 = img4.GetComponent<Animator>();

        audio = GetComponent<AudioSource>();

        StartCoroutine("Title");
    }

    void Update()
    {
        if(Input.GetButtonDown("Abutton")) {
            audio.PlayOneShot(audio.clip);
            anim5.SetTrigger("Start");
            StartFlag = true;
        }
        if(StartFlag) {
            StartTimer += Time.deltaTime;
            if(StartTimer >= 2f) {
                SceneManager.LoadScene("Stage1");
            }
        }
    }

    // Update is called once per frame
    private IEnumerator Title() {
      yield return new WaitForSeconds(1.0f);

      anim1.SetTrigger("Start");

      yield return new WaitForSeconds(2.0f);

      anim2.SetTrigger("Start");

      yield return new WaitForSeconds(3.0f);

      anim3.SetTrigger("Start");

      yield return new WaitForSeconds(4.0f);

      anim4.SetTrigger("Start");
    }
}

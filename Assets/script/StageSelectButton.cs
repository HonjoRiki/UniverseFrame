using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    public Text ClearText1;
    public Text ClearText2;
    public Text ClearText3;
    public Text ClearText4;
    public Text ThanksText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Game.StageClearFrag[0]) {
            ClearText1.enabled = true;
        } else {
            ClearText1.enabled = false;
        }

        if(Game.StageClearFrag[1]) {
            ClearText2.enabled = true;
        } else {
            ClearText2.enabled = false;
        }

        if(Game.StageClearFrag[2]) {
            ClearText3.enabled = true;
        } else {
            ClearText3.enabled = false;
        }

        if(Game.StageClearFrag[3]) {
            ClearText4.enabled = true;
        } else {
            ClearText4.enabled = false;
        }

        if(Game.StageClearFrag[0] && Game.StageClearFrag[1] && Game.StageClearFrag[2] && Game.StageClearFrag[3]) {
            ThanksText.enabled = true;
        } else {
            ThanksText.enabled = false;
        }
    }

    public void OnClick(int id)
    {
        switch(id) {
            case 0:
                SceneManager.LoadScene("Stage1");
                break;
            case 1:
                SceneManager.LoadScene("Stage2");
                break;
            case 2:
                SceneManager.LoadScene("Stage3");
                break;
            case 3:
                SceneManager.LoadScene("Stage4");
                break;
        }
    }
}

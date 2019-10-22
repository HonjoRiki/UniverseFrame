using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{

    public Image Blue;
    public Image Red;
    CtrlLockonTrigger LockonScript;

    // Start is called before the first frame update
    void Start()
    {
        LockonScript = GameObject.Find("Camera/Cube").GetComponent<CtrlLockonTrigger>();
        initParameter();
    }

    // Update is called once per frame
    void Update()
    {
        if(LockonScript.shotTime >= LockonScript.MaxShotTime) {
            Blue.fillAmount = LockonScript.MaxShotTime * 0.03f;
        } else {
            Blue.fillAmount = LockonScript.shotTime / LockonScript.MaxShotTime * 0.3f;
        }
    }

    private void initParameter()
    {
        Blue.fillAmount *= 0.3f;
        Red.fillAmount *= 0.3f;
    }

}

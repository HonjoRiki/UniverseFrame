using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonCtrl : MonoBehaviour
{

  private GameObject currentButton;

  public Image Line1;
  public Image Line2;
  public Image Line3;
  public Image Line4;
  public Image Line5;
  public Image Line6;
  public Image Line7;
  public Image Line8;

    // Start is called before the first frame update
    void Start()
    {
      currentButton = EventSystem.current.currentSelectedGameObject;

    }

    // Update is called once per frame
    void Update()
    {
        currentButton = EventSystem.current.currentSelectedGameObject;

        if(currentButton.gameObject.name == "Stage1") {
          Line1.enabled = true;
          Line2.enabled = true;
        } else {
          Line1.enabled = false;
          Line2.enabled = false;
        }

        if(currentButton.gameObject.name == "Stage2") {
          Line3.enabled = true;
          Line4.enabled = true;
        } else {
          Line3.enabled = false;
          Line4.enabled = false;
        }

        if(currentButton.gameObject.name == "Stage3") {
          Line5.enabled = true;
          Line6.enabled = true;
        } else {
          Line5.enabled = false;
          Line6.enabled = false;
        }

        if(currentButton.gameObject.name == "Stage4") {
          Line7.enabled = true;
          Line8.enabled = true;
        } else {
          Line7.enabled = false;
          Line8.enabled = false;
        }
    }
}

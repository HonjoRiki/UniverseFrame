using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ctrlHP : MonoBehaviour
{

  private ctrlcharactor player;
  public Image Green;
  public Image Red;

  public float MaxHP_Limit;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ctrlcharactor>();
        initParameter();
    }

    // Update is called once per frame
    void Update()
    {
        Green.fillAmount = player.HP / player.MaxHP * 0.45f;
    }

    private void initParameter()
    {
        Green.fillAmount *= 0.45f;
        Red.fillAmount *= 0.45f;
    }
}

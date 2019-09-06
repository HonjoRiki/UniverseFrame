using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_DRIVER : MonoBehaviour
{
    public float speed = 2.0F;
    public float spin = 9.0F;
    public float senkai = 4.5F;

    private float x=0.0F, y=0.0F, z=0.0F;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow)) { x = spin; }
        else if (Input.GetKey(KeyCode.DownArrow)) { x = -spin; }
        else { x = 0.0F; }

        if (Input.GetKey(KeyCode.W)) { y = senkai; }
        else if (Input.GetKey(KeyCode.Q)) { y = -senkai; }
        else { y = 0.0F; }

        if (Input.GetKey(KeyCode.LeftArrow)) { z = spin; }
        else if (Input.GetKey(KeyCode.RightArrow)) { z = -spin; }
        else { z = 0.0F; }

        this.transform.Rotate(x,y,z,Space.Self);
        this.transform.position += this.transform.forward* speed;
    }
}

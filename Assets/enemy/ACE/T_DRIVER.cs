using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_DRIVER : MonoBehaviour
{
    private float speed = 2.0F;

    public Texture2D pattern;

    private Color[] data;

    // Start is called before the first frame update
    void Start()
    {
        data = pattern.GetPixels(0);

        Debug.Log("r"+data[0].b);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position += new Vector3(data[0].r, data[0].g, data[0].b) *speed;
    }
}

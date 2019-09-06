using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W0P1 : MonoBehaviour
{
    /// <summary>
    /// vec3はvec4へ
    /// 方向、位置の順番
    /// </summary>

    const int size =6;
    public GameObject prefab;
    private GameObject player;

    ///////準備
    public  ComputeShader setPos;//シェーダ
    private int setPos_k;//カーネル
    private ComputeBuffer output;//出力バッファ
    ///////////

    ///////
    public ComputeShader pattern1;
    private int p1;
    private ComputeBuffer input;

    [System.NonSerialized] public float[] GPUoutput = new float[size*8];
    private float[] plyData;
    ///////


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            GameObject insta = Instantiate(prefab) as GameObject;
            insta.GetComponent<EnemyTerminal>().setNumber(i);
        }

        setPos_k = setPos.FindKernel("main");
        output = new ComputeBuffer(size, sizeof(float) * 8);
        setPos.SetBuffer(setPos_k,"Result",output);
        setPos.Dispatch(setPos_k, size, 1, 1);

        p1=pattern1.FindKernel("main");
        pattern1.SetBuffer(p1,"Result",output);
        input = new ComputeBuffer(2, sizeof(float) * 4);
        pattern1.SetBuffer(p1,"player",input);

        player=GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        plyData = new float[] {player.transform.position.x, player.transform.position.y, player.transform.position.z,0.0F,
                                player.transform.forward.x,player.transform.forward.y,player.transform.forward.z,0.0F};
        input.SetData(plyData);

        pattern1.Dispatch(p1,size,1,1);

        output.GetData(GPUoutput);

    }

    void OnApplicationQuit()
    {
        output.Release();
        input.Release();
    }
}

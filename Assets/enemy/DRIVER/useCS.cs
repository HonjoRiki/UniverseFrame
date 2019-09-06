using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useCS : MonoBehaviour
{

    public ComputeShader cs;//コンピュートシェーダ
    private int shader_kanel;

    private ComputeBuffer cb;//コンピュートバッファ
    private ComputeBuffer uniformCB;//ユニフォーム変数の代わり


    // Start is called before the first frame update
    void Start()
    {
        shader_kanel = cs.FindKernel("main");

        cb = new ComputeBuffer(1, sizeof(int));
        cs.SetBuffer(shader_kanel, "Result", cb);

        int[] spsp = { 10 };
        uniformCB = new ComputeBuffer(1,sizeof(int));
        uniformCB.SetData(spsp);
        cs.SetBuffer(shader_kanel, "spsp", uniformCB);
        int temp = 5;
        cs.SetInt( "intTest", temp);////

        cs.Dispatch(shader_kanel, 1, 1, 1);

        int[] picUP = new int[1];
        cb.GetData(picUP);
        Debug.Log("CSout"+picUP[0]);
    }

    void OnApplicationQuit()
    {
        cb.Release();
        uniformCB.Release();
    }
}

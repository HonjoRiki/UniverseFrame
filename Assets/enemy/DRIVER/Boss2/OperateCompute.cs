using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperateCompute : MonoBehaviour
{/// <summary>
/// vec3は本家と同じで不可能 vec4を用いよ
/// 共有のやつの変更が反映されているか注意
/// </summary>
    private GameObject player;

    // //シェーダ01
    public ComputeShader cs;//シェーダ
    private int kernel;//カーネル

    private ComputeBuffer Result;//バッファ(出力)
   [System.NonSerialized] public float[] GPUoutput= new float[8];//ResultのCPU側

    private ComputeBuffer playerData;//バッファ(入力:プレイヤー情報)
    private float[] plyData;//playerDataのCPU側
    // //////


    // Start is called before the first frame update
    void Start()
    {
        kernel = cs.FindKernel("main");//カーネル取得
        Result = new ComputeBuffer(2,sizeof(float)*4);//バッファ実体化(vec3*2)
        cs.SetBuffer(kernel,"Result",Result);//シェーダーにバッファセット
        float[] test = new float[] { 0.0f, 0.0f, 0.0f,0.0f,0.0f, 0.0f, 0.0f, 0.0f};
        Result.SetData(test);
        playerData = new ComputeBuffer(2, sizeof(float) * 3);//バッファ実体化(vec3*2)
        cs.SetBuffer(kernel, "playerData", playerData);//シェーダーにセット

        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        plyData = new float[] {player.transform.position.x, player.transform.position.y, player.transform.position.z,
                                player.transform.forward.x,player.transform.forward.y,player.transform.forward.z};
        playerData.SetData(plyData);

        cs.Dispatch(kernel,1,1,1);//演算実行

        Result.GetData(GPUoutput);//値取り出し
    }

    //終了時バッファ開放
    void OnApplicationQuit()
    {
        playerData.Release();
        Result.Release();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldOperateCompute : MonoBehaviour
{
    public float speed=1.0f;//移動スピード

    public ComputeShader cs;//コンピュートシェーダ
    private int shader_kanel;

    private ComputeBuffer cb;//コンピュートバッファ
    private ComputeBuffer uniformCB;//ユニフォーム変数の代わり1
    private ComputeBuffer uniformCB2;//ユニフォーム変数の代わり2

    private GameObject player;////プレイヤー機

    private float[] plyPos;//敵機位置転送用
    private float[] myPos;//自機位置転送用

    public float[] GPUoutput=new float[3];//compute_shaderからの出力


    // Start is called before the first frame update
    void Start()
    {
        shader_kanel = cs.FindKernel("main");

        ////演算結果格納
        cb = new ComputeBuffer(1, sizeof(float)*3);
        cs.SetBuffer(shader_kanel, "Result", cb);
        ////////

        ////プレイヤー機位置転送準備
        uniformCB = new ComputeBuffer(2, sizeof(float)*3);
        cs.SetBuffer(shader_kanel, "plyData", uniformCB);
        ////////

        ////自機位置転送準備
        uniformCB2 = new ComputeBuffer(1, sizeof(float) * 3);
        cs.SetBuffer(shader_kanel, "myPos", uniformCB2);
        ////////

        ////プレイヤーオブジェクト自動取得
        player = GameObject.Find("player");
        ////////

    }

    void Update()
    {
        ////プレイヤー機位置転送
        plyPos = new float[] { player.transform.position.x, player.transform.position.y, player.transform.position.z,
                                player.transform.forward.x,player.transform.forward.y,player.transform.forward.z};
        uniformCB.SetData(plyPos);
        ////////

        ////自機位置転送
        myPos = new float[] { transform.position.x, transform.position.y,transform.position.z};
        uniformCB2.SetData(myPos);
        ////////

        ////演算実行
        cs.Dispatch(shader_kanel, 1, 1, 1);
        ////////

        ////演算結果取り出し
        cb.GetData(GPUoutput);//上記の演算結果格納と対
      //  transform.forward = new Vector3(GPUoutput[0], GPUoutput[1], GPUoutput[2]);
       // transform.position += transform.forward * speed;
      //  Debug.Log("BOSS2out" + picUP[2]);
        ////////
    }


    ////終了時バッファ解放
    void OnApplicationQuit()
    {
        cb.Release();
        uniformCB.Release();
        uniformCB2.Release();
    }
}

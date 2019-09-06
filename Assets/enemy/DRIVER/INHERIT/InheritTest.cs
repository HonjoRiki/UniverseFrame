using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritTest : MonoBehaviour
{//敵位置初期配置
 //computebufferの共有成功
 //bufferのset,getはCPU側への調停

    ////コンピュートシェーダのセット01
    public ComputeShader cs0;//シェーダ
    private int kernel;//カーネル
    private ComputeBuffer EnemyPosBuffer;//バッファ
    //cpuへ取り出し
    ////////

   　////シェーダ02
    public ComputeShader cs1;//シェーダ
    private int kernel1;//カーネル
    private ComputeBuffer buf;//コンピュートバッファ
    private float[] val;//setする値
    private float[] display;//GPUから取り出し
    ////////

    // Start is called before the first frame update
    void Start()
    {
        ////シェーダー01
        kernel = cs0.FindKernel("main");//カーネルセット

        EnemyPosBuffer = new ComputeBuffer(1,sizeof(float)*1);//一機分
        cs0.SetBuffer(kernel,"Result",EnemyPosBuffer);

        cs0.Dispatch(kernel,1,1,1);
        ////////

        ////シェーダー02
        kernel1 = cs1.FindKernel("main");//カーネルセット
        buf = new ComputeBuffer(1,sizeof(float)*1);//バッファ作成
        cs1.SetBuffer(kernel1,"Result",buf);//バッファセット
        val = new float[] { 10.0f };//バッファに送る値を定義
        buf.SetData(val);//バッファに値をセット
        cs1.SetBuffer(kernel1, "Inherit", EnemyPosBuffer);
        cs1.Dispatch(kernel1,1,1,1);//実行
        display = new float[1];//取り出す領域を定義
        buf.GetData(display);//バッファの値をcpuへ出す
        ////////

        Debug.Log("cs1"+display[0]);


    }

    ////終了時バッファ解放
    void OnApplicationQuit()
    {
        EnemyPosBuffer.Release();
        buf.Release();
    }

}

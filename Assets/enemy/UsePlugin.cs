using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Linq;//コードでメッシュを生成するときに用いる

public class UsePlugin : MonoBehaviour
{
    public GameObject lightsan;//ライト
    public GameObject camerasan;//カメラ
    private Mesh myMesh;//頂点情報
    float[] view = new float[16];//v行列送信用
    float[] proj = new float[16];//p行列送信用
    float[] ligh = new float[3];//ライトの方向
    Matrix4x4 printTest;//unityで表示・かくにんする



    [DllImport("EnemyManage")]
    private static extern IntPtr GetRenderEventFunc();

    [DllImport("EnemyManage")]
    private static extern void SetMeshVertex(IntPtr vHandle, IntPtr iHandle, uint vCount, float[] projMat, float[] lightP);

    [DllImport("EnemyManage")]
    private static extern void SetViewMatrix(float[] viewMat);

    // Start is called before the first frame update
    IEnumerator Start()
    {

        /////このオブジェクトのメッシュフィルターからメッシュをゲット////////////
        myMesh = this.GetComponent<MeshFilter>().mesh;
        /////


        /////p行列作成//////
        Matrix4x4 pre_proj = camerasan.GetComponent<Camera>().projectionMatrix;
        //pre_proj[10] *= -1.0F;
        for (int i = 0; i < 16; i++) { proj[i] = (float)pre_proj[i]; }
        printTest = camerasan.GetComponent<Camera>().worldToCameraMatrix; ;
        /////////////////////

        ////////////////////
        Vector3 pre_ligh = lightsan.transform.forward;
        pre_ligh.z *= 1.0F;
        for (int i = 0; i < 3; i++) { ligh[i] = pre_ligh[i]; }
        ///////////////////

        ////////プラグインに情報を送信/////////////
        SetMeshVertex(myMesh.GetNativeVertexBufferPtr(0),
                       myMesh.GetNativeIndexBufferPtr(),
                     myMesh.GetIndexCount(0),
                     proj,
                     ligh);
        ////////////////////////////

        GL.IssuePluginEvent(GetRenderEventFunc(), 0);//GLを用いた下準備
        yield return StartCoroutine("CallPluginAtEndOfFrames");
    }




    private IEnumerator CallPluginAtEndOfFrames()
    {
        print(lightsan.transform.forward);
        while (true)
        {

            yield return new WaitForEndOfFrame();

            Matrix4x4 pre_view = camerasan.GetComponent<Camera>().worldToCameraMatrix;
            for (int i = 0; i < 16; i++) { view[i] = (float)pre_view[i]; }
            SetViewMatrix(view);
            GL.IssuePluginEvent(GetRenderEventFunc(), 1);//render
         // camerasan.GetComponent<Camera>().Render();
        }
    }
}

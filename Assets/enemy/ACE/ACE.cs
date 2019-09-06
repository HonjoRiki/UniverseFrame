using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ACE : MonoBehaviour
{
    public Mesh mesh;
    public Shader shader;//シェーダー
    private Material material;

    private Camera cam;//仮カメラ

    private ComputeBuffer kyoriBuf;//距離格納
    private float[] kyori = new float[256];

    // Start is called before the first frame update
    void Start()
    {
        //距離格納用コンピュートバッファ
        kyoriBuf = new ComputeBuffer(1, sizeof(float) * 256);

        //マテリアル、カメラ準備
        material = new Material(shader);
        material.enableInstancing=true;
        cam = this.GetComponent<Camera>();

        //コンピュートバッファをセット
        material.SetBuffer("kyoriBuf", kyoriBuf);
    }

    // Update is called once per frame
    void Update()
    {
        Graphics.DrawMeshInstanced(mesh, 0, material, new Matrix4x4[] { Matrix4x4.identity }, 1, null, ShadowCastingMode.Off, false, 10, cam);
        
        kyoriBuf.GetData(kyori);
        for (int i = 0; i < 20; i++)
        { Debug.Log("kyori_" + i + "=" + kyori[i]); }

    }

    void OnDestroy()
    {
        kyoriBuf.Release();
    }
}

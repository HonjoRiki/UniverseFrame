using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RayTestIndirect : MonoBehaviour
{
    private ComputeBuffer DIB;//描画命令用
    private uint[] commands;

    public GameObject obj;//地形obj
    private Mesh mesh;
    private Matrix4x4 mat;

    public Shader shader;//シェーダー
    private Material material;

    
    private Camera cam;//仮カメラ

    private ComputeBuffer kyoriBuf;//距離格納
    private float[] kyori=new float[256];

    // Start is called before the first frame update
    void Start()
    {
        //地形オブジェクト
        mesh = obj.GetComponent<MeshFilter>().mesh;
        mat.SetTRS(obj.transform.position,
                   obj.transform.rotation, 
                   obj.transform.lossyScale);

        //描画命令コンピュートバッファ
        commands = new uint[] { mesh.GetIndexCount(0), 1, 0, 0, 0 };
        DIB = new ComputeBuffer(1,sizeof(uint)*5);
        DIB.SetData(commands);

        //距離格納用コンピュートバッファ
        kyoriBuf = new ComputeBuffer(1,sizeof(float)*256);
        

        material = new Material(shader);
        cam = this.GetComponent<Camera>();

        material.SetMatrix("RayTestVertMat",mat);
        material.SetBuffer("kyoriBuf",kyoriBuf);
        
    }

    // Update is called once per frame
    void Update()
    {
        Graphics.DrawMeshInstancedIndirect(mesh, 0, material,
    new Bounds(Vector3.zero, new Vector3(10000, 10000,10000)), DIB,
    0, null, ShadowCastingMode.On, true, 9, cam);

        kyoriBuf.GetData(kyori);
        for (int i = 0; i < 20; i++)
        { Debug.Log("kyori_" +i+"="+ kyori[i]); }

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1000;
        Debug.DrawRay(transform.position, forward, Color.green);
    }

    void OnDestroy()
    {
        DIB.Release();
        kyoriBuf.Release();
    }
}

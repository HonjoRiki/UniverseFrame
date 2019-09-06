using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RayTest : MonoBehaviour
{
    public GameObject  obje;
    public Shader shader;
    private Material material;
    private Camera cam;
    private Mesh mesh;
    private Matrix4x4[] mat;

    // Start is called before the first frame update
    void Start()
    {
        material = new Material(this.shader);
        material.enableInstancing=true;
        cam = this.GetComponent<Camera>();
        mesh = obje.GetComponent<MeshFilter>().mesh;
        Matrix4x4 m = Matrix4x4.identity;
        m.SetTRS(obje.transform.position,obje.transform.rotation,obje.transform.lossyScale);
        mat = new Matrix4x4[] { m};
        Debug.Log(mat[0]);

    }

    // Update is called once per frame
    void Update()
    {
       // Graphics.DrawMesh(mesh, obje.transform.position/*Vector3.zero*/, this.transform.rotation, material, 9, cam);
        Graphics.DrawMeshInstanced(mesh,0,material,mat,mat.Length,null,ShadowCastingMode.Off,false,9,cam );
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public GameObject chasis;
    public GameObject llanta1;
    public GameObject llanta2;
    public GameObject llanta3;
    public GameObject llanta4;
    public GameObject tenedor;
    public GameObject luz;

    Vector3[] geometria1;
    Vector3[] geometria2;
    Vector3[] geometria3;
    Vector3[] geometria4;
    Vector3[] geometria5;
    Vector3[] geometria6;

    public Vector3 A;
    public Vector3 B;
    float t;


    Vector3[] Rotar(GameObject componente,float rY)
    {
        Matrix4x4 rm = Transformations.RotateM(rY,Transformations.AXIS.AX_Y);
        MeshFilter mf = componente.GetComponent<MeshFilter>();
        Mesh mesh = mf.mesh;
        Vector3[] transform = new Vector3[mesh.vertices.Length];

        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            Vector3 v = mesh.vertices[i];
            Vector4 temp = new Vector4(v.x,v.y,v.z,1);
            transform[i] = rm*temp;
        }
        return transform;
    }

    Vector3[] Trasladar(float t, Vector3[] geom)
    {
        Vector3 pos = A+t*(B-A); //Interpolacion Lineal
        Matrix4x4 tm = Transformations.TranslateM(pos.x,pos.y,pos.z);
        Vector3[] transform = new Vector3[geom.Length];

        for (int i = 0; i < geom.Length; i++)
        {
            Vector3 v = geom[i];
            Vector4 temp = new Vector4(v.x,v.y,v.z,1);
            transform[i] = tm*temp;
        }
        return transform;
    }

    // Start is called before the first frame update
    void Start()
    {
       MeshFilter mf1 = chasis.GetComponent<MeshFilter>();
        Mesh mesh1 = mf1.mesh; //De probuilder
        geometria1 = mesh1.vertices; 

        MeshFilter mf2 = llanta1.GetComponent<MeshFilter>();
        Mesh mesh2 = mf2.mesh; //De probuilder
        geometria2 = mesh2.vertices; 

        MeshFilter mf3 = llanta2.GetComponent<MeshFilter>();
        Mesh mesh3 = mf3.mesh; //De probuilder
        geometria3 = mesh3.vertices; 

        MeshFilter mf4 = llanta3.GetComponent<MeshFilter>();
        Mesh mesh4 = mf4.mesh; //De probuilder
        geometria4 = mesh4.vertices; 

        MeshFilter mf5 = llanta4.GetComponent<MeshFilter>();
        Mesh mesh5 = mf5.mesh; //De probuilder
        geometria5 = mesh5.vertices; 

        MeshFilter mf6 = tenedor.GetComponent<MeshFilter>();
        Mesh mesh6 = mf6.mesh; //De probuilder
        geometria6 = mesh6.vertices; 


        t = 0; 

    }

    // Update is called once per frame
    void Update()
    {
         MeshFilter mf1 = chasis.GetComponent<MeshFilter>();
        Mesh mesh1 = mf1.mesh; //De probuilder

        MeshFilter mf2 = llanta1.GetComponent<MeshFilter>();
        Mesh mesh2 = mf2.mesh; //De probuilder

        MeshFilter mf3 = llanta2.GetComponent<MeshFilter>();
        Mesh mesh3 = mf3.mesh; //De probuilder

        MeshFilter mf4 = llanta3.GetComponent<MeshFilter>();
        Mesh mesh4 = mf4.mesh; //De probuilder

        MeshFilter mf5 = llanta4.GetComponent<MeshFilter>();
        Mesh mesh5 = mf5.mesh; //De probuilder

        MeshFilter mf6 = tenedor.GetComponent<MeshFilter>();
        Mesh mesh6 = mf6.mesh; //De probuilder


        //MeshFilter mf = chasis.GetComponent<MeshFilter>();
        //Mesh mesh = mf.mesh;//De probuilder
        t += 0.001f;
        mesh1.vertices = Trasladar(t,geometria1);
        mesh2.vertices = Trasladar(t,geometria2);
        mesh3.vertices = Trasladar(t,geometria3);
        mesh4.vertices = Trasladar(t,geometria4);
        mesh5.vertices = Trasladar(t,geometria5);
        mesh6.vertices = Trasladar(t,geometria6);
        Vector3 pos = luz.transform.position;
        Vector3 posNueva = pos + t/7000 * (B - pos);
        if(B.x > 0){
            luz.transform.position = new Vector3(posNueva.x, luz.transform.position.y, luz.transform.position.z);
        }
        if(B.y > 0){
            luz.transform.position = new Vector3(luz.transform.position.x, posNueva.y, luz.transform.position.z);
        }
        if(B.z > 0){
            luz.transform.position = new Vector3(luz.transform.position.x,luz.transform.position.y,posNueva.z);
        }
        

    }
}

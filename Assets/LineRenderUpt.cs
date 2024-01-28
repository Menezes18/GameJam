using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineRenderUpt : MonoBehaviour
{
    private LineRenderer linha;
    public GameObject[] target;
    
    public bool colisao = false;
    
    private Mesh m;
    private MeshFilter mf;
    
    public Vector3[] pontos_atual;

    // Start is called before the first frame update
    void Start()
    {
        linha = transform.GetComponent<LineRenderer>();
        linha.positionCount = target.Length+1;
        pontos_atual = new Vector3[target.Length+1];
        //tartCoroutine(checkLineCollision());
    }

    // Update is called once per frame
    void Update()
    {
        linha.SetPosition(0,transform.position);
        pontos_atual[0] = transform.position;
        for(int i = 0; i<target.Length; i++)
        {
            linha.SetPosition(i+1,target[i].transform.position);
            pontos_atual[i+1] = target[i].transform.position;
        }
        
        Vector3[] pontos = new Vector3[2];
        pontos[0] = linha.GetPosition(0);
        pontos[1] = linha.GetPosition(1);
        
        //GerarMalha(pontos);
        if (colisao == true)
        {
            Debug.Log("Colidiu");
        }
    }

    // IEnumerator checkLineCollision()
    // {
    //     yield return new WaitForSeconds(.5f);
    //
    //     GameObject[] linhas = GameObject.FindGameObjectsWithTag("Linha");
    //     
    //     colisao = false;
    //
    //     for (int i = 0; i < linhas.Length; i++)
    //     {
    //         if (linhas[i].name != transform.name)
    //         {
    //             LineRenderer linha = linhas[i].transform.GetComponent<LineRenderer>();
    //             int Total = linha.positionCount;
    //             Vector3[] pontos = new Vector3[Total];
    //             for (int j = 0; j < Total; j++)
    //             {
    //                 pontos[j] = linha.GetPosition(j);
    //             }
    //             
    //             for (int j = 0; j < pontos_atual.Length; j++)
    //             {
    //                 if (j + 1 < pontos_atual.Length)
    //                 {
    //                     for (int m = 0; m < pontos.Length; m++)
    //                     {
    //                         if (m + 1 < pontos.Length)
    //                         {
    //                             if (pontos_atual[j] != pontos[m] && pontos_atual[j + 1] != pontos[m + 1])
    //                             {
    //                                 //Debug.Log("Checando: " + pontos_atual[j] + " - " + pontos_atual[j + 1] + "  |  " + pontos[m] + " - " + pontos[m + 1]);
    //                                 Vector2 p;
    //                                 colisao = lineLine(pontos_atual[j], pontos_atual[j + 1], pontos[m], pontos[m + 1], out p);
    //                                 //Debug.Log("Checando: " + pontos_atual[j] + " - " + pontos_atual[j + 1] + "  |  " + pontos[m] + " - " + pontos[m + 1]+"  | "+colisao);
    //                             }
    //                         }
    //                     }
    //                 }
    //             }                
    //             
    //         }
    //     }
    //     
    //     StartCoroutine(checkLineCollision());
    // }
    
    // void GerarMalha(Vector3[] pontos)
    // {
    //     Vector3[] VerteicesArray = new Vector3[3];
    //     int[] trianglesArray = new int[3];
    //
    //     VerteicesArray[0] = transform.InverseTransformPoint(pontos[0]);
    //     VerteicesArray[1] = transform.InverseTransformPoint(pontos[1]);
    //     VerteicesArray[2] = new Vector3(.2f, 0, 0);
    //
    //     trianglesArray[0] = 0;
    //     trianglesArray[1] = 1;
    //     trianglesArray[2] = 2;
    //
    //     m.vertices = VerteicesArray;
    //     m.triangles = trianglesArray;
    //     
    //     //m.RecalculateBounds ();
    //     transform.GetComponent<MeshCollider>().sharedMesh = null;
    //     transform.GetComponent<MeshCollider>().sharedMesh = m;
    // }
    //

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Linha"))
        {
            Debug.Log("Colisao: " + other.name);
        }
    }
    
    
    



}

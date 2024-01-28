using UnityEngine;

public class LineMeshGenerator : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public int resolution = 10;

    private LineRenderer lineRenderer;
    private MeshFilter meshFilter;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        meshFilter = GetComponent<MeshFilter>();

        GenerateLine();
        GenerateMesh();
    }

    private void GenerateLine()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, pointA.position);
        lineRenderer.SetPosition(1, pointB.position);
    }

    private void GenerateMesh()
    {
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        Vector3[] vertices = new Vector3[resolution * 2];
        int[] triangles = new int[(resolution - 1) * 6];

        for (int i = 0; i < resolution; i++)
        {
            float t = i / (float)(resolution - 1);
            vertices[i] = Vector3.Lerp(pointA.position, pointB.position, t);
            vertices[i + resolution] = vertices[i] + Vector3.up * 0.1f; // Extrude a malha para cima

            if (i < resolution - 1)
            {
                int triIndex = i * 6;
                triangles[triIndex] = i;
                triangles[triIndex + 1] = i + resolution;
                triangles[triIndex + 2] = i + 1;

                triangles[triIndex + 3] = i + 1;
                triangles[triIndex + 4] = i + resolution;
                triangles[triIndex + 5] = i + resolution + 1;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
}
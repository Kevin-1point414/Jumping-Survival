using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    [SerializeField] private Vector2 size;
    [SerializeField] private float pointDensity;
    [SerializeField] private float maxHeight;
    void Start()
    {
        Mesh mesh = new();

        int numVertices = Mathf.CeilToInt(Mathf.CeilToInt(size.x / pointDensity + 1) *
            Mathf.CeilToInt(size.y / pointDensity + 1));

        Vector3[] vertices = new Vector3[numVertices];
        int[] indices = new int[(int)(6 * (numVertices - Mathf.CeilToInt(size.y / pointDensity)) - 7)];
        Color[] colors = new Color[numVertices];

        for (int i = 0; i < Mathf.CeilToInt(size.x / pointDensity + 1); i++) 
        {
            for (int j = 0; j < Mathf.CeilToInt(size.y / pointDensity + 1); j++) 
            {
                vertices[Mathf.CeilToInt(size.y / pointDensity + 1) * i + j] = new Vector3(
                    size.x / Mathf.CeilToInt(size.x / pointDensity) * i - size.x / 2, 0, j * size.y /
                    Mathf.CeilToInt(size.y / pointDensity) - size.y / 2);
            }
        }
        for (int j = 0, i = 0; i < 6 * indices.Length - 11; i += 6, j++) 
        {
            indices[i] = j;
            indices[i + 1] = j + 1;
            indices[i + 2] = Mathf.CeilToInt(size.y / pointDensity + 1) + j;
            indices[i + 3] = j + 1;
            indices[i + 4] = Mathf.CeilToInt(size.y / pointDensity + 1) + j + 1;
            indices[i + 5] = Mathf.CeilToInt(size.y / pointDensity + 1) + j;
        }
        foreach(var value in indices){
            Debug.Log(value);
        }

        /*for (int i = 0; i < numVertices; i++)
        {
            vertices[i] += new Vector3(0, maxHeight * (2 * Mathf.PerlinNoise(
                (vertices[i].x + size.x / 2) / size.x, (vertices[i].z + size.y / 2) / size.y) - 1), 0);
            colors[i] = Color.Lerp(Color.green, Color.gray, vertices[i].y);
        }*/

        mesh.SetVertices(vertices);
        mesh.RecalculateBounds();
        mesh.SetTriangles(indices, 0);
        mesh.SetColors(colors);
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
}

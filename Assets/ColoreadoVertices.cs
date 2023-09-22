using UnityEngine;

public class VertexColoring : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public RenderTexture vertexPositionTexture;

    void Start()
    {
        Mesh mesh = skinnedMeshRenderer.sharedMesh;
        Vector3[] vertices = mesh.vertices;
        Vector4[] vertexPositions = new Vector4[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
        {
            vertexPositions[i] = new Vector4(vertices[i].x, vertices[i].y, vertices[i].z, 1.0f);
        }

        vertexPositionTexture = new RenderTexture(mesh.vertexCount, 1, 0, RenderTextureFormat.ARGBFloat);
        vertexPositionTexture.filterMode = FilterMode.Point;
        Graphics.Blit(vertexPositionTexture, vertexPositionTexture);

        Material material = skinnedMeshRenderer.material;
        material.SetTexture("_VertexPositionTexture", vertexPositionTexture);
    }
}

using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CustomProbeGroup : MonoBehaviour
{
    public int width = 5;
    public int height = 5;
    public int depth = 5;
    public float spacing = 1.0f;
    public Color gizmoColor = Color.yellow;

    public float radio = 1f;

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int z = 0; z < depth; z++)
                {
                    Vector3 position = new Vector3(x * spacing, y * spacing, z * spacing);
                    Gizmos.DrawWireCube(transform.position + position, Vector3.one * spacing);

                    Vector3 position2 = new Vector3(x * spacing, y * spacing, z * spacing);

                    Gizmos.DrawWireSphere(transform.position + position, radio);
                }
            }
        }
    }

}

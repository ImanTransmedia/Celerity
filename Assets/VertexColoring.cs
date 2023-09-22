using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX; // Asegúrate de importar esta biblioteca.

public class ColoreadoVertices : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer; // Renderer del Skinned Mesh.
    public VisualEffect visualEffect; // El efecto visual donde quieres ajustar el color de las partículas.
    public float maxDistance = 10f; // La distancia máxima para la gradiente de colores.

    void Update()
    {
        // Asegúrate de que tienes un Skinned Mesh Renderer y un efecto visual asignados.
        if (skinnedMeshRenderer == null || visualEffect == null)
        {
            Debug.LogError("Falta asignar el Skinned Mesh Renderer o el Visual Effect.");
            return;
        }

        // Obtiene la posición del Skinned Mesh como el punto de referencia.
        Vector3 referencePoint = skinnedMeshRenderer.transform.position;

        // Obtiene los vértices del Skinned Mesh.
        Mesh mesh = skinnedMeshRenderer.sharedMesh;
        Vector3[] vertices = mesh.vertices;

        // Ajusta el color de las partículas en función de la distancia desde el punto de referencia.
        Color[] colors = new Color[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            float distance = Vector3.Distance(vertices[i], referencePoint);

            // Define una gradiente de colores desde blanco (cerca) a negro (lejos).
            float t = Mathf.InverseLerp(0f, maxDistance, distance);
            Color vertexColor = Color.Lerp(Color.white, Color.black, t);

            colors[i] = vertexColor;
        }

        // Convierte los colores de los vértices en una textura y asigna la textura al efecto visual.
        Texture2D colorTexture = new Texture2D(1, 1);
        colorTexture.SetPixel(0, 0, colors[0]); // Puedes ajustar esta asignación según tus necesidades.
        colorTexture.Apply();

        visualEffect.SetTexture("ColorMap", colorTexture); // Asegúrate de que "ColorMap" sea un parámetro válido en tu Visual Effect Graph.
        visualEffect.Reinit(); // Vuelve a inicializar el efecto visual para aplicar los cambios.
    }
}

using UnityEngine;

public class RenderSkinnedMeshToTexture : MonoBehaviour
{
    public RenderTexture renderTexture; // Asigna el Render Texture en el Inspector

    private Camera renderCamera;

    void Start()
    {
        renderCamera = gameObject.AddComponent<Camera>();
        renderCamera.targetTexture = renderTexture;
        renderCamera.clearFlags = CameraClearFlags.SolidColor;
        renderCamera.backgroundColor = Color.clear; // Opcional: para un fondo transparente
    }

    void Update()
    {
        // Renderiza la vista actual del Skinned Mesh en el Render Texture
        renderCamera.Render();
    }
}


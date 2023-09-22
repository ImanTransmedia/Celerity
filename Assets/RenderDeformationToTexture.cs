using UnityEngine;

public class ApplyRenderTexture : MonoBehaviour
{
    public RenderTexture renderTexture; // Asigna el Render Texture en el Inspector
    public LayerMask mask; // Asigna la capa que deseas enmascarar como completamente blanco en el Inspector
    public Camera customCamera; // Asigna la cámara deseada en el Inspector

    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Renderizar el contenido de la cámara en el Render Texture
        RenderTexture.active = renderTexture;
        customCamera.Render();
        RenderTexture.active = null;

        // Aplicar el Render Texture al material del objeto
        material.mainTexture = renderTexture;

        // Aplicar la máscara para hacer que el objeto enmascarado sea completamente blanco
        Color maskColor = Color.white;
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, mask))
        {
            maskColor = Color.black;
        }

        material.color = maskColor;
    }
}

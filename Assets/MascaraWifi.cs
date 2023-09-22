using UnityEngine;

public class MascaraWifi : MonoBehaviour
{
    public RenderTexture renderTexture; // Asigna el Render Texture en el Inspector

    public Camera customCamera; // Asigna la c�mara deseada en el Inspector

    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Renderizar el contenido de la c�mara en el Render Texture
        RenderTexture.active = renderTexture;
        customCamera.Render();
        RenderTexture.active = null;

        // Aplicar el Render Texture al material del objeto
        material.mainTexture = renderTexture;

    }
}

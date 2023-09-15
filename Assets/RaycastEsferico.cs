using UnityEngine;

public class RaycastEsferico : MonoBehaviour
{
    public int numRayos = 10;
    public float radio = 10f;

    void Update()
    {
        for (int i = 0; i < numRayos; i++)
        {
            Vector3 direccion = Random.onUnitSphere * radio;
            Ray rayo = new Ray(transform.position, direccion);
            RaycastHit hit;

            if (Physics.Raycast(rayo, out hit))
            {
                Debug.DrawLine(rayo.origin, hit.point, Color.red,1f);
            }
            else
            {
                Debug.DrawRay(rayo.origin, rayo.direction * radio, Color.green, 1f);
            }
        }
    }
}

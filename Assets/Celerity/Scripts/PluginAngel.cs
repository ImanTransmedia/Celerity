
using UnityEngine;

public static class PluginAngel
{
    public static int GenerateRandomInteger(int minValue, int maxValue)
    {
        int randomValue = Random.Range(minValue, maxValue + 1);
        return randomValue;
    }

    public static void ActivarComponente<T>(GameObject gameObject) where T : MonoBehaviour
    {
        T componente = gameObject.GetComponent<T>();
        if (componente != null)
        {
            componente.enabled = true;
        }
    }

    public static void DesactivarComponente<T>(GameObject gameObject) where T : MonoBehaviour
    {
        T componente = gameObject.GetComponent<T>();
        if (componente != null)
        {
            componente.enabled = false;
        }
    }
}

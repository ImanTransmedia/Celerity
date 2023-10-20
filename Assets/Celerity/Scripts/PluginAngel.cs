
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;

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

   /* public static bool TodosLosObjetosEstanActivos(List<GameObject> objetos, string Activo)
    {
        
        foreach (GameObject objeto in objetos)
        {
            FieldInfo fieldInfo = objeto.GetType().GetField(Activo)
            if (!objeto.)
            {
                return false;
            }
        }
        return true;
    }*/

    public static bool TodosLosObjetosEstanActivos(List<GameObject> objetos, string nombreVariableBooleana)
    {
        foreach (GameObject objeto in objetos)
        {
            FieldInfo fieldInfo = objeto.GetType().GetField(nombreVariableBooleana);
            if (fieldInfo != null)
            {
                bool valorBooleano = (bool)fieldInfo.GetValue(objeto);
                if (!valorBooleano)
                {
                    return false;
                }
            }
            else
            {
                Debug.LogWarning($"La variable '{nombreVariableBooleana}' no se encontró en el objeto '{objeto.name}'.");
            }
        }
        return true;
    }


}

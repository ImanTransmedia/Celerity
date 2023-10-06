using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Locomotion;
using Oculus.Interaction;
public class DesactivarTeleport : MonoBehaviour
{
    public GameObject [] Rotar;
    public GameObject [] GrupoControladorLocomotion;
    public GameObject [] Teleport;

    public void ActivarRotar()
    {
        foreach (var item in Rotar)
        {
            TurnerEventBroadcaster componente = item.GetComponent<TurnerEventBroadcaster>();

            if (componente != null)
            {
                // Desactiva el componente
                componente.enabled = true;
            }
            else
            {
                Debug.LogWarning("El componente MiComponente no se encontró en el GameObject.");
            }
        }
        
    }

    public void ActivarTeleport()
    {
        foreach (var item in GrupoControladorLocomotion)
        {
            BestHoverInteractorGroup componente = item.GetComponent<BestHoverInteractorGroup>();

            if (componente != null)
            {
                // Desactiva el componente
                componente.enabled = true;
            }
            else
            {
                Debug.LogWarning("El componente MiComponente no se encontró en el GameObject.");
            }
        }
        foreach (var item in Teleport)
        {
            item.SetActive(true);
        }
         
    }

    public void DesactivarRotar()
    {
        foreach (var item in Rotar)
        {
            TurnerEventBroadcaster componente = item.GetComponent<TurnerEventBroadcaster>();

            if (componente != null)
            {
                // Desactiva el componente
                componente.enabled = false;
            }
            else
            {
                Debug.LogWarning("El componente MiComponente no se encontró en el GameObject.");
            }
        }
        
    }

    public void DesactivarTeleporteo()
    {
        foreach (var item in GrupoControladorLocomotion)
        {
            TurnerEventBroadcaster componente = item.GetComponent<TurnerEventBroadcaster>();

            if (componente != null)
            {
                // Desactiva el componente
                componente.enabled = false;
            }
            else
            {
                Debug.LogWarning("El componente MiComponente no se encontró en el GameObject.");
            }
        }
        foreach (var item in Teleport)
        {
            item.SetActive(false);
        }

    }
}

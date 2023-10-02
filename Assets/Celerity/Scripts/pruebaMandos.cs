using System.Collections;
using UnityEngine;


public class pruebaMandos : MonoBehaviour
{
    public float vibrationDuration = 0.5f; // Duración de la vibración en segundos.
    public float Strenght = 1.0f; // Intensidad de la vibración.

    public  IEnumerator VibracionDerecha()
    {
        OVRInput.SetControllerVibration(Strenght, Strenght, OVRInput.Controller.RHand);
        yield return new WaitForSeconds(vibrationDuration);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RHand);
    }
    public  IEnumerator VibracionIzquierda()
    {
        OVRInput.SetControllerVibration(Strenght, Strenght, OVRInput.Controller.LHand);
        yield return new WaitForSeconds(vibrationDuration);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.LHand);
    }

    public void mandoIzquierdo()
    {
        VibracionIzquierda();
    }
    public void mandoDerecho()
    {
        VibracionDerecha();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;
using Unity.XR.Oculus;
using System.Timers;
using Oculus;

public static class ControladorOculus
{

    /*public static void VibracionControl(float intensity)
    {
        OVRInput.Controller controller = OVRInput.GetActiveController();

        // Hace que el mando vibre con la intensidad dada
        OVRInput.SetControllerVibration(intensity, intensity, controller);
    }*/
public static void VibracionControl(float intensity, bool controles, int controllerIndex = 0)
{
    OVRInput.Controller controller;

    if (controles)
    {
        if (controllerIndex == 0)
        {
            controller = OVRInput.Controller.LTouch;
        }
        else if (controllerIndex == 1)
        {
            controller = OVRInput.Controller.RTouch;
        }
        else
        {
            Debug.LogWarning("�ndice de controlador no v�lido. Usando el controlador activo.");
            controller = OVRInput.GetActiveController();
        }
    }
    else
    {
        controller = OVRInput.GetActiveController();
    }

    // Hace que el mando vibre con la intensidad dada.
    OVRInput.SetControllerVibration(intensity, intensity, controller);
}



public static void PararControl()
    {
        // Detiene la vibraci�n del mando
        OVRInput.Controller controller = OVRInput.GetActiveController();
        OVRInput.SetControllerVibration(0, 0, controller);
    }

    public static void VibracionControlHaptico(AudioClip MiAudio)
    {
        OVRHapticsClip MiClip;
   
        MiClip = new OVRHapticsClip(MiAudio);

        foreach (var item in OVRHaptics.Channels)
        {
            item.Preempt(MiClip);
        }
        //OVRHaptics.Channels[1].Preempt(MiClip);
    }

    //OVRInput.Controller controller
    public static void VibrateController2(float Strenght, float vibrationDuration, OVRInput.Controller control)
    {
        OVRInput.SetControllerVibration(Strenght, Strenght, control);

        Timer timer = new Timer(vibrationDuration * 1000);
        timer.Elapsed += (sender, e) =>
        {
            OVRInput.SetControllerVibration(0f, 0f, control);
            ((Timer)sender).Dispose();
        };
        timer.AutoReset = false;
        timer.Enabled = true;
    }

}


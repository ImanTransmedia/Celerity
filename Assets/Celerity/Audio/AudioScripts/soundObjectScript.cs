using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class soundObjectScript : MonoBehaviour
{
    public FMODUnity.EventReference startObjectEmitter;
    private FMOD.Studio.EventInstance startEventState;

    public FMODUnity.EventReference stopObjectEmitter;
    private FMOD.Studio.EventInstance stopEventState;


    public void StartEvent()
    {
        startEventState = FMODUnity.RuntimeManager.CreateInstance(startObjectEmitter);
        startEventState.start();
    }

    
    public void StopEvent()
    {
        startEventState = FMODUnity.RuntimeManager.CreateInstance(startObjectEmitter);
        startEventState.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

        stopEventState = FMODUnity.RuntimeManager.CreateInstance(stopObjectEmitter);
        stopEventState.start();
           
    }
}

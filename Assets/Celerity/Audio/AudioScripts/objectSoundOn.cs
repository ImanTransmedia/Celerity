using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;


public class objectSoundOn : MonoBehaviour
{
    public FMODUnity.EventReference fmodEventEmitter1;

    private FMOD.Studio.EventInstance fmodEventInstance1;

    private void Start()
    {
        fmodEventInstance1 = FMODUnity.RuntimeManager.CreateInstance(fmodEventEmitter1);
    }

    public void StartEvent()
    {
        fmodEventInstance1.start();
               
    }

    public void StopEvent()
    {
        fmodEventInstance1.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}

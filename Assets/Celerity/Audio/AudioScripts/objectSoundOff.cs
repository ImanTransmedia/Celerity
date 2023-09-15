using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;


public class objectSoundOff : MonoBehaviour
{
    public FMODUnity.EventReference fmodEventEmitter2;

    private FMOD.Studio.EventInstance fmodEventInstance2;

    private void Start()
    {
        fmodEventInstance2 = FMODUnity.RuntimeManager.CreateInstance(fmodEventEmitter2);
    }

    public void StartStopEvent()
    {
        fmodEventInstance2.start();

    }
        
}

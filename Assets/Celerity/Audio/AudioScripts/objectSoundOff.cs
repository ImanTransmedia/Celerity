using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;


public class objectSoundOff : MonoBehaviour
{
    public FMODUnity.EventReference fmodEventEmitter2;

    private FMOD.Studio.EventInstance fmodEventInstance2;

    

    public void StartStopEvent()
    {
        fmodEventInstance2 = FMODUnity.RuntimeManager.CreateInstance(fmodEventEmitter2);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(fmodEventInstance2, GetComponent<Transform>(), GetComponent<Rigidbody>());
        fmodEventInstance2.start();

    }
        
}

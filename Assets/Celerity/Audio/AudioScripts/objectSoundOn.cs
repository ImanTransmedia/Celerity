using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;


public class objectSoundOn : MonoBehaviour
{
    public FMODUnity.EventReference fmodEventEmitter1;

    private FMOD.Studio.EventInstance fmodEventInstance1;

    

    public void StartEvent()
    {
        fmodEventInstance1 = FMODUnity.RuntimeManager.CreateInstance(fmodEventEmitter1);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(fmodEventInstance1, GetComponent<Transform>(), GetComponent<Rigidbody>());
        //fmodEventInstance1.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(GetComponent<Transform>(), GetComponent<Rigidbody>()));
        fmodEventInstance1.start();
               
    }

    public void StopEvent()
    {
        fmodEventInstance1.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}

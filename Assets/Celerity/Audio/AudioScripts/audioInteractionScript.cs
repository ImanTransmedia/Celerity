using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class audioInteractionScript : MonoBehaviour
{
    public FMODUnity.EventReference fmodEventEmitter3;

    private FMOD.Studio.EventInstance fmodEventInstance3;

    private void Start()
    {
        fmodEventInstance3 = FMODUnity.RuntimeManager.CreateInstance(fmodEventEmitter3);
    }

    public void InteractiveSoundEvent()
    {
        fmodEventInstance3.start();

    }
}

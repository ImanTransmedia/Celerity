using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.Playables;
using FMOD.Studio;

public class cellSoundParameters1 : MonoBehaviour
{
    public FMODUnity.EventReference eventEmitter;
    FMOD.Studio.EventInstance eventState;
           
    
    public void PlayEvent()
    {

        Debug.Log("testing parameters");
        eventState = FMODUnity.RuntimeManager.CreateInstance(eventEmitter);
        eventState.start();



    }

    /*public void StopEvent()
    {
        eventState.setParameterByNameWithLabel("OnOff", "Apagado");
        
    }*/

    public void StopEvent(string parameterName, float value)
    {
        eventState.setParameterByName("OnOff", 1);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class soundEventTest : MonoBehaviour
{
    [FMODUnity.EventRef] public string fmodEventPath;

    public void soundEvent()
    {
        Debug.Log("suena suena suena suena");

        FMODUnity.RuntimeManager.PlayOneShot(fmodEventPath);
    }

    // Start is called before the first frame update
   
}

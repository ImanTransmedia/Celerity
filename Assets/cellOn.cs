using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


public class cellOn : MonoBehaviour
{
    public string fmodEventPath;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hand")
        {
            FMODUnity.RuntimeManager.PlayOneShot(fmodEventPath);
        }
    }
}

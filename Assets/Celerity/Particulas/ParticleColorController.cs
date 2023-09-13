using System.Collections.Generic;
using UnityEngine;

public class ParticleColorController : MonoBehaviour
{
    public List<Transform> targetObjects;
    public float radius = 1.0f;
    public Material particleMaterial;

    private Vector4[] positionsArray = new Vector4[10];
    private float[] radiiArray = new float[10];

    void Update()
    {
        for (int i = 0; i < targetObjects.Count; i++)
        {
            positionsArray[i] = targetObjects[i].position;
            radiiArray[i] = radius;
        }

        particleMaterial.SetVectorArray("_PositionsArray", positionsArray);
        particleMaterial.SetFloatArray("_RadiiArray", radiiArray);
        particleMaterial.SetInt("_ObjectsCount", targetObjects.Count);
    }
}


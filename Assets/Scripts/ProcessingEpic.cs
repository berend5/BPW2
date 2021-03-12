using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class ProcessingEpic : MonoBehaviour
{
    public Volume volume;
    //private ChromaticAberration ca;
    private ColorAdjustments ca;

    void Start()
    {
        volume = GetComponent<Volume>();
        //volume.sharedProfile.TryGet<ChromaticAberration>(out ca);
        GhostMode(0);
        volume.sharedProfile.TryGet<ColorAdjustments>(out ca);

    }

    public void GhostMode(float value)
    {
        //ca.intensity.SetValue(new NoInterpMinFloatParameter(value, 0, true));
        if (ca != null)
        {
            ca.saturation.SetValue(new NoInterpMinFloatParameter(value, -100, true));
        }
        
    }
}
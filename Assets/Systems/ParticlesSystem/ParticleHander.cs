using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class ParticleHander : MonoBehaviour
{
    public ParticleSystem particlesToHandle;

    public void PlayVFX()
    {
        particlesToHandle.Play();
        
    }
}

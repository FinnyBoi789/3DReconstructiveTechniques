using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionParticleSystem : MonoBehaviour
{

    private ParticleSystem ps;

    private void Awake()
    {
        ps = GetComponentInChildren<ParticleSystem>();
    }

    public void PlayParticles()
    {
        if (!ps.isPlaying)
            ps.Play();
    }

    public void StopParticles()
    {
        if (ps.isPlaying)
            ps.Stop();
    }

}

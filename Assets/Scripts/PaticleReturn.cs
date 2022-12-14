using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaticleReturn : MonoBehaviour
{
    private void OnParticleSystemStopped()
    {
        var particle = GetComponent<ParticleSystem>();
        EffectManager.GetInstance().ReturnEffect(particle);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinConstantParticles : MonoBehaviour
{
    public ParticleSystem.EmissionModule emission;
    void Start()
    {
        emission = GetComponent<ParticleSystem>().emission;
    }
    void Update()
    {
        if (GameManager.autoGoblins < 1000)
            emission.rateOverTime = (float)GameManager.autoGoblins;
        else
            emission.rateOverTime = 1000f;
    }
}

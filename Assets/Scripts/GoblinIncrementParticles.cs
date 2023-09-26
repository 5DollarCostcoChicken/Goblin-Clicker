using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinIncrementParticles : MonoBehaviour
{
    public void Pulse()
    {
        StartCoroutine(Play());
    }
    IEnumerator Play()
    {
        int count = 100;
        if (GameManager.multiplier <= 100)
            count = (int)GameManager.multiplier;
        for (int i = 0; i < count; i++) {
            GetComponent<ParticleSystem>().Emit(1);
            yield return new WaitForSeconds(.005f);
        }
    }
}

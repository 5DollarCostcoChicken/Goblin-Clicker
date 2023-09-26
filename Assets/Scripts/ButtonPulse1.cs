using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPulse1 : MonoBehaviour
{
    float Scale;
    public void PulseCall(float scale)
    {
        StartCoroutine(Pulse());
        Scale = scale;
    }
    public IEnumerator Pulse()
    {
        transform.localScale = new Vector3(Scale, Scale, Scale);
        for (int i = 0; i < 10; i++)
        {
            transform.localScale = new Vector3(Scale + (i / 100f), Scale + (i / 100f), Scale + (i / 100f));
            yield return new WaitForSeconds(.005f);
        }
        for (int i = 10; i > 0; i--)
        {
            transform.localScale = new Vector3(Scale + (i / 100f), Scale + (i / 100f), Scale + (i / 100f));
            yield return new WaitForSeconds(.01f);
        }
    }
}

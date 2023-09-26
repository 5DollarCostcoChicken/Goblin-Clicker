using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarButton : MonoBehaviour
{ 
    public void SpringUp()
    {
        StartCoroutine(Bounce());
        GameManager.WarOpen = true;
    }
    IEnumerator Bounce()
    {
        int i = 0;
        while (transform.position.y < 88 * (Screen.height / 1080f))
        {
            transform.position = new Vector3(transform.position.x, -112 * (Screen.height / 1080f) + .2f * Mathf.Pow(i, 2) * (Screen.height / 1080f), transform.position.z);
            i++;
            yield return new WaitForSeconds(.005f);
        }
        i = 0;
        while (transform.position.y > 50 * (Screen.height / 1080f))
        {
            transform.position = new Vector3(transform.position.x, 88 * (Screen.height / 1080f) - 3 * i * (Screen.height / 1080f) + .1f * Mathf.Pow(i, 1.5f) * (Screen.height / 1080f), transform.position.z);
            i++;
            yield return new WaitForSeconds(.005f);
        }
        i = 0;
        while (transform.position.y < 88 * (Screen.height / 1080f))
        {
            transform.position = new Vector3(transform.position.x, 50 * (Screen.height / 1080f) + .2f * Mathf.Pow(i, 2) * (Screen.height / 1080f), transform.position.z);
            i++;
            yield return new WaitForSeconds(.005f);
        }
    }
    IEnumerator Lower()
    {
        int i = 0;
        while (transform.position.y > -112 * (Screen.height / 1080f))
        {
            transform.position = new Vector3(transform.position.x, 88 * (Screen.height / 1080f) - .2f * Mathf.Pow(i, 2) * (Screen.height / 1080f), transform.position.z);
            i++;
            yield return new WaitForSeconds(.005f);
        }
    }
}

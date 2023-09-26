using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarShop : MonoBehaviour
{
    bool isMoving = false;
    public bool up = false;
    public void SpringUp(BattleButton b)
    {
        if (!b.bought && !isMoving && !up) {
            if (transform.localPosition.x > 0)
                StartCoroutine(Bounce());
            else
                StartCoroutine(Lower());
        }
    }
    public void SpringUpX()
    {
        if (!isMoving)
        {
            if (transform.localPosition.x > 0)
                StartCoroutine(Bounce());
            else
                StartCoroutine(Lower());
        }
    }
    IEnumerator Bounce()
    {
        isMoving = true;
        int i = 0;
        while (transform.localPosition.x > 0)
        {
            transform.localPosition = new Vector3(1630 - .8f * Mathf.Pow(i, 2), transform.localPosition.y, transform.localPosition.z);
            i++;
            yield return new WaitForSeconds(.01f);
        }
        i = 0;
        while (transform.localPosition.x < 70)
        {
            transform.localPosition = new Vector3(3f * i + .16f * Mathf.Pow(i, 1.5f), transform.localPosition.y, transform.localPosition.z);
            i++;
            yield return new WaitForSeconds(.01f);
        }
        i = 0;
        while (transform.localPosition.x > 0)
        {
            transform.localPosition = new Vector3(105 - .8f * Mathf.Pow(i, 2), transform.localPosition.y, transform.localPosition.z);
            i++;
            yield return new WaitForSeconds(.01f);
        }
        up = true;
        isMoving = false;
    }
    IEnumerator Lower()
    {
        isMoving = true;
        int i = 0;
        while (transform.localPosition.x < 1630)
        {
            transform.localPosition = new Vector3(.8f * Mathf.Pow(i, 2), transform.localPosition.y, transform.localPosition.z);
            i++;
            yield return new WaitForSeconds(.01f);
        }
        up = false;
        isMoving = false;
    }
}

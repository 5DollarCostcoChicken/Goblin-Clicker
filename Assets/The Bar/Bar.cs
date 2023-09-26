using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public GameObject bar;
    public GameObject barRed;
    bool reached;
    public Sprite Completed;
    double previous;
    // Start is called before the first frame update
    void Start()
    {
        previous = 0;
        reached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (previous < 10000 && GameManager.bar)
        {
            if (GameManager.goblins > previous)
            {
                previous = GameManager.goblins;
            }
            bar.transform.localScale = new Vector3((float)(.98f * (GameManager.goblins / 10000)), bar.transform.localScale.y, bar.transform.localScale.z);
            barRed.transform.localScale = new Vector3((float)(.98f * (previous / 10000)), barRed.transform.localScale.y, barRed.transform.localScale.z);
        }
        else if (!reached)
        {
            bar.GetComponent<Image>().sprite = Completed;
            bar.transform.localScale = new Vector3(1, bar.transform.localScale.y, bar.transform.localScale.z);
            barRed.transform.localScale = new Vector3(1, barRed.transform.localScale.y, barRed.transform.localScale.z);
            reached = true;
            StartCoroutine(Lower());
        }
    }
    IEnumerator Lower()
    {
        if (GameManager.bar)
        {
            transform.localScale = new Vector3(5.580077f, 0.7389832f, 1.508129f);
            for (int i = 0; i < 10; i++)
            {
                transform.localScale = new Vector3(5.580077f + (i / 100f), 0.7389832f + (i / 100f), 1.508129f + (i / 100f));
                yield return new WaitForSeconds(.005f);
            }
            for (int i = 10; i > 0; i--)
            {
                transform.localScale = new Vector3(5.580077f + (i / 100f), 0.7389832f + (i / 100f), 1.508129f + (i / 100f));
                yield return new WaitForSeconds(.01f);
            }
            yield return new WaitForSeconds(1);
        }
        GameManager.bar = false;
        Destroy(gameObject);
    }
}

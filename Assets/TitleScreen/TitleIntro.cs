using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TitleIntro : MonoBehaviour
{
    public GameObject transition;
    public GameObject logo;
    public GameObject trocketScreen;
    public GameObject trocketText1;
    public GameObject trocketText2;
    public GameObject kiwiScreen;
    public GameObject kiwiText1;
    public GameObject kiwiText2;
    public GameObject award1;
    public GameObject award2;
    public GameObject award3;
    public Sprite transition2;
    public GameObject titlescreen;
    public GameObject title;
    public Button continueButton;
    void Awake()
    {
        StartCoroutine(intro());
        StartCoroutine(Title());
    }
    
    IEnumerator Title()
    {
        yield return new WaitForSecondsRealtime(0.35f);
        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                title.transform.localScale += new Vector3(0.06f, 0.06f, 0.06f);
                yield return WaitTime(0.005f);
            }
            for (int i = 0; i < 30; i++)
            {
                title.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
                yield return WaitTime(0.005f);
            }
            yield return new WaitForSecondsRealtime(0.35f);
        }
    }

    IEnumerator WaitTime(float duration)
    {
        float startTime = Time.unscaledTime;
        while (Time.unscaledTime - startTime < duration)
        {
            yield return null;
        }
    }
    IEnumerator intro()
    {
        transition.GetComponent<RectTransform>().position = new Vector3(transition.GetComponent<RectTransform>().position.x, 0, transition.GetComponent<RectTransform>().position.z);
        yield return new WaitForSecondsRealtime(1);
        while (transition.GetComponent<RectTransform>().position.y < Screen.height * 2.1f)
        {
            transition.GetComponent<RectTransform>().position = new Vector3(transition.GetComponent<RectTransform>().position.x, transition.GetComponent<RectTransform>().position.y + (Screen.height / 63.75f), transition.GetComponent<RectTransform>().position.z);
            yield return WaitTime(0.01f);
        }
        while (logo.transform.localScale.x < 0.7975458)
        {
            logo.transform.localScale = new Vector3(logo.transform.localScale.x + .026666666f * 2, logo.transform.localScale.y + .026666666f * 2, logo.transform.localScale.z + .026666666f * 2);
            yield return WaitTime(0.01f);
        }
        for (int i = 0; i < 100; i++)
        {
            logo.transform.localScale = new Vector3(logo.transform.localScale.x + .002f, logo.transform.localScale.y + .002f, logo.transform.localScale.z + .002f);
            yield return WaitTime(0.02f);
        }
        //
        trocketScreen.SetActive(true);
        for (int i = 0; i < 15; i++)
        {
            trocketText1.transform.localScale = new Vector3(trocketText1.transform.localScale.x + (0.1444980667f * 1.5f), trocketText1.transform.localScale.y + (0.1444980667f * 1.5f), trocketText1.transform.localScale.z + (0.1444980667f * 1.5f));
            trocketText2.transform.localScale = new Vector3(trocketText2.transform.localScale.x + (0.1444980667f * 1.5f), trocketText2.transform.localScale.y + (0.1444980667f * 1.5f), trocketText2.transform.localScale.z + (0.1444980667f * 1.5f));
            yield return WaitTime(0.01f);
        }
        for (int i = 0; i < 100; i++)
        {
            trocketText1.transform.localScale = new Vector3(trocketText1.transform.localScale.x + .01f, trocketText1.transform.localScale.y + .01f, trocketText1.transform.localScale.z + .01f);
            trocketText2.transform.localScale = new Vector3(trocketText2.transform.localScale.x + .01f, trocketText2.transform.localScale.y + .01f, trocketText2.transform.localScale.z + .01f);
            yield return WaitTime(0.02f);
        }
        //
        kiwiScreen.SetActive(true);
        for (int i = 0; i < 30; i++)
        {
            kiwiText1.transform.localScale = new Vector3(kiwiText1.transform.localScale.x + .13209f * .75f, kiwiText1.transform.localScale.y + .13209f * .75f, kiwiText1.transform.localScale.z + .13209f * .75f);
            kiwiText2.transform.localScale = new Vector3(kiwiText2.transform.localScale.x + .1915305f * .75f, kiwiText2.transform.localScale.y + .1915305f * .75f, kiwiText2.transform.localScale.z + .1915305f * .75f);
            yield return WaitTime(0.005f);
        }
        for (int i = 0; i < 50; i++)
        {
            kiwiText1.transform.localScale = new Vector3(kiwiText1.transform.localScale.x + .01f, kiwiText1.transform.localScale.y + .01f, kiwiText1.transform.localScale.z + .01f);
            kiwiText2.transform.localScale = new Vector3(kiwiText2.transform.localScale.x + .01f, kiwiText2.transform.localScale.y + .01f, kiwiText2.transform.localScale.z + .01f);
            yield return WaitTime(0.02f);
        }
        //
        trocketScreen.SetActive(false);
        transition.GetComponent<Image>().sprite = transition2;
        kiwiScreen.SetActive(false);
        logo.SetActive(false);
        award1.transform.SetParent(transition.transform);
        award2.transform.SetParent(transition.transform);
        award3.transform.SetParent(transition.transform);
        for (int i = 0; i < 26; i++)
        {
            award1.transform.localScale = new Vector3(award1.transform.localScale.x + .2187866667f, award1.transform.localScale.y + .2187866667f, award1.transform.localScale.z + .2187866667f);
            yield return WaitTime(0.005f);
        }
        yield return WaitTime(0.5f);
        for (int i = 0; i < 26; i++)
        {
            award2.transform.localScale = new Vector3(award2.transform.localScale.x + .2187866667f, award2.transform.localScale.y + .2187866667f, award2.transform.localScale.z + .2187866667f);
            yield return WaitTime(0.005f);
        }
        yield return WaitTime(0.5f);
        for (int i = 0; i < 26; i++)
        {
            award3.transform.localScale = new Vector3(award3.transform.localScale.x + .2187866667f, award3.transform.localScale.y + .2187866667f, award3.transform.localScale.z + .2187866667f);
            yield return WaitTime(0.005f);
        }
        yield return WaitTime(1);
        //
        titlescreen.SetActive(true);
        while (transition.GetComponent<RectTransform>().position.y > 0)
        {
            transition.GetComponent<RectTransform>().position = new Vector3(transition.GetComponent<RectTransform>().position.x, transition.GetComponent<RectTransform>().position.y - (Screen.height / 127.5f), transition.GetComponent<RectTransform>().position.z);
            yield return WaitTime(0.004f);
        }
        string path = Application.persistentDataPath + "/player.goblin";
        if (!File.Exists(path))
        {
            continueButton.interactable = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public GameObject bg;
    public GameObject text;
    public GameObject buttonReset;
    public GameObject buttonExit;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Scroll());
        buttonReset.GetComponent<CanvasRenderer>().SetAlpha(0);
        buttonExit.GetComponent<CanvasRenderer>().SetAlpha(0);
    }
    IEnumerator Scroll()
    {
        for (int i = 1; i < 3800; i++)
        {
            yield return new WaitForSecondsRealtime(.02f);
            bg.transform.position += Vector3.up * -.095f * (Screen.height / 1080f) * 2;
            text.transform.position += Vector3.up * .820f * (Screen.height / 1080f) * 2;
        }
        buttonReset.GetComponent<CanvasRenderer>().SetAlpha(0);
        buttonExit.GetComponent<CanvasRenderer>().SetAlpha(0);
        for (float i = 1; i < 300; i++)
        {
            yield return new WaitForSecondsRealtime(.01f);
            buttonReset.GetComponent<CanvasRenderer>().SetAlpha(i / 300);
            buttonExit.GetComponent<CanvasRenderer>().SetAlpha(i / 300);
            bg.transform.position += Vector3.up * -.095f * (Screen.height / 1080f);
        }
        buttonReset.GetComponent<Button>().interactable = true;
        buttonExit.GetComponent<Button>().interactable = true;
        for (int i = 1; i < 2600; i++)
        {
            yield return new WaitForSecondsRealtime(.01f);
            bg.transform.position += Vector3.up * -.095f * (Screen.height / 1080f);
        }
    }
    public void ResetButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}

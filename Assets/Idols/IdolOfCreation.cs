using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdolOfCreation : MonoBehaviour
{
    public double value;
    public Text valueDisplay;
    public GameObject statue;
    public GameObject vignettePale;
    public GameObject vignetteLightning;
    public GameObject flashbang;
    public IdolOfDestruction otherButton;
    // Start is called before the first frame update
    void Start()
    {
        if (value == 0)
            value = 1000000000;
    }

    // Update is called once per frame
    void Update()
    {
        if (value != 69)
            valueDisplay.text = "$" + value.ToString("n0");
        else
            valueDisplay.text = "MAX";
        if (GameManager.goblins >= value)
            valueDisplay.color = Color.green;
        else
            valueDisplay.color = Color.red;
    }
    public void Pressed()
    {
        if (GameManager.goblins >= value && value != 69)
        {
            GameManager.autoGoblins += 100000000;
            otherButton.value *= 20;
            GameManager.idolCreationCount = true;
            statue.SetActive(true);
            GameManager.goblins -= value;
            value = 69;
            GameManager.Godslayer = true;
            StartCoroutine(flash());
            GameManager.instance.GetComponent<EndTheGame>().Pressed();
        }
    }

    IEnumerator flash()
    {
        flashbang.GetComponent<CanvasRenderer>().SetAlpha(0);
        flashbang.SetActive(true);
        for (float i = 1; i <= 5; i++)
        {
            yield return new WaitForSeconds(.025f);
            flashbang.GetComponent<CanvasRenderer>().SetAlpha(i / 5f);
        }
        if (!GameManager.Virion)
        {
            vignettePale.SetActive(true);
            GameManager.instance.mainCamera.backgroundColor = new Color(218f / 256, 224f / 256, 170f / 256);
        }
        else
            vignetteLightning.SetActive(false);
        yield return new WaitForSeconds(.3f);
        for (float i = 20; i > 0; i--)
        {
            yield return new WaitForSeconds(.1f);
            flashbang.GetComponent<CanvasRenderer>().SetAlpha(i / 20f);
        }
    }
}

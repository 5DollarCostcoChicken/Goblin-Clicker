using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Amoromancers : MonoBehaviour
{
    public int value;
    public Text valueDisplay;
    public GameObject Crystal;
    public Sprite mancer2;
    public Sprite mancer3;
    public Sprite mancer4;
    public Sprite mancer5;
    public Sprite mancer6;
    private void Start()
    {
        if (value == 0)
            value = 800;
    }
    // Update is called once per frame
    void Update()
    {
        if (value != 69)
            valueDisplay.text = "$" + value.ToString("n0");
        else
            valueDisplay.text = "MAX";
        if (GameManager.goblins >= value)
            valueDisplay.color = Color.white;
        else
            valueDisplay.color = Color.red;
    }
    public void Pressed()
    {
        if (GameManager.goblins >= value && value != 69)
        {
            if (IdolOfElixir.multiplier > 0)
                GameManager.autoGoblins += 5 * IdolOfSorcery.multiplier;
            else
                GameManager.autoGoblins += 5;
            GameManager.goblins -= value;
            GameManager.amoromancers++;
            Crystal.transform.localScale = new Vector3(Crystal.transform.localScale.x + .03f, Crystal.transform.localScale.y + .03f, Crystal.transform.localScale.z + .03f);
            switch (value)
            {
                case 800:
                    value = 1100;
                    Crystal.SetActive(true);
                    break;
                case 1100:
                    value = 1400;
                    break;
                case 1400:
                    value = 1700;
                    Crystal.GetComponent<Image>().sprite = mancer2;
                    break;
                case 1700:
                    value = 2000;
                    break;
                case 2000:
                    value = 2500;
                    break;
                case 2500:
                    value = 3000;
                    Crystal.GetComponent<Image>().sprite = mancer3;
                    break;
                case 3000:
                    value = 4000;
                    break;
                case 4000:
                    value = 4500;
                    break;
                case 4500:
                    value = 5000;
                    Crystal.GetComponent<Image>().sprite = mancer4;
                    break;
                case 5000:
                    value = 6000;
                    break;
                case 6000:
                    value = 7000;
                    break;
                case 7000:
                    value = 8000;
                    Crystal.GetComponent<Image>().sprite = mancer5;
                    break;
                case 8000:
                    value = 9000;
                    break;
                case 9000:
                    value = 10000;
                    break;
                case 10000:
                    value = 69;
                    Crystal.GetComponent<Image>().sprite = mancer6;
                    break;
            }
        }
    }
}

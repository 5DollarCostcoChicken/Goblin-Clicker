using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public int value;
    public Text valueDisplay;
    public GameObject AmoromancerButton;
    public GameObject MudButton;
    public GameObject House1;
    public Sprite House2;
    public Sprite House3;
    public Sprite House4;
    public Sprite House5;
    public Sprite House6;
    public Sprite House7;
    public Sprite House8;
    public Sprite House9;
    public Sprite House10;
    public Sprite House11;
    public Sprite House12;
    public Sprite House13;
    public Sprite House14;
    public Sprite House15;
    public Sprite House16;
    public Sprite House17;
    public Sprite House18;
    public Sprite House19;
    public Sprite House20;
    public Sprite House21;
    public Sprite House22;
    private void Start()
    {
        value = 100;
    }
    // Update is called once per frame
    void Update()
    {
        if (value != 0)
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
        if (GameManager.goblins >= value && value != 0)
        {
            GameManager.multiplier *= 2;
            GameManager.houseUpgrades++;
            GameManager.goblins -= value;
            switch (value)
            {
                case 100:
                    value = 500;
                    House1.GetComponent<Image>().sprite = House2;
                    break;
                case 500:
                    value = 1000;
                    House1.GetComponent<Image>().sprite = House3;
                    break;
                case 1000:
                    value = 2000;
                    AmoromancerButton.SetActive(true);
                    AmoromancerButton.GetComponent<ButtonPulse>().PulseCall(0.4608868f);
                    House1.GetComponent<Image>().sprite = House4;
                    break;
                case 2000:
                    value = 3500;
                    House1.GetComponent<Image>().sprite = House5;
                    break;
                case 3500:
                    value = 6000;
                    House1.GetComponent<Image>().sprite = House6;
                    break;
                case 6000:
                    value = 10000;
                    House1.GetComponent<Image>().sprite = House7;
                    break;
                case 10000:
                    value = 20000;
                    MudButton.SetActive(true);
                    MudButton.GetComponent<ButtonPulse>().PulseCall(0.4608868f);
                    House1.GetComponent<Image>().sprite = House8;
                    break;
                case 20000:
                    value = 40000;
                    House1.GetComponent<Image>().sprite = House9;
                    break;
                case 40000:
                    value = 200000;
                    House1.GetComponent<Image>().sprite = House10;
                    break;
                case 200000:
                    value = 500000;
                    House1.GetComponent<Image>().sprite = House11;
                    break;
                case 500000:
                    value = 1000000;
                    House1.GetComponent<Image>().sprite = House12;
                    break;
                case 1000000:
                    value = 1800000;
                    House1.GetComponent<Image>().sprite = House13;
                    break;
                case 1800000:
                    value = 4000000;
                    House1.GetComponent<Image>().sprite = House14;
                    break;
                case 4000000:
                    value = 8000000;
                    House1.GetComponent<Image>().sprite = House15;
                    break;
                case 8000000:
                    value = 15000000;
                    House1.GetComponent<Image>().sprite = House16;
                    break;
                case 15000000:
                    value = 50000000;
                    House1.GetComponent<Image>().sprite = House17;
                    break;
                case 50000000:
                    value = 100000000;
                    House1.GetComponent<Image>().sprite = House18;
                    break;
                case 100000000:
                    value = 200000000;
                    House1.GetComponent<Image>().sprite = House19;
                    break;
                case 200000000:
                    value = 500000000; 
                    House1.GetComponent<Image>().sprite = House20;
                    break;
                case 500000000:
                    value = 1000000000;
                    House1.GetComponent<Image>().sprite = House21;
                    break;
                case 1000000000:
                    value = 0;
                    House1.GetComponent<Image>().sprite = House22;
                    break;
            }
        }
    }
}

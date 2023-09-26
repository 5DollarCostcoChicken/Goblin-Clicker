using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdolOfWar : MonoBehaviour
{
    public int value;
    public Text valueDisplay;
    public Text warDisplay;
    int victoriesNeeded = 0;
    public GameObject statue;
    // Start is called before the first frame update
    void Start()
    {
        if (value == 0)
            value = 100000;
        //victoriesNeeded = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (victoriesNeeded <= GameManager.victories || value == 69) {
            if (value != 69)
                valueDisplay.text = "$" + value.ToString("n0");
            else
                valueDisplay.text = "MAX";
            if (GameManager.goblins >= value)
                valueDisplay.color = Color.green;
            else
                valueDisplay.color = Color.red;
        }
        else
        {
            valueDisplay.color = Color.white;
            valueDisplay.text = "" + (victoriesNeeded - GameManager.victories) + " more battles to unlock";
        }
        warDisplay.text = "War Shop Discount: " + GameManager.warDiscount + "%";
    }
    public void Pressed()
    {
        if (GameManager.goblins >= value && value != 69 && victoriesNeeded <= GameManager.victories)
        {
            GameManager.warDiscount += 5;
            GameManager.idolWarCount++;
            victoriesNeeded += 5;
            GameManager.goblins -= value;
            switch (value)
            {
                case 100000:
                    value = 400000;
                    warDisplay.gameObject.SetActive(true);
                    statue.SetActive(true);
                    break;
                case 400000:
                    value = 2500000;
                    break;
                case 2500000:
                    value = 8000000;
                    break;
                case 8000000:
                    value = 19000000;
                    break;
                case 19000000:
                    value = 37500000;
                    break;
                case 37500000:
                    value = 65000000;
                    break;
                case 65000000:
                    value = 100000000;
                    break;
                case 100000000:
                    value = 150000000;
                    break;
                case 150000000:
                    value = 300000000;
                    break;
                case 300000000:
                    value = 69;
                    break;
            }
        }
    }
}
